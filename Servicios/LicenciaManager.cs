using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace ControlInventario.Servicios
{
    public static class LicenciaManager
    {
        private const int DIAS_PRUEBA = 15;
        private const string CLAVE_CIFRADO = "C0ntr0l!nv3nt@r10#2025$Lic";
        private const string PREFIJO_LICENCIA = "CINV";

        // Clave secreta para generar licencias (solo tú la conoces)
        private const string CLAVE_LICENCIA = "M1Cl@v3S3cr3t@L1c3nc1a2025!";

        // Ruta del registro para respaldo anti-manipulación
        private const string REGISTRO_RUTA = @"SOFTWARE\ControlInventario";
        private const string REGISTRO_FECHA = "InstDate";
        private const string REGISTRO_MACHINE = "MachineRef";

        private static string ObtenerRutaArchivo()
        {
            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ControlInventario");
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);
            return Path.Combine(carpeta, ".appdata");
        }

        /// <summary>
        /// Obtiene un identificador único de la máquina basado en el hardware.
        /// </summary>
        public static string ObtenerIdMaquina()
        {
            try
            {
                string raw = "";
                using (var searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        raw += obj["ProcessorId"]?.ToString() ?? "";
                        break;
                    }
                }
                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        raw += obj["SerialNumber"]?.ToString() ?? "";
                        break;
                    }
                }
                if (string.IsNullOrEmpty(raw))
                    raw = Environment.MachineName + Environment.UserName;

                return GenerarHash(raw).Substring(0, 16).ToUpper();
            }
            catch
            {
                return GenerarHash(Environment.MachineName + Environment.UserName).Substring(0, 16).ToUpper();
            }
        }

        /// <summary>
        /// Registra la fecha de primera ejecución si no existe.
        /// Usa archivo local + registro de Windows como respaldo.
        /// </summary>
        public static void RegistrarInstalacion()
        {
            var datos = LeerDatos();
            string machineId = ObtenerIdMaquina();

            // Verificar si hay una fecha guardada en el registro (anti-borrado de archivo)
            DateTime fechaRegistro = LeerFechaDeRegistro();

            if (datos.FechaInstalacion == DateTime.MinValue && fechaRegistro != DateTime.MinValue)
            {
                // El archivo fue borrado pero el registro tiene la fecha original
                datos.FechaInstalacion = fechaRegistro;
                datos.MachineId = machineId;
                GuardarDatos(datos);
                return;
            }

            if (datos.FechaInstalacion == DateTime.MinValue)
            {
                datos.FechaInstalacion = DateTime.Now;
                datos.MachineId = machineId;
                GuardarDatos(datos);
                GuardarFechaEnRegistro(datos.FechaInstalacion, machineId);
            }
            else if (string.IsNullOrEmpty(datos.MachineId))
            {
                // Migrar datos existentes: agregar MachineId
                datos.MachineId = machineId;
                GuardarDatos(datos);
                GuardarFechaEnRegistro(datos.FechaInstalacion, machineId);
            }
        }

        /// <summary>
        /// Verifica si la app tiene licencia activa para esta máquina.
        /// </summary>
        public static bool TieneLicencia()
        {
            var datos = LeerDatos();
            if (string.IsNullOrEmpty(datos.Licencia))
                return false;

            // Validar formato de licencia
            if (!ValidarLicencia(datos.Licencia))
                return false;

            // Validar que la licencia esté vinculada a esta máquina
            if (!string.IsNullOrEmpty(datos.MachineIdLicencia))
            {
                string machineActual = ObtenerIdMaquina();
                if (datos.MachineIdLicencia != machineActual)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Obtiene los días restantes de prueba.
        /// </summary>
        public static int DiasRestantes()
        {
            var datos = LeerDatos();
            DateTime fechaBase = datos.FechaInstalacion;

            // Si el archivo no tiene fecha, intentar leer del registro
            if (fechaBase == DateTime.MinValue)
            {
                fechaBase = LeerFechaDeRegistro();
                if (fechaBase == DateTime.MinValue)
                    return DIAS_PRUEBA;
            }

            int diasTranscurridos = (DateTime.Now.Date - fechaBase.Date).Days;

            // Protección contra cambio de reloj hacia atrás
            if (diasTranscurridos < 0)
                return 0;

            int restantes = DIAS_PRUEBA - diasTranscurridos;
            return restantes < 0 ? 0 : restantes;
        }

        /// <summary>
        /// Verifica si el periodo de prueba expiró.
        /// </summary>
        public static bool PruebaExpirada()
        {
            return DiasRestantes() <= 0;
        }

        /// <summary>
        /// Valida e intenta activar una licencia vinculándola a esta máquina.
        /// </summary>
        public static bool ActivarLicencia(string licencia)
        {
            if (ValidarLicencia(licencia))
            {
                var datos = LeerDatos();
                string machineId = ObtenerIdMaquina();
                datos.Licencia = licencia.Trim().ToUpper();
                datos.MachineIdLicencia = machineId;
                GuardarDatos(datos);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Valida el formato y autenticidad de una licencia.
        /// Formato: CINV-XXXXX-XXXXX-XXXXX
        /// </summary>
        public static bool ValidarLicencia(string licencia)
        {
            if (string.IsNullOrWhiteSpace(licencia)) return false;

            licencia = licencia.Trim().ToUpper();
            string[] partes = licencia.Split('-');

            if (partes.Length != 4 || partes[0] != PREFIJO_LICENCIA)
                return false;

            // Verificar que los 3 bloques coincidan con el hash esperado
            string bloque = $"{partes[1]}-{partes[2]}";
            string hashEsperado = GenerarHash($"{CLAVE_LICENCIA}-{bloque}");
            string bloqueVerificacion = hashEsperado.Substring(0, 5).ToUpper();

            return partes[3] == bloqueVerificacion;
        }

        /// <summary>
        /// Genera una licencia válida. Usa esto para crear licencias para tus clientes.
        /// </summary>
        public static string GenerarLicencia()
        {
            string bloque1 = GenerarBloqueAleatorio(5);
            string bloque2 = GenerarBloqueAleatorio(5);
            string bloque = $"{bloque1}-{bloque2}";
            string hash = GenerarHash($"{CLAVE_LICENCIA}-{bloque}");
            string bloqueVerificacion = hash.Substring(0, 5).ToUpper();

            return $"{PREFIJO_LICENCIA}-{bloque1}-{bloque2}-{bloqueVerificacion}";
        }

        #region Métodos privados

        private static string GenerarBloqueAleatorio(int longitud)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random(Guid.NewGuid().GetHashCode());
            var resultado = new char[longitud];
            for (int i = 0; i < longitud; i++)
                resultado[i] = caracteres[random.Next(caracteres.Length)];
            return new string(resultado);
        }

        private static string GenerarHash(string input)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }

        private static DatosLicencia LeerDatos()
        {
            var datos = new DatosLicencia();
            string ruta = ObtenerRutaArchivo();

            if (!File.Exists(ruta)) return datos;

            try
            {
                string contenidoCifrado = File.ReadAllText(ruta);
                string contenido = Descifrar(contenidoCifrado);
                string[] lineas = contenido.Split('|');

                if (lineas.Length >= 1 && DateTime.TryParse(lineas[0], out DateTime fecha))
                    datos.FechaInstalacion = fecha;
                if (lineas.Length >= 2)
                    datos.Licencia = lineas[1];
                if (lineas.Length >= 3)
                    datos.MachineId = lineas[2];
                if (lineas.Length >= 4)
                    datos.MachineIdLicencia = lineas[3];
            }
            catch
            {
                // Archivo corrupto, tratar como nueva instalación
            }

            return datos;
        }

        private static void GuardarDatos(DatosLicencia datos)
        {
            string ruta = ObtenerRutaArchivo();
            string contenido = $"{datos.FechaInstalacion:yyyy-MM-dd}|{datos.Licencia ?? ""}|{datos.MachineId ?? ""}|{datos.MachineIdLicencia ?? ""}";
            string cifrado = Cifrar(contenido);
            File.WriteAllText(ruta, cifrado);
        }

        private static void GuardarFechaEnRegistro(DateTime fecha, string machineId)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(REGISTRO_RUTA))
                {
                    key.SetValue(REGISTRO_FECHA, Cifrar(fecha.ToString("yyyy-MM-dd")), RegistryValueKind.String);
                    key.SetValue(REGISTRO_MACHINE, Cifrar(machineId), RegistryValueKind.String);
                }
            }
            catch { }
        }

        private static DateTime LeerFechaDeRegistro()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(REGISTRO_RUTA))
                {
                    if (key == null) return DateTime.MinValue;
                    string valor = key.GetValue(REGISTRO_FECHA) as string;
                    if (string.IsNullOrEmpty(valor)) return DateTime.MinValue;
                    string descifrado = Descifrar(valor);
                    if (DateTime.TryParse(descifrado, out DateTime fecha))
                        return fecha;
                }
            }
            catch { }
            return DateTime.MinValue;
        }

        private static string Cifrar(string texto)
        {
            byte[] clave = Encoding.UTF8.GetBytes(CLAVE_CIFRADO.PadRight(32).Substring(0, 32));
            byte[] iv = Encoding.UTF8.GetBytes(CLAVE_CIFRADO.PadRight(16).Substring(0, 16));

            using (var aes = Aes.Create())
            {
                aes.Key = clave;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] datos = Encoding.UTF8.GetBytes(texto);
                    byte[] resultado = encryptor.TransformFinalBlock(datos, 0, datos.Length);
                    return Convert.ToBase64String(resultado);
                }
            }
        }

        private static string Descifrar(string textoCifrado)
        {
            byte[] clave = Encoding.UTF8.GetBytes(CLAVE_CIFRADO.PadRight(32).Substring(0, 32));
            byte[] iv = Encoding.UTF8.GetBytes(CLAVE_CIFRADO.PadRight(16).Substring(0, 16));

            using (var aes = Aes.Create())
            {
                aes.Key = clave;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] datos = Convert.FromBase64String(textoCifrado);
                    byte[] resultado = decryptor.TransformFinalBlock(datos, 0, datos.Length);
                    return Encoding.UTF8.GetString(resultado);
                }
            }
        }

        private class DatosLicencia
        {
            public DateTime FechaInstalacion { get; set; } = DateTime.MinValue;
            public string Licencia { get; set; } = "";
            public string MachineId { get; set; } = "";
            public string MachineIdLicencia { get; set; } = "";
        }

        #endregion
    }
}

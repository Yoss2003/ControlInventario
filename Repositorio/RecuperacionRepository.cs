using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Database
{
    public class RecuperacionRepository
    {
        public static void CrearTablaPreguntasSeguridad(SQLiteConnection con)
        {
            string query = @"
                CREATE TABLE IF NOT EXISTS PreguntasSeguridad (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Usuario INT NOT NULL,
                    Nombre_Usuario TEXT NOT NULL,
                    Id_Pregunta1 INT NOT NULL,
                    Pregunta1 TEXT NOT NULL,
                    Respuesta1 TEXT NOT NULL,
                    Id_Pregunta2 INT NOT NULL,
                    Pregunta2 TEXT NOT NULL,
                    Respuesta2 TEXT NOT NULL,
                    Id_Pregunta3 INT NOT NULL,
                    Pregunta3 TEXT NOT NULL,
                    Respuesta3 TEXT NOT NULL,
                    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id)
                );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla para controlar intentos fallidos de recuperación
            string queryIntentos = @"
                CREATE TABLE IF NOT EXISTS IntentosRecuperacion (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre_Usuario TEXT NOT NULL,
                    Intentos_Fallidos INT DEFAULT 0,
                    Fecha_Ultimo_Intento TEXT,
                    Bloqueado_Hasta TEXT
                );";
            using (var cmd = new SQLiteCommand(queryIntentos, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Obtiene las preguntas de seguridad de un usuario.
        /// </summary>
        public static (string Pregunta1, string Pregunta2, string Pregunta3) ObtenerPreguntasUsuario(string nombreUsuario)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT Pregunta1, Pregunta2, Pregunta3 FROM PreguntasSeguridad WHERE Nombre_Usuario = @Usuario LIMIT 1;";
                
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                reader["Pregunta1"].ToString(),
                                reader["Pregunta2"].ToString(),
                                reader["Pregunta3"].ToString()
                            );
                        }
                    }
                }
            }
            return (null, null, null);
        }

        /// <summary>
        /// Valida las respuestas de seguridad del usuario.
        /// </summary>
        public static bool ValidarRespuestasSeguridad(string nombreUsuario, string respuesta1, string respuesta2, string respuesta3)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"SELECT Respuesta1, Respuesta2, Respuesta3 
                                 FROM PreguntasSeguridad 
                                 WHERE Nombre_Usuario = @Usuario LIMIT 1;";
                
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string r1BD = reader["Respuesta1"].ToString().Trim();
                            string r2BD = reader["Respuesta2"].ToString().Trim();
                            string r3BD = reader["Respuesta3"].ToString().Trim();

                            // Comparación case-insensitive
                            return r1BD.Equals(respuesta1.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                   r2BD.Equals(respuesta2.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                   r3BD.Equals(respuesta3.Trim(), StringComparison.OrdinalIgnoreCase);
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el usuario está bloqueado temporalmente por intentos fallidos.
        /// </summary>
        public static bool UsuarioBloqueado(string nombreUsuario, out DateTime bloqueadoHasta)
        {
            bloqueadoHasta = DateTime.MinValue;

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT Bloqueado_Hasta FROM IntentosRecuperacion WHERE Nombre_Usuario = @Usuario LIMIT 1;";
                
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    var result = cmd.ExecuteScalar();
                    
                    if (result != null && result != DBNull.Value)
                    {
                        if (DateTime.TryParse(result.ToString(), out DateTime fechaBloqueo))
                        {
                            bloqueadoHasta = fechaBloqueo;
                            return DateTime.Now < fechaBloqueo;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Registra un intento fallido de recuperación.
        /// </summary>
        public static void RegistrarIntentoFallido(string nombreUsuario)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Verificar si ya existe un registro
                string queryExiste = "SELECT Intentos_Fallidos FROM IntentosRecuperacion WHERE Nombre_Usuario = @Usuario;";
                int intentosActuales = 0;

                using (var cmd = new SQLiteCommand(queryExiste, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        intentosActuales = Convert.ToInt32(result);
                    }
                }

                intentosActuales++;
                DateTime? bloqueadoHasta = null;

                // Si llega a 3 intentos, bloquear por 3 horas
                if (intentosActuales >= 3)
                {
                    bloqueadoHasta = DateTime.Now.AddHours(3);
                }

                // Actualizar o insertar
                string queryUpsert = @"
                    INSERT OR REPLACE INTO IntentosRecuperacion (Nombre_Usuario, Intentos_Fallidos, Fecha_Ultimo_Intento, Bloqueado_Hasta)
                    VALUES (@Usuario, @Intentos, @FechaIntento, @BloqueadoHasta);";

                using (var cmd = new SQLiteCommand(queryUpsert, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Intentos", intentosActuales);
                    cmd.Parameters.AddWithValue("@FechaIntento", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@BloqueadoHasta", bloqueadoHasta?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Reinicia el contador de intentos fallidos al validar correctamente.
        /// </summary>
        public static void ReiniciarIntentos(string nombreUsuario)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM IntentosRecuperacion WHERE Nombre_Usuario = @Usuario;";
                
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

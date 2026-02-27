using System;
using System.Data.SQLite;
using System.IO;

namespace ControlInventario.Database
{
    public static class ConexionGlobal
    {
        private static string nombreArchivo = "Empleados.db";
        private static string carpetaApp = "App";
        private static string rutaFinal;

        public static SQLiteConnection ObtenerConexion()
        {
            string rutaD = Path.Combine(@"D:\", carpetaApp, nombreArchivo);
            if (File.Exists(rutaD))
            {
                rutaFinal = rutaD;
            }
            else
            {
                string rutaC = Path.Combine(@"C:\", carpetaApp, nombreArchivo);
                string carpetaC = Path.Combine(@"C:\", carpetaApp);

                if (!Directory.Exists(carpetaC))
                {
                    Directory.CreateDirectory(carpetaC);
                    DirectoryInfo dirInfo = new DirectoryInfo(carpetaC);
                    dirInfo.Attributes |= FileAttributes.Hidden;
                }

                rutaFinal = rutaC;

                if (!File.Exists(rutaFinal))
                {
                    SQLiteConnection.CreateFile(rutaFinal);
                }
            }

            // Crear carpeta Bkp y sus subcarpetas
            string carpetaBase = Path.GetDirectoryName(rutaFinal);
            string carpetaBkp = Path.Combine(carpetaBase, "Bkp");
            string carpetaComprobantes = Path.Combine(carpetaBkp, "Comprobantes");
            string carpetaImagenes = Path.Combine(carpetaBkp, "Imagenes");

            if (!Directory.Exists(carpetaBkp)) Directory.CreateDirectory(carpetaBkp);
            if (!Directory.Exists(carpetaComprobantes)) Directory.CreateDirectory(carpetaComprobantes);
            if (!Directory.Exists(carpetaImagenes)) Directory.CreateDirectory(carpetaImagenes);

            string cadenaConexion = $"Data Source={rutaFinal};Version=3;";
            return new SQLiteConnection(cadenaConexion);
        }

        public static string ObtenerCarpetaComprobantes()
        {
            return Path.Combine(Path.GetDirectoryName(rutaFinal), "Bkp", "Comprobantes");
        }

        public static string ObtenerCarpetaImagenes()
        {
            return Path.Combine(Path.GetDirectoryName(rutaFinal), "Bkp", "Imagenes");
        }
    }
}
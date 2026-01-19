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
            // Intentar en D:
            string rutaD = Path.Combine(@"D:\", carpetaApp, nombreArchivo);
            if (File.Exists(rutaD))
            {
                rutaFinal = rutaD;
            }
            else
            {
                // Intentar en C:
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

            string cadenaConexion = $"Data Source={rutaFinal};Version=3;";
            return new SQLiteConnection(cadenaConexion);
        }
    }
}
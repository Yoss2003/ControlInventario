using ControlInventario.Database;
using ControlInventario.Servicios;
using System;
using System.Windows.Forms;

namespace ControlInventario
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    DatabaseInitializer.CreateTables(con);
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VistaInicioSesion());
        }
    }
}

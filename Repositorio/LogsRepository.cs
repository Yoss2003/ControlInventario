
using ControlInventario.Database;
using ControlInventario.Servicios;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public class LogsRepository
    {
        public static void CrearTablaLogs(SQLiteConnection con)
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS Historial (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
                Usuario TEXT NOT NULL,
                Modulo TEXT NOT NULL,
                Accion TEXT NOT NULL,
                Detalle TEXT
            );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarLogs(string modulo, string accion, string detalle)
        {
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    string sql = @"
                        INSERT INTO Historial (Fecha, Usuario, Modulo, Accion, Detalle) 
                        VALUES (@Fecha, @Usuario, @Modulo, @Accion, @Detalle);";

                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmd.Parameters.AddWithValue("@Usuario", UsuarioSesion.NombreUsuario ?? "SISTEMA");

                        cmd.Parameters.AddWithValue("@Modulo", modulo);
                        cmd.Parameters.AddWithValue("@Accion", accion);
                        cmd.Parameters.AddWithValue("@Detalle", detalle);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}

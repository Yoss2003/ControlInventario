using ControlInventario.Modelos;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data;
using System.Data.SQLite;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace ControlInventario.Database
{
    public class CargoRepository
    {
        /* CRUD */
        public static void CrearTablaCargos(SQLiteConnection con)
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS Cargos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Descripcion TEXT
            );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarCargo(Cargo carg)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    INSERT INTO Cargos (Nombre, Descripcion) 
                    VALUES (@Nombre, @Descripcion);";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", carg.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", carg.Descripcion); 
                    cmd.ExecuteNonQuery();
                }
                con.Clone();
            }            
        }

        public static void ActualizarCargo(Cargo carg)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                UPDATE Cargos SET 
                    Nombre = @Nombre,
                    Descripcion = @Descripcion
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", carg.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", carg.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", carg.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }            
        }

        public static void EliminarCargo(Cargo carg)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = "DELETE FROM Cargos WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", carg.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarCargos(SQLiteConnection con)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM Cargos ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class AreaRepository
    {
        /* CRUD */
        public static void CrearTablaAreas(SQLiteConnection con)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Areas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Descripcion TEXT
                );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarArea(Area ar)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                INSERT INTO Areas (Nombre, Descripcion) 
                VALUES (@Nombre, @Descripcion);";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", ar.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", ar.Descripcion);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ActualizarArea(Area ar)
        {
            using  (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                UPDATE Areas SET 
                    Nombre = @Nombre, 
                    Descripcion = @Descripcion
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", ar.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", ar.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", ar.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }            
        }

        public static void EliminarArea(Area ar)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = "DELETE FROM Areas WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", ar.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarAreas(SQLiteConnection con)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM Areas ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

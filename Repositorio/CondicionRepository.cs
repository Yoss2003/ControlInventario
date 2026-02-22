using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class CondicionRepository
    {
        /* CRUD */
        public static void CrearTablaCondicion(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Condiciones (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarCondicion(Condicion cond)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "INSERT INTO Condiciones (Nombre, Description) VALUES (@Nombre, @Description);";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cond.Nombre);
                    cmd.Parameters.AddWithValue("@Description", cond.Descripcion);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarCondicion(Condicion cond)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "UPDATE Condiciones SET Nombre = @Nombre, Description = @Description WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cond.Nombre);
                    cmd.Parameters.AddWithValue("@Description", cond.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", cond.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void EliminarCondicion(Condicion cond)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM Condiciones WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", cond.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarCondicion(SQLiteConnection con)
        {
            var dt = new DataTable();            
            string query = "SELECT Id, Nombre FROM Condiciones ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

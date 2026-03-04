using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class UbicacionRepository
    {
        public static void CrearTablaUbicaciones (SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Ubicaciones (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER,
                Nombre TEXT NOT NULL,
                Descripcion TEXT    
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarUbicacion(Ubicacion ubi)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                    INSERT INTO Ubicaciones (InventarioId, Nombre, Descripcion) 
                    VALUES (@InventarioId, @Nombre, @Descripcion);";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", ubi.InventarioId);
                    cmd.Parameters.AddWithValue("@Nombre", ubi.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", ubi.Descripcion);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ActualizarUbicacion(Ubicacion ubi)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "UPDATE Ubicaciones SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", ubi.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", ubi.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", ubi.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void EliminarUbicacion(Ubicacion ubi)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM Ubicaciones WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", ubi.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static DataTable ListarUbicacion(SQLiteConnection con)
        {
            var dt = new DataTable();
            string query = "SELECT Id, Nombre FROM Ubicaciones ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

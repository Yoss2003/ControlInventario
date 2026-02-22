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
                Nombre TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
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

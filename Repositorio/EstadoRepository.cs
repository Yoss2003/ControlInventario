using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class EstadoRepository
    {
        public static void CrearTablaEstadoEmpleados(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS EstadoEmpleados (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Descripcion TEXT    
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void CrearTablaEstadoArticulos(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS EstadoArticulos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Descripcion TEXT    
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarEstadoArticulos(Estado est)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                INSERT INTO EstadoArticulos (Nombre, Descripcion) 
                VALUES (@Nombre, @Descripcion);";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", est.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", est.Descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertarEstadoEmpleados(Estado est)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                INSERT INTO EstadoEmpleados (Nombre, Descripcion) 
                VALUES (@Nombre, @Descripcion);";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", est.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", est.Descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarEstadoEmpleados(Estado est)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE EstadoEmpleados 
                SET Nombre = @Nombre, Descripcion = @Descripcion 
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", est.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", est.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", est.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarEstadoArticulos(Estado est)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE EstadoArticulos 
                SET Nombre = @Nombre, Descripcion = @Descripcion 
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", est.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", est.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", est.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarEstadosEmpleados(SQLiteConnection con)
        {
            var dt = new DataTable();

            string query = "SELECT * FROM EstadoEmpleados ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable ListarEstadosArticulos (SQLiteConnection con)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM EstadoArticulos ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

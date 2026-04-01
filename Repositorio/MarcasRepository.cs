using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class MarcasRepository
    {
        public static void CrearTablaMarcas(SQLiteConnection con)
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS Marcas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                CategoriaId INTEGER NOT NULL,
                Nombre TEXT NOT NULL,
                FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
            );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarMarca(Marcas mar)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    INSERT INTO Marcas (InventarioId, Nombre, CategoriaId)
                    VALUES (@InventarioId, @Nombre, @CategoriaId);";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", mar.InventarioId);
                    cmd.Parameters.AddWithValue("@Nombre", mar.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", mar.CategoriasId);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ActualizarMarca(Marcas mar)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    UPDATE Marcas SET 
                        Nombre = @Nombre, 
                        CategoriaId = @CategoriaId
                    WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", mar.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", mar.CategoriasId);
                    cmd.Parameters.AddWithValue("@Id", mar.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Clone();
            }
        }

        public static void EliminarMarca(Marcas mar)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = "DELETE FROM Marcas WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", mar.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarMarcas(SQLiteConnection con, int categoriaId)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM Marcas WHERE CategoriaId = @CategoriaId;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable BuscarMarcasPorArticulosPorCategoria(SQLiteConnection con, int categoriaId, int inventarioId, bool esIngreso)
        {
            var dt = new DataTable();
            string filtroAcciones = esIngreso ? "(1, 8, 11, 12)" : "(2, 4, 5, 6, 9, 10)";
            string query = @"
            SELECT DISTINCT m.Id, m.Nombre 
            FROM Articulos a
            INNER JOIN Marcas m ON a.IdMarca = m.Id
            WHERE a.CategoriaId = @CategoriaId
              AND a.InventarioId = @InventarioId
            ORDER BY m.Nombre ASC;";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                cmd.Parameters.AddWithValue("@InventarioId", inventarioId);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}

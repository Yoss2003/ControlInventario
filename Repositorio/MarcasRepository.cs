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

        public static DataTable BuscarMarcasPorArticulosPorCategoria(SQLiteConnection con, int categoriaId, int inventarioId, bool esIngreso, params int[] accionesFiltro)
        {
            var dt = new DataTable();

            string filtroAcciones;

            if (accionesFiltro != null && accionesFiltro.Length > 0 && accionesFiltro[0] != 0)
            {
                filtroAcciones = $"({string.Join(",", accionesFiltro)})";
            }
            else
            {
                filtroAcciones = esIngreso ? "(1, 4, 12, 13)" : "(2, 3, 5, 6, 8, 10, 11)";
            }

            string query = $@"
            SELECT DISTINCT m.Id, m.Nombre 
            FROM Articulos a
            INNER JOIN Marcas m ON a.IdMarca = m.Id
            WHERE a.InventarioId = @InventarioId
                AND a.IdAccion IN {filtroAcciones}";

            if (categoriaId > 0)
            {
                query += " AND a.CategoriaId = @CategoriaId";
            }

            query += " ORDER BY m.Nombre ASC;";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                if (categoriaId > 0)
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}

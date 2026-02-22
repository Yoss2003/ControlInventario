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
                CategoriaId INTEGER NOT NULL,
                Categoria TEXT NOT NULL,
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
                    INSERT INTO Marcas (Nombre, CategoriaId, Categoria)
                    VALUES (@Nombre, @CategoriaId, @Categoria);";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", mar.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", mar.CategoriasId);
                    cmd.Parameters.AddWithValue("@Categoria", mar.Categoria);
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
                        CategoriaId = @CategoriaId, 
                        Categoria = @Categoria 
                    WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", mar.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", mar.CategoriasId);
                    cmd.Parameters.AddWithValue("@Categoria", mar.Categoria);
                    cmd.Parameters.AddWithValue("@Id", mar.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Clone();
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
    }
}

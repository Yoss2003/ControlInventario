using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ControlInventario.Database
{
    public class CategoriaRepository
    {
        private readonly Inventario _inventario;
        public CategoriaRepository(Inventario inventario)
        {
            _inventario = inventario;
        }

        /* CRUD */
        public static void CrearTablaCategorias(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Categorias (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                Nombre TEXT NOT NULL,
                Descripcion TEXT,
                FechaCreacion TEXT,
                UsuarioCreacion TEXT,
                FechaModificacion TEXT,
                UsuarioModificacion TEXT,
                FechaEliminacion TEXT,
                UsuarioEliminacion TEXT,
                EsDevolvible INTEGER NOT NULL DEFAULT 1,
            FOREIGN KEY (InventarioId) REFERENCES Inventarios(Id)
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void MigrarTablaCategorias(SQLiteConnection con)
        {
            string queryVerificar = "PRAGMA table_info(Categorias);";
            bool existeColumna = false;

            using (var cmd = new SQLiteCommand(queryVerificar, con))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString() == "EsDevolvible")
                    {
                        existeColumna = true;
                        break;
                    }
                }
            }

            if (!existeColumna)
            {
                string queryAlter = "ALTER TABLE Categorias ADD COLUMN EsDevolvible INTEGER NOT NULL DEFAULT 1;";
                using (var cmd = new SQLiteCommand(queryAlter, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static long AgregarCategoría(Categoria cat) 
        {
            if (cat.Nombre.Length > 11)
            {
                MessageBox.Show("El nombre de la categoría no puede superar los 11 caracteres.", "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return -1;
            }

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                INSERT INTO Categorias (
                    InventarioId,
                    Nombre,
                    Descripcion,
                    FechaCreacion,
                    UsuarioCreacion
                ) VALUES (
                    @InventarioId,
                    @Nombre,
                    @Descripcion,
                    @FechaCreacion,
                    @UsuarioCreacion
                );
                SELECT last_insert_rowid();";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", cat.InventarioId);
                    cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", cat.FechaCreacion);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", cat.UsuarioCreacion);

                    long nuevoId = (long)cmd.ExecuteScalar();

                    return nuevoId;
                }
            }
        }

        public static void ActualizarCategoria(Categoria cat)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Categorias SET 
                    Nombre = @Nombre,
                    Descripcion = @Descripcion,
                    FechaModificacion = @FechaModificacion,
                    UsuarioModificacion = @UsuarioModificacion
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaModificacion", cat.FechaModificacion);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", cat.UsuarioModificacion);
                    cmd.Parameters.AddWithValue("@Id", cat.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void EliminarCategoria(Categoria cat)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM Categorias WHERE Id = @Id; ";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", cat.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static bool ExisteCategoria(Categoria cat)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Buscamos si el nombre existe ignorando mayúsculas/minúsculas (COLLATE NOCASE).
                // Si estamos editando, excluimos el ID actual (Id != @IdActual) para no marcar error consigo mismo.
                string query = @"
                    SELECT COUNT(*) 
                    FROM Categorias 
                    WHERE TRIM(Nombre) = TRIM(@Nombre) COLLATE NOCASE 
                    AND InventarioId = @InventarioId 
                    AND Id != @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
                    cmd.Parameters.AddWithValue("@InventarioId", cat.InventarioId);
                    cmd.Parameters.AddWithValue("@Id", cat.Id);

                    long cantidad = (long)cmd.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarCategorias(int inventarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dt = new DataTable();

                string query = "SELECT * FROM Categorias WHERE InventarioId = @InventarioId;";
                using (var cmd = new SQLiteCommand(query, con))
                {
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
}

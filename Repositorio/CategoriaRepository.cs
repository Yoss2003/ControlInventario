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
                FechaCreacion TEXT NOT NULL,
                UsuarioCreacion TEXT NOT NULL,
                FechaModificacion TEXT,
                UsuarioModificacion TEXT,
                FechaEliminacion TEXT,
                UsuarioEliminacion TEXT,
            FOREIGN KEY (InventarioId) REFERENCES Inventarios(Id)
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void AgregarCategoría(Categoria cat)
        {            
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
                );";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", cat.InventarioId);

                    if (cat.Nombre.Length > 11)
                    {
                        MessageBox.Show("El nombre de la categoría no puede superar los 11 caracteres.", "Validación", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning
                        ); 
                        return;
                    }

                    cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", cat.FechaCreacion);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", cat.UsuarioCreacion);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
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

        public void InsertarCategoriaInventario(Categoria cat, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Categorias (
                Nombre,
                InventarioId,
                FechaCreacion,
                UsuarioCreacion
            )   
            VALUES(
                @Nombre,
                @InventarioId,
                @FechaCreacion,
                @UsuarioCreacion
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
                cmd.Parameters.AddWithValue("@InventarioId", cat.InventarioId);
                cmd.Parameters.AddWithValue("@FechaCreacion", cat.FechaCreacion);
                cmd.Parameters.AddWithValue("@UsuarioCreacion", cat.UsuarioCreacion);

                cmd.ExecuteNonQuery();
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarCategorias(int inventarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dt = new DataTable();

                string query = "SELECT Id, Nombre FROM Categorias WHERE InventarioId = @InventarioId;";
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

using ControlInventario.Modelos;
using System;
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

        public static void EliminarCategoria(Categoria cat, bool eliminarArticulos)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    if (eliminarArticulos)
                    {
                        // 1. Movimientos internos (solo ingresos, devoluciones, ajustes, retornos, modificaciones)
                        string deleteMovimientos = @"DELETE FROM Movimientos WHERE ArticuloId IN (
                            SELECT Id FROM Articulos WHERE CategoriaId = @CategoriaId
                        );";
                        using (var cmd = new SQLiteCommand(deleteMovimientos, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CategoriaId", cat.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Articulos
                        string deleteArticulos = "DELETE FROM Articulos WHERE CategoriaId = @CategoriaId;";
                        using (var cmd = new SQLiteCommand(deleteArticulos, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CategoriaId", cat.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. Marcas (siempre se eliminan con la categoría)
                    string deleteMarcas = "DELETE FROM Marcas WHERE CategoriaId = @CategoriaId;";
                    using (var cmd = new SQLiteCommand(deleteMarcas, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@CategoriaId", cat.Id);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Categoría
                    string deleteCategoria = "DELETE FROM Categorias WHERE Id = @Id;";
                    using (var cmd = new SQLiteCommand(deleteCategoria, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Id", cat.Id);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                con.Close();
            }
        }
        
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

        public static bool TieneArticulosAsociados(int categoriaId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Articulos WHERE CategoriaId = @CategoriaId;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static bool TieneMovimientosDeSalida(int categoriaId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                    SELECT COUNT(*) FROM Movimientos m
                    INNER JOIN Articulos a ON m.ArticuloId = a.Id
                    WHERE a.CategoriaId = @CategoriaId
                    AND m.IdAccion IN (2, 3, 5, 6, 7, 8, 10, 11);";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}

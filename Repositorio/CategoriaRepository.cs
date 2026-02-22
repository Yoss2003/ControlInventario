using ControlInventario.Modelos;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class CategoriaRepository
    {
        private readonly Inventario InventarioActual;
        public CategoriaRepository(Inventario inventario)
        {
            InventarioActual = inventario;
        }

        /* CRUD */
        public static void CrearTablaCategorias(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Categorias (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                Nombre TEXT NOT NULL,
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
        public static DataTable ListarCategorias(SQLiteConnection con)
        {
            var dt = new DataTable();

            string query = "SELECT Id, Nombre FROM Categorias;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

using ControlInventario.Modelos;
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

    }
}

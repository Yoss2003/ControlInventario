using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public class AccionesRepository
    {
        public static void CrearTablaAccion(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Acciones (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL UNIQUE,
                Descripcion TEXT
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }

            string datos = @"
            INSERT OR IGNORE INTO Acciones (Id, Nombre, Descripcion) VALUES 
            (1, 'INGRESO', 'Registro inicial en el almacén.'),
            (2, 'VENTA', 'Registro final en el almacén.'),
            (3, 'ASIGNACION', 'Se entrega el equipo a un empleado.'),
            (4, 'DEVOLUCION', 'El empleado devuelve el equipo al almacén.'),
            (5, 'MANTENIMIENTO', 'Sale temporalmente para reparación técnica.'),
            (6, 'BAJA', 'Salida definitiva del sistema (Venta, pérdida o desecho).'),
            (7, 'TRANSFERIDO', 'Movimiento entre sucursales o almacenes.'),
            (8, 'EXTRAVIADO', 'Reporte de pérdida o robo.'),
            (9, 'AJUSTE', 'Ajuste de inventario manual.'),
            (10, 'RESERVADO', 'Separado para un propósito o cliente.'),
            (11, 'CONSUMIDO', 'Gasto de suministro.'),
            (12, 'RETORNO', 'Retorno por garantía o cancelación.'),
            (13, 'MODIFICADO', 'Se modifico el articulo ingresado.');";

            using (var cmd = new SQLiteCommand(datos, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

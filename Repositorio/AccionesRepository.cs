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
            (1, 'INGRESO', 'Registro inicial en el almacén (Sin dueño).'),
            (2, 'ASIGNACION', 'Se entrega el equipo a un empleado.'),
            (3, 'DEVOLUCION', 'El empleado devuelve el equipo al almacén.'),
            (4, 'MANTENIMIENTO', 'Sale temporalmente para reparación técnica.'),
            (5, 'BAJA', 'Salida definitiva del sistema (Venta, pérdida o desecho).'),
            (6, 'TRANSFERIDO', 'Movimiento entre sucursales o almacenes.'),
            (7, 'EXTRAVIADO', 'Reporte de pérdida o robo.'),
            (8, 'AJUSTE', 'Ajuste de inventario manual.'),
            (9, 'RESERVADO', 'Separado para un propósito o cliente.'),
            (10, 'CONSUMIDO', 'Gasto de suministro.'),
            (11, 'RETORNO', 'Retorno por garantía o cancelación.');";

            using (var cmd = new SQLiteCommand(datos, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

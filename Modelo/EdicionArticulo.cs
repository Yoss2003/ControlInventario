using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class EdicionArticulo
    {
        public int Id { get; set; }
        
        // --- IDs para hacer el enlace seguro ---
        public int IdMarca { get; set; }
        public int IdEstado { get; set; }
        public int IdUbicacion { get; set; }
        public int IdCondicion { get; set; }
        
        // IDs de los Empleados
        public int? IdEmpleadoActual { get; set; }
        public int? IdEmpleadoAnterior { get; set; }

        // Mantenemos los strings por si los usas para mostrar datos en algún DataGridView o Label
        public string Marca { get; set; }
        public string Estado { get; set; }
        public string Ubicacion { get; set; }
        public string Condicion { get; set; }
        public string Area1 { get; set; }
        public string Area2 { get; set; }
        public string Cargo1 { get; set; }
        public string Cargo2 { get; set; }
    }
}

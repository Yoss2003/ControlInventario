using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public int? EmpleadoId { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Observacion { get; set; }
        public decimal? Monto { get; set; }
        public string UsuarioResponsable { get; set; }

        // Propiedades de lectura para la grilla visual (Vienen de la Vista SQL)
        public string ArticuloCodigo { get; set; }
        public string EmpleadoNombre { get; set; }
    }
}

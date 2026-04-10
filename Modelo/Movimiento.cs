using System;

namespace ControlInventario.Modelo
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public int? EmpleadoId { get; set; }
        public int IdAccion { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Observacion { get; set; }
        public decimal? Monto { get; set; }

        // Datos de venta independientes
        public string Destinatario { get; set; }
        public decimal? PrecioVenta { get; set; }
        public string Documento { get; set; }
        public string MetodoPago { get; set; }
        public string TipoComprobante { get; set; }

        // Propiedades de lectura para la grilla visual (Vienen de la Vista SQL)
        public string ArticuloCodigo { get; set; }
        public string EmpleadoNombre { get; set; }
        public string NombreAccion { get; set; }
    }
}

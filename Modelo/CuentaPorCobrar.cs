using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class CuentaPorCobrar
    {
        public int Id { get; set; }
        public int MovimientoId { get; set; }
        public int NumeroCuota { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal MontoMora { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; } // Pendiente, Pagada, Vencida, Renegociada, Cancelada
        public string Frecuencia { get; set; } // Semanal, Quincenal, Mensual

        // Propiedades calculadas
        public decimal Saldo => MontoCuota + MontoMora - MontoPagado;
        public bool EstaVencida => Estado != "Pagada" && Estado != "Cancelada" && DateTime.Now.Date > FechaVencimiento.Date;

        // Propiedades de lectura para la grilla (vienen de JOINs)
        public string Destinatario { get; set; }
        public string Documento { get; set; }
        public string ArticuloCodigo { get; set; }
        public int ArticuloId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class SalidaArticulo
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public int InventarioId { get; set; }

        // Datos Básicos de la Salida
        public string Motivo { get; set; } // Ejemplo: Venta, Baja, Donación, Préstamo
        public string Destinatario { get; set; } // Nombre del cliente o empresa
        public DateTime FechaSalida { get; set; }

        // Datos Financieros (Venta)
        public decimal? PrecioVenta { get; set; }
        public string TipoPago { get; set; } // Contado, Crédito, Transferencia
        public int? Cuotas { get; set; } // Cantidad de cuotas
        public DateTime? FechaFinPago { get; set; } // Límite para pagar todo

        // Estado
        public bool EstaPagado { get; set; } // false = Deuda pendiente (evalúa morosidad)
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}

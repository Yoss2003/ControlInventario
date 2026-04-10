using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class PagoCuota
    {
        public int Id { get; set; }
        public int CuotaId { get; set; }
        public decimal MontoAbono { get; set; }
        public DateTime FechaPago { get; set; }
        public string Observacion { get; set; }
    }
}

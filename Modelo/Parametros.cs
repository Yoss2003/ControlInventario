using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class Parametros
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public string TipoParametro { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}

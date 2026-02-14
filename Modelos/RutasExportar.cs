using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelos
{
    public class RutasExportar
    {
        public int usuarioId { get; set; }
        public string rutaPredeterminada { get; set; }
        public string rutaPersonalizada { get; set; }
        public string TipoArchivo { get; set; }
    }
}

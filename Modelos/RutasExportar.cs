using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelos
{
    public class RutasExportar
    {
        public int Id { get; set; }
        public int usuarioId { get; set; }
        public string rutaPredeterminada1 { get; set; }
        public string rutaPersonalizada1 { get; set; }
        public string TipoArchivo1 { get; set; }
        public string rutaPredeterminada2 { get; set; }
        public string rutaPersonalizada2 { get; set; }
        public string TipoArchivo2 { get; set; }
    }
}

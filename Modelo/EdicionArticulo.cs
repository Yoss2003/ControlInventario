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
        public string Marca { get; set; }
        public string Area1 { get; set; }
        public string Area2 { get; set; }
        public string Cargo1 { get; set; }
        public string Cargo2 { get; set; }
        public string Estado { get; set; }
        public string Ubicacion { get; set; }
        public string Condicion { get; set; }
    }
}

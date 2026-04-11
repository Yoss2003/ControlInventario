using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class ArticuloGrupo
    {
        public int GrupoRegistroId { get; set; }
        public string GrupoNombre { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }
        public string Ubicacion { get; set; }
        public string Condicion { get; set; }
        public string UnidadMedida { get; set; }
        public int Cantidad { get; set; }
        public string FotoPrincipal { get; set; }
        public List<Articulos> Articulos { get; set; }
    }
}

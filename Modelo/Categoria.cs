using System;

namespace ControlInventario.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EsDevolvible { get; set; }
    }

}

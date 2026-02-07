using System;
using System.Collections.Generic;

namespace ControlInventario.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string UsuarioEliminacion { get; set; }
    }

}

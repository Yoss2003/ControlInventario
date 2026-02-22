using System;
using System.Collections.Generic;

namespace ControlInventario.Modelos
{
    public class Inventario
    {
        public int Id { get; set; }
        public string NombreInventario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion {get; set; }

        // Relación con Empleado
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }

        // Relación con Categorías
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        // Relación con Artículos
        public List<Articulos> Articulos { get; set; } = new List<Articulos>();
    }
}

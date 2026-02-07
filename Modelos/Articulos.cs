using System;
using System.Collections.Generic;

namespace ControlInventario.Modelos
{
    public class Articulos
    {
        // Identificación básica
        public int Id { get; set; } // Identificador articulo
        public string Codigo { get; set; } // Codigo del articulo
        public string Modelo { get; set; } // Modelo del articulo
        public string Serie { get; set; } // Serie del articulo
        public string Marca { get; set; } // Marca del articulo

        // Fechas
        public DateTime FechaAdquisicion { get; set; } // Fecha de adquisición
        public DateTime? FechaBaja { get; set; } // nullable, porque no siempre hay baja
        public DateTime? FechaFinGarantia { get; set; } // opcional: fin de garantía

        // Usuarios
        public string UsuarioActual { get; set; } // Usuario quien lo posee
        public string UsuarioAnterior { get; set; } // Usuario quien lo poseyó

        // Área y cargo
        public int IdArea { get; set; } // Identificador del Area
        public string Area { get; set; } // Area del Usuario
        public string Cargo { get; set; } // Cargo del Usuario 

        // Estado
        public int IdEstado { get; set; } // Identificador del estado
        public string Estado { get; set; } // Estado de uso

        // Ubicación
        public int IdUbicacion { get; set; } // Identificador del lugar
        public string Ubicacion { get; set; } // Donde se encuentra

        // Información adicional
        public string Observacion { get; set; } // Observasiones del articulo
        public byte[] Foto { get; set; } // imagen del articulo

        // Campos contables / logísticos
        public decimal? PrecioAdquisicion { get; set; } // Precio inicial
        public int? VidaUtilMeses { get; set; } // RAngo de uso
        public string Proveedor { get; set; } // Lugar de origen
        public string Condicion { get; set; } // nuevo, usado, reparado
        public string ActivoFijo { get; set; } // número de activo fijo

        // Relación con Categoria
        public int CategoriaId { get; set; } // Identificador de la categoría del articulo
        public string Categoria { get; set; } // Categoría asociada

        // Características dinámicas (EAV)
        public Dictionary<string, string> Caracteristicas { get; set; } = new Dictionary<string, string>(); 
    }
}
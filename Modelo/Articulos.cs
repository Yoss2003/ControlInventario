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
        public DateTime? FechaAdquisicion { get; set; } // Fecha de adquisición
        public DateTime? FechaBaja { get; set; } // nullable, porque no siempre hay baja
        public DateTime? FechaFinGarantia { get; set; } // opcional: fin de garantía

        // Información Usuario Actual
        public string DniUsuarioActual { get; set; } // DNI del usuario actual
        public string NombreUsuarioActual { get; set; } // Usuario quien lo posee
        public int IdAreaUsuarioActual { get; set; } // Identificador del Area del usuario actual
        public string AreaUsuarioActual { get; set; } // Area del usuario actual
        public string CargoUsuarioActual { get; set; } // Cargo del usuario actual

        // Información Usuario Anterior
        public string DniUsuarioAnterior { get; set; } // DNI del usuario anterior
        public string NombreUsuarioAnterior { get; set; } // Usuario quien lo poseyó
        public int IdAreaUsuarioAnterior { get; set; } // Identificador del Area del usuario anterior
        public string AreaUsuarioAnterior { get; set; } // Area del usuario anterior
        public string CargoUsuarioAnterior { get; set; } // Cargo del usuario anterior

        // Información de articulo
        public int IdEstado { get; set; } // Identificador del estado
        public string Estado { get; set; } // Estado de uso
        public int IdUbicacion { get; set; } // Identificador del lugar
        public string Ubicacion { get; set; } // Donde se encuentra
        public int IdCondicion { get; set; } // Identificador de la condición
        public string Condicion { get; set; } // nuevo, usado, reparado
        public string ActivoFijo { get; set; } // número de activo fijo

        // Información adicional
        public string Observacion { get; set; } // Observasiones del articulo
        public byte[] Foto { get; set; } // imagen del articulo
        public byte[] Comprobante { get; set; } // imagen del comprobante

        // Campos contables / logísticos
        public string RucProveedor { get; set; } // Identificador del proveedor
        public string Proveedor { get; set; } // Lugar de origen
        public decimal? PrecioAdquisicion { get; set; } // Precio inicial
        public int? VidaUtilMeses { get; set; } // RAngo de uso

        // Relación con Categoria
        public int CategoriaId { get; set; } // Identificador de la categoría del articulo
        public string Categoria { get; set; } // Categoría asociada

        // Relación con Caracteristicas
        public List<Caracteristicas> Caracteristicas { get; set; } // Lista de características asociadas al artículo
    }
}
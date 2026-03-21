using System;
using System.Collections.Generic;

namespace ControlInventario.Modelos
{
    public class Articulos
    {
        // Identificación básica
        public int Id { get; set; } // Identificador articulo
        public int InventarioId { get; set; } // Identificador inventario
        public string Codigo { get; set; } // Codigo del articulo
        public string Modelo { get; set; } // Modelo del articulo
        public string Serie { get; set; } // Serie del articulo
        public int IdMarca { get; set; } // Id marca del articulo
        public string Marca { get; set; } // Marca del articulo
        public DateTime FechaAdquisicion { get; set; } // Fecha de adquisición
        public DateTime? FechaBaja { get; set; } // nullable, porque no siempre hay baja
        public DateTime? FechaFinGarantia { get; set; } // opcional: fin de garantía
        public string Caracteristicas { get; set; } // opcional: caracteristicas

        // Información Usuario Actual
        public int? EmpleadoActualId { get; set; } // ID del empleado que lo tiene ahora
        public string EmpleadoActualTexto { get; set; } // Nombre completo (Viene de la Vista SQL)
        
        //Propiedades Extendidas del Empleado Actual
        public string EmpleadoActualDNI { get; set; }
        public int? EmpleadoActualIdArea { get; set; }
        public string EmpleadoActualAreaTexto { get; set; }
        public int? EmpleadoActualIdCargo { get; set; }
        public string EmpleadoActualCargoTexto { get; set; }

        // Información Usuario Anterior
        public int? EmpleadoAnteriorId { get; set; } // ID del empleado que lo tuvo antes
        public string EmpleadoAnteriorTexto { get; set; } // Nombre completo (Viene de la Vista SQL)

        // Propiedades Extendidas del Empleado Anterior
        public string EmpleadoAnteriorDNI { get; set; }
        public int? EmpleadoAnteriorIdArea { get; set; }
        public string EmpleadoAnteriorAreaTexto { get; set; }
        public int? EmpleadoAnteriorIdCargo { get; set; }
        public string EmpleadoAnteriorCargoTexto { get; set; }

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
        public string FotoPrincipal { get; set; } // Ruta foto principal
        public string FotoSecundaria { get; set; } // Ruta foto secundaria
        public string ComprobantePrincipal { get; set; } // Ruta comprobante principal
        public string ComprobanteSecundaria { get; set; } // Ruta comprobante secundaria

        // Campos contables / logísticos
        public string RucProveedor { get; set; } // Identificador del proveedor
        public string Proveedor { get; set; } // Lugar de origen
        public decimal? PrecioAdquisicion { get; set; } // Precio inicial
        public int? VidaUtilMeses { get; set; } // RAngo de uso

        // Relación con Categoria
        public int CategoriaId { get; set; } // Identificador de la categoría del articulo
        public string Categoria { get; set; } // Categoría asociada

        // Datos Busqueda
        public DateTime FechaRegistro { get; set; } // Fecha de registro del artículo
        public DateTime FechaModificacion { get; set; } // Fecha de modificación del artículo
        public string Accion { get; set; } // Acción realizada (Ingreso o Salida)
    }
}
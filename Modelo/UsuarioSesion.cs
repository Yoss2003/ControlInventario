using ControlInventario.Modelos;

namespace ControlInventario.Servicios
{
    public static class UsuarioSesion
    {
        // Datos Tabla
        public static string NombreUsuario { get; set; }

        public static int IdIdioma { get; set; }
        public static string Idioma { get; set; }

        public static int IdTema { get; set; }
        public static string Tema { get; set; }

        public static int IdNotificaciones { get; set; }
        public static string Notificaciones { get; set; }

        public static int IdFormatoFecha { get; set; }
        public static string FormatoFecha { get; set; }

        public static int IdMoneda { get; set; }
        public static string Moneda { get; set; }

        public static int IdUnidadMedida { get; set; }
        public static string UnidadMedida { get; set; }

        public static int IdZonaHoraria { get; set; }
        public static string ZonaHoraria { get; set; }

        public static bool Autenticacion { get; set; }
        public static bool ActividadCompartida { get; set; }
        public static bool GeneraCodigoAuto { get; set; }
        public static bool CodigoBarras { get; set; }
        public static bool CalcularDevaluacion { get; set; }

        // Datos extras
        public static int UsuarioId { get; set; }
        public static int InventarioId { get; set; }
        public static string NombrePersonal { get; set; }
        public static string Rol { get; set; }

        public static Perfiles Configuracion { get; set; }
    }
}

using System;

namespace ControlInventario.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }

        // Datos personales
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Datos del aplicativo
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        // Datos empresariales
        public string Cargo { get; set; }
        public string Area { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoContrato { get; set; }

        // Roles
        public int IdRol { get; set; }
        public string Rol { get; set; }

        // Relación: un empleado tiene un inventario
        public Inventario Inventario { get; set; }
    }
}

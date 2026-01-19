using System;

namespace ControlInventario.Modelos
{
    public class Empleado
    {
        public int Id { get; set; }

        // Datos personales
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Datos del aplicativo
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        // Datos empresariales
        public string Cargo { get; set; }
        public string Area { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoContrato { get; set; }

        // Roles
        public bool Developer { get; set; }
        public bool Administrador { get; set; }
        public bool User { get; set; }
        public bool Invitado { get; set; }
        public bool Bloqueado { get; set; }
    }
}

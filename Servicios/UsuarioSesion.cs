using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Servicios
{
    public static class UsuarioSesion
    {
        public static int UsuarioId { get; set; }
        public static string NombreUsuario { get; set; }
        public static string NombrePersonal { get; set; }
        public static string Rol { get; set; }

        public static int inventarioId { get; set; }
    }
}

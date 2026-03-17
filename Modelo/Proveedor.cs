using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Modelo
{
    public class Proveedor
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public string Ruc {  get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Correo {  get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }
    }
}

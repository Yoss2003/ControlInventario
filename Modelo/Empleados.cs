namespace ControlInventario.Modelo
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}

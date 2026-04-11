namespace ControlInventario.Modelo
{
    public class GruposRegistros
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}

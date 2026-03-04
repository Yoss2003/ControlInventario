namespace ControlInventario.Modelos
{
    public class Condicion
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}

namespace ControlInventario.Modelos
{
    public class Marcas
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public int CategoriasId { get; set; }
        public string Nombre { get; set; }
    }
}

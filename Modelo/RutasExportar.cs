namespace ControlInventario.Modelos
{
    public class RutasExportar
    {
        public int IdRuta { get; set; }
        public int UsuarioId { get; set; }
        public string RutaPredeterminada1 { get; set; }
        public string RutaPersonalizada1 { get; set; }
        public string TipoArchivo1 { get; set; }
        public string RutaPredeterminada2 { get; set; }
        public string RutaPersonalizada2 { get; set; }
        public string TipoArchivo2 { get; set; }
        public bool EsPredeterminado1 { get; set; }
        public bool EsPredeterminado2 { get; set; }
    }
}

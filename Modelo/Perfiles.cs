namespace ControlInventario.Modelos
{
    public class Perfiles
    {
        public int IdPerfil { get; set; }
        public string NombreUsuario { get; set; }
        public int IdIdioma { get; set; }
        public string Idioma { get; set; }
        public int IdTema { get; set; }
        public string Tema { get; set; }
        public int IdNotificaciones { get; set; }
        public string Notificaciones { get; set; }
        public int IdFormatoFecha { get; set; }
        public string FormatoFecha { get; set; }
        public int IdMoneda { get; set; }
        public string Moneda { get; set; }
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public int IdZonaHoraria { get; set; }
        public string ZonaHoraria { get; set; }

        public bool Autenticacion { get; set; }
        public bool ActividadCompartida { get; set; }
        public bool CodigoBarras { get; set; }
        public bool CategoriaPersonalizada { get; set; }
        public bool CalcularDevaluacion { get; set; }
        public bool GeneracionCodigos { get; set; }
    }
}

using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaConfiguracion : Form
    {
        string nombreUsuario = UsuarioSesion.NombreUsuario;
        private bool generarCodigoAutomatico = false;
        public VistaConfiguracion()
        {
            InitializeComponent();
        }

        private void CbIdioma_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbIdioma);
        }

        private void CbTema_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbTema);
        }

        private void CbNotificaciones_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbNotificaciones);
        }

        private void CbFormatoFecha_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbFormatoFecha);
        }

        private void CbMoneda_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbMoneda);
        }

        private void CbUniMedida_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbUniMedida);
        }

        private void CbZonaHoraria_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbZonaHoraria);
        }

        private void VistaConfiguracion_Load(object sender, EventArgs e)
        {
            ClassHelper.LlenarDesdeTabla(CbIdioma, "Idioma", "Idioma");
            ClassHelper.LlenarDesdeTabla(CbTema, "Tema", "Tema");
            ClassHelper.LlenarDesdeTabla(CbNotificaciones, "Notificaciones", "Notificaciones");
            ClassHelper.LlenarDesdeTabla(CbFormatoFecha, "FormatoFecha", "FormatoFecha");
            ClassHelper.LlenarDesdeTabla(CbMoneda, "Moneda", "Moneda");
            ClassHelper.LlenarDesdeTabla(CbUniMedida, "UnidadMedida", "UnidadMedida");
            ClassHelper.LlenarDesdeTabla(CbZonaHoraria, "ZonaHoraria", "ZonaHoraria");

            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    var perfil = PerfilRepository.ObtenerPerfilUsuario(nombreUsuario, con);
                    if(perfil != null)
                    {
                        CbIdioma.SelectedValue = perfil.IdIdioma;
                        CbIdioma.SelectedItem = perfil.Idioma;

                        CbTema.SelectedValue = perfil.IdTema;
                        CbTema.SelectedItem = perfil.Tema;

                        CbNotificaciones.SelectedValue = perfil.IdNotificaciones;
                        CbNotificaciones.SelectedItem = perfil.Notificaciones;

                        CbFormatoFecha.SelectedValue = perfil.IdFormatoFecha;
                        CbFormatoFecha.SelectedItem = perfil.FormatoFecha;

                        CbMoneda.SelectedValue = perfil.IdMoneda;
                        CbMoneda.SelectedItem = perfil.Moneda;

                        CbUniMedida.SelectedValue = perfil.IdUnidadMedida;
                        CbUniMedida.SelectedItem = perfil.UnidadMedida;

                        CbZonaHoraria.SelectedValue = perfil.IdZonaHoraria;
                        CbZonaHoraria.SelectedItem = perfil.ZonaHoraria; 

                        ChkAutenticacion2FA.Checked = perfil.Autenticacion; 
                        ChkCompartirActividad.Checked = perfil.ActividadCompartida; 
                        ChkCodigoBarras.Checked = perfil.CodigoBarras;
                        ChkCalcularDevaluacion.Checked = perfil.CalcularDevaluacion; 
                        ChkGeneracionCodigo.Checked = perfil.GeneracionCodigos;
                    };
                }
            }
            catch
            {
                MessageBox.Show(Idiomas.MensajeErrorConfiguracionPerfil, "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

            ClassHelper.AplicarTema(this);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {            
            try
            {                
                using (var con = ConexionGlobal.ObtenerConexion())
                {    
                    con.Open();
                    Perfiles perf = new Perfiles
                    {
                        NombreUsuario = nombreUsuario,
                        IdIdioma = Convert.ToInt32(CbIdioma.SelectedValue),
                        Idioma = CbIdioma.Text,

                        IdTema = Convert.ToInt32(CbTema.SelectedValue),
                        Tema = CbTema.Text,

                        IdNotificaciones = Convert.ToInt32(CbNotificaciones.SelectedValue),
                        Notificaciones = CbNotificaciones.Text,

                        IdFormatoFecha = Convert.ToInt32(CbFormatoFecha.SelectedValue),
                        FormatoFecha = CbFormatoFecha.Text,

                        IdMoneda = Convert.ToInt32(CbMoneda.SelectedValue),
                        Moneda = CbMoneda.Text,

                        IdUnidadMedida = Convert.ToInt32(CbUniMedida.SelectedValue),
                        UnidadMedida = CbUniMedida.Text,

                        IdZonaHoraria = Convert.ToInt32(CbZonaHoraria.SelectedValue),
                        ZonaHoraria = CbZonaHoraria.Text,

                        Autenticacion = ChkAutenticacion2FA.Checked,
                        ActividadCompartida = ChkCompartirActividad.Checked,
                        CodigoBarras = ChkCodigoBarras.Checked,
                        CalcularDevaluacion = ChkCalcularDevaluacion.Checked,
                        GeneracionCodigos = ChkGeneracionCodigo.Checked
                    };

                    LogsRepository.InsertarLogs("Perfil", "Modificar", $"Se modificó el perfil del usuario: {nombreUsuario}");
                    PerfilRepository.GuardarPerfilUsuario(perf, con);
                    UsuarioSesion.Configuracion = perf;

                    ClassHelper.ActualizarTemaGlobal();
                    ClassHelper.AplicarIdiomaGlobal();
                    
                    string mensajeExito = string.Format(Idiomas.MensajeExitoConfiguracionGuardar, nombreUsuario);
                    MessageBox.Show(
                        mensajeExito,
                        Idiomas.TituloExito,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                string mensajeError = string.Format(Idiomas.MensajeErrorConfiguracionGuardar, nombreUsuario);
                MessageBox.Show(mensajeError, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TreeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nodo = e.Node;
            switch (nodo.Name)
            {
                case "NodeGeneral":
                    GrpGeneral.BringToFront();
                    GrpGeneral.Visible = true;
                    GrpInventario.Visible = false;
                    GrpSeguridad.Visible = false;
                    GrpDefault.Visible = false;
                    break;
                case "NodeInventario":
                    GrpGeneral.BringToFront();
                    GrpInventario.Visible = true;
                    GrpSeguridad.Visible = false;
                    GrpGeneral.Visible = false;
                    GrpDefault.Visible = false;
                    break;
                case "NodeSeguridad":
                    GrpGeneral.BringToFront();
                    GrpSeguridad.Visible = true;
                    GrpInventario.Visible = false;
                    GrpGeneral.Visible = false;
                    GrpDefault.Visible = false;
                    break;
            }
        }

        // FUNCIONES DE CONFIGURACION
        public static void AplicarFormatoFecha(DateTimePicker dtp)
        {
            string formato = UsuarioSesion.Configuracion?.FormatoFecha ?? "dd/MM/yyyy";

            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = formato;
        }

        private void CbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temaOriginal = UsuarioSesion.Configuracion?.Tema ?? "Claro";
            if (UsuarioSesion.Configuracion != null)
            {
                UsuarioSesion.Configuracion.Tema = CbTema.Text;
            }
            ClassHelper.AplicarTema(this);
        }
    }
}

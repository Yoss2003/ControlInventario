using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using DocumentFormat.OpenXml.EMMA;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaConfiguracion : Form
    {
        string nombreUsuario = UsuarioSesion.NombreUsuario;
        public VistaConfiguracion()
        {
            InitializeComponent();
        }

        private void CbIdioma_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbIdioma.Text))
            {
                CbIdioma.Text = "SELECCIONE";
            }
        }

        private void CbTema_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbTema.Text))
            {
                CbTema.Text = "SELECCIONE";
            }
        }

        private void CbNotificaciones_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbNotificaciones.Text))
            {
                CbNotificaciones.Text = "SELECCIONE";
            }
        }

        private void CbFormatoFecha_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbFormatoFecha.Text))
            {
                CbFormatoFecha.Text = "SELECCIONE";
            }
        }

        private void CbMoneda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbMoneda.Text))
            {
                CbMoneda.Text = "SELECCIONE";
            }
        }

        private void CbUniMedida_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbUniMedida.Text))
            {
                CbUniMedida.Text = "SELECCIONE";
            }
        }

        private void CbZonaHoraria_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbZonaHoraria.Text))
            {
                CbZonaHoraria.Text = "SELECCIONE";
            }
        }

        private void VistaConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    var perfil = PerfilRepository.ObtenerPerfilUsuario(nombreUsuario, con);
                    if(perfil != null)
                    {
                        CbIdioma.SelectedItem = perfil.Idioma; 
                        CbTema.SelectedItem = perfil.Tema; 
                        CbNotificaciones.SelectedItem = perfil.Notificaciones; 
                        CbFormatoFecha.SelectedItem = perfil.FormatoFecha; 
                        CbMoneda.SelectedItem = perfil.Moneda; 
                        CbUniMedida.SelectedItem = perfil.UnidadMedida; 
                        CbZonaHoraria.SelectedItem = perfil.ZonaHoraria; 
                        ChkAutenticacion2FA.Checked = perfil.Autenticacion; 
                        ChkCompartirActividad.Checked = perfil.ActividadCompartida; 
                        ChkCodigoBarras.Checked = perfil.CodigoBarras; 
                        ChkCategoriaPersonalizada.Checked = perfil.CategoriaPersonalizada; 
                        ChkCalcularDevaluacion.Checked = perfil.CalcularDevaluacion; 
                        ChkGeneracionCodigo.Checked = perfil.GeneracionCodigos;
                    };
                }
            }
            catch
            {
                MessageBox.Show("Error al crear la tabla Perfil en la base de datos.", "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
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
                        IdIdioma = CbIdioma.SelectedIndex,
                        Idioma = CbIdioma.Text,
                        IdTema = CbTema.SelectedIndex,
                        Tema = CbTema.Text,
                        IdNotificaciones = CbNotificaciones.SelectedIndex,
                        Notificaciones = CbNotificaciones.Text,
                        IdFormatoFecha = CbFormatoFecha.SelectedIndex,
                        FormatoFecha = CbFormatoFecha.Text,
                        IdMoneda = CbMoneda.SelectedIndex,
                        Moneda = CbMoneda.Text,
                        IdUnidadMedida = CbUniMedida.SelectedIndex,
                        UnidadMedida = CbUniMedida.Text,
                        IdZonaHoraria = CbZonaHoraria.SelectedIndex,
                        ZonaHoraria = CbZonaHoraria.Text,
                        Autenticacion = ChkAutenticacion2FA.Checked,
                        ActividadCompartida = ChkCompartirActividad.Checked,
                        CodigoBarras = ChkCodigoBarras.Checked,
                        CategoriaPersonalizada = ChkCategoriaPersonalizada.Checked,
                        CalcularDevaluacion = ChkCalcularDevaluacion.Checked,
                        GeneracionCodigos = ChkGeneracionCodigo.Checked
                    };

                    PerfilRepository.GuardarPerfilUsuario(perf, con);
                    MessageBox.Show("Configuración para " + nombreUsuario + " guardada correctamente.", "Éxito", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error al guardar la configuración para "+ nombreUsuario + ".", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TreeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nodo = e.Node;
            switch (nodo.Text)
            {
                case "General":
                    GrpGeneral.BringToFront();
                    GrpGeneral.Visible = true;
                    GrpInventario.Visible = false;
                    GrpSeguridad.Visible = false;
                    GrpDefault.Visible = false;
                    break;
                case "Inventario":
                    GrpGeneral.BringToFront();
                    GrpInventario.Visible = true;
                    GrpSeguridad.Visible = false;
                    GrpGeneral.Visible = false;
                    GrpDefault.Visible = false;
                    break;
                case "Seguridad":
                    GrpGeneral.BringToFront();
                    GrpSeguridad.Visible = true;
                    GrpInventario.Visible = false;
                    GrpGeneral.Visible = false;
                    GrpDefault.Visible = false;
                    break;
            }
        }
    }
}

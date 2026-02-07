using ControlInventario.Database;
using ControlInventario.Modelos;
using DocumentFormat.OpenXml.EMMA;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaConfiguracion : Form
    {
        private Empleado empleadoActual;
        public VistaConfiguracion(Empleado emp)
        {
            InitializeComponent();
            empleadoActual = emp;
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

                    string query = @"
                        CREATE TABLE IF NOT EXISTS Perfil (
                            IdPerfil INTEGER PRIMARY KEY AUTOINCREMENT,
                            NombreUsuario TEXT,
                            IdIdioma INT,
                            Idioma TEXT,
                            IdTema INT,
                            Tema TEXT,
                            IdNotificaciones INT,
                            Notificaciones TEXT,
                            IdFormatoFecha INT,
                            FormatoFecha TEXT,
                            IdMoneda INT,
                            Moneda TEXT,
                            IdUnidadMedida INT,
                            UnidadMedida TEXT,
                            IdZonaHoraria INT,
                            ZonaHoraria TEXT,
                            Autenticacion BOOL,
                            ActividadCompartida BOOL,
                            CodigoBarras BOOL,
                            CategoriaPersonalizada BOOL,
                            CalcularDevaluacion BOOL,
                            GeneracionCodigos BOOL
                        );";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    var perfil = ConfiguracionPerfiles.ObtenerPerfilUsuario(empleadoActual.Usuario, con);
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
                        NombreUsuario = empleadoActual.Usuario,
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

                    ConfiguracionPerfiles.GuardarPerfilUsuario(perf, con);
                    MessageBox.Show("Configuración para " + empleadoActual.Usuario + " guardada correctamente.", "Éxito", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error al guardar la configuración para "+ empleadoActual.Usuario + ".", "Error",
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
                    GrpGeneral.Visible = true;
                    GrpInventario.Visible = false;
                    GrpSeguridad.Visible = false;
                    break;
                case "Inventario":
                    GrpInventario.Visible = true;
                    GrpSeguridad.Visible = false;
                    GrpGeneral.Visible = false;
                    break;
                case "Seguridad":
                    GrpSeguridad.Visible = true;
                    GrpInventario.Visible = false;
                    GrpGeneral.Visible = false;
                    break;
            }
        }
    }
}

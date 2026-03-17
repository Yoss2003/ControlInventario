using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Aplicacion;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaMenuPrincipal : Form
    {
        string nombreUsusario = UsuarioSesion.NombreUsuario;
        string rol = UsuarioSesion.Rol;

        public VistaMenuPrincipal()
        {
            InitializeComponent();
        }

        private void CentrarElementos(Control control, Control contenedor)
        {
            control.Location = new Point(
                (contenedor.ClientSize.Width - control.Size.Width) / 2,
                control.Location.Y
            );
        }

        private void VistaInicio_Load(object sender, EventArgs e)
        {
            string mensajeBienvenida = string.Format(Idiomas.MensajeMenuPrincipalBienvenida, nombreUsusario);
            string mensajeRol = string.Format(Idiomas.MensajeMenuPrincipalRol, rol);
            string mensajeFecha = string.Format(Idiomas.MensajeMenuPrincipalFecha, DateTime.Now.ToString("dd/MM/yyyy"));
            string mensajeUsuario = string.Format(Idiomas.MensajeMenuPrincipalUsuario, nombreUsusario);

            lblBienvenida.Text = mensajeBienvenida;
            lblRol.Text = mensajeRol;
            lblFecha.Text = mensajeFecha;
            lblUsuario.Text = mensajeUsuario;

            string[] frases = {
                Idiomas.MensajeMenuPrincipal1,
                Idiomas.MensajeMenuPrincipal2,
                Idiomas.MensajeMenuPrincipal3,
                Idiomas.MensajeMenuPrincipal4,
                Idiomas.MensajeMenuPrincipal5,
                Idiomas.MensajeMenuPrincipal6
            };
            lblTextoRandom.Text = frases[new Random().Next(frases.Length)];

            CentrarElementos(lblTextoRandom, groupAcciones);
            CentrarElementos(btnCerrarSesion, groupAcciones);

            // Crear y configurar el TableLayoutPanel
            TableLayoutPanel panelInfo = new TableLayoutPanel();
            panelInfo.Name = "panelInfo";
            panelInfo.ColumnCount = 2;
            panelInfo.RowCount = 2;
            panelInfo.Dock = DockStyle.Top;
            panelInfo.AutoSize = true;
            panelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            lblBienvenida.TextAlign = ContentAlignment.MiddleLeft;
            lblRol.TextAlign = ContentAlignment.MiddleLeft;
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;

            lblFecha.Dock = DockStyle.Fill;
            lblUsuario.Dock = DockStyle.Fill;
            lblRol.Dock = DockStyle.Fill;
            lblBienvenida.Dock = DockStyle.Fill;

            // Agregar los Label al panel
            panelInfo.Controls.Add(lblBienvenida, 0, 0);
            panelInfo.Controls.Add(lblFecha, 1, 0);
            panelInfo.Controls.Add(lblRol, 0, 1);
            panelInfo.Controls.Add(lblUsuario, 1, 1);

            // Insertar el panel en el GroupBox
            groupInicio.Controls.Add(panelInfo);
            ClassHelper.AplicarTema(this);
            lblFecha.Text = ClassHelper.FormatearFecha(DateTime.Now);            
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            VistaRegistros registros = new VistaRegistros();
            registros.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            VistaReporte reporte = new VistaReporte();
            reporte.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            var repo = new InventarioRepository();

            VistaInventario inventarioForm = new VistaInventario();
            inventarioForm.ShowDialog();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            VistaConfiguracion configuracion = new VistaConfiguracion();
            configuracion.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            VistaInicioSesion vistaSesion = new VistaInicioSesion();
            vistaSesion.ShowDialog();
            this.Close();
        }
    }
}

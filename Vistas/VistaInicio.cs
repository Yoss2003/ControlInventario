using ControlInventario.Modelos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaInicio : Form
    {
        private Empleado empleadoActual;

        public VistaInicio(Empleado emp)
        {
            InitializeComponent();
            empleadoActual = emp;
        }

        private void CentrarElementos(Control control, Control contenedor)
        {
            control.Location = new System.Drawing.Point(
                (contenedor.ClientSize.Width - control.Size.Width) / 2,
                control.Location.Y
            );
        }

        private void VistaInicio_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "Bienvenido " + empleadoActual.Nombres;
            lblRol.Text = $"Rol: {empleadoActual.Roles}";
            lblFecha.Text = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
            lblUsuario.Text = $"Usuario: {empleadoActual.Usuario}";

            string[] frases = {
                "Espero no hayas perdido nada",
                "¿El inventario está al día?",
                "Recuerda tener tu reporte actualizado",
                "Tu jefe confía en tí, no robes.",
                "Error",
                "Recuerda por quién trabajas.",
                "¿Cuando fue la ultima vez que ingresaste acá?"
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
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            //En desarrollo
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            VistaReporte reporte = new VistaReporte();
            reporte.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            VistaInventario inventario = new VistaInventario();
            inventario.ShowDialog();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            VistaConfiguracion configuracion = new VistaConfiguracion();
            configuracion.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }
    }

}

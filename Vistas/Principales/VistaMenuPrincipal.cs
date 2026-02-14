using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaMenuPrincipal : Form
    {
        int usuarioId = UsuarioSesion.UsuarioId;
        string nombreUusario = UsuarioSesion.NombreUsuario;
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
            lblBienvenida.Text = $"Bienvenido {nombreUusario}";
            lblRol.Text = $"Rol: {rol}";
            lblFecha.Text = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
            lblUsuario.Text = $"Usuario: {nombreUusario}";

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
            Inventario Buscarinventario;
            var repo = new InventarioRepository();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string queryInventario = @"
                CREATE TABLE IF NOT EXISTS Inventarios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NombreInventario TEXT,
                    FechaCreacion TEXT,                        
                    FechaModificacion TEXT,
                    UsuarioId INT,
                    Usuario TEXT
                );";

                using(var cmd = new SQLiteCommand(queryInventario, con))
                {
                    cmd.ExecuteNonQuery();
                }

                Buscarinventario = repo.ObtenerOCrearInventarioPorUsuario(con);
            }
            VistaInventario inventario = new VistaInventario(Buscarinventario);
            inventario.ShowDialog();
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

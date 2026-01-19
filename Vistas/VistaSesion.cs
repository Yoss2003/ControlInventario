using ControlInventario.Database;
using ControlInventario.Vistas;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario
{
    public partial class VistaSesion : Form
    {
        public VistaSesion()
        {
            InitializeComponent();
        }

        private void lnkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VistaRegistro vistaRegistro = new VistaRegistro();
            vistaRegistro.ShowDialog();
        }

        private void VistaSesion_Load(object sender, System.EventArgs e)
        {
            try
            {
                var conexion = ConexionGlobal.ObtenerConexion();
                conexion.Open();

                lblConexion.Visible = true;
                lblConexion.Text = "Conexión exitosa";
                lblConexion.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblConexion.Visible = true;
                lblConexion.Text = "Error de conexión: " + ex.Message;
                lblConexion.ForeColor = Color.Red;
            }
        }
    }
}

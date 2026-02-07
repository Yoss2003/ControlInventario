using ControlInventario.Database;
using ControlInventario.Modelos;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ControlInventario.Vistas
{
    public partial class VistaRecuperacion : Form
    {
        public VistaRecuperacion(string usuario)
        {
            InitializeComponent();
            txtUsuario.Text = usuario;
            txtUsuario.Enabled = false;
        }

        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {

            string codigoIngresado = txtDig1.Text + txtDig2.Text + txtDig3.Text + txtDig4.Text +
                         txtDig5.Text + txtDig6.Text + txtDig7.Text + txtDig8.Text;

            TimeSpan diferencia = DateTime.Now - RecuperacionHelper.FechaGeneracion;

            if (diferencia.TotalMinutes > 3)
            {
                MessageBox.Show("El código ha expirado. Solicita uno nuevo.");
                return;
            }

            if (codigoIngresado == RecuperacionHelper.CodigoGenerado)
            {
                MessageBox.Show(
                    "Verificación exitosa\n\nEl código ingresado es correcto. Ahora puedes establecer una nueva contraseña.",
                    "Restablecer contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                txtNuevaContraseña.Enabled = true;
                btnGuardarContraseña.Enabled = true;
            }
            else
            {
                MessageBox.Show(
                    "Verificación fallida\n\nEl código ingresado no es válido. Por favor, verifica e intenta nuevamente.",
                    "Error de seguridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGuardarContraseña_Click(object sender, EventArgs e)
        {
            string nuevaContraseña = txtNuevaContraseña.Text.Trim();

            if (string.IsNullOrEmpty(nuevaContraseña))
            {
                MessageBox.Show(
                    "Campo vacío\n\nLa contraseña no puede estar vacía. Por favor, ingresa una nueva contraseña.",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "UPDATE Empleados SET Contraseña = @Contraseña WHERE Usuario = @Usuario";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Contraseña", nuevaContraseña);
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show(
                "Actualización exitosa\n\nTu contraseña ha sido modificada correctamente.",
                "Confirmación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            VistaInicioSesion sesion = new VistaInicioSesion();
            this.Hide();
            sesion.Show();
            this.Close();
        }
        private void Codigo_TextChanged(object sender, EventArgs e)
        {
            TextBox actual = sender as TextBox;

            if (actual.Text.Length == 1)
            {
                // Buscar el siguiente TextBox por nombre
                string nombreActual = actual.Name;
                int numero = int.Parse(nombreActual.Substring(6));
                int siguiente = numero + 1;

                Control siguienteControl = this.Controls.Find("txtDig" + siguiente, true).FirstOrDefault();
                siguienteControl?.Focus();
            }
        }

        private void Codigo_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox actual = sender as TextBox;

            if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(actual.Text))
            {
                int numero = int.Parse(actual.Name.Substring(6));
                int anterior = numero - 1;
                Control anteriorControl = this.Controls.Find("txtDig" + anterior, true).FirstOrDefault();
                anteriorControl?.Focus();
            }
        }

        private void VistaRecuperacion_Load(object sender, EventArgs e)
        {
            TextBox[] campoCodigo;
            campoCodigo = new TextBox[] { txtDig1, txtDig2, txtDig3, txtDig4, txtDig5, txtDig6, txtDig7, txtDig8 };
            foreach (var txt in campoCodigo)
            {
                txt.TextChanged += Codigo_TextChanged;
                txt.KeyDown += Codigo_KeyDown;
                txt.TextAlign = HorizontalAlignment.Center;
            }
        }
    }
}

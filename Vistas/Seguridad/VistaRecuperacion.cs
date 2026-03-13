using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

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

            TimeSpan diferencia = DateTime.Now - Recuperacion.FechaGeneracion;

            if (diferencia.TotalMinutes > 3)
            {
                MessageBox.Show(Idiomas.MensajeCodigoRecuperacionExpirado);
                return;
            }

            if (codigoIngresado == Recuperacion.CodigoGenerado)
            {
                MessageBox.Show(
                    Idiomas.MensajeCodigoRecuperacionCorrecto,
                    Idiomas.TituloExito,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                txtNuevaContraseña.Enabled = true;
                btnGuardarContraseña.Enabled = true;
            }
            else
            {
                EfectoTemblorCasillas();
                MessageBox.Show(
                    Idiomas.MensajeCodigoRecuperacionIncorrecto,
                    "Error",
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
                    Idiomas.MensajeContraseñaNuevaVacía,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "UPDATE Usuario SET Contraseña = @Contraseña WHERE Usuario = @Usuario";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Contraseña", nuevaContraseña);
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show(
                Idiomas.MensajeContraseñaNuevaExito,
                Idiomas.TituloConfirmacion,
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
            ClassHelper.AplicarTema(this);
        }

        private async void EfectoTemblorCasillas()
        {
            // Reemplaza txt1, txt2, etc., por los nombres reales de tus 8 casillas
            TextBox[] casillas = { txtDig1, txtDig2, txtDig3, txtDig4, txtDig5, txtDig6, txtDig7, txtDig8 };
            int[] posicionesX = new int[8];

            // Guardamos la posición original de cada casilla
            for (int i = 0; i < 8; i++) posicionesX[i] = casillas[i].Location.X;

            // Las hacemos temblar juntas
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++) casillas[j].Left = posicionesX[j] + 5;
                await System.Threading.Tasks.Task.Delay(30);

                for (int j = 0; j < 8; j++) casillas[j].Left = posicionesX[j] - 5;
                await System.Threading.Tasks.Task.Delay(30);
            }

            // Las regresamos a su lugar exacto
            for (int j = 0; j < 8; j++) casillas[j].Left = posicionesX[j];
        }

        private void VerificarCasillasCompletas()
        {
            btnValidarCodigo.Enabled =
                txtDig1.Text.Length > 0 && txtDig2.Text.Length > 0 &&
                txtDig3.Text.Length > 0 && txtDig4.Text.Length > 0 &&
                txtDig5.Text.Length > 0 && txtDig6.Text.Length > 0 &&
                txtDig7.Text.Length > 0 && txtDig8.Text.Length > 0;
        }

        private void txtDig1_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig1_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig2_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig2_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig3_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }
        
        private void txtDig3_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig4_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig4_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig5_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig5_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig6_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig6_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig7_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig7_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void txtDig8_Enter(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.LightCyan;
        }

        private void txtDig8_Leave(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            cajaActual.BackColor = System.Drawing.Color.White;
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            VerificarCasillasCompletas();
        }

        private void Casillas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string textoPegado = Clipboard.GetText().Trim();

                if (!string.IsNullOrEmpty(textoPegado))
                {
                    TextBox[] casillas = { txtDig1, txtDig2, txtDig3, txtDig4, txtDig5, txtDig6, txtDig7, txtDig8 };

                    for (int i = 0; i < casillas.Length && i < textoPegado.Length; i++)
                    {
                        casillas[i].Text = textoPegado[i].ToString();
                    }

                    int indiceUltima = Math.Min(textoPegado.Length - 1, 7);
                    casillas[indiceUltima].Focus();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtNuevaContraseña_TextChanged(object sender, EventArgs e)
        {
            if(txtNuevaContraseña.TextLength >= 8)
            {
                btnGuardarContraseña.Enabled = true;
            }
        }
    }
}

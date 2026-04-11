using ControlInventario.Database;
using ControlInventario.Servicios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Seguridad
{
    public partial class VistaValidarPreguntasSeguridad : Form
    {
        private string nombreUsuario;
        private int intentosRestantes = 3;

        private Label lblTitulo;
        private Label lblPregunta1;
        private TextBox txtRespuesta1;
        private Label lblPregunta2;
        private TextBox txtRespuesta2;
        private Label lblPregunta3;
        private TextBox txtRespuesta3;
        private Label lblIntentos;
        private Button btnValidar;
        private Button btnCancelar;

        public bool RespuestasCorrectas { get; private set; }

        public VistaValidarPreguntasSeguridad(string usuario)
        {
            this.nombreUsuario = usuario;
            InitializeComponent();
            CargarPreguntas();
        }

        private void InitializeComponent()
        {
            this.Text = "Validación de Seguridad";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblTitulo = new Label
            {
                Text = "Responda las preguntas de seguridad para continuar:",
                Location = new Point(20, 20),
                Size = new Size(450, 40),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold)
            };

            lblPregunta1 = new Label
            {
                Location = new Point(20, 70),
                Size = new Size(450, 20),
                Font = new Font("Segoe UI", 9f)
            };

            txtRespuesta1 = new TextBox
            {
                Location = new Point(20, 95),
                Size = new Size(450, 25),
                Font = new Font("Segoe UI", 9f)
            };

            lblPregunta2 = new Label
            {
                Location = new Point(20, 135),
                Size = new Size(450, 20),
                Font = new Font("Segoe UI", 9f)
            };

            txtRespuesta2 = new TextBox
            {
                Location = new Point(20, 160),
                Size = new Size(450, 25),
                Font = new Font("Segoe UI", 9f)
            };

            lblPregunta3 = new Label
            {
                Location = new Point(20, 200),
                Size = new Size(450, 20),
                Font = new Font("Segoe UI", 9f)
            };

            txtRespuesta3 = new TextBox
            {
                Location = new Point(20, 225),
                Size = new Size(450, 25),
                Font = new Font("Segoe UI", 9f)
            };

            lblIntentos = new Label
            {
                Text = $"⚠️ Intentos restantes: {intentosRestantes}",
                Location = new Point(20, 270),
                Size = new Size(450, 25),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.DarkOrange
            };

            btnValidar = new Button
            {
                Text = "Validar Respuestas",
                Location = new Point(150, 320),
                Size = new Size(120, 40),
                Font = new Font("Segoe UI", 9f),
                BackColor = Color.LightGreen
            };
            btnValidar.Click += BtnValidar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(280, 320),
                Size = new Size(100, 40),
                Font = new Font("Segoe UI", 9f),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] {
                lblTitulo, lblPregunta1, txtRespuesta1,
                lblPregunta2, txtRespuesta2, lblPregunta3,
                txtRespuesta3, lblIntentos, btnValidar, btnCancelar
            });

            ClassHelper.AplicarTema(this);
        }

        private void CargarPreguntas()
        {
            var preguntas = RecuperacionRepository.ObtenerPreguntasUsuario(nombreUsuario);

            if (string.IsNullOrEmpty(preguntas.Pregunta1))
            {
                MessageBox.Show("El usuario no tiene preguntas de seguridad configuradas.\n\nNo puede recuperar su contraseña.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            lblPregunta1.Text = $"1. {preguntas.Pregunta1}";
            lblPregunta2.Text = $"2. {preguntas.Pregunta2}";
            lblPregunta3.Text = $"3. {preguntas.Pregunta3}";
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            string r1 = txtRespuesta1.Text.Trim();
            string r2 = txtRespuesta2.Text.Trim();
            string r3 = txtRespuesta3.Text.Trim();

            if (string.IsNullOrWhiteSpace(r1) || string.IsNullOrWhiteSpace(r2) || string.IsNullOrWhiteSpace(r3))
            {
                MessageBox.Show("Por favor responda las 3 preguntas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar respuestas
            bool correctas = RecuperacionRepository.ValidarRespuestasSeguridad(nombreUsuario, r1, r2, r3);

            if (correctas)
            {
                // Respuestas correctas → reiniciar intentos y continuar
                RecuperacionRepository.ReiniciarIntentos(nombreUsuario);
                RespuestasCorrectas = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Respuesta incorrecta → registrar intento fallido
                intentosRestantes--;
                RecuperacionRepository.RegistrarIntentoFallido(nombreUsuario);

                if (intentosRestantes > 0)
                {
                    lblIntentos.Text = $"⚠️ Respuestas incorrectas. Intentos restantes: {intentosRestantes}";
                    lblIntentos.ForeColor = Color.Red;
                    
                    // Limpiar campos
                    txtRespuesta1.Clear();
                    txtRespuesta2.Clear();
                    txtRespuesta3.Clear();
                    txtRespuesta1.Focus();
                }
                else
                {
                    // Se acabaron los intentos → bloquear por 3 horas
                    MessageBox.Show(
                        "❌ Ha superado el número máximo de intentos (3).\n\n" +
                        "Por seguridad, la recuperación de contraseña está bloqueada durante 3 horas.\n\n" +
                        "Intente nuevamente después de las " + DateTime.Now.AddHours(3).ToString("HH:mm") + " hrs.",
                        "Cuenta Bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }
    }
}

using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Vistas;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario
{
    public partial class VistaSesion : Form
    {
        private OverlayCarga overlay;
        public VistaSesion()
        {
            InitializeComponent();
        }

        private void lnkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VistaRegistro vistaRegistro = new VistaRegistro();
            vistaRegistro.ShowDialog();
        }

        private void CentrarElementos(Control control, Control contenedor)
        {
            control.Location = new Point(
                (contenedor.ClientSize.Width - control.Size.Width) / 2,
                control.Location.Y
            );
        }

        private void VistaSesion_Load(object sender, System.EventArgs e)
        {
            overlay = new OverlayCarga(this);
            string usuarioGuardado = Properties.Settings.Default.UsuarioGuardado;
            string contraseñaGuardada = Properties.Settings.Default.ContraseñaGuardada;
            if (!string.IsNullOrEmpty(usuarioGuardado))
            {
                txtUsuario.Text = usuarioGuardado;
                txtContraseña.Text = contraseñaGuardada;
                chkRecuerdame.Checked = true;
            }
            else
            {
                chkRecuerdame.Checked = false;
            }

            CentrarElementos(lblBienvenida,groupBienvenida);
            CentrarElementos(lblRegistro,groupBienvenida);
            CentrarElementos(txtUsuario,groupLogin);
            CentrarElementos(txtContraseña,groupLogin);
            CentrarElementos(btnIngresar,groupLogin);
            CentrarElementos(lblConexion,groupInformation);
            CentrarElementos(lnkDerechos, groupInformation);

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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            lblErrorUsuario.Visible = false;
            lblErrorContraseña.Visible = false;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña)) 
            { 
                if (string.IsNullOrWhiteSpace(usuario)) 
                    lblErrorUsuario.Text = "Ingrese el usuario."; 
                if (string.IsNullOrWhiteSpace(contraseña)) 
                    lblErrorContraseña.Text = "Ingrese la contraseña."; 

                lblErrorUsuario.Visible = string.IsNullOrWhiteSpace(usuario); 
                lblErrorContraseña.Visible = string.IsNullOrWhiteSpace(contraseña); 
                return; 
            }

            // Validar credenciales contra la BD
            Empleado emp = EmpleadoRepository.BuscarPorUsuario(usuario);

            if (chkRecuerdame.Checked)
            {
                Properties.Settings.Default.UsuarioGuardado = txtUsuario.Text;
                Properties.Settings.Default.ContraseñaGuardada = txtContraseña.Text;
            }
            else
            {
                Properties.Settings.Default.UsuarioGuardado = "";
                Properties.Settings.Default.ContraseñaGuardada = "";
            }
                        
            if (emp == null)
            {
                lblErrorUsuario.Text = "Usuario no encontrado."; 
                lblErrorUsuario.Visible = true; 
                return;
            }

            if(emp.Contraseña != contraseña)
            {
                lblErrorContraseña.Text = "Contraseña incorrecta."; 
                lblErrorContraseña.Visible = true; 
                return;
            }

            Properties.Settings.Default.Save();

            VistaInicio frm = new VistaInicio(emp);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void chkRecuerdame_Click(object sender, EventArgs e)
        {
            if (chkRecuerdame.Checked == true)
            {
                MessageBox.Show("Si el equipo es compartido no recomendamos activar esta casilla", "Information",
                    MessageBoxButtons.OK);
            }
        }

        // Variables en memoria
        public string codigoGenerado;
        public DateTime fechaGeneracion;

        private async void lnkContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string correoUsuario = "";
            overlay.Mostrar();
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(usuarioIngresado))
                {
                    MessageBox.Show("Ingresa tu usuario antes de recuperar la contraseña.");
                    return;
                }

                // 1. Buscar el correo en la BD (solo lectura)
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    string query = "SELECT Correo FROM Empleados WHERE Usuario = @Usuario";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuarioIngresado);
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Usuario no encontrado.");
                            return;
                        }
                        correoUsuario = result.ToString();
                    }
                }

                // 2. Generar código y guardar en memoria
                RecuperacionHelper.CodigoGenerado = new Random().Next(10000000, 99999999).ToString();
                RecuperacionHelper.FechaGeneracion = DateTime.Now;

                // 3. Enviar correo con HTML
                try
                {
                    MailMessage message = new MailMessage();
                    message.To.Add(correoUsuario);
                    message.Subject = "Código de recuperación de contraseña";
                    message.From = new MailAddress("soporte@controlinventario.com", "Soporte ControlInventario");
                    message.IsBodyHtml = true;
                    message.Body = $@"
                    <div style='font-family:Segoe UI; padding:20px; background-color:#f9f9f9; border:1px solid #ddd;'>
                        <h2 style='color:#2c3e50;'>Recuperación de contraseña</h2>
                        <p>Hola <strong>{usuarioIngresado}</strong>,</p>
                        <p>Has solicitado recuperar tu contraseña. Tu código de seguridad es:</p>
                        <div style='font-size:24px; font-weight:bold; color:#2980b9; margin:20px 0;'>{RecuperacionHelper.CodigoGenerado}</div>
                        <p>Este código es válido por 10 minutos. Si no solicitaste este correo, puedes ignorarlo.</p>
                        <hr />
                        <p style='font-size:12px; color:#888;'>© 2026 ControlInventario. Todos los derechos reservados.</p>
                    </div>";

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("mercadogarciayossimar3@gmail.com", "qbjt qkud xgfu fgpx");
                    smtp.EnableSsl = true;
                    smtp.Send(message);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        overlay.Ocultar();
                        MessageBox.Show(
                            "Código enviado\n\nHemos enviado un código de seguridad a tu correo electrónico.",
                            "Verificación de seguridad",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el correo: " + ex.Message);
                }
            });

            var recuperar = new VistaRecuperacion(usuarioIngresado);
            this.Hide();
            recuperar.ShowDialog();
        }
    }
}

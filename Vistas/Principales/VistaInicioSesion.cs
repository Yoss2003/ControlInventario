using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas;
using ControlInventario.Vistas.Seguridad;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario
{
    public partial class VistaInicioSesion : Form
    {
        // Variables en memoria
        public string codigoGenerado;
        public DateTime fechaGeneracion;
        private GestorVoz _gestorVoz;

        //Varible para el overlay
        private OverlayCarga overlay;

        public VistaInicioSesion()
        {
            InitializeComponent();
            _gestorVoz = new GestorVoz();
        }

        private void lnkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abrir la vista de registro
            VistaRegistro vistaRegistro = new VistaRegistro();
            vistaRegistro.ShowDialog();
        }

        public static void CentrarElementos(Control control, Control contenedor)
        {
            // Centrar horizontalmente el control dentro del contenedor
            control.Location = new Point(
                (contenedor.ClientSize.Width - control.Size.Width) / 2,
                control.Location.Y
            );
        }

        private async void VistaSesion_Load(object sender, EventArgs e)
        {
            // Inicializar el overlay de carga
            overlay = new OverlayCarga(this);

            // Cargar credenciales guardadas
            string usuarioGuardado = Properties.Settings.Default.UsuarioGuardado;
            string contraseñaGuardada = Properties.Settings.Default.ContraseñaGuardada;

            // Si hay credenciales guardadas, rellenar los campos y marcar el checkbox
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

            // Verificar conexión a la base de datos
            using (var con = ConexionGlobal.ObtenerConexion())
            {                
                try
                {
                    con.Open();
                    lblConexion.Visible = true;
                    lblConexion.Text = Idiomas.MensajeConexionBdExitosa;
                    lblConexion.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    string mensajeError = string.Format(Idiomas.MensajeConexionBdError, ex.Message);
                    lblConexion.Visible = true;
                    lblConexion.Text = mensajeError;
                    lblConexion.ForeColor = Color.Red;
                }

                try
                {
                    await ApiHelper.CargarTasasDeCambioDesdeAPI();
                }
                catch
                {
                    MessageBox.Show("No se pudo conectar a la API de Monedas. Se usarán las tasas locales.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            ClassHelper.AplicarTema(this);
            ClassHelper.AplicarIdiomaGlobal();
            //_gestorVoz.HablarAsincrono("Bienvenido al sistema de control de inventario.");
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener y limpiar entradas
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            // Ocultar mensajes de error previos
            lblErrorUsuario.Visible = false;
            lblErrorContraseña.Visible = false;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña)) 
            { 
                if (string.IsNullOrWhiteSpace(usuario)) 
                    lblErrorUsuario.Text = Idiomas.MensajeAdvertenciaIniciarSesionUsuario; 
                if (string.IsNullOrWhiteSpace(contraseña)) 
                    lblErrorContraseña.Text = Idiomas.MensajeAdvertenciaIniciarSesionContraseña; 

                lblErrorUsuario.Visible = string.IsNullOrWhiteSpace(usuario); 
                lblErrorContraseña.Visible = string.IsNullOrWhiteSpace(contraseña); 
                return; 
            }

            // Validar credenciales contra la BD
            Usuario user = UsuarioRepository.BuscarPorUsuario(usuario);

            // Guardar o limpiar credenciales según el estado del checkbox
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

            // Validar si el usuario existe
            if (user == null)
            {
                lblErrorUsuario.Text = Idiomas.MensajeErrorIniciarSesionUsuario; 
                lblErrorUsuario.Visible = true; 
                return;
            }

            // Validar contraseña
            if (user.Contraseña != contraseña)
            {
                lblErrorContraseña.Text = Idiomas.MensajeErrorIniciarSesionContraseña; 
                lblErrorContraseña.Visible = true; 
                return;
            }

            // Guardar cambios en la configuración
            Properties.Settings.Default.Save();
            try
            {
                UsuarioSesion.UsuarioId = user.Id;
                UsuarioSesion.NombreUsuario = user.NombreUsuario;
                UsuarioSesion.Rol = "Usuario";
                UsuarioSesion.NombrePersonal = $"{user.Nombres}"; 
                UsuarioSesion.FechaIngreso = user.FechaIngreso;

                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    var perfil = PerfilRepository.ObtenerPerfilUsuario(UsuarioSesion.NombreUsuario, con);

                    if (perfil != null)
                    {
                        UsuarioSesion.Configuracion = perfil;
                    }
                    else
                    {
                        Perfiles nuevoPerfil = PerfilRepository.GenerarPerfilPorDefecto(UsuarioSesion.NombreUsuario, con);
                        PerfilRepository.GuardarPerfilUsuario(nuevoPerfil, con);
                        UsuarioSesion.Configuracion = nuevoPerfil;

                        LogsRepository.InsertarLogs("Perfil", "Crear", $"Se creó un nuevo perfil con el usuario: {nuevoPerfil.NombreUsuario}");
                    }
                }
            }
            catch { }

            var repo = new InventarioRepository();
            var inventario = repo.ObtenerOCrearInventarioPorUsuario(user.NombreUsuario); 
            await ApiHelper.CargarTasasDeCambioDesdeAPI();

            UsuarioSesion.InventarioId = inventario.Id;

            // Abrir el menú principal
            ClassHelper.AplicarIdiomaGlobal();
            VistaMenuPrincipal frm = new VistaMenuPrincipal();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void chkRecuerdame_Click(object sender, EventArgs e)
        {
            // Mostrar advertencia si se activa la casilla "Recuérdame"
            if (chkRecuerdame.Checked == true)
            {
                MessageBox.Show(Idiomas.MensajeAdvertenciaIniciarSesionRecuerdame, Idiomas.TituloInformacion,
                    MessageBoxButtons.OK);
            }
        }

        private async void lnkContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();

            // Validar que el usuario no esté vacío
            if (string.IsNullOrEmpty(usuarioIngresado))
            {
                MessageBox.Show(Idiomas.MensajeAdvertenciaRecuperarUsuario);
                return;
            }

            // PASO 1: Verificar si el usuario está bloqueado
            if (RecuperacionRepository.UsuarioBloqueado(usuarioIngresado, out DateTime bloqueadoHasta))
            {
                TimeSpan tiempoRestante = bloqueadoHasta - DateTime.Now;
                string mensaje = $"⛔ Recuperación bloqueada por seguridad.\n\n" +
                    $"Demasiados intentos fallidos.\n\n" +
                    $"Podrá intentar nuevamente en: {tiempoRestante.Hours}h {tiempoRestante.Minutes}m";

                MessageBox.Show(mensaje, "Acceso Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // PASO 2: Validar que el usuario exista y obtener su correo
            string correoUsuario = "";
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT Correo FROM Usuario WHERE Usuario = @Usuario";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuarioIngresado);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show(Idiomas.MensajeErrorUsuario);
                        return;
                    }
                    correoUsuario = result.ToString();
                }
            }

            // PASO 3: Mostrar preguntas de seguridad para validar identidad
            using (var vistaPreguntas = new VistaValidarPreguntasSeguridad(usuarioIngresado))
            {
                if (vistaPreguntas.ShowDialog() != DialogResult.OK || !vistaPreguntas.RespuestasCorrectas)
                {
                    // Usuario canceló o falló las preguntas → no enviar correo
                    return;
                }
            }

            // PASO 4: Generar código y enviar correo (solo si pasó las preguntas)
            overlay.Mostrar();

            await Task.Run(() =>
            {
                // Generar código y guardar en memoria
                Recuperacion.CodigoGenerado = new Random().Next(10000000, 99999999).ToString();
                Recuperacion.FechaGeneracion = DateTime.Now;

                // Enviar correo con HTML
                try
                {
                    MailMessage message = new MailMessage();
                    message.To.Add(correoUsuario);
                    message.Subject = Idiomas.AsuntoCorreoRecuperacion;
                    message.From = new MailAddress("soporte@controlinventario.com", Idiomas.NombreRemitenteCorreo);
                    message.IsBodyHtml = true;
                    message.Body = string.Format(Idiomas.PlantillaCorreoRecuperacion, usuarioIngresado, Recuperacion.CodigoGenerado);

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("mercadogarciayossimar3@gmail.com", "qbjt qkud xgfu fgpx");
                    smtp.EnableSsl = true;
                    smtp.Send(message);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        overlay.Ocultar();
                        MessageBox.Show(
                            Idiomas.MensajeExitoEnvioCorreo,
                            Idiomas.TituloValidacion,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        overlay.Ocultar();
                        string mensajeError = string.Format(Idiomas.MensajeErrorEnviarCorreo, ex.Message);
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }
            });

            // PASO 5: Abrir la vista de ingreso del código
            var recuperar = new VistaRecuperacion(usuarioIngresado);
            this.Hide();
            recuperar.ShowDialog();
        }
    }
}

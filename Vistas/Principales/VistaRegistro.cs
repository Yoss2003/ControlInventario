using ControlInventario.Database;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaRegistro : Form, ICargosRefrescable, IAreasRefrescable, ITipoContratoRefrescable
    {
        public ComboBox CbCargoPublic => CbCargo;
        public ComboBox CbAreaPublic => CbArea;
        public ComboBox CbTipoContratoPublic => CbTipoContrato;

        private string rolCalculado = "Usuario";
        public VistaRegistro()
        {
            InitializeComponent();
        }

        private bool ValidarFormulario()
        {
            // Validación de campos con reglas específicas
            bool valido = true;
            errorProvider1.Clear();

            // Datos Personales
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, Idiomas.MensajeErrorRegistrarNombre);
                valido = false;
            }
            else if (txtNombre.Text.Length < 3 || Regex.IsMatch(txtNombre.Text, @"(.)\1{2,}"))
            {
                errorProvider1.SetError(txtNombre, Idiomas.MensajeErrorRegistrarNombreExtra);
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, Idiomas.MensajeErrorRegistrarApellido);
                valido = false;
            }
            else if (txtApellido.Text.Length < 3 || Regex.IsMatch(txtApellido.Text, @"(.)\1{2,}"))
            {
                errorProvider1.SetError(txtApellido, Idiomas.MensajeErrorRegistrarApellidoExtra);
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "El correo es obligatorio. Se usará para enviar correos automáticos a clientes.");
                valido = false;
            }
            else if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]{2,}@[^@\s]+\.(com|net|org|edu|pe)$"))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido. Recomendado: Gmail para envío automático.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                errorProvider1.SetError(txtEdad, Idiomas.MensajeErrorRegistrarEdad);
                valido = false;
            }
            else
            {
                if (int.TryParse(txtEdad.Text, out int edad))
                {
                    DateTime hoy = DateTime.Today;
                    int edadCalculada = hoy.Year - dtFechaNac.Value.Year;

                    if (hoy.Month < dtFechaNac.Value.Month || (hoy.Month == dtFechaNac.Value.Month && hoy.Day < dtFechaNac.Value.Day))
                    {
                        edadCalculada--;
                    }

                    if (dtFechaNac.Value > DateTime.Now || edadCalculada != edad)
                    {
                        errorProvider1.SetError(dtFechaNac, Idiomas.MensajeErrorRegistrarFechaNacimiento);
                        valido = false;
                    }

                    if (edad < 18 || edad > 65)
                    {
                        errorProvider1.SetError(txtEdad, Idiomas.MensajeErrorRegistrarEdadExtra1);
                        valido = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(txtEdad, Idiomas.MensajeErrorRegistrarEdadExtra2);
                    valido = false;
                }
            }

            // Datos Empresariales
            if (CbCargo.Text == Idiomas.OpcionSeleccione || CbCargo.SelectedIndex == 0)
            {
                errorProvider1.SetError(CbCargo, Idiomas.MensajeErrorRegistrarCargo);
                valido = false;
            }

            if (CbArea.Text == Idiomas.OpcionSeleccione || CbArea.SelectedIndex == 0)
            {
                errorProvider1.SetError(CbArea, Idiomas.MensajeErrorRegistrarArea);
                valido = false;
            }

            // Datos del aplicativo
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                errorProvider1.SetError(txtContraseña, Idiomas.MensajeErrorRegistrarContraseña);
                valido = false;
            }
            else
            {
                if (txtContraseña.Text.Length < 8 || !Regex.IsMatch(txtContraseña.Text, @"[!@#$%^&*(),.?""{}|<>]"))
                {
                    errorProvider1.SetError(txtContraseña, Idiomas.MensajeErrorRegistrarContraseñaExtra1);
                    valido = false;
                }

                if (txtContraseña.Text != txtConfirmContraseña.Text)
                {
                    errorProvider1.SetError(txtConfirmContraseña, Idiomas.MensajeErrorRegistrarContraseñaExtra2);
                    valido = false;
                }
            }

            // Validar que el usuario generado no exista en la base de datos
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    long count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        errorProvider1.SetError(txtUsuario, Idiomas.MensajeErrorRegistrarNombreUsuario);
                        valido = false;
                    }
                }
            }

            return valido;
        }

        private void GenerarUsuario()
        {
            // Si alguno de los campos está vacío, limpiar el usuario
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                txtUsuario.Text = "";

            // Obtener nombre y apellidos
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellido.Text.Trim();

            // Validar que ambos campos tengan al menos 3 caracteres
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos))
                return;

            // Tomar las 3 primeras letras del nombre
            string parteNombre = nombre.Length >= 3 ? nombre.Substring(0, 3) : nombre;
            parteNombre = char.ToUpper(parteNombre[0]) + parteNombre.Substring(1).ToLower();

            // Separar apellidos por espacio
            string[] partesApellidos = apellidos.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string parteApellidos = "";
            if (partesApellidos.Length >= 2)
            {
                // Dos apellidos -> inicial de cada uno
                parteApellidos = partesApellidos[0][0].ToString().ToUpper() +
                                 partesApellidos[1][0].ToString().ToUpper();
            }
            else if (partesApellidos.Length == 1)
            {
                // Un apellido -> inicial
                parteApellidos = partesApellidos[0][0].ToString().ToUpper();
            }

            // Concatenar resultado
            txtUsuario.Text = parteNombre + parteApellidos;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VistaRegistro_Load(object sender, EventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dtCargo = ParametrosRepository.ListarParametros(con, "Cargo", UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbCargo, dtCargo, "Nombre", "Id", "SELECCIONE");

                var dtArea = ParametrosRepository.ListarParametros(con, "Area", UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbArea, dtArea, "Nombre", "Id", "SELECCIONE");

                var dtCont = ParametrosRepository.ListarParametros(con, "Contrato", UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbTipoContrato, dtCont, "Nombre", "Id", "SELECCIONE");
            }

            checkedListRol.Enabled = true;

            // Marcar "Usuario" por defecto
            for (int i = 0; i < checkedListRol.Items.Count; i++)
            {
                checkedListRol.SetItemChecked(i, false);

                // Verificar si el ítem es "Usuario"
                string item = checkedListRol.Items[i].ToString();
                if (item.StartsWith("Usuario"))
                {
                    checkedListRol.SetItemChecked(i, true);
                    break;
                }
            }

            checkedListRol.Enabled = false;
            ClassHelper.AplicarTema(this);
            ClassHelper.AplicarFormatoFecha(dtFechaIngre);
            ClassHelper.AplicarFormatoFecha(dtFechaNac);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar formulario
            if (!ValidarFormulario())
                return;

            // Guardar en base de datos
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    int rolSeleccionado = 3; // Usuario por defecto

                    // Si el checkedList está habilitado y hay un rol seleccionado, obtener su ID
                    if (checkedListRol.Enabled && checkedListRol.CheckedItems.Count == 1)
                    {
                        string item = checkedListRol.CheckedItems[0].ToString();
                        rolSeleccionado = int.Parse(item.Split('-')[0].Trim());
                    }

                    // Validar que se haya seleccionado un rol si el checkedList está habilitado
                    if (checkedListRol.Enabled && checkedListRol.CheckedItems.Count == 0)
                    {
                        MessageBox.Show(Idiomas.MensajeErrorRegistrarRol);
                        return;
                    }

                    if (checkedListRol.Enabled && checkedListRol.CheckedIndices.Count > 0)
                    {
                        switch (checkedListRol.CheckedIndices[0])
                        {
                            case 0:
                                rolCalculado = "Administrador";
                                break;
                            case 1:
                                rolCalculado = "Supervisor";
                                break;
                            case 2:
                                rolCalculado = "Usuario";
                                break;
                        }
                    }

                    //Crear objeto
                    Usuario emp = new Usuario
                    {
                        Nombres = txtNombre.Text,
                        Apellidos = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        Edad = int.Parse(txtEdad.Text),
                        FechaNacimiento = dtFechaNac.Value,
                        NombreUsuario = txtUsuario.Text,
                        Contraseña = txtContraseña.Text,
                        IdCargo = Convert.ToInt32(CbCargo.SelectedValue),
                        IdArea = Convert.ToInt32(CbArea.SelectedValue),
                        FechaIngreso = dtFechaIngre.Value,
                        IdTipoContrato = Convert.ToInt32(CbTipoContrato.SelectedValue),
                        IdRol = rolSeleccionado
                    };

                    //Guardar en BD
                    long nuevoId = UsuarioRepository.InsertarUsuario(emp, con);

                    UsuarioSesion.UsuarioId = (int)nuevoId;
                    UsuarioSesion.NombreUsuario = emp.NombreUsuario;
                    UsuarioSesion.NombrePersonal = emp.Nombres;
                    UsuarioSesion.Rol = rolCalculado;

                    // Crear perfil con configuración de correo SMTP
                    // Crear perfil por defecto
                    Perfiles nuevoPerfil = PerfilRepository.GenerarPerfilPorDefecto(emp.NombreUsuario, con);

                    // Preguntar si desea configurar correo SMTP (ANTES de las preguntas de seguridad)
                    var configSMTP = ConfigurarCorreoSMTPOpcional(emp.Correo);
                    if (configSMTP.correoSMTP != null && configSMTP.claveSMTP != null)
                    {
                        nuevoPerfil.CorreoSMTP = configSMTP.correoSMTP;
                        nuevoPerfil.ClaveSMTP = configSMTP.claveSMTP;

                        // Si el correo fue editado, actualizar también en la tabla Usuario
                        if (configSMTP.correoSMTP != emp.Correo)
                        {
                            emp.Correo = configSMTP.correoSMTP;
                            UsuarioRepository.ActualizarCorreoUsuario((int)nuevoId, configSMTP.correoSMTP);
                        }

                        MessageBox.Show("✓ Correo SMTP configurado correctamente.\n\nYa puede enviar correos automáticos desde su cuenta.",
                            "Configuración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    PerfilRepository.GuardarPerfilUsuario(nuevoPerfil, con);
                    UsuarioSesion.Configuracion = nuevoPerfil;

                    // Ahora sí, mostrar preguntas de seguridad
                    MessageBox.Show(Idiomas.MensajeExitoRegistrarGuardar,
                                    Idiomas.TituloExito,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    VistaPreguntasSeguridad seguridad = new VistaPreguntasSeguridad(nuevoId, emp.NombreUsuario);
                    seguridad.ShowDialog();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string mensajeError = string.Format(Idiomas.MensajeErrorRegistrarGuardar, ex.Message);
                MessageBox.Show(mensajeError,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            GenerarUsuario();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            GenerarUsuario();
        }

        private void Btn_VerContraseña1_Click(object sender, EventArgs e)
        {
            if (txtContraseña.UseSystemPasswordChar == true)
            {
                Btn_VerContraseña1.Text = "Off";
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                Btn_VerContraseña1.Text = "Ver";
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void Btn_VerContraseña2_Click(object sender, EventArgs e)
        {
            if (txtConfirmContraseña.UseSystemPasswordChar == true)
            {
                Btn_VerContraseña2.Text = "Off";
                txtConfirmContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                Btn_VerContraseña2.Text = "Ver";
                txtConfirmContraseña.UseSystemPasswordChar = true;
            }
        }

        private void BtnAgregarTipoContrato_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Contrato", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnAgregarCargo_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Cargo", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnAgregarArea_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Area", this);
            vistaAgregar.ShowDialog();
        }

        // Agregar este método al final de la clase VistaRegistro, antes del cierre:

        private (string correoSMTP, string claveSMTP) ConfigurarCorreoSMTPOpcional(string correoRegistrado)
        {
            // Preguntar si desea configurar
            string mensajePregunta = "CONFIGURACIÓN OPCIONAL DE CORREO\n\n" +
                "¿Desea configurar el envío automático de correos desde su propia cuenta de Gmail?\n\n" +
                "Esto le permitirá:\n" +
                "✓ Enviar correos a clientes desde SU cuenta personal\n" +
                "✓ Recibir el código de recuperación en su correo si olvida su contraseña\n\n" +
                "Si omite este paso:\n" +
                "• Los correos se enviarán desde la cuenta del sistema\n" +
                "• Los códigos de recuperación llegarán al correo del administrador\n\n" +
                "¿Configurar ahora?";

            DialogResult respuesta = MessageBox.Show(mensajePregunta, "Configuración de Correo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return (null, null);
            }

            // Variables para almacenar el resultado
            string correoFinalResultado = null;
            string claveFinalResultado = null;

            // Crear formulario de configuración
            using (Form frmSMTP = new Form
            {
                Text = "Configurar Correo SMTP",
                ClientSize = new Size(500, 380),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                Label lblInfo = new Label
                {
                    Text = "Configure su cuenta de Gmail para envío automático de correos:",
                    Location = new Point(20, 15),
                    Size = new Size(460, 25),
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold)
                };

                Label lblCorreo = new Label
                {
                    Text = "Correo de Gmail:",
                    Location = new Point(20, 55),
                    Size = new Size(460, 20)
                };

                TextBox txtCorreo = new TextBox
                {
                    Text = correoRegistrado,
                    Location = new Point(20, 80),
                    Size = new Size(380, 25),
                    Font = new Font("Segoe UI", 9f),
                    ReadOnly = true,
                    BackColor = Color.WhiteSmoke
                };

                Button btnEditarCorreo = new Button
                {
                    Text = "Editar",
                    Location = new Point(410, 78),
                    Size = new Size(70, 28),
                    Font = new Font("Segoe UI", 8f)
                };

                btnEditarCorreo.Click += (s, ev) =>
                {
                    txtCorreo.ReadOnly = false;
                    txtCorreo.BackColor = Color.White;
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                    btnEditarCorreo.Text = "✓";
                    btnEditarCorreo.BackColor = Color.LightGreen;
                };

                Label lblInstrucciones = new Label
                {
                    Text = "Para obtener la contraseña de aplicación:\n" +
                           "1. Active la verificación en 2 pasos en su cuenta de Google\n" +
                           "2. Vaya al enlace de abajo y genere una contraseña de aplicación\n" +
                           "3. Copie la contraseña de 16 caracteres que le proporciona Google",
                    Location = new Point(20, 120),
                    Size = new Size(460, 70),
                    Font = new Font("Segoe UI", 8.5f)
                };

                LinkLabel lnkGoogle = new LinkLabel
                {
                    Text = "🔗 Abrir Google App Passwords",
                    Location = new Point(20, 195),
                    Size = new Size(250, 20),
                    Font = new Font("Segoe UI", 9f)
                };
                lnkGoogle.LinkClicked += (s, ev) =>
                {
                    System.Diagnostics.Process.Start("https://myaccount.google.com/apppasswords");
                };

                Label lblClave = new Label
                {
                    Text = "Contraseña de aplicación (16 caracteres):",
                    Location = new Point(20, 230),
                    Size = new Size(460, 20)
                };

                TextBox txtClave = new TextBox
                {
                    Location = new Point(20, 255),
                    Size = new Size(460, 25),
                    Font = new Font("Consolas", 10f),
                    MaxLength = 19,
                    TextAlign = HorizontalAlignment.Center
                };

                txtClave.TextChanged += (s, ev) =>
                {
                    string texto = txtClave.Text.Replace(" ", "");
                    if (texto.Length > 16) texto = texto.Substring(0, 16);

                    string formateado = "";
                    for (int i = 0; i < texto.Length; i++)
                    {
                        if (i > 0 && i % 4 == 0) formateado += " ";
                        formateado += texto[i];
                    }

                    if (txtClave.Text != formateado)
                    {
                        int cursorPos = txtClave.SelectionStart;
                        txtClave.Text = formateado;
                        txtClave.SelectionStart = Math.Min(cursorPos + 1, formateado.Length);
                    }
                };

                Button btnGuardar = new Button
                {
                    Text = "Guardar Configuración",
                    Location = new Point(150, 300),
                    Size = new Size(150, 40),
                    Font = new Font("Segoe UI", 9f),
                    BackColor = Color.LightGreen
                };

                Button btnOmitir = new Button
                {
                    Text = "Omitir",
                    Location = new Point(310, 300),
                    Size = new Size(100, 40),
                    Font = new Font("Segoe UI", 9f),
                    DialogResult = DialogResult.Cancel
                };

                btnGuardar.Click += (s, ev) =>
                {
                    string correoFinal = txtCorreo.Text.Trim();
                    string claveFinal = txtClave.Text.Replace(" ", "").Trim();

                    if (string.IsNullOrWhiteSpace(correoFinal) || !correoFinal.Contains("@gmail.com"))
                    {
                        MessageBox.Show("Ingrese un correo de Gmail válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCorreo.Focus();
                        return;
                    }

                    if (claveFinal.Length != 16)
                    {
                        MessageBox.Show("La contraseña de aplicación debe tener 16 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClave.Focus();
                        return;
                    }

                    // Guardar en variables de nivel superior
                    correoFinalResultado = correoFinal;
                    claveFinalResultado = claveFinal;

                    // Si editó el correo, actualizar emp.Correo también
                    if (correoFinal != correoRegistrado)
                    {
                        if (MessageBox.Show(
                            $"Ha modificado el correo de:\n{correoRegistrado}\n\na:\n{correoFinal}\n\n" +
                            "Este correo se actualizará en su perfil de usuario.\n¿Continuar?",
                            "Correo Modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    frmSMTP.DialogResult = DialogResult.OK;
                };

                frmSMTP.Controls.AddRange(new Control[] {
            lblInfo, lblCorreo, txtCorreo, btnEditarCorreo,
            lblInstrucciones, lnkGoogle, lblClave, txtClave,
            btnGuardar, btnOmitir
        });

                if (frmSMTP.ShowDialog() == DialogResult.OK)
                {
                    return (correoFinalResultado, claveFinalResultado);
                }

                return (null, null);
            }
        }
    }
}

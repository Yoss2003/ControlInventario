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
                    Perfiles nuevoPerfil = PerfilRepository.GenerarPerfilPorDefecto(emp.NombreUsuario, con);

                    // Preguntar si desea configurar el envío automático de correos
                    if (MostrarInstruccionesCorreoSMTP())
                    {
                        string claveApp = SolicitarClaveAplicacionGmail();
                        if (!string.IsNullOrEmpty(claveApp))
                        {
                            nuevoPerfil.CorreoSMTP = emp.Correo; // Usar el correo que ya ingresó
                            nuevoPerfil.ClaveSMTP = claveApp;
                            MessageBox.Show("✓ Correo SMTP configurado correctamente.\n\nYa puedes enviar correos automáticos a tus clientes.",
                                "Configuración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    PerfilRepository.GuardarPerfilUsuario(nuevoPerfil, con);
                    UsuarioSesion.Configuracion = nuevoPerfil;

                    //Abrir vista de preguntas de seguridad
                    MessageBox.Show(Idiomas.MensajeExitoRegistrarGuardar,
                                    Idiomas.TituloExito,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Pasar el nuevo ID y el usuario a la vista de preguntas de seguridad
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

        private bool MostrarInstruccionesCorreoSMTP()
        {
            string mensaje = "CONFIGURACIÓN DE CORREO PARA ENVÍO AUTOMÁTICO\n\n" +
                "El correo que ingresaste se usará para:\n" +
                "• Recibir notificaciones del sistema\n" +
                "• ENVIAR correos automáticos a tus clientes (ventas a crédito, recordatorios)\n\n" +
                "Para enviar correos automáticamente desde tu Gmail, necesitas:\n" +
                "1. Activar la verificación en 2 pasos en Google\n" +
                "2. Generar una 'Contraseña de aplicación'\n\n" +
                "¿Deseas configurar el envío automático ahora?\n" +
                "(Puedes hacerlo después en Configuración > Seguridad)";

            DialogResult result = MessageBox.Show(mensaje, "Configuración de Correo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            return result == DialogResult.Yes;
        }

        private string SolicitarClaveAplicacionGmail()
        {
            using (Form frmClave = new Form
            {
                Text = "Contraseña de Aplicación de Gmail",
                ClientSize = new System.Drawing.Size(450, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                Label lblInstrucciones = new Label
                {
                    Text = "Pasos para obtener tu contraseña de aplicación:\n\n" +
                           "1. Ve a: myaccount.google.com/apppasswords\n" +
                           "2. Selecciona 'Correo' y 'Otro dispositivo'\n" +
                           "3. Escribe: Control Inventario\n" +
                           "4. Copia la contraseña de 16 dígitos\n" +
                           "5. Pégala aquí abajo:",
                    Location = new System.Drawing.Point(15, 10),
                    Size = new System.Drawing.Size(420, 120)
                };

                LinkLabel lnkAyuda = new LinkLabel
                {
                    Text = "🔗 Abrir Google App Passwords",
                    Location = new System.Drawing.Point(15, 135),
                    Size = new System.Drawing.Size(220, 20)
                };
                lnkAyuda.LinkClicked += (s, e) =>
                {
                    System.Diagnostics.Process.Start("https://myaccount.google.com/apppasswords");
                };

                Label lblClave = new Label
                {
                    Text = "Contraseña de aplicación (16 caracteres):",
                    Location = new System.Drawing.Point(15, 165),
                    Size = new System.Drawing.Size(420, 20)
                };

                TextBox txtClave = new TextBox
                {
                    Location = new System.Drawing.Point(15, 190),
                    Size = new System.Drawing.Size(420, 25),
                    Font = new System.Drawing.Font("Consolas", 10f),
                    MaxLength = 19,
                    TextAlign = HorizontalAlignment.Center,
                    Text = "xxxx xxxx xxxx xxxx",
                    ForeColor = Color.Gray
                };

                // Simular placeholder con eventos
                txtClave.Enter += (s, ev) =>
                {
                    if (txtClave.Text == "xxxx xxxx xxxx xxxx")
                    {
                        txtClave.Text = "";
                        txtClave.ForeColor = Color.Black;
                    }
                };

                txtClave.Leave += (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(txtClave.Text))
                    {
                        txtClave.Text = "xxxx xxxx xxxx xxxx";
                        txtClave.ForeColor = Color.Gray;
                    }
                };

                // Formatear automáticamente con espacios
                txtClave.TextChanged += (s, e) =>
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

                Button btnAceptar = new Button
                {
                    Text = "Guardar",
                    Location = new System.Drawing.Point(150, 240),
                    Size = new System.Drawing.Size(80, 35),
                    DialogResult = DialogResult.OK
                };

                Button btnOmitir = new Button
                {
                    Text = "Omitir",
                    Location = new System.Drawing.Point(240, 240),
                    Size = new System.Drawing.Size(80, 35),
                    DialogResult = DialogResult.Cancel
                };

                frmClave.Controls.AddRange(new Control[] { lblInstrucciones, lnkAyuda, lblClave, txtClave, btnAceptar, btnOmitir });
                frmClave.AcceptButton = btnAceptar;

                if (frmClave.ShowDialog() == DialogResult.OK)
                {
                    return txtClave.Text.Replace(" ", "");
                }
                return null;
            }
        }
    }
}

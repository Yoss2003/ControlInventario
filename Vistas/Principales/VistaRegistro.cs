using ControlInventario.Database;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Data.SQLite;
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
                errorProvider1.SetError(txtCorreo, Idiomas.MensajeErrorRegistrarCorreo);
                valido = false;
            }
            else if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]{2,}@[^@\s]+\.(com|net|org|edu|pe)$"))
            {
                errorProvider1.SetError(txtCorreo, Idiomas.MensajeErrorRegistrarCorreoExtra);
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
    }
}

using ControlInventario.Database;
using ControlInventario.Modelos;
using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaRegistro : Form
    {
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
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio");
                valido = false;
            }
            else if (txtNombre.Text.Length < 3 || Regex.IsMatch(txtNombre.Text, @"(.)\1{2,}"))
            {
                errorProvider1.SetError(txtNombre, "El nombre no puede ser demasiado corto ni tener letras repetidas sucesivas");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "El apellido es obligatorio");
                valido = false;
            }
            else if (txtApellido.Text.Length < 3 || Regex.IsMatch(txtApellido.Text, @"(.)\1{2,}"))
            {
                errorProvider1.SetError(txtApellido, "El apellido no puede ser demasiado corto ni tener letras repetidas sucesivas");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "El correo es obligatorio");
                valido = false;
            }
            else if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]{2,}@[^@\s]+\.(com|net|org|edu|pe)$"))
            {
                errorProvider1.SetError(txtCorreo, "El formato del correo no es válido");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                errorProvider1.SetError(txtEdad, "La edad es obligatoria");
                valido = false;
            }
            else
            {
                if (int.TryParse(txtEdad.Text, out int edad))
                {
                    int edadCalculada = DateTime.Now.Year - dtFechaNac.Value.Year;
                    if (dtFechaNac.Value > DateTime.Now || edadCalculada != edad)
                    {
                        errorProvider1.SetError(dtFechaNac, "La fecha de nacimiento no coincide con la edad ingresada");
                        valido = false;
                    }

                    if (edad < 18 || edad > 65)
                    {
                        errorProvider1.SetError(txtEdad, "La edad debe estar entre 18 y 65 años");
                        valido = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(txtEdad, "La edad debe ser un número válido");
                    valido = false;
                }
            }

            // Datos Empresariales
            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                errorProvider1.SetError(txtCargo, "El cargo es obligatorio");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                errorProvider1.SetError(txtArea, "El área es obligatoria");
                valido = false;
            }

            // Datos del aplicativo
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                errorProvider1.SetError(txtContraseña, "La contraseña es obligatoria");
                valido = false;
            }
            else
            {
                if (txtContraseña.Text.Length < 8 || !Regex.IsMatch(txtContraseña.Text, @"[!@#$%^&*(),.?""{}|<>]"))
                {
                    errorProvider1.SetError(txtContraseña, "La contraseña debe tener al menos 8 caracteres y un carácter especial");
                    valido = false;
                }

                if (txtContraseña.Text != txtConfirmContraseña.Text)
                {
                    errorProvider1.SetError(txtConfirmContraseña, "Las contraseñas no coinciden");
                    valido = false;
                }
            }

            // Validar que el usuario generado no exista en la base de datos
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Empleados WHERE Usuario = @Usuario";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    long count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        errorProvider1.SetError(txtUsuario, "El nombre de usuario ya está registrado");
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

            // Crear tabla si no existe
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                        CREATE TABLE IF NOT EXISTS Empleados (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombres TEXT,
                            Apellidos TEXT,
                            Correo TEXT,
                            Edad INTEGER,
                            FechaNacimiento TEXT,
                            Usuario TEXT,
                            Contraseña TEXT,
                            Cargo TEXT,
                            Area TEXT,
                            FechaIngreso TEXT,
                            TipoContrato TEXT,
                            IdRol INT,
                            Rol TEXT
                        );";

                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            checkedListRol.Enabled = false;
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
                        MessageBox.Show("Debes seleccionar un rol para el empleado.");
                        return;
                    }

                    //Crear objeto
                    Empleado emp = new Empleado
                    {
                        Nombres = txtNombre.Text,
                        Apellidos = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        Edad = int.Parse(txtEdad.Text),
                        FechaNacimiento = dtFechaNac.Value,
                        Usuario = txtUsuario.Text,
                        Contraseña = txtContraseña.Text,
                        Cargo = txtCargo.Text,
                        Area = txtArea.Text,
                        FechaIngreso = dtFechaIngre.Value,
                        TipoContrato = cbmTipoContrato.SelectedItem?.ToString(),
                        IdRol = rolSeleccionado,
                        Rol = checkedListRol.Enabled ? checkedListRol.CheckedItems[0].ToString().Split('-')[1].Trim() : "Usuario"
                    };

                    //Guardar en BD
                    long nuevoId = EmpleadoRepository.InsertarEmpleado(emp, con);

                    //Abrir vista de preguntas de seguridad
                    MessageBox.Show("Empleado registrado correctamente.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Pasar el nuevo ID y el usuario a la vista de preguntas de seguridad
                    VistaPreguntasSeguridad seguridad = new VistaPreguntasSeguridad((int)nuevoId, emp.Usuario);
                    seguridad.ShowDialog();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar empleado: " + ex.Message,
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
    }
}

using ControlInventario.Database;
using ControlInventario.Modelos;
using System;
using System.Data.SQLite;
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
            bool valido = true;
            errorProvider1.Clear();

            // Datos Personales
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "El apellido es obligatorio");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "El correo es obligatorio");
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
                if(txtContraseña.Text != txtConfirmContraseña.Text)
                {
                    errorProvider1.SetError(txtConfirmContraseña, "Las contraseñas no coinciden");
                }
            }

            return valido;
        }

        private void GenerarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                txtUsuario.Text = "";

            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellido.Text.Trim();

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
                            Rol INT
                        );";

                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Conexión verificada correctamente.", "Información", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                int rolSeleccionado = 3; // Usuario por defecto

                if (checkedListRol.Enabled && checkedListRol.CheckedItems.Count == 1)
                {
                    string item = checkedListRol.CheckedItems[0].ToString(); // "2 - Administrador"
                    rolSeleccionado = int.Parse(item.Split('-')[0].Trim());
                }

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
                    Roles = rolSeleccionado
                };

                if (checkedListRol.Enabled && checkedListRol.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un rol para el empleado.");
                    return;
                }

                // Llamar al repositorio para guardar
                EmpleadoRepository.InsertarEmpleado(emp);

                MessageBox.Show("Empleado registrado correctamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
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

using ControlInventario.Database;
using ControlInventario.Servicios;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControlInventario.Vistas
{
    public partial class VistaPreguntasSeguridad : Form
    {
        int idUsuario = UsuarioSesion.UsuarioId;
        string nombreUsuario = UsuarioSesion.NombreUsuario;

        public VistaPreguntasSeguridad()
        {
            InitializeComponent();
        }

        private bool ValidarPreguntas()
        {
            errorProvider1.Clear();
            bool valido = true;

            // Validar selección de preguntas
            if (CmbPregunta1.SelectedIndex <= 0)
            {
                errorProvider1.SetError(CmbPregunta1, "Seleccione una pregunta válida");
                valido = false;
            }
            if (CmbPregunta2.SelectedIndex <= 0)
            {
                errorProvider1.SetError(CmbPregunta2, "Seleccione una pregunta válida");
                valido = false;
            }
            if (CmbPregunta3.SelectedIndex <= 0)
            {
                errorProvider1.SetError(CmbPregunta3, "Seleccione una pregunta válida");
                valido = false;
            }

            // Validar que no se repitan preguntas
            if (CmbPregunta1.SelectedIndex == CmbPregunta2.SelectedIndex ||
                CmbPregunta1.SelectedIndex == CmbPregunta3.SelectedIndex ||
                CmbPregunta2.SelectedIndex == CmbPregunta3.SelectedIndex)
            {
                MessageBox.Show("Las preguntas seleccionadas deben ser diferentes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
            }

            // Obtener respuestas
            string r1 = TxtRespuesta1.Text.Trim();
            string r2 = TxtRespuesta2.Text.Trim();
            string r3 = TxtRespuesta3.Text.Trim();

            // Validar respuestas no vacías
            if (string.IsNullOrWhiteSpace(r1))
            {
                errorProvider1.SetError(TxtRespuesta1, "La respuesta 1 es obligatoria");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(r2))
            {
                errorProvider1.SetError(TxtRespuesta2, "La respuesta 2 es obligatoria");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(r3))
            {
                errorProvider1.SetError(TxtRespuesta3, "La respuesta 3 es obligatoria");
                valido = false;
            }

            // Validar respuestas distintas
            if (r1.Equals(r2, StringComparison.OrdinalIgnoreCase) ||
                r1.Equals(r3, StringComparison.OrdinalIgnoreCase) ||
                r2.Equals(r3, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Las respuestas deben ser diferentes entre sí.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
            }

            // Validar respuestas no triviales
            Regex trivial = new Regex(@"^(abc|123|qwerty|asdf|hola|respuesta)$", RegexOptions.IgnoreCase);
            if (trivial.IsMatch(r1) || r1.Length < 3)
            {
                errorProvider1.SetError(TxtRespuesta1, "La respuesta 1 es muy corta o inválida");
                valido = false;
            }
            if (trivial.IsMatch(r2) || r2.Length < 3)
            {
                errorProvider1.SetError(TxtRespuesta2, "La respuesta 2 es muy corta o inválida");
                valido = false;
            }
            if (trivial.IsMatch(r3) || r3.Length < 3)
            {
                errorProvider1.SetError(TxtRespuesta3, "La respuesta 3 es muy corta o inválida");
                valido = false;
            }

            return valido;
        }

        private bool ValidarUsuario()
        {
            // No se le permite al usuario cerrar la ventana sin haber completado las preguntas de seguridad
            if (string.IsNullOrWhiteSpace(CmbPregunta1.Text) || string.IsNullOrWhiteSpace(TxtRespuesta1.Text) || 
                string.IsNullOrWhiteSpace(CmbPregunta2.Text) || string.IsNullOrWhiteSpace(TxtRespuesta2.Text) || 
                string.IsNullOrWhiteSpace(CmbPregunta3.Text) || string.IsNullOrWhiteSpace(TxtRespuesta3.Text))
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de salir de la operación?", "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Si el usuario confirma que desea salir, se elimina el usuario recién creado
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("El usuario no se pudo registrar por que se canceló la operación.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                    long nuevoId = EmpleadoRepository.EliminarEmpleado(idUsuario);
                    this.Close();
                }                
            }
            return true;
        }

        private void CmbPregunta1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRespuesta1.Enabled = CmbPregunta1.SelectedIndex >= 0;
        }

        private void CmbPregunta2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRespuesta2.Enabled = CmbPregunta2.SelectedIndex >= 0;
        }

        private void CmbPregunta3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRespuesta3.Enabled = CmbPregunta3.SelectedIndex >= 0;
        }

        private void VistaPreguntasSeguridad_Load(object sender, EventArgs e)
        {
            // Agregar opciones de preguntas al ComboBox
            CmbPregunta1.Items.Insert(0, "Seleccione una pregunta..."); 
            CmbPregunta2.Items.Insert(0, "Seleccione una pregunta..."); 
            CmbPregunta3.Items.Insert(0, "Seleccione una pregunta...");

            // Agregar preguntas de seguridad al ComboBox
            lblIdusuario.Text = idUsuario.ToString();
            lblUsuario.Text = nombreUsuario;

            // Cargar preguntas de seguridad predefinidas
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    //Activar claves foraneas
                    using (var pragmacmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
                    {
                        pragmacmd.ExecuteNonQuery();
                    }

                    //crear tabla de preguntas de seguridad si no existe
                    string query = @"
                        CREATE TABLE IF NOT EXISTS PreguntasSeguridad (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Id_Usuario INT,
                            Nombre_Usuario TEXT,
                            Id_Pregunta1 INT,
                            Pregunta1 TEXT,
                            Respuesta1 TEXT,
                            Id_Pregunta2 INT,
                            Pregunta2 TEXT,
                            Respuesta2 TEXT,
                            Id_Pregunta3 INT,
                            Pregunta3 TEXT,
                            Respuesta3 TEXT,
                            FOREIGN KEY (Id_Usuario) REFERENCES Empleados(Id)
                        );";

                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que se hayan seleccionado preguntas y proporcionado respuestas antes de guardar
            if (!ValidarPreguntas())
                return;

            // Guardar preguntas de seguridad en la base de datos
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    string insertQuery = @"
                        INSERT INTO PreguntasSeguridad
                        (Id_Usuario, Nombre_Usuario, Id_Pregunta1, Pregunta1, Respuesta1, Id_Pregunta2, Pregunta2, Respuesta2, Id_Pregunta3, Pregunta3, Respuesta3)
                        VALUES
                        (@Id_Usuario, @Nombre_Usuario, @Id_Pregunta1, @Pregunta1, @Respuesta1, @Id_Pregunta2, @Pregunta2, @Respuesta2, @Id_Pregunta3, @Pregunta3, @Respuesta3);";

                    using (var cmd = new SQLiteCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@Nombre_Usuario", nombreUsuario);

                        cmd.Parameters.AddWithValue("@Id_Pregunta1", CmbPregunta1.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Pregunta1", CmbPregunta1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Respuesta1", TxtRespuesta1.Text);

                        cmd.Parameters.AddWithValue("@Id_Pregunta2", CmbPregunta2.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Pregunta2", CmbPregunta2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Respuesta2", TxtRespuesta2.Text);

                        cmd.Parameters.AddWithValue("@Id_Pregunta3", CmbPregunta3.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Pregunta3", CmbPregunta3.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Respuesta3", TxtRespuesta3.Text);
                                                
                        DialogResult result = MessageBox.Show("¿Estás seguro de que las respuestas son correctas?", "Confirmación", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);

                        // Si el usuario confirma que las respuestas son correctas, se guardan en la base de datos
                        if (result == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Preguntas de seguridad guardadas correctamente.",
                                            "Éxito",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar preguntas de seguridad: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Si ocurre un error al guardar, se elimina el usuario recién creado para evitar inconsistencias
                long nuevoId = EmpleadoRepository.EliminarEmpleado(idUsuario);
                this.Close();
            }
        }

        private void CmbPregunta1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbPregunta1.Text))
            {
                CmbPregunta1.Text = "SELECCIONE";
            }
        }

        private void CmbPregunta2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbPregunta2.Text))
            {
                CmbPregunta2.Text = "SELECCIONE";
            }
        }

        private void CmbPregunta3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbPregunta3.Text))
            {
                CmbPregunta3.Text = "SELECCIONE";
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void VistaPreguntasSeguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si no se completó el flujo de las preguntas de seguridad se elimina el usuario creado
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!ValidarUsuario())
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
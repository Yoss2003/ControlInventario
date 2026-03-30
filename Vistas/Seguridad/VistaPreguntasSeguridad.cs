using ControlInventario.Database;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ControlInventario.Vistas
{
    public partial class VistaPreguntasSeguridad : Form, IPregunta1Refrescable, IPregunta2Refrescable, IPregunta3Refrescable
    {
        private long idUsuario = UsuarioSesion.UsuarioId;
        private string nombreUsuario = UsuarioSesion.NombreUsuario;
        public ComboBox CbPregunta1Public => CbPregunta1;
        public ComboBox CbPregunta2Public => CbPregunta2;
        public ComboBox CbPregunta3Public => CbPregunta3;

        public VistaPreguntasSeguridad(long id, string nombre)
        {
            InitializeComponent();
            this.idUsuario = id;
            this.nombreUsuario = nombre;
        }

        private bool ValidarPreguntas()
        {
            errorProvider1.Clear();
            bool valido = true;

            // Validar selección de preguntas
            if (CbPregunta1.SelectedIndex <= 0)
            {
                errorProvider1.SetError(CbPregunta1, Idiomas.MensajeErrorPreguntaValida);
                valido = false;
            }
            if (CbPregunta2.SelectedIndex <= 0)
            {
                errorProvider1.SetError(CbPregunta2, Idiomas.MensajeErrorPreguntaValida);
                valido = false;
            }
            if (CbPregunta3.SelectedIndex <= 0)
            {
                errorProvider1.SetError(CbPregunta3, Idiomas.MensajeErrorPreguntaValida);
                valido = false;
            }

            // Validar que no se repitan preguntas
            if (CbPregunta1.SelectedIndex == CbPregunta2.SelectedIndex ||
                CbPregunta1.SelectedIndex == CbPregunta3.SelectedIndex ||
                CbPregunta2.SelectedIndex == CbPregunta3.SelectedIndex)
            {
                MessageBox.Show(Idiomas.MensajeErrorPreguntaRepetida, Idiomas.TituloValidacion, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                valido = false;
            }

            // Obtener respuestas
            string r1 = TxtRespuesta1.Text.Trim();
            string r2 = TxtRespuesta2.Text.Trim();
            string r3 = TxtRespuesta3.Text.Trim();

            // Validar respuestas no vacías
            if (string.IsNullOrWhiteSpace(r1))
            {
                errorProvider1.SetError(TxtRespuesta1, Idiomas.MensajeErrorPregunta1);
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(r2))
            {
                errorProvider1.SetError(TxtRespuesta2, Idiomas.MensajeErrorPregunta2);
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(r3))
            {
                errorProvider1.SetError(TxtRespuesta3, Idiomas.MensajeErrorPregunta3);
                valido = false;
            }

            // Validar respuestas distintas
            if (r1.Equals(r2, StringComparison.OrdinalIgnoreCase) ||
                r1.Equals(r3, StringComparison.OrdinalIgnoreCase) ||
                r2.Equals(r3, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(Idiomas.MensajeErrorRespuestaRepetida, Idiomas.TituloValidacion, 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
            }

            // Validar respuestas no triviales
            Regex trivial = new Regex(@"^(abc|123|qwerty|asdf|hola|respuesta)$", RegexOptions.IgnoreCase);
            if (trivial.IsMatch(r1) || r1.Length < 3)
            {
                errorProvider1.SetError(TxtRespuesta1, Idiomas.MensajeErrorRespuesta1);
                valido = false;
            }
            if (trivial.IsMatch(r2) || r2.Length < 3)
            {
                errorProvider1.SetError(TxtRespuesta2, Idiomas.MensajeErrorRespuesta2);
                valido = false;
            }
            if (trivial.IsMatch(r3) || r3.Length < 3)
            {
                errorProvider1.SetError(TxtRespuesta3, Idiomas.MensajeErrorRespuesta3);
                valido = false;
            }

            return valido;
        }

        private bool ValidarUsuario()
        {
            bool camposCompletos = !string.IsNullOrWhiteSpace(CbPregunta1.Text) && !string.IsNullOrWhiteSpace(TxtRespuesta1.Text) &&
                                   !string.IsNullOrWhiteSpace(CbPregunta2.Text) && !string.IsNullOrWhiteSpace(TxtRespuesta2.Text) &&
                                   !string.IsNullOrWhiteSpace(CbPregunta3.Text) && !string.IsNullOrWhiteSpace(TxtRespuesta3.Text);

            if (camposCompletos)
            {
                return true;
            }

            DialogResult result = MessageBox.Show(Idiomas.MnesajeAdvertenciaPreguntasSeguridad, Idiomas.TituloConfirmacion,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(Idiomas.MensajeErrorPreguntasSeguridad,
                    Idiomas.TituloAdvertencia,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                UsuarioRepository.EliminarUsuario((int)idUsuario);
                return true; 
            }

            return false;
        }

        private void CmbPregunta1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRespuesta1.Enabled = CbPregunta1.SelectedIndex >= 0;
        }

        private void CmbPregunta2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRespuesta2.Enabled = CbPregunta2.SelectedIndex >= 0;
        }

        private void CmbPregunta3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRespuesta3.Enabled = CbPregunta3.SelectedIndex >= 0;
        }

        private void VistaPreguntasSeguridad_Load(object sender, EventArgs e)
        {
            // Agregar preguntas de seguridad al ComboBox
            lblIdusuario.Text = idUsuario.ToString();
            lblUsuario.Text = nombreUsuario;

            CbPregunta1.BindingContext = new BindingContext();
            CbPregunta2.BindingContext = new BindingContext();
            CbPregunta3.BindingContext = new BindingContext();

            // Agregar opciones de preguntas al ComboBox
            CbPregunta1.Items.Insert(0, Idiomas.OpcionPreguntasSeguridad);
            CbPregunta2.Items.Insert(0, Idiomas.OpcionPreguntasSeguridad);
            CbPregunta3.Items.Insert(0, Idiomas.OpcionPreguntasSeguridad);


            // Cargar preguntas de seguridad predefinidas
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    string tipo = "Preguntas";

                    var dtPregunta1 = ParametrosRepository.ListarParametros(con, tipo, UsuarioSesion.InventarioId);
                    RefreshService.RefrescarComboDT(CbPregunta1, dtPregunta1, "Nombre", "Id", "SELECCIONE");

                    var dtPregunta2 = ParametrosRepository.ListarParametros(con, tipo, UsuarioSesion.InventarioId);
                    RefreshService.RefrescarComboDT(CbPregunta2, dtPregunta2, "Nombre", "Id", "SELECCIONE");

                    var dtPregunta3 = ParametrosRepository.ListarParametros(con, tipo, UsuarioSesion.InventarioId);
                    RefreshService.RefrescarComboDT(CbPregunta3, dtPregunta3, "Nombre", "Id", "SELECCIONE");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
            }

            ClassHelper.AplicarTema(this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarPreguntas())
                return;

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

                        cmd.Parameters.AddWithValue("@Id_Pregunta1", CbPregunta1.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Pregunta1", CbPregunta1.Text);
                        cmd.Parameters.AddWithValue("@Respuesta1", TxtRespuesta1.Text);

                        cmd.Parameters.AddWithValue("@Id_Pregunta2", CbPregunta2.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Pregunta2", CbPregunta2.Text);
                        cmd.Parameters.AddWithValue("@Respuesta2", TxtRespuesta2.Text);

                        cmd.Parameters.AddWithValue("@Id_Pregunta3", CbPregunta3.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Pregunta3", CbPregunta3.Text);
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
                            
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                string diagnostico = $"Error: {ex.Message} " +
                         $"\nValores enviados: " +
                         $"\nUser: {idUsuario}, " +
                         $"\nP1: {CbPregunta1.SelectedIndex}, " +
                         $"\nP2: {CbPregunta2.SelectedIndex}, " +
                         $"\nP3: {CbPregunta3.SelectedIndex}";

                MessageBox.Show(diagnostico, "Diagnóstico de Error");

                string mensajeError = string.Format(Idiomas.MensajeErrorPreguntasSeguridadGuardar, ex.Message);
                MessageBox.Show(mensajeError,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Si ocurre un error al guardar, se elimina el usuario recién creado para evitar inconsistencias
                long nuevoId = UsuarioRepository.EliminarUsuario((int)idUsuario);
                this.Close();
            }
        }

        private void CmbPregunta1_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbPregunta1);
        }

        private void CmbPregunta2_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbPregunta2);
        }

        private void CmbPregunta3_TextChanged(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbPregunta3);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VistaPreguntasSeguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
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
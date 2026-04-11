using ControlInventario.Database;
using ControlInventario.Servicios;
using System;
using System.Windows.Forms;
using SQLitePCL;

namespace ControlInventario
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Batteries.Init();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    DatabaseInitializer.CreateTables(con);
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // === SISTEMA DE LICENCIA ===
            LicenciaManager.RegistrarInstalacion();

            if (!LicenciaManager.TieneLicencia())
            {
                if (LicenciaManager.PruebaExpirada())
                {
                    if (!MostrarDialogoLicencia(true))
                        return;
                }
                else
                {
                    int dias = LicenciaManager.DiasRestantes();
                    MostrarAvisoPrueba(dias);
                }
            }

            Application.Run(new VistaInicioSesion());
        }

        private static void MostrarAvisoPrueba(int diasRestantes)
        {
            string machineId = LicenciaManager.ObtenerIdMaquina();
            string mensaje = $"Bienvenido a Control de Inventario\n\n" +
                $"Está utilizando una versión de prueba gratuita.\n" +
                $"Le quedan {diasRestantes} día(s) de prueba.\n\n" +
                $"ID de máquina: {machineId}\n\n" +
                $"Si tiene una licencia, ingrésela ahora.\n" +
                $"¿Desea ingresar una licencia?";

            DialogResult result = MessageBox.Show(mensaje, "Periodo de Prueba",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MostrarDialogoLicencia(false);
            }
        }

        private static bool MostrarDialogoLicencia(bool obligatorio)
        {
            string machineId = LicenciaManager.ObtenerIdMaquina();

            using (Form frmLicencia = new Form
            {
                Text = obligatorio ? "Licencia Requerida" : "Activar Licencia",
                ClientSize = new System.Drawing.Size(420, 250),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false
            })
            {
                bool activada = false;

                Label lblMensaje = new Label
                {
                    Text = obligatorio
                        ? "Su periodo de prueba ha finalizado.\nIngrese una licencia válida para continuar:"
                        : "Ingrese su licencia para activar el producto:",
                    Location = new System.Drawing.Point(20, 15),
                    Size = new System.Drawing.Size(380, 40),
                    ForeColor = obligatorio ? System.Drawing.Color.DarkRed : System.Drawing.SystemColors.ControlText
                };

                Label lblMachineId = new Label
                {
                    Text = $"ID de máquina: {machineId}",
                    Location = new System.Drawing.Point(20, 55),
                    Size = new System.Drawing.Size(380, 20),
                    Font = new System.Drawing.Font("Consolas", 9f),
                    ForeColor = System.Drawing.Color.DarkBlue
                };

                TextBox txtLicencia = new TextBox
                {
                    Location = new System.Drawing.Point(20, 85),
                    Size = new System.Drawing.Size(380, 26),
                    Font = new System.Drawing.Font("Consolas", 11f),
                    CharacterCasing = CharacterCasing.Upper,
                    TextAlign = HorizontalAlignment.Center,
                    MaxLength = 22
                };

                Label lblError = new Label
                {
                    Location = new System.Drawing.Point(20, 115),
                    Size = new System.Drawing.Size(380, 20),
                    ForeColor = System.Drawing.Color.Red,
                    Text = ""
                };

                Button btnActivar = new Button
                {
                    Text = "Activar Licencia",
                    Location = new System.Drawing.Point(70, 145),
                    Size = new System.Drawing.Size(150, 40),
                    Cursor = Cursors.Hand
                };

                Button btnCopiarId = new Button
                {
                    Text = "Copiar ID",
                    Location = new System.Drawing.Point(230, 145),
                    Size = new System.Drawing.Size(100, 40),
                    Cursor = Cursors.Hand
                };

                btnCopiarId.Click += (s, ev) =>
                {
                    Clipboard.SetText(machineId);
                    MessageBox.Show("ID de máquina copiado al portapapeles.",
                        "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                btnActivar.Click += (s, ev) =>
                {
                    if (LicenciaManager.ActivarLicencia(txtLicencia.Text))
                    {
                        MessageBox.Show("¡Licencia activada correctamente!\nGracias por su compra.",
                            "Activación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        activada = true;
                        frmLicencia.Close();
                    }
                    else
                    {
                        lblError.Text = "Licencia inválida. Verifique e intente nuevamente.";
                        txtLicencia.SelectAll();
                        txtLicencia.Focus();
                    }
                };

                txtLicencia.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter)
                    {
                        ev.SuppressKeyPress = true;
                        btnActivar.PerformClick();
                    }
                };

                frmLicencia.Controls.AddRange(new Control[] { lblMensaje, lblMachineId, txtLicencia, lblError, btnActivar, btnCopiarId });

                if (obligatorio)
                    frmLicencia.FormClosing += (s, ev) => { if (!activada) ev.Cancel = false; };

                frmLicencia.ShowDialog();
                return activada;
            }
        }
    }
}

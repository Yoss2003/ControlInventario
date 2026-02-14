using ClosedXML.Excel;
using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaRutaExportacion : Form
    {
        private bool message= false;
        private ListView listViewInventario; 
        private string categoria; 
        private string nombreArchivo;
        int UsuarioId = UsuarioSesion.UsuarioId;

        public VistaRutaExportacion(string nombreArchivo, ListView listViewActivo, string categoria)
        {
            InitializeComponent();
            this.nombreArchivo = nombreArchivo; 
            this.listViewInventario = listViewActivo; 
            this.categoria = categoria;

            LblRutaArchivo.Text = nombreArchivo;
        }

        private void ExportarACsv(ListView listView, string categoria, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Debe seleccionar una ruta válida antes de exportar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string carpeta = filePath;
            string rutaFinal = Path.Combine(carpeta, nombreArchivo);

            try
            {
                using (var writer = new StreamWriter(rutaFinal))
                {
                    // Escribir encabezados
                    var headers = listView.Columns.Cast<ColumnHeader>().Select(h => h.Text);
                    writer.WriteLine(string.Join(",", headers));

                    // Escribir filas
                    foreach (ListViewItem item in listView.Items)
                    {
                        var values = new List<string> { item.Text };
                        values.AddRange(item.SubItems.Cast<ListViewItem.ListViewSubItem>().Skip(1).Select(s => s.Text));
                        writer.WriteLine(string.Join(",", values));
                    }
                }

                this.Close();
            }
            catch
            {
                if (!filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La extensión seleccionada no es válida. Debe ser .csv", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }


        private void ExportarAExcel(ListView listView, string categoria, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Debe seleccionar una ruta válida antes de exportar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string carpeta = filePath;
            string rutaFinal = Path.Combine(carpeta, nombreArchivo);

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Datos");

                    for (int i = 0; i < listView.Columns.Count; i++)
                        worksheet.Cell(1, i + 1).Value = listView.Columns[i].Text;

                    for (int r = 0; r < listView.Items.Count; r++)
                    {
                        var item = listView.Items[r];
                        worksheet.Cell(r + 2, 1).Value = item.Text;

                        for (int c = 1; c < item.SubItems.Count; c++)
                            worksheet.Cell(r + 2, c + 1).Value = item.SubItems[c].Text;
                    }

                    workbook.SaveAs(rutaFinal);
                }

                this.Close();
            }
            catch
            {
                if (!filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La extensión seleccionada no es válida. Debe ser .xlsx", "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            string extension = (LblRutaArchivo.Text.Contains("xlsx")) ? ".xlsx" : ".csv";
            string filePath = null;

            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    var rutRepo = new RutasRepository();
                    var rutas = rutRepo.ObtenerRutas(UsuarioSesion.UsuarioId);
                    var nuevaRuta = TxtRutaPersonalizada.Enabled ? TxtRutaPersonalizada.Text : TxtRutaPredeterminada.Text;

                    if (extension == ".xlsx")
                    {
                        if (rutas != null)
                        {
                            if (ChkRutaPredeterminada.Checked)
                            {
                                rutas.rutaPredeterminada1 = TxtRutaPredeterminada.Text;
                                rutas.TipoArchivo1 = extension;
                                rutRepo.ActualizarRuta(rutas);

                                filePath = rutas.rutaPredeterminada1;

                                if (string.IsNullOrEmpty(filePath))
                                {
                                    MessageBox.Show("La ruta predeterminada no puede estar vacía.", "Información",
                                        MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(nuevaRuta) && nuevaRuta != filePath)
                                {
                                    rutas.rutaPredeterminada1 = TxtRutaPredeterminada.Text;
                                    rutas.rutaPersonalizada1 = TxtRutaPersonalizada.Text;
                                    rutas.TipoArchivo1 = extension;
                                    rutRepo.ActualizarRuta(rutas);
                                    filePath = nuevaRuta;
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(nuevaRuta))
                            {
                                MessageBox.Show("No se ha seleccionado una ruta válida para la exportación.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            var rutExport = new RutasExportar
                            {
                                usuarioId = UsuarioId,
                                rutaPredeterminada1 = TxtRutaPredeterminada.Text,
                                rutaPersonalizada1 = TxtRutaPersonalizada.Text,
                                TipoArchivo1 = extension
                            };

                            rutRepo.GuardarRuta(rutExport, con);
                            filePath = nuevaRuta;
                        }
                    }
                    else // CSV
                    {
                        if (rutas != null)
                        {
                            if (ChkRutaPredeterminada.Checked)
                            {
                                rutas.rutaPredeterminada2 = TxtRutaPredeterminada.Text;
                                rutas.TipoArchivo2 = extension;
                                rutRepo.ActualizarRuta(rutas); // <-- actualizar BD
                                filePath = rutas.rutaPredeterminada2;

                                if (string.IsNullOrEmpty(filePath))
                                {
                                    MessageBox.Show("La ruta predeterminada no puede estar vacía.", "Información",
                                        MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(nuevaRuta) && nuevaRuta != filePath)
                                {
                                    rutas.rutaPredeterminada2 = TxtRutaPredeterminada.Text;
                                    rutas.rutaPersonalizada2 = TxtRutaPersonalizada.Text;
                                    rutas.TipoArchivo2 = extension;
                                    rutRepo.ActualizarRuta(rutas);
                                    filePath = nuevaRuta;
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(nuevaRuta))
                            {
                                MessageBox.Show("No se ha seleccionado una ruta válida para la exportación.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            var rutExport = new RutasExportar
                            {
                                usuarioId = UsuarioId,
                                rutaPredeterminada2 = TxtRutaPredeterminada.Text,
                                rutaPersonalizada2 = TxtRutaPersonalizada.Text,
                                TipoArchivo2 = extension
                            };

                            rutRepo.GuardarRuta(rutExport, con);
                            filePath = nuevaRuta;
                        }
                    }
                }

                // Exportar según extensión
                if (extension == ".csv")
                    ExportarACsv(listViewInventario, categoria, filePath);
                else if (extension == ".xlsx")
                    ExportarAExcel(listViewInventario, categoria, filePath);

                MessageBox.Show($"Archivo exportado correctamente en: {filePath}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error al guardar/obtener la ruta de exportación en la base de datos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkRutaPredeterminada_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRutaPredeterminada.Checked && !message)
            {
                message = true;
                MessageBox.Show("Al activar esta opción, las exportaciones se guardarán en tu ruta predeterminada y ya no podrás elegir otra ruta.", 
                    "Información",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
            }

            TxtRutaPredeterminada.Enabled = ChkRutaPredeterminada.Checked;
            BtnBuscarRutaPred.Enabled = ChkRutaPredeterminada.Checked;
            TxtRutaPersonalizada.Enabled = !ChkRutaPredeterminada.Checked;
            BtnBuscarRutaPerso.Enabled = !ChkRutaPredeterminada.Checked;
        }

        private void VistaRutaExportacion_Load(object sender, EventArgs e)
        {
            VistaInicioSesion.CentrarElementos(LblRutaArchivo, GpRutas);

            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    string queryRutas = @"
                    CREATE TABLE IF NOT EXISTS RutasExportar (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UsuarioId INT NOT NULL,

                        RutaPredeterminada1 NVARCHAR(500),
                        RutaPersonalizada1 NVARCHAR(500),

                        RutaPredeterminada2 NVARCHAR(500),
                        RutaPersonalizada2 NVARCHAR(500),

                        TipoArchivo1 VARCHAR(20),
                        TipoArchivo2 VARCHAR(20),
                        UNIQUE (UsuarioId)
                    );";

                    using (var cmd = new SQLiteCommand(queryRutas, con)) cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las rutas de exportación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscarRutaPred_Click(object sender, EventArgs e)
        {
            BuscarRutas(TxtRutaPredeterminada);
        }

        private void BtnBuscarRutaPerso_Click(object sender, EventArgs e)
        {
            BuscarRutas(TxtRutaPredeterminada);
        }

        private void BuscarRutas(TextBox textBox)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta donde desea guardar los archivos";
                fbd.ShowNewFolderButton = true; // permite crear nuevas carpetas

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string carpetaSeleccionada = fbd.SelectedPath;

                    // Detectar qué tipo de archivo se está configurando
                    string extension = (LblRutaArchivo.Text.Contains("xlsx")) ? ".xlsx" : ".csv";

                    if (TxtRutaPredeterminada.Enabled == true)
                    {
                        Properties.Settings.Default.RutaExcel = carpetaSeleccionada;
                        TxtRutaPredeterminada.Text = Properties.Settings.Default.RutaExcel;
                    }
                    else
                    {
                        Properties.Settings.Default.RutaCsv = carpetaSeleccionada;
                        TxtRutaPersonalizada.Text = Properties.Settings.Default.RutaCsv;
                    }

                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}

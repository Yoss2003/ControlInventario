using ClosedXML.Excel;
using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public VistaRutaExportacion(string nombreArchivo, ListView listViewActivo, string categoria)
        {
            InitializeComponent();
            this.nombreArchivo = nombreArchivo; 
            this.listViewInventario = listViewActivo; 
            this.categoria = categoria;

            LblRutaArchivo.Text = nombreArchivo;
        }

        private void ExportarACsv(ListView listView, string categoria)
        {
            string filePath;

            if (!string.IsNullOrWhiteSpace(TxtRutaPersonalizada.Text))
            {
                filePath = TxtRutaPersonalizada.Text;
            }
            else if (!string.IsNullOrWhiteSpace(TxtRutaPredeterminada.Text))
            {
                filePath = TxtRutaPredeterminada.Text;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta válida antes de exportar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string rutaFinal = Path.Combine(filePath, nombreArchivo);

            using (StreamWriter writer = new StreamWriter(rutaFinal))
            {
                var headers = listView.Columns.Cast<ColumnHeader>().Select(h => h.Text);
                writer.WriteLine(string.Join(",", headers));

                foreach (ListViewItem item in listView.Items)
                {
                    var values = new List<string> { item.Text };
                    values.AddRange(item.SubItems.Cast<ListViewItem.ListViewSubItem>().Skip(1).Select(s => s.Text));
                    writer.WriteLine(string.Join(",", values));
                }
            }

            MessageBox.Show("Exportación a CSV completada.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void ExportarAExcel(ListView listView, string categoria)
        {
            string filePath;

            if (!string.IsNullOrWhiteSpace(TxtRutaPersonalizada.Text))
            {
                filePath = TxtRutaPersonalizada.Text;
            }
            else if (!string.IsNullOrWhiteSpace(TxtRutaPredeterminada.Text))
            {
                filePath = TxtRutaPredeterminada.Text;
            }
            else
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

                MessageBox.Show("Exportación a Excel completada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //string campo = TxtRutaPersonalizada.Enabled ? "ruta personalizada" : "ruta predeterminada";

            //if (string.IsNullOrWhiteSpace(TxtRutaPersonalizada.Text) || string.IsNullOrWhiteSpace(TxtRutaPredeterminada.Text))
            //{
            //    MessageBox.Show($"Por favor ingrese una {campo}.",
            //                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            string filePath = TxtRutaPersonalizada.Enabled ? TxtRutaPersonalizada.Text : TxtRutaPredeterminada.Text;
            string extension = (LblRutaArchivo.Text.Contains("xlsx")) ? ".xlsx" : ".csv";
            string carpetaDestino = extension == ".xlsx" ? Properties.Settings.Default.RutaExcel : Properties.Settings.Default.RutaCsv;

            if (extension == ".csv")
            {
                ExportarACsv(listViewInventario, categoria);
            }
            else if(extension == ".xlsx")
            {
                ExportarAExcel(listViewInventario, categoria);
            }
        }

        private void ChkRutaPredeterminada_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRutaPredeterminada.Checked && !message)
            {
                message = true;
                MessageBox.Show("Al activar esta opción, las exportaciones se guardarán en tu ruta predeterminada.", 
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

            string queryRutas = @"
            CREATE TABLE IF NOT EXISTS ConfiguracionRutas (
                UsuarioId INT NOT NULL,
                TipoArchivo VARCHAR(20) NOT NULL, -- 'Excel', 'CSV', etc.
                Ruta NVARCHAR(500) NOT NULL,
                PRIMARY KEY (UsuarioId, TipoArchivo)
            );";
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

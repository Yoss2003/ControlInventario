using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaInventario : Form
    {
        public int categoriaSeleccionadaId;
        public string categoriaSeleccionadaNombre;
        public int articuloID;
        public static bool isEdit = false;

        private ClassHelper helper;
        private int _articuloId;
        private Button botonSeleccionado = null;
        readonly int usuarioId = UsuarioSesion.UsuarioId;
        readonly string nombreUusario = UsuarioSesion.NombreUsuario;
        readonly int inventarioId = UsuarioSesion.InventarioId;

        public VistaInventario()
        {
            InitializeComponent();
            helper = new ClassHelper(this);

            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, FlCategorias, new object[] { true });
        }

        private void VistaInventario_Load(object sender, EventArgs e)
        {
            LstArticulos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LblAccionDecription.Text = "EXCEL";
            CargarArticulos();
        }

        private void BtnNuevaCategoria_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Categoria", this);
            vistaAgregar.ShowDialog();
        }

        public void RefrescarArticulos()
        {
            if (categoriaSeleccionadaId > 0)
            {
                var articulosCategoria = ArticuloRepository.ListarArticulos(categoriaSeleccionadaId);
                ClassHelper.RefrescarListView(LstArticulos, articulosCategoria);
                LstArticulos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void ActivarBotonCategoria(Button botonActivar, int idCat, string nombreCat)
        {
            LstArticulos.Visible = true;

            this.categoriaSeleccionadaId = idCat;
            this.categoriaSeleccionadaNombre = nombreCat;

            RefrescarArticulos();

            if (botonSeleccionado != null)
                botonSeleccionado.Enabled = true;

            botonActivar.Enabled = false;
            botonSeleccionado = botonActivar;
            LstArticulos.Focus();
        }

        public void CargarArticulos()
        {
            // 1. Guardar memoria de lo que estaba seleccionado
            int idSeleccionadoPreviamente = this.categoriaSeleccionadaId;
            Button botonARestaurar = null;

            var dtCategorias = CategoriaRepository.ListarCategorias(inventarioId);

            // 2. Congelamos el panel
            FlCategorias.SuspendLayout();
            FlCategorias.Controls.Clear();
            botonSeleccionado = null;

            // 3. Crear botones
            foreach (DataRow row in dtCategorias.Rows)
            {
                string nombreCategoria = row["Nombre"].ToString();
                int idCategoria = Convert.ToInt32(row["Id"]);

                Button btn = new Button
                {
                    Text = nombreCategoria,
                    Tag = idCategoria,
                    Width = 75,
                    Height = 23,
                    Cursor = Cursors.Hand
                };

                btn.Click += (s, e) =>
                {
                    ActivarBotonCategoria((Button)s, idCategoria, nombreCategoria);
                };

                FlCategorias.Controls.Add(btn);

                // Guardamos el botón si es el que estábamos viendo antes de refrescar
                if (idCategoria == idSeleccionadoPreviamente)
                {
                    botonARestaurar = btn;
                }
            }

            // 4. Descongelamos el panel
            FlCategorias.ResumeLayout();

            // 5. Restaurar la selección simulando un clic (para que no pierdas de vista los artículos)
            if (botonARestaurar != null)
            {
                botonARestaurar.PerformClick();
            }
        }

        private void NuAccionInventario_ValueChanged(object sender, EventArgs e)
        {
            switch (NuAccionInventario.Value)
            {
                case 1: LblAccionDecription.Text = "EXCEL"; break;
                case 2: LblAccionDecription.Text = "CSV"; break;
            }
        }

        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            isEdit = false;

            int categoriaId = categoriaSeleccionadaId;
            string categoria = categoriaSeleccionadaNombre;
            string texto = categoriaSeleccionadaNombre;

            int articuloId = 0;

            if (categoriaId == 0)
            {
                MessageBox.Show("Seleccione una categoría para agregar un artículo.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }                

            using (var articulos = new VistaArticulos(categoriaId, categoria, articuloId))
            {
                // Configuración inicial
                articulos.Text = "Crear Artículo " + "(" + $"{categoria}" + ")";
                articulos.TxtCodigo.Enabled = true;
                articulos.CbMarcas.Visible = true;
                articulos.GpCaracteristicas.Visible = true;

                switch (texto)
                {
                    case "Accesorios":
                        //articulos.Size = new Size(828, 510);
                        articulos.GpCaracteristicas.Visible = false;

                        // Group Informacion
                        articulos.GpInformación.Size = new Size(306, 454);
                        articulos.GpInformación.Location = new Point(494, 12);
                        articulos.TabMultipedia.Size = new Size(294, 329);

                        // Group Adquisicion
                        articulos.GpAdquisicion.Size = new Size(475, 116);
                        articulos.GpAdquisicion.Location = new Point(12, 476);

                        // Elementos de Group Adquisicion
                        articulos.LblRuc.Location = new Point(7, 16);
                        articulos.TxtRuc.Location = new Point(10, 32);
                        articulos.BtnAgregarRUC.Location = new Point(120, 29);

                        articulos.LblActivoFijo.Location = new Point(226, 16);
                        articulos.TxtActivoFijo.Location = new Point(229, 32);

                        articulos.LblPrecio.Location = new Point(361, 16);
                        articulos.TxtPrecio.Location = new Point(364, 32);

                        articulos.LblRazonSocial.Location = new Point(7, 66);
                        articulos.TxtRazonSocial.Location = new Point(10, 82);
                        articulos.TxtRazonSocial.Size = new Size(449, 20);

                        // Gp Usos
                        articulos.GpUsos.Size = new Size(476, 172);
                        articulos.TxtObservaciones.Size = new Size(318, 122);

                        // Gp Acciones
                        articulos.GpAcciones.Location = new Point(494, 476);
                        articulos.GpAcciones.Size = new Size(306, 116);

                        articulos.BtnGuardar.Location = new Point(69, 38);
                        articulos.BtnGuardarPlus.Location = new Point(190, 38);
                        articulos.BtnCancelar.Location = new Point(69, 79);
                        articulos.BtnEmpleados.Location = new Point(190, 79);


                    break;

                    default:
                        articulos.Size = new Size(828, 643);
                    break;
                }

                // Mostrar el formulario de alta
                if (articulos.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la lista activa al volver
                    RefrescarArticulos();
                }
            }
        }

        private void BtnEditarArticulo_Click(object sender, EventArgs e)
        {
            isEdit = true;
            int categoriaId = categoriaSeleccionadaId;
            string categoria = categoriaSeleccionadaNombre;

            if (categoriaId == 0)
            {
                MessageBox.Show("Seleccione una categoría para editar un artículo.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (LstArticulos == null || LstArticulos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para editar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            ListViewItem item = LstArticulos.SelectedItems[0];
            _articuloId = Convert.ToInt32(item.SubItems[0].Text);

            using (var articulos = new VistaArticulos(categoriaId, categoria, _articuloId))
            {
                var datos = new EdicionArticulo
                {
                    Id = _articuloId,
                    Marca = item.SubItems[4].Text,
                    Area1 = item.SubItems[10].Text,
                    Cargo1 = item.SubItems[11].Text,
                    Area2 = item.SubItems[14].Text,
                    Cargo2 = item.SubItems[15].Text,
                    Estado = item.SubItems[16].Text,
                    Ubicacion = item.SubItems[17].Text,
                    Condicion = item.SubItems[18].Text,
                };

                // Configuración inicial
                articulos.Text = "Editar Artículo";
                articulos.TxtCodigo.Enabled = false;
                articulos.GpCaracteristicas.Visible = true;

                switch (categoriaSeleccionadaNombre)
                {
                    case "Accesorios":
                        //articulos.Size = new Size(828, 510);
                        articulos.GpCaracteristicas.Visible = false;

                        // Group Informacion
                        articulos.GpInformación.Size = new Size(306, 454);
                        articulos.GpInformación.Location = new Point(494, 12);
                        articulos.TabMultipedia.Size = new Size(294, 329);

                        // Group Adquisicion
                        articulos.GpAdquisicion.Size = new Size(475, 116);
                        articulos.GpAdquisicion.Location = new Point(12, 476);

                        // Elementos de Group Adquisicion
                        articulos.LblRuc.Location = new Point(7, 16);
                        articulos.TxtRuc.Location = new Point(10, 32);
                        articulos.BtnAgregarRUC.Location = new Point(120, 29);

                        articulos.LblActivoFijo.Location = new Point(226, 16);
                        articulos.TxtActivoFijo.Location = new Point(229, 32);

                        articulos.LblPrecio.Location = new Point(361, 16);
                        articulos.TxtPrecio.Location = new Point(364, 32);

                        articulos.LblRazonSocial.Location = new Point(7, 66);
                        articulos.TxtRazonSocial.Location = new Point(10, 82);
                        articulos.TxtRazonSocial.Size = new Size(449, 20);

                        // Gp Usos
                        articulos.GpUsos.Size = new Size(476, 172);
                        articulos.TxtObservaciones.Size = new Size(318, 122);

                        //Gp Acciones
                        articulos.GpAcciones.Location = new Point(494, 476);
                        articulos.GpAcciones.Size = new Size(306, 116);

                        articulos.BtnGuardar.Location = new Point(69, 38);
                        articulos.BtnGuardarPlus.Location = new Point(190, 38);
                        articulos.BtnCancelar.Location = new Point(69, 79);
                        articulos.BtnEmpleados.Location = new Point(190, 79);


                    break;

                    default:
                        // Caso genérico: cualquier categoría con marcas
                        articulos.Size = new Size(828, 643);
                        break;
                }

                articulos.DatosEdicion = datos;

                // Campos básicos
                articulos.TxtCodigo.Text = item.SubItems[1]?.Text ?? string.Empty;
                articulos.TxtModelo.Text = item.SubItems[2]?.Text ?? string.Empty;
                articulos.TxtSerie.Text = item.SubItems[3]?.Text ?? string.Empty;

                // Fechas con TryParse
                if (item.SubItems.Count > 5 && DateTime.TryParse(item.SubItems[5]?.Text, out DateTime fechaAdquisicion))
                    articulos.DtpFechaAdquisicion.Value = fechaAdquisicion;

                if (item.SubItems.Count > 6 && DateTime.TryParse(item.SubItems[6]?.Text, out DateTime fechaBaja))
                {
                    articulos.DtpFechaBaja.Value = fechaBaja;
                    articulos.ChkFechaBaja.Checked = true;
                }
                else
                {
                    articulos.ChkFechaBaja.Checked = false;
                }

                if (item.SubItems.Count > 7 && DateTime.TryParse(item.SubItems[7]?.Text, out DateTime fechaFinGarantia))
                {
                    articulos.DtpFechaFinGarantia.Value = fechaFinGarantia;
                    articulos.ChkFechaGarantia.Checked = true;
                }
                else
                {
                    articulos.ChkFechaGarantia.Checked = false;
                }

                // Usuario actual
                articulos.TxtDniUsuarioActual.Text = item.SubItems[8]?.Text ?? string.Empty;
                articulos.TxtNombreUsuarioActual.Text = item.SubItems[9]?.Text ?? string.Empty;

                // Usuario anterior
                articulos.TxtDniUsuarioAnterior.Text = item.SubItems[12]?.Text ?? string.Empty;
                articulos.TxtNombreUsuarioAnterior.Text = item.SubItems[13]?.Text ?? string.Empty;

                // Datos adicionales
                articulos.TxtRuc.Text = item.SubItems[19]?.Text ?? string.Empty;
                articulos.TxtRazonSocial.Text = item.SubItems[20]?.Text ?? string.Empty;
                articulos.TxtPrecio.Text = item.SubItems[21]?.Text ?? string.Empty;
                articulos.TxtActivoFijo.Text = item.SubItems[22]?.Text ?? string.Empty;
                articulos.TxtObservaciones.Text = item.SubItems[23]?.Text ?? string.Empty;
                articulos.TxtDireccionImagen.Text = item.SubItems[24]?.Text ?? string.Empty;
                articulos.TxtRutaComprobante.Text = item.SubItems[25]?.Text ?? string.Empty;

                // Obtener el artículo completo de la BD
                var art = ArticuloRepository.ObtenerArticuloPorId(_articuloId);

                string rutaFoto = File.Exists(art.FotoPrincipal)
                                ? art.FotoPrincipal
                                : art.FotoSecundaria;

                if (!string.IsNullOrEmpty(rutaFoto) && File.Exists(rutaFoto))
                {
                    articulos.PbFotoArticulo.Image = Image.FromFile(rutaFoto);
                }

                string rutaComprobante = File.Exists(art.ComprobantePrincipal)
                                            ? art.ComprobantePrincipal
                                            : art.ComprobanteSecundaria;

                if (!string.IsNullOrEmpty(rutaComprobante) && File.Exists(rutaComprobante))
                {
                    using (var pdfDocument = PdfiumViewer.PdfDocument.Load(rutaComprobante))
                    {
                        articulos.TxtRutaComprobante.Text = rutaComprobante;

                        articulos.PdfViewerControl.Document?.Dispose();
                        articulos.PdfViewerControl.Document = PdfiumViewer.PdfDocument.Load(rutaComprobante);
                        articulos.PdfViewerControl.BringToFront();
                    }
                }

                // Mostrar el formulario de alta
                if (articulos.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la lista activa al volver
                    RefrescarArticulos();
                }
            }
        }

        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            isEdit = false;
            int categoriaId = categoriaSeleccionadaId;
            string categoria = categoriaSeleccionadaNombre;

            if(categoriaId == 0)
            {
                MessageBox.Show("Seleccione una categoría para eliminar un artículo.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (LstArticulos == null || LstArticulos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                ListViewItem item = LstArticulos.SelectedItems[0];
                _articuloId = Convert.ToInt32(item.SubItems[0].Text);

                DialogResult result = MessageBox.Show(
                    "¿Seguro que quieres eliminar este artículo?",
                    "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var con = ConexionGlobal.ObtenerConexion())
                        {
                            con.Open();
                            ArticuloRepository.EliminarArticulo(_articuloId);
                            RefrescarArticulos();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores: loguear, mostrar mensaje, etc.
                        MessageBox.Show("Ocurrió un error al eliminar el artículo: " + ex.Message);
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            int categoriaId = categoriaSeleccionadaId;
            string categoria = categoriaSeleccionadaNombre;
            string usuario = nombreUusario;

            if (categoriaId == 0)
            {
                MessageBox.Show("Seleccione una categoría para exportar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (LstArticulos.Items.Count == 0)
            {
                MessageBox.Show("No hay articulos para exportar.", "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Determinar extensión según el valor del NumericUpDown
            string extension = NuAccionInventario.Value == 1 ? "xlsx" : "csv";
            string filePath = null;

            // Generar nombre automático
            string nombreArchivo = GenerarNombreArchivo(extension, usuario, categoria);

            var rutRepo = new RutasRepository();
            var rutas = rutRepo.ObtenerRutas(usuarioId);

            // Crear UNA sola instancia de la vista
            VistaRutaExportacion vistaRuta = new VistaRutaExportacion(nombreArchivo, LstArticulos, categoria);
            if (rutas.EsPredeterminado1 == true)
            {
                if (extension == ".xlsx")
                {
                    filePath = rutas.RutaPredeterminada1;
                    vistaRuta.ExportarAExcel(LstArticulos, categoria, filePath);
                }

                MessageBox.Show($"Archivo exportado correctamente en: {filePath}", "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (rutas.EsPredeterminado2 == true)
            {
                // Exportar según extensión
                if (extension == ".csv")
                {
                    filePath = rutas.RutaPredeterminada2;
                    vistaRuta.ExportarACsv(LstArticulos, categoria, filePath);
                }

                MessageBox.Show($"Archivo exportado correctamente en: {filePath}", "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                // Asignar rutas según el inventario
                if (NuAccionInventario.Value == 1)
                {
                    vistaRuta.TxtRutaPredeterminada.Text = rutas.RutaPredeterminada1;
                    vistaRuta.TxtRutaPersonalizada.Text = rutas.RutaPersonalizada1;
                }
                else
                {
                    vistaRuta.TxtRutaPredeterminada.Text = rutas.RutaPredeterminada2;
                    vistaRuta.TxtRutaPersonalizada.Text = rutas.RutaPersonalizada2;
                }
                // Mostrar vista de exportación
                vistaRuta.ShowDialog();
            }
        }

        private string GenerarNombreArchivo(string formato, string usuario, string categoria)
        {
            // Normalizar valores (evitar espacios o caracteres raros)
            string usuarioLimpio = usuario.Replace(" ", "_");
            string categoriaLimpia = categoria.Replace(" ", "_");

            // Fecha y hora en formato ordenado
            string fecha = DateTime.Now.ToString("yyyyMMdd_HHmm");

            // Construcción del nombre
            string nombreArchivo = $"Invent_{usuarioLimpio}_{categoriaLimpia}_{fecha}.{formato}";

            return nombreArchivo;
        }
    }
}

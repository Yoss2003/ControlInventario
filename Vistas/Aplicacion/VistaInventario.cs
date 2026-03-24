using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Aplicacion;
using ControlInventario.Vistas.Extras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaInventario : Form, IMarcasRefrescable
    {
        public int categoriaSeleccionadaId;
        public string categoriaSeleccionadaNombre;
        public int articuloID;
        public static bool isEdit = false;
        public ComboBox CbMarcasPublic => CbBuscarMarcaArticulo;

        private ClassHelper helper;
        private int _articuloId;
        private Button botonSeleccionado = null;
        readonly int usuarioId = UsuarioSesion.UsuarioId;
        readonly string nombreUusario = UsuarioSesion.NombreUsuario;
        readonly int inventarioId = UsuarioSesion.InventarioId;

        private ToolStripDropDown burbujaActual = null;
        private int filaBurbujaAbierta = -1;

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
            this.Click += Fondo_Click;
            ConfigurarPerdidaDeFoco(this);

            TxtBuscarCodArticulo.Enabled = false;
            CbBuscarMarcaArticulo.Enabled = false;
            ChkUsarFechas.Enabled = false;
            DvgIngresos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            LblAccionDecription.Text = "EXCEL";
            CargarCategorias();

            ClassHelper.AplicarTema(this);
            ClassHelper.AplicarFormatoFecha(DtBuscarFechaFin);
            ClassHelper.AplicarFormatoFecha(DtBuscarFechaInicio);
            ActualizarVistaBotones();

            this.BeginInvoke(new MethodInvoker(() => {
                DvgIngresos.ClearSelection();
            }));
            CargarTabSalidas();
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
                ClassHelper.RefrescarListView(DvgIngresos, articulosCategoria);
                DvgIngresos.ClearSelection();
                DvgIngresos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            }
        }

        private void ActivarBotonCategoria(Button botonActivar, int idCat, string nombreCat)
        {
            DvgIngresos.Visible = true;

            this.categoriaSeleccionadaId = idCat;
            this.categoriaSeleccionadaNombre = nombreCat;

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dtMarcas = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, this.categoriaSeleccionadaId, UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbMarcasPublic, dtMarcas, "Nombre", "Id", "SELECCIONE");
            }

            RefrescarArticulos();

            if (botonSeleccionado != null)
                botonSeleccionado.Enabled = true;

            botonActivar.Enabled = false;
            botonSeleccionado = botonActivar;

            TxtBuscarCodArticulo.Enabled = true;
            CbBuscarMarcaArticulo.Enabled = true;
            ChkUsarFechas.Enabled = true;

            DvgIngresos.Focus();
        }

        public void CargarCategorias()
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
                articulos.ChkAutoCodigo.Enabled = true;
                articulos.TxtModelo.Enabled = true;
                articulos.ChkAutoModelo.Enabled = true;
                articulos.TxtSerie.Enabled = true;
                articulos.ChkAutoSerie.Enabled = true;
                articulos.CbMarcas.Visible = true;                

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
                MessageBox.Show("Seleccione una categoría para editar un artículo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DvgIngresos == null || DvgIngresos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow filaSeleccionada = DvgIngresos.SelectedRows[0];
            _articuloId = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

            var art = ArticuloRepository.ObtenerArticuloPorId(_articuloId);

            if (art == null)
            {
                MessageBox.Show("Error al cargar los datos del artículo desde la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var articulos = new VistaArticulos(categoriaId, categoria, _articuloId))
            {
                var datos = new EdicionArticulo
                {
                    Id = _articuloId,
                    IdMarca = art.IdMarca,
                    IdEstado = art.IdEstado,
                    IdUbicacion = art.IdUbicacion,
                    IdCondicion = art.IdCondicion,
                    IdEmpleadoActual = art.EmpleadoActualId,
                    IdEmpleadoAnterior = art.EmpleadoAnteriorId,
                    Caracteristicas = art.Caracteristicas
                };

                // Configuración inicial
                articulos.Text = "Editar Artículo";
                articulos.TxtCodigo.Enabled = false;
                articulos.ChkAutoCodigo.Enabled = false;
                articulos.TxtModelo.Enabled = false;
                articulos.ChkAutoModelo.Enabled = false;
                articulos.TxtSerie.Enabled = false;
                articulos.ChkAutoSerie.Enabled = false;
                articulos.DatosEdicion = datos;
                articulos.TxtCodigo.Text = art.Codigo ?? string.Empty;
                articulos.TxtModelo.Text = art.Modelo ?? string.Empty;
                articulos.TxtSerie.Text = art.Serie ?? string.Empty;

                // Fechas
                articulos.DtpFechaAdquisicion.Value = art.FechaAdquisicion;

                if (art.FechaFinGarantia.HasValue)
                {
                    articulos.DtpFechaFinGarantia.Value = art.FechaFinGarantia.Value;
                    articulos.ChkFechaGarantia.Checked = true;
                }
                else
                {
                    articulos.ChkFechaGarantia.Checked = false;
                }

                // Datos contables / adicionales
                articulos.TxtRuc.Text = art.RucProveedor ?? string.Empty;
                articulos.TxtRazonSocial.Text = art.Proveedor ?? string.Empty;
                articulos.TxtPrecio.Text = ClassHelper.AgregarSimboloVisual(art.PrecioAdquisicion);
                articulos.TxtObservaciones.Text = art.Observacion ?? string.Empty;

                // Carga de imágenes
                string rutaFoto = File.Exists(art.FotoPrincipal) ? art.FotoPrincipal : art.FotoSecundaria;

                if (!string.IsNullOrEmpty(rutaFoto) && File.Exists(rutaFoto))
                {
                    articulos.TxtDireccionImagen.Text = rutaFoto;
                    articulos.PbFotoArticulo.Image = Image.FromFile(rutaFoto);
                }

                // Carga de PDF
                string rutaComprobante = File.Exists(art.ComprobantePrincipal) ? art.ComprobantePrincipal : art.ComprobanteSecundaria;

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

                if (articulos.ShowDialog() == DialogResult.OK)
                {
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

            if (DvgIngresos == null || DvgIngresos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                DataGridViewRow filaSeleccionada = DvgIngresos.SelectedRows[0];
                _articuloId = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

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

            if (DvgIngresos.SelectedRows.Count == 0)
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
            VistaRutaExportacion vistaRuta = new VistaRutaExportacion(nombreArchivo, DvgIngresos, categoria);
            if (rutas.EsPredeterminado1 == true)
            {
                if (extension == ".xlsx")
                {
                    filePath = rutas.RutaPredeterminada1;
                    vistaRuta.ExportarAExcel(DvgIngresos, categoria, filePath);
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
                    vistaRuta.ExportarACsv(DvgIngresos, categoria, filePath);
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

        private void BusquedaArticulos(DataTable dt)
        {
            DvgIngresos.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string json = row["Caracteristicas"]?.ToString();
                string textoBoton = (!string.IsNullOrEmpty(json) && json != "{}") ? "Ver Detalles" : "N/A";

                int rowIndex = DvgIngresos.Rows.Add(
                    row["Id"], row["Codigo"], row["Modelo"], row["Serie"], row["Marca"],
                    row["FechaAdquisicion"], row["FechaBaja"], row["FechaFinGarantia"],
                    row["DniUsuarioActual"], row["NombreUsuarioActual"], row["AreaUsuarioActual"], row["CargoUsuarioActual"],
                    row["DniUsuarioAnterior"], row["NombreUsuarioAnterior"], row["AreaUsuarioAnterior"], row["CargoUsuarioAnterior"],
                    row["Estado"], row["Ubicacion"], row["Condicion"],
                    row["RucProveedor"], row["Proveedor"], row["PrecioAdquisicion"],
                    row["Observacion"], row["RutaFotoPrincipal"], row["RutaComprobantePrincipal"],
                    textoBoton
                );

                Articulos art = new Articulos
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Caracteristicas = json
                };
                DvgIngresos.Rows[rowIndex].Tag = art;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (this.categoriaSeleccionadaId == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría primero para buscar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(TxtBuscarCodArticulo.Text == "" || CbBuscarMarcaArticulo.SelectedIndex == 0 || ChkUsarFechas.Checked == false)
            {
                MessageBox.Show("Por favor, debe ingresar datos en los campos de búqueda.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string codigo = TxtBuscarCodArticulo.Text.Trim();

            int idMarca = 0;
            if (CbBuscarMarcaArticulo.SelectedValue != null && int.TryParse(CbBuscarMarcaArticulo.SelectedValue.ToString(), out int marcaParsed))
            {
                idMarca = marcaParsed;
            }

            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;

            if (ChkUsarFechas.Checked)
            {
                DtBuscarFechaInicio.Enabled = true;
                DtBuscarFechaFin.Enabled = true;

                fechaInicio = DtBuscarFechaInicio.Value.Date;
                fechaFin = DtBuscarFechaFin.Value.Date;

                // Validación de lógica de fechas
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.",
                                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                DtBuscarFechaInicio.Enabled = false;
                DtBuscarFechaFin.Enabled = false;
            }

            // 5. Llamamos a tu repositorio con todos los datos recolectados
            var resultados = ArticuloRepository.BuscarArticulosPorCategoria(UsuarioSesion.InventarioId, this.categoriaSeleccionadaId,codigo,idMarca,fechaInicio,fechaFin);

            // 6. Actualizar tu LstArticulos (ListView) con los resultados
            BusquedaArticulos(resultados);

            // 7. Feedback visual si no hay resultados
            if (resultados.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron artículos que coincidan con los filtros de búsqueda.",
                                "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ValidarBtnLimpiar()
        {
            bool tieneTexto = !string.IsNullOrWhiteSpace(TxtBuscarCodArticulo.Text);

            bool tieneMarca = CbBuscarMarcaArticulo.SelectedIndex > 0;

            bool tieneFecha = ChkUsarFechas.Checked;

            BtnLimpiar.Enabled = (tieneTexto || tieneMarca || tieneFecha);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtBuscarCodArticulo.Text = "";
            CbBuscarMarcaArticulo.SelectedIndex = 0;
            DtBuscarFechaInicio.Value = DateTime.Now;
            DtBuscarFechaFin.Value = DateTime.Now;
            ChkUsarFechas.Checked = false;

            TxtBuscarCodArticulo.Focus();
            CargarCategorias();
        }

        private void TxtBuscarCodArticulo_TextChanged(object sender, EventArgs e)
        {
            ValidarBtnLimpiar();
        }

        private void CbBuscarMarcaArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarBtnLimpiar();
        }

        private void ChkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUsarFechas.Checked)
            {
                DtBuscarFechaInicio.Enabled = true;
                DtBuscarFechaFin.Enabled = true;
            }
            else
            {
                DtBuscarFechaInicio.Enabled = false;
                DtBuscarFechaFin.Enabled = false;
            }

            ValidarBtnLimpiar();
        }

        private void CbBuscarMarcaArticulo_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbBuscarMarcaArticulo);
        }

        private void TbPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVistaBotones();
        }

        private void ActualizarVistaBotones()
        {
            bool esTabIngresos = TbPrincipal.SelectedIndex == 0;

            BtnAgregarArticulo.Visible = esTabIngresos;
            BtnEditarArticulo.Visible = esTabIngresos;
            BtnEliminarArticulo.Visible = esTabIngresos;
            BtnNuevaCategoria.Visible = esTabIngresos;

            BtnVenta.Visible = !esTabIngresos;
            BtnNuevaAsignacion.Visible = !esTabIngresos;
            BtnDevolucion.Visible = !esTabIngresos;
        }

        private void BtnNuevaAsignacion_Click(object sender, EventArgs e)
        {
            VistaMovimiento vistaMovimiento = new VistaMovimiento();
            vistaMovimiento.ShowDialog();
        }

        private void DvgIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DvgIngresos.Columns[e.ColumnIndex].Name == "CaracteristicasArticulo")
            {
                string valorBoton = DvgIngresos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (valorBoton != null && valorBoton.Contains("Ver Detalles"))
                {
                    if (burbujaActual != null && burbujaActual.Visible && filaBurbujaAbierta == e.RowIndex)
                    {
                        burbujaActual.Close();
                        return;
                    }

                    Articulos art = (Articulos)DvgIngresos.Rows[e.RowIndex].Tag;
                    MostrarDetallesBurbuja(art.Caracteristicas, e.ColumnIndex, e.RowIndex);
                }
            }
        }

        private void MostrarDetallesBurbuja(string jsonString, int colIndex, int rowIndex)
        {
            try
            {
                var diccionario = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
                if (diccionario == null || diccionario.Count == 0) return;

                if (burbujaActual != null && burbujaActual.Visible)
                {
                    burbujaActual.Close();
                }

                const int G_BORDE = 1;
                const int P_INTERNO = 10;
                const int H_CABECERA_GRID = 24;
                const int H_FILA_GRID = 22;
                const int A_INDICADOR = 8;

                Panel pnlBordeExterno = new Panel
                {
                    AutoSize = true,
                    BackColor = Color.Black,
                    Padding = new Padding(G_BORDE),
                    Margin = new Padding(0)
                };

                TableLayoutPanel contenedorInterno = new TableLayoutPanel
                {
                    ColumnCount = 1,
                    RowCount = 3,
                    AutoSize = true,
                    BackColor = Color.White,
                    Padding = new Padding(P_INTERNO),
                    Dock = DockStyle.Fill
                };
                pnlBordeExterno.Controls.Add(contenedorInterno);

                Label lblTitulo = new Label
                {
                    Text = "RESUMEN DE CARACTERÍSTICAS",
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 30, 30),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 0, 0, 10)
                };
                contenedorInterno.Controls.Add(lblTitulo, 0, 0);

                DataGridView dgvDetalles = new DataGridView
                {
                    AllowUserToAddRows = false,
                    ReadOnly = true,
                    Enabled = false,
                    RowHeadersVisible = false,
                    ColumnHeadersVisible = true,
                    BorderStyle = BorderStyle.None,
                    BackgroundColor = Color.White,
                    ScrollBars = ScrollBars.None,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                    AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                    //GridColor = Color.FromArgb(220, 220, 220),
                    EnableHeadersVisualStyles = false,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 2, 0, 5)
                };

                dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 7, FontStyle.Bold);
                dgvDetalles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDetalles.ColumnHeadersHeight = H_CABECERA_GRID;
                dgvDetalles.RowTemplate.Height = H_FILA_GRID;

                DataGridViewTextBoxColumn colCaract = new DataGridViewTextBoxColumn
                {
                    Name = "Caracteristica",
                    HeaderText = "PROPIEDAD",
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn
                {
                    Name = "Valor",
                    HeaderText = "VALOR",
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvDetalles.Columns.AddRange(colCaract, colValor);

                dgvDetalles.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
                dgvDetalles.DefaultCellStyle.BackColor = Color.White;
                dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.White;
                dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.FromArgb(70, 70, 70);
                dgvDetalles.DefaultCellStyle.Font = new Font("Segoe UI", 7);

                foreach (var item in diccionario)
                {
                    string valorSeguro = string.IsNullOrWhiteSpace(item.Value) ? "-" : item.Value;
                    dgvDetalles.Rows.Add(item.Key, valorSeguro);
                }

                int anchoCalculado = 0;
                foreach (DataGridViewColumn col in dgvDetalles.Columns) anchoCalculado += col.Width;
                dgvDetalles.Width = anchoCalculado + 3;

                int altoCalculado = dgvDetalles.ColumnHeadersHeight;
                foreach (DataGridViewRow row in dgvDetalles.Rows) altoCalculado += row.Height;
                dgvDetalles.Height = altoCalculado + 3;

                contenedorInterno.Controls.Add(dgvDetalles, 0, 1);

                string codigoArt = DvgIngresos.Rows[rowIndex].Cells[1].Value?.ToString();
                string modeloArt = DvgIngresos.Rows[rowIndex].Cells[2].Value?.ToString();
                string cod = string.IsNullOrWhiteSpace(codigoArt) ? "N/A" : codigoArt;
                string mod = string.IsNullOrWhiteSpace(modeloArt) ? "N/A" : modeloArt;

                Label lblInfo = new Label
                {
                    Text = $"ARTÍCULO: {cod} | MODELO: {mod.ToUpper()}",
                    Font = new Font("Verdana", 6, FontStyle.Italic),
                    ForeColor = Color.FromArgb(100, 100, 100),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                };
                contenedorInterno.Controls.Add(lblInfo, 0, 2);

                ToolStripControlHost host = new ToolStripControlHost(pnlBordeExterno);
                host.Margin = new Padding(0, A_INDICADOR, 0, 0);

                burbujaActual = new ToolStripDropDown
                {
                    Padding = Padding.Empty,
                    DropShadowEnabled = false,
                    BackColor = Color.Black
                };
                burbujaActual.Items.Add(host);

                burbujaActual.Opened += (s, e) =>
                {
                    int w = burbujaActual.Width;
                    int h = burbujaActual.Height;
                    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

                    path.AddRectangle(new Rectangle(0, A_INDICADOR, w, h - A_INDICADOR));

                    Point[] puntos = {
                        new Point(w / 2 - (A_INDICADOR + 2), A_INDICADOR + 1),
                        new Point(w / 2 + (A_INDICADOR + 2), A_INDICADOR + 1),
                        new Point(w / 2, 0)
                    };
                    path.AddPolygon(puntos);

                    
                    burbujaActual.Region = new Region(path);
                };

                Rectangle rectCelda = DvgIngresos.GetCellDisplayRectangle(colIndex, rowIndex, false);
                filaBurbujaAbierta = rowIndex;

                Point ubicacion = new Point(
                    rectCelda.Left + (rectCelda.Width / 2) - (pnlBordeExterno.PreferredSize.Width / 2),
                    rectCelda.Bottom + 2
                );

                burbujaActual.Show(DvgIngresos, ubicacion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void Fondo_Click(object sender, EventArgs e)
        {
            DvgIngresos.ClearSelection();

            this.ActiveControl = null;
        }

        private void ConfigurarPerdidaDeFoco(Control contenedorPadre)
        {
            foreach (Control c in contenedorPadre.Controls)
            {
                if (c is Panel || c is GroupBox || c is Label || c is PictureBox || c is FlowLayoutPanel)
                {
                    c.Click += Fondo_Click;
                    ConfigurarPerdidaDeFoco(c);
                }
            }
        }

        private void CargarTabSalidas()
        {
            // 1. Creamos una tabla virtual en memoria
            DataTable dtAsignados = new DataTable();
            dtAsignados.Columns.Add("Id", typeof(int));
            dtAsignados.Columns.Add("Codigo", typeof(string));
            dtAsignados.Columns.Add("Modelo", typeof(string));
            dtAsignados.Columns.Add("Responsable", typeof(string));
            dtAsignados.Columns.Add("Area", typeof(string));
            dtAsignados.Columns.Add("Estado", typeof(string));
            dtAsignados.Columns.Add("Foto", typeof(Image));

            // 2. Traemos los datos de la BD
            DataTable tablaBD = ArticuloRepository.ListarArticulosAsignados(UsuarioSesion.InventarioId);

            // 3. Recorremos para convertir las rutas de texto en Imágenes reales
            foreach (DataRow row in tablaBD.Rows)
            {
                int idArt = Convert.ToInt32(row["Id"]);
                string codigo = row["Codigo"].ToString();
                string modelo = row["Modelo"].ToString();
                string responsable = row["EmpleadoActualTexto"].ToString();
                string area = row["EmpleadoActualAreaTexto"].ToString();
                string estado = row["EstadoTexto"].ToString();

                string rutaFoto = row["RutaFotoPrincipal"].ToString();
                if (!File.Exists(rutaFoto)) rutaFoto = row["RutaFotoSecundaria"].ToString();

                Image fotoVisual = (File.Exists(rutaFoto)) ? Image.FromFile(rutaFoto) : null;

                dtAsignados.Rows.Add(idArt, codigo, modelo, responsable, area, estado, fotoVisual);
            }

            // 4. Asignamos la tabla a tu DataGridView de Salidas
            DgvSalidas.DataSource = dtAsignados;

            // (Opcional) Llamar a tu método de estilos si quieres que se vea igual de moderno
            // AplicarEstilosGrillas(DgvSalidas); 
        }
    }
}

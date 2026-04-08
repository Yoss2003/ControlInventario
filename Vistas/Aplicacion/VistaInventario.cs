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
        public ComboBox CbMarcasPublic => CbBuscarMarcaArticuloIngreso;

        private ClassHelper helper;
        private int _articuloId;
        private Button botonSeleccionado = null;
        readonly int usuarioId = UsuarioSesion.UsuarioId;
        readonly string nombreUusario = UsuarioSesion.NombreUsuario;
        readonly int inventarioId = UsuarioSesion.InventarioId;

        private ToolStripDropDown burbujaActual = null;
        private int filaBurbujaAbierta = -1;
        private DataTable dtSalidasOriginal;
        private int accionSalidaSeleccionada = 0;
        public EdicionArticulo DatosEdicion { get; set; }
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

            TxtBuscarCodArticuloIngreso.Enabled = false;
            CbBuscarMarcaArticuloIngreso.Enabled = false;
            ChkUsarFechasIngreso.Enabled = false;

            DataTable dtVaciaIngresos = new DataTable();
            RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloIngreso, dtVaciaIngresos, "Nombre", "Id", "SELECCIONE");

            DataTable dtVaciaSalidas = new DataTable();
            RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloSalida, dtVaciaSalidas, "Nombre", "Id", "SELECCIONE");

            DgvArticulos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            LblAccionDecription.Text = "EXCEL";
            CargarCategorias();
            CargarMenuSalidas();

            ClassHelper.AplicarTema(this);
            ClassHelper.AplicarFormatoFecha(DtBuscarFechaFinIngreso);
            ClassHelper.AplicarFormatoFecha(DtBuscarFechaInicioIngreso);
            ActualizarVistaBotones();

            this.BeginInvoke(new MethodInvoker(() => {
                DgvArticulos.ClearSelection();
            }));
            CargarTabSalidas();
            ClassHelper.AplicarEstilosGrillas(DgvArticulos);
            ClassHelper.AplicarEstilosGrillas(DvgSalidas);
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
                ClassHelper.RefrescarDvgIngresos(DgvArticulos, articulosCategoria);
                DgvArticulos.ClearSelection();
                DgvArticulos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);

                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    var dtMarcasIngresos = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, this.categoriaSeleccionadaId, UsuarioSesion.InventarioId, true);
                    RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloIngreso, dtMarcasIngresos, "Nombre", "Id", "SELECCIONE");
                }
            }
        }

        private void ActivarBotonCategoria(Button botonActivar, int idCat, string nombreCat)
        {
            DgvArticulos.Visible = true;
            ChkUsarFechasIngreso.Enabled = true;
            TxtBuscarCodArticuloIngreso.Enabled = true;

            this.categoriaSeleccionadaId = idCat;
            this.categoriaSeleccionadaNombre = nombreCat;

            RefrescarArticulos();

            if (botonSeleccionado != null)
                botonSeleccionado.Enabled = true;

            botonActivar.Enabled = false;
            botonSeleccionado = botonActivar;

            TxtBuscarCodArticuloIngreso.Enabled = true;
            CbBuscarMarcaArticuloIngreso.Enabled = true;
            ChkUsarFechasIngreso.Enabled = true;

            DgvArticulos.Focus();
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
                    Height = 35,
                    Width = FlCategorias.ClientSize.Width - 6,
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatStyle = FlatStyle.Standard
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

            if (DgvArticulos == null || DgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow filaSeleccionada = DgvArticulos.SelectedRows[0];
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

            if (DgvArticulos == null || DgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                DataGridViewRow filaSeleccionada = DgvArticulos.SelectedRows[0];
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

            if (DgvArticulos.SelectedRows.Count == 0)
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
            VistaRutaExportacion vistaRuta = new VistaRutaExportacion(nombreArchivo, DgvArticulos, categoria);
            if (rutas.EsPredeterminado1 == true)
            {
                if (extension == ".xlsx")
                {
                    filePath = rutas.RutaPredeterminada1;
                    vistaRuta.ExportarAExcel(DgvArticulos, categoria, filePath);
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
                    vistaRuta.ExportarACsv(DgvArticulos, categoria, filePath);
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
            DgvArticulos.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string json = row["Caracteristicas"]?.ToString();
                string textoBoton = (!string.IsNullOrEmpty(json) && json != "{}") ? "Ver Detalles" : "N/A";

                int rowIndex = DgvArticulos.Rows.Add(
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
                DgvArticulos.Rows[rowIndex].Tag = art;
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

            if(TxtBuscarCodArticuloIngreso.Text == "" || CbBuscarMarcaArticuloIngreso.SelectedIndex == 0 || ChkUsarFechasIngreso.Checked == false)
            {
                MessageBox.Show("Por favor, debe ingresar datos en los campos de búqueda.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string codigo = TxtBuscarCodArticuloIngreso.Text.Trim();

            int idMarca = 0;
            if (CbBuscarMarcaArticuloIngreso.SelectedValue != null && int.TryParse(CbBuscarMarcaArticuloIngreso.SelectedValue.ToString(), out int marcaParsed))
            {
                idMarca = marcaParsed;
            }

            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;

            if (ChkUsarFechasIngreso.Checked)
            {
                DtBuscarFechaInicioIngreso.Enabled = true;
                DtBuscarFechaFinIngreso.Enabled = true;

                fechaInicio = DtBuscarFechaInicioIngreso.Value.Date;
                fechaFin = DtBuscarFechaFinIngreso.Value.Date;

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
                DtBuscarFechaInicioIngreso.Enabled = false;
                DtBuscarFechaFinIngreso.Enabled = false;
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
            bool tieneTexto = !string.IsNullOrWhiteSpace(TxtBuscarCodArticuloIngreso.Text);

            bool tieneMarca = CbBuscarMarcaArticuloIngreso.SelectedIndex > 0;

            bool tieneFecha = ChkUsarFechasIngreso.Checked;

            BtnLimpiarIngreso.Enabled = (tieneTexto || tieneMarca || tieneFecha);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtBuscarCodArticuloIngreso.Text = "";
            CbBuscarMarcaArticuloIngreso.SelectedIndex = 0;
            DtBuscarFechaInicioIngreso.Value = DateTime.Now;
            DtBuscarFechaFinIngreso.Value = DateTime.Now;
            ChkUsarFechasIngreso.Checked = false;

            TxtBuscarCodArticuloIngreso.Focus();
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
            if (ChkUsarFechasIngreso.Checked)
            {
                DtBuscarFechaInicioIngreso.Enabled = true;
                DtBuscarFechaFinIngreso.Enabled = true;
            }
            else
            {
                DtBuscarFechaInicioIngreso.Enabled = false;
                DtBuscarFechaFinIngreso.Enabled = false;
            }

            ValidarBtnLimpiar();
        }

        private void CbBuscarMarcaArticulo_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbBuscarMarcaArticuloIngreso);
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
            VistaAsignacion vistaAsignacion = new VistaAsignacion();

            if (vistaAsignacion.ShowDialog() == DialogResult.OK)
            {
                if (categoriaSeleccionadaId > 0)
                {
                    var articulosCategoria = ArticuloRepository.ListarArticulos(categoriaSeleccionadaId);
                    ClassHelper.RefrescarDvgIngresos(DgvArticulos, articulosCategoria);
                }

                dtSalidasOriginal = ArticuloRepository.ListarArticulosAsignados(UsuarioSesion.InventarioId);
                DataView vistaFiltrada = dtSalidasOriginal.DefaultView;

                if (accionSalidaSeleccionada > 0)
                    vistaFiltrada.RowFilter = $"IdAccion = {accionSalidaSeleccionada}";

                ClassHelper.RefrescarDvgSalidas(DvgSalidas, vistaFiltrada.ToTable());

                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    var dtMarcasIngresos = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, this.categoriaSeleccionadaId, UsuarioSesion.InventarioId, true);
                    RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloIngreso, dtMarcasIngresos, "Nombre", "Id", "SELECCIONE");

                    var dtMarcasSalidas = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, 0, UsuarioSesion.InventarioId, false, accionSalidaSeleccionada);
                    RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloSalida, dtMarcasSalidas, "Nombre", "Id", "SELECCIONE");
                }
            }
        }

        private void DvgIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvArticulos.Columns[e.ColumnIndex].Name == "CaracteristicasArticulo")
            {
                string valorBoton = DgvArticulos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (valorBoton != null && valorBoton.Contains("Ver Detalles"))
                {
                    if (burbujaActual != null && burbujaActual.Visible && filaBurbujaAbierta == e.RowIndex)
                    {
                        burbujaActual.Close();
                        return;
                    }

                    Articulos art = (Articulos)DgvArticulos.Rows[e.RowIndex].Tag;
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

                string codigoArt = DgvArticulos.Rows[rowIndex].Cells[1].Value?.ToString();
                string modeloArt = DgvArticulos.Rows[rowIndex].Cells[2].Value?.ToString();
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

                Rectangle rectCelda = DgvArticulos.GetCellDisplayRectangle(colIndex, rowIndex, false);
                filaBurbujaAbierta = rowIndex;

                Point ubicacion = new Point(
                    rectCelda.Left + (rectCelda.Width / 2) - (pnlBordeExterno.PreferredSize.Width / 2),
                    rectCelda.Bottom + 2
                );

                burbujaActual.Show(DgvArticulos, ubicacion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void Fondo_Click(object sender, EventArgs e)
        {
            DgvArticulos.ClearSelection();

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
            dtSalidasOriginal = ArticuloRepository.ListarArticulosAsignados(UsuarioSesion.InventarioId);
            ClassHelper.RefrescarDvgSalidas(DvgSalidas, dtSalidasOriginal);

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dtMarcasSalidas = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, 0, UsuarioSesion.InventarioId, false, 0);
                RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloSalida, dtMarcasSalidas, "Nombre", "Id", "SELECCIONE");
            }
        }
        private void CargarMenuSalidas()
        {
            FlAcciones.Controls.Clear();

            string[] opciones = { "Todo", "Asignaciones", "Ventas", "Bajas" };
            int[] acciones = { 0, 2, 4, 5 };
            int altoTotal = 0;

            for (int i = 0; i < opciones.Length; i++)
            {
                Button btn = new Button
                {
                    Text = opciones[i],
                    Tag = acciones[i],
                    Height = 40,
                    Width = FlAcciones.Width - 6,
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatStyle = FlatStyle.Standard,
                    Margin = new Padding(3) 
                };

                btn.Click += BtnFiltroSalida_Click;
                FlAcciones.Controls.Add(btn);
                altoTotal += btn.Height + 6;
            }
            FlAcciones.Height = altoTotal;
            FlAcciones.BorderStyle = BorderStyle.None;
        }

        private void BtnFiltroSalida_Click(object sender, EventArgs e)
        {
            DvgSalidas.Visible = true;
            CbBuscarMarcaArticuloSalida.Enabled = true;
            ChkUsarFechasSalida.Enabled = true;
            TxtBuscarCodArticuloSalida.Enabled = true;
            Button btn = sender as Button;
            int idAccion = (int)btn.Tag;

            accionSalidaSeleccionada = idAccion;

            if (dtSalidasOriginal != null)
            {
                DataView vistaFiltrada = dtSalidasOriginal.DefaultView;

                if (idAccion == 0)
                    vistaFiltrada.RowFilter = "";
                else
                    vistaFiltrada.RowFilter = $"IdAccion = {idAccion}"; 

                ClassHelper.RefrescarDvgSalidas(DvgSalidas, vistaFiltrada.ToTable());
                DvgSalidas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                DvgSalidas.Columns["ResponsableArticuloSalida"].Visible = false;
                DvgSalidas.Columns["AreaArticuloSalida"].Visible = false;
                DvgSalidas.Columns["CargoArticuloSalida"].Visible = false;

                DvgSalidas.Columns["ClienteArticuloSalida"].Visible = false;
                DvgSalidas.Columns["PrecioVentaSalida"].Visible = false;

                DvgSalidas.Columns["MotivoBajaSalida"].Visible = false;

                switch (idAccion)
                {
                    case 2:
                        DvgSalidas.Columns["ResponsableArticuloSalida"].Visible = true;
                        DvgSalidas.Columns["AreaArticuloSalida"].Visible = true;
                        DvgSalidas.Columns["CargoArticuloSalida"].Visible = true;
                        break;

                    case 4:
                        DvgSalidas.Columns["ClienteArticuloSalida"].Visible = true;
                        DvgSalidas.Columns["PrecioVentaSalida"].Visible = true;
                        break;

                    case 5:
                        DvgSalidas.Columns["MotivoBajaSalida"].Visible = true;
                        break;

                    case 0:
                        DvgSalidas.Columns["ResponsableArticuloSalida"].Visible = true;
                        DvgSalidas.Columns["ClienteArticuloSalida"].Visible = true;
                        DvgSalidas.Columns["MotivoBajaSalida"].Visible = true;
                        break;
                }
                DvgSalidas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dtMarcasSalidas = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, 0, UsuarioSesion.InventarioId, false, accionSalidaSeleccionada);
                RefreshService.RefrescarComboDT(CbBuscarMarcaArticuloSalida, dtMarcasSalidas, "Nombre", "Id", "SELECCIONE");
            }
        }

        private void DvgIngresos_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = DgvArticulos.SelectedRows.Count > 0;

            BtnEditarArticulo.Enabled = haySeleccion;
            BtnEliminarArticulo.Enabled = haySeleccion;
        }

        private void DvgSalidas_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = DvgSalidas.SelectedRows.Count > 0;
            if (haySeleccion && (accionSalidaSeleccionada == 2 || accionSalidaSeleccionada == 0))
            {
                BtnDevolucion.Enabled = true;
            }
            else
            {
                BtnDevolucion.Enabled = false;
            }
        }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            VistaVentas vistaVentas = new VistaVentas();
            vistaVentas.ShowDialog();
        }

        private void DvgIngresos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvArticulos.Columns[e.ColumnIndex].Name == "PrecioAdquisicion")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal valorSolesBD))
                {
                    decimal? valorLocal = ClassHelper.ConvertirBDAMonedaLocal(valorSolesBD, DatosEdicion.MonedaAdquisicion);

                    string simbolo = UsuarioSesion.Configuracion?.Moneda.Split('-')[0].Trim() ?? "S/";
                    if (simbolo == "PEN") simbolo = "S/";
                    if (simbolo == "EUR") simbolo = "€";
                    if (simbolo == "USD") simbolo = "$";

                    e.Value = $"{simbolo} {valorLocal:N2}";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}

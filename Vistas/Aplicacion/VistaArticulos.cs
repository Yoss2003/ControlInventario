using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;

namespace ControlInventario.Vistas
{
    public partial class VistaArticulos : Form, IMarcasRefrescable, IEstadoArticulosRefrescable, ICondicionRefrescable, IUbicacionRefrescable
    {
        private PdfViewer pdfViewer;
        private readonly int _categoriaId;
        private readonly string _categoria;
        private readonly int _articuloId;
        private string dniTemporal;
        private int? idEmpleadoActualTemporal = null;
        private int? idEmpleadoAnteriorTemporal = null;
        public ComboBox CbMarcasPublic => CbMarcas;
        public ComboBox CbEstadoArticulosPublic => CbEstadoArticulo;
        public ComboBox CbCondicionPublic => CbCondicion;
        public ComboBox CbUbicacionPublic => CbUbicacion;
        public PdfViewer PdfViewerControl => pdfViewer;
        public EdicionArticulo DatosEdicion { get; set; }
        private bool generarCodigoAutomatico = false;
        private string nombreCategoriaActual = "";
        private string serieAutomaticaGenerada = "";
        private string modeloAutomaticoGenerado = "";
        private string ultimoModeloGuardado = "";
        private int ultimaCategoriaIdGuardada = 0;
        private bool rechazoSugerenciaModelo = false;

        private Dictionary<string, string> caracteristicasTemporales = new Dictionary<string, string>();

        private ToolTip toolTipCaracteristicas = new ToolTip();

        public VistaArticulos(int categoriaId, string categoria, int articuloId)
        {
            InitializeComponent();
            _categoriaId = categoriaId;
            _categoria = categoria;
            _articuloId = articuloId;

            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.ShowToolbar = true;
            pdfViewer.ShowBookmarks = true;

            PanelComprobante.Controls.Add(pdfViewer);
            nombreCategoriaActual = categoria;
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text))
            {
                ErrorArticulos.SetError(TxtCodigo, Idiomas.MensajeErrorAgregarCodigoArticulo);
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(TxtModelo.Text))
            {
                ErrorArticulos.SetError(TxtModelo, Idiomas.MensajeErrorAgregarModeloArticulo);
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(TxtSerie.Text))
            {
                ErrorArticulos.SetError(TxtSerie, Idiomas.MensajeErrorAgregarSerieArticulo);
                valido = false; 
            }

            if (CbMarcas.Text == Idiomas.OpcionSeleccione || CbMarcas.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbMarcas, Idiomas.MensajeErrorAgregarMarcaArticulo);
                valido = false; 
            }

            if (ChkFechaGarantia.Checked) 
            {
                if (DtpFechaFinGarantia.Value < DtpFechaAdquisicion.Value)
                {
                    ErrorArticulos.SetError(DtpFechaFinGarantia, Idiomas.MensajeErrorAgregarFechaGarantiaArticulo);
                    valido = false; 
                }
            }

            if (CbEstadoArticulo.Text == Idiomas.OpcionSeleccione || CbEstadoArticulo.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbEstadoArticulo, Idiomas.MensajeErrorAgregarEstadoArticulo);
                valido = false; 
            }

            if (CbUbicacion.Text == Idiomas.OpcionSeleccione || CbUbicacion.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbUbicacion, Idiomas.MensajeErrorAgregarUbicacionArticulo);
                valido = false; 
            }

            if (CbCondicion.Text == Idiomas.OpcionSeleccione || CbCondicion.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbCondicion, Idiomas.MensajeErrorAgregarCondicionArticulo);
                valido = false; 
            }

            if (string.IsNullOrWhiteSpace(TxtDireccionImagen.Text))
            {
                ErrorArticulos.SetError(TxtDireccionImagen, Idiomas.MensajeErrorAgregarFotoArticulo);
                valido = false; 
            }

            return valido;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (VistaCaracteristicas vista = new VistaCaracteristicas(caracteristicasTemporales))
            {
                if (vista.ShowDialog() == DialogResult.OK)
                {
                    caracteristicasTemporales = vista.CaracteristicasGuardadas;

                    ActualizarBotonCaracteristicas();
                }
            }
        }        

        private void RecolectarControles(Control parent, List<Control> lista)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    lista.Add(c);

                if (c.HasChildren)
                    RecolectarControles(c, lista);
            }
        }

        private string ObtenerNombreBase(Control ctrl)
        {
            if (string.IsNullOrEmpty(ctrl?.Name)) return string.Empty;
            string n = ctrl.Name.ToLowerInvariant();
            n = n.Replace("txt", "").Replace("cb", "");
            return n;
        }

        private Label BuscarLabelRecursivo(Control root, string nombreBase)
        {
            if (string.IsNullOrEmpty(nombreBase)) return null;

            foreach (Control c in root.Controls)
            {
                if (c is Label lbl && !string.IsNullOrEmpty(lbl.Name))
                {
                    if (lbl.Name.IndexOf(nombreBase, StringComparison.OrdinalIgnoreCase) >= 0)
                        return lbl;
                }
            }

            foreach (Control c in root.Controls)
            {
                if (c.HasChildren)
                {
                    var encontrado = BuscarLabelRecursivo(c, nombreBase);
                    if (encontrado != null) return encontrado;
                }
            }

            return null;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            TxtCodigo.Text = "";
            TxtModelo.Text = "";
            TxtSerie.Text = "";
            CbMarcas.SelectedIndex = 0;
            DtpFechaAdquisicion.Value = DateTime.Now;
            DtpFechaFinGarantia.Value = DateTime.Now;

            TxtDniUsuarioActual.Text = "";
            TxtNombreUsuarioActual.Text = "";
            TxtAreaUsuarioActual.Text = "";
            TxtCargoUsuarioActual.Text = "";

            TxtDniUsuarioAnterior.Text = "";
            TxtNombreUsuarioAnterior.Text = "";
            TxtAreaUsuarioAnterior.Text = "";
            TxtCargoUsuarioAnterior.Text = "";

            CbEstadoArticulo.SelectedIndex = -1;
            CbUbicacion.SelectedIndex = -1;
            CbCondicion.SelectedIndex = -1;
            TxtObservaciones.Text = "";

            TxtRuc.Text = "";
            TxtRazonSocial.Text = "";
            TxtPrecio.Text = "";

            TxtRutaComprobante.Text = "";
            TxtDireccionImagen.Text = "";

            PbFotoArticulo.Image = null;
            PanelComprobante.Controls.Clear();

            serieAutomaticaGenerada = "";

            if (ChkAutoSerie != null && ChkAutoSerie.Checked) ActualizarSerie();

            ultimoModeloGuardado = TxtModelo.Text.Trim();
            ultimaCategoriaIdGuardada = _categoriaId;
            modeloAutomaticoGenerado = "";
            rechazoSugerenciaModelo = false;

            if (ChkAutoModelo != null && ChkAutoModelo.Checked)
            {
                if (_categoriaId == ultimaCategoriaIdGuardada && !string.IsNullOrEmpty(ultimoModeloGuardado))
                {
                    var result = MessageBox.Show($"Se encontró un modelo previo: [{ultimoModeloGuardado}].\n\n¿Desea reutilizarlo para este nuevo artículo?",
                        "Reutilizar Modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        modeloAutomaticoGenerado = ultimoModeloGuardado; // Mantiene el de memoria
                    }
                }
                ActualizarModelo();
            }
        }

        private void ActualizarBotonCaracteristicas()
        {
            if (caracteristicasTemporales == null || caracteristicasTemporales.Count == 0)
            {
                btnAgregar.BackColor = Color.White;
                toolTipCaracteristicas.SetToolTip(btnAgregar, "Haz clic para agregar especificaciones técnicas.");
            }
            else
            {
                btnAgregar.Text = $"Extras: ({caracteristicasTemporales.Count})";
                btnAgregar.BackColor = Color.LightGreen;

                // Construimos el "Mini-Recibo" para el cartelito flotante
                System.Text.StringBuilder textoTooltip = new System.Text.StringBuilder();
                textoTooltip.AppendLine("Características registradas:");
                textoTooltip.AppendLine("--------------------------");

                int contador = 1;
                foreach (var item in caracteristicasTemporales)
                {
                    textoTooltip.AppendLine($"{contador}. {item.Key}: {item.Value}");
                    contador++;
                }

                // Le asignamos el texto flotante al botón
                toolTipCaracteristicas.SetToolTip(btnAgregar, textoTooltip.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                string codigoFinal = TxtCodigo.Text.Trim();
                string carpetaComprobantes = ConexionGlobal.ObtenerCarpetaComprobantes();
                string carpetaImagenes = ConexionGlobal.ObtenerCarpetaImagenes();

                string precioTexto = TxtPrecio.Text.Trim();
                decimal? precioFinal = ClassHelper.ConvertirTextoAMoneda(precioTexto);

                // Mapear Codigo automatico
                if (generarCodigoAutomatico)
                {
                    string prefijo = nombreCategoriaActual.Length >= 3 ?
                                     nombreCategoriaActual.Substring(0, 3).ToUpper() :
                                     nombreCategoriaActual.ToUpper();

                    codigoFinal = ArticuloRepository.GenerarCodigoArticulo(prefijo, UsuarioSesion.InventarioId);
                }

                string jsonCaracteristicas = null;
                if (caracteristicasTemporales != null && caracteristicasTemporales.Count > 0)
                {
                    jsonCaracteristicas = JsonSerializer.Serialize(caracteristicasTemporales);
                }

                // Actualizar o Guardar articuloa
                if (VistaInventario.isEdit == false)
                {
                    try
                    {
                        using (var con = ConexionGlobal.ObtenerConexion())
                        {
                            con.Open();
                            Articulos art = new Articulos
                            {
                                InventarioId = UsuarioSesion.InventarioId,
                                Codigo = codigoFinal,
                                Modelo = TxtModelo.Text,
                                Serie = TxtSerie.Text,
                                IdMarca = Convert.ToInt32(CbMarcas.SelectedValue),
                                Marca = ClassHelper.NormalizarCombo(CbMarcas),
                                FechaAdquisicion = DtpFechaAdquisicion.Value,
                                FechaFinGarantia = ChkFechaGarantia.Checked ? DtpFechaFinGarantia.Value.Date : (DateTime?)null,

                                EmpleadoActualId = idEmpleadoActualTemporal,
                                EmpleadoAnteriorId = idEmpleadoAnteriorTemporal,

                                IdEstado = Convert.ToInt32(CbEstadoArticulo.SelectedValue),
                                Estado = string.IsNullOrWhiteSpace(CbEstadoArticulo.Text) ? null : CbEstadoArticulo.Text,
                                IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                                Ubicacion = ClassHelper.NormalizarCombo(CbUbicacion),
                                IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),
                                Condicion = ClassHelper.NormalizarCombo(CbCondicion),
                                Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                                RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                                Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                                PrecioAdquisicion = precioFinal,
                                Caracteristicas = jsonCaracteristicas,

                                FechaRegistro = DateTime.Now,

                                CategoriaId = _categoriaId,
                                Categoria = _categoria
                            };

                            // guardar Foto
                            if (!string.IsNullOrWhiteSpace(TxtDireccionImagen.Text) && File.Exists(TxtDireccionImagen.Text))
                            {
                                string nombreImagen = Path.GetFileName(TxtDireccionImagen.Text);
                                string destinoImagen = Path.Combine(carpetaImagenes, nombreImagen);

                                File.Copy(TxtDireccionImagen.Text, destinoImagen, true);
                                art.FotoPrincipal = TxtDireccionImagen.Text;
                                art.FotoSecundaria = destinoImagen;
                            }

                            // guardar comprobante
                            if (!string.IsNullOrWhiteSpace(TxtRutaComprobante.Text) && File.Exists(TxtRutaComprobante.Text))
                            {
                                string nombreComprobate = Path.GetFileName(TxtRutaComprobante.Text);
                                string destinoComprobante = Path.Combine(carpetaComprobantes, nombreComprobate);

                                File.Copy(TxtRutaComprobante.Text, destinoComprobante, true);
                                art.ComprobantePrincipal = TxtRutaComprobante.Text;
                                art.ComprobanteSecundaria = destinoComprobante;
                            }

                            // verificar fecha garantía y fecha baja
                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show(Idiomas.MensajeAdvertenciaAgregarFechasArticulo, Idiomas.TituloAdvertencia, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            ArticuloRepository.InsertarArticulo(art, con);
                            LogsRepository.InsertarLogs("Artículos", "Crear", $"Se registró un nuevo artículo con el código: {art.Codigo}");

                            MessageBox.Show(Idiomas.MensajeAgregarArticulo, Idiomas.TituloExito, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Idiomas.MensajeErrorAgregarArticulo + ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    try
                    {
                        using (var con = ConexionGlobal.ObtenerConexion())
                        {
                            con.Open();

                            Articulos art = new Articulos
                            {
                                InventarioId = UsuarioSesion.InventarioId,
                                Id = _articuloId, 
                                Codigo = codigoFinal,
                                Modelo = TxtModelo.Text,
                                Serie = TxtSerie.Text,
                                IdMarca = Convert.ToInt32(CbMarcas.SelectedValue),
                                Marca = ClassHelper.NormalizarCombo(CbMarcas),
                                FechaAdquisicion = DtpFechaAdquisicion.Value,
                                FechaFinGarantia = ChkFechaGarantia.Checked ? DtpFechaFinGarantia.Value.Date : (DateTime?)null,

                                EmpleadoActualId = idEmpleadoActualTemporal,
                                EmpleadoAnteriorId = idEmpleadoAnteriorTemporal,

                                IdEstado = Convert.ToInt32(CbEstadoArticulo.SelectedValue),
                                Estado = string.IsNullOrWhiteSpace(CbEstadoArticulo.Text) ? null : CbEstadoArticulo.Text,
                                IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                                Ubicacion = ClassHelper.NormalizarCombo(CbUbicacion),
                                IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),
                                Condicion = ClassHelper.NormalizarCombo(CbCondicion),
                                Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                                RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                                Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                                PrecioAdquisicion = precioFinal,

                                Caracteristicas = jsonCaracteristicas,

                                FechaRegistro = DateTime.Now,

                                CategoriaId = _categoriaId,
                                Categoria = _categoria
                            };

                            // guardar comprobante
                            if (!string.IsNullOrWhiteSpace(TxtRutaComprobante.Text) && File.Exists(TxtRutaComprobante.Text))
                            {
                                string nombreComprobate = Path.GetFileName(TxtRutaComprobante.Text);
                                string destinoComprobante = Path.Combine(carpetaComprobantes, nombreComprobate);

                                File.Copy(TxtRutaComprobante.Text, destinoComprobante, true);
                                art.ComprobantePrincipal = TxtRutaComprobante.Text;
                                art.ComprobanteSecundaria = destinoComprobante;
                            }

                            // guardar Foto
                            if (!string.IsNullOrWhiteSpace(TxtDireccionImagen.Text) && File.Exists(TxtDireccionImagen.Text))
                            {
                                string nombreImagen = Path.GetFileName(TxtDireccionImagen.Text);
                                string destinoImagen = Path.Combine(carpetaImagenes, nombreImagen);

                                File.Copy(TxtDireccionImagen.Text, destinoImagen, true);
                                art.FotoPrincipal = TxtDireccionImagen.Text;
                                art.FotoSecundaria = destinoImagen;
                            }

                            // verificar fecha garantía y fecha baja
                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show(Idiomas.MensajeAdvertenciaAgregarFechasArticulo, Idiomas.TituloAdvertencia, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            ArticuloRepository.ActualizarArticulo(art);
                            LogsRepository.InsertarLogs("Artículos", "Actualizar", $"Se actualizó un nuevo artículo con el código: {art.Codigo}");

                            MessageBox.Show(Idiomas.MensajeAgregarArticulo, Idiomas.TituloExito,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Idiomas.MensajeErrorActualizarArticulo + ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                VistaInventario vista = new VistaInventario();
                vista.RefrescarArticulos();
            }
        }

        private void BtnGuardarPlus_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                string codigoFinal = TxtCodigo.Text.Trim();
                string carpetaComprobantes = ConexionGlobal.ObtenerCarpetaComprobantes();
                string carpetaImagenes = ConexionGlobal.ObtenerCarpetaImagenes();

                string precioTexto = TxtPrecio.Text.Trim();
                decimal? precioFinal = ClassHelper.ConvertirTextoAMoneda(precioTexto);              

                // Mapear Codigo automatico
                if (generarCodigoAutomatico)
                {
                    string prefijo = nombreCategoriaActual.Length >= 3 ?
                                     nombreCategoriaActual.Substring(0, 3).ToUpper() :
                                     nombreCategoriaActual.ToUpper();

                    codigoFinal = ArticuloRepository.GenerarCodigoArticulo(prefijo, UsuarioSesion.InventarioId);
                }

                string jsonCaracteristicas = null;
                if (caracteristicasTemporales != null && caracteristicasTemporales.Count > 0)
                {
                    jsonCaracteristicas = JsonSerializer.Serialize(caracteristicasTemporales);
                }

                try
                {
                    using (var con = ConexionGlobal.ObtenerConexion())
                    {
                        con.Open();
                        Articulos art = new Articulos
                        {
                            Codigo = TxtCodigo.Text,
                            Modelo = TxtModelo.Text,
                            Serie = TxtSerie.Text,
                            IdMarca = Convert.ToInt32(CbMarcas.SelectedValue),

                            FechaAdquisicion = DtpFechaAdquisicion.Value,
                            FechaFinGarantia = ChkFechaGarantia.Checked ? DtpFechaFinGarantia.Value.Date : (DateTime?)null,

                            EmpleadoActualId = idEmpleadoActualTemporal,
                            EmpleadoAnteriorId = idEmpleadoAnteriorTemporal,

                            IdEstado = Convert.ToInt32(CbEstadoArticulo.SelectedValue),
                            IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                            IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),

                            Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                            RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                            Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                            PrecioAdquisicion = precioFinal,

                            Caracteristicas = jsonCaracteristicas,

                            CategoriaId = _categoriaId,
                            Categoria = _categoria,
                            FechaRegistro = DateTime.Now
                        };

                        // guardar comprobante
                        if (!string.IsNullOrWhiteSpace(TxtRutaComprobante.Text) && File.Exists(TxtRutaComprobante.Text))
                        {
                            string nombreComprobate = Path.GetFileName(TxtRutaComprobante.Text);
                            string destinoComprobante = Path.Combine(carpetaComprobantes, nombreComprobate);

                            File.Copy(TxtRutaComprobante.Text, destinoComprobante, true);
                            art.ComprobantePrincipal = TxtRutaComprobante.Text;
                            art.ComprobanteSecundaria = destinoComprobante;
                        }

                        // verificar fecha garantía y fecha baja
                        if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now))
                        {
                            var result = MessageBox.Show(Idiomas.MensajeAdvertenciaAgregarFechasArticulo, Idiomas.TituloAdvertencia, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                                return;
                        }

                        ArticuloRepository.InsertarArticulo(art, con);
                        LogsRepository.InsertarLogs("Artículos", "Crear", $"Se registró un nuevo artículo con el código: {art.Codigo}");

                        MessageBox.Show(Idiomas.MensajeAgregarArticulo, Idiomas.TituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Idiomas.MensajeErrorAgregarArticulo + ex.Message, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                VistaInventario vista = new VistaInventario();
                vista.RefrescarArticulos();
            }
        }

        private void BtnAgregarComprobante_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                ofd.Title = "Seleccionar comprobante de compra";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TxtRutaComprobante.Text = ofd.FileName;
                    try
                    {
                        pdfViewer.Document?.Dispose();
                        pdfViewer.Document = PdfDocument.Load(ofd.FileName);
                        pdfViewer.BringToFront();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Idiomas.MensajeErrorCargarComprobante + ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void BtnAgregarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Seleccionar foto";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TxtDireccionImagen.Text = ofd.FileName;
                    try
                    {
                        PbFotoArticulo.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Idiomas.MensajeErrorCargarImagen + ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void VistaArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    // Le preguntamos a la base de datos qué configuración tiene este usuario
                    var perfil = PerfilRepository.ObtenerPerfilUsuario(UsuarioSesion.NombreUsuario, con);

                    if (perfil != null)
                    {
                        ChkAutoCodigo.Checked = perfil.GeneracionCodigos;
                    }
                }
            }
            catch (Exception ex)
            {
                string mensajeError = string.Format(Idiomas.MensajeErrorConfiguracion, ex.Message);
                MessageBox.Show(mensajeError);
            }

            this.Click += Fondo_Click; 
            ConfigurarPerdidaDeFoco(this);

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                var dtEstadoArticulos = ParametrosRepository.ListarParametros(con, "EstadoArticulos");
                RefreshService.RefrescarComboDT(CbEstadoArticulo, dtEstadoArticulos, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtCondicion = ParametrosRepository.ListarParametros(con, "Condicion");
                RefreshService.RefrescarComboDT(CbCondicion, dtCondicion, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtUbicacion = ParametrosRepository.ListarParametros(con, "Ubicacion");
                RefreshService.RefrescarComboDT(CbUbicacion, dtUbicacion, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtMarcas = MarcasRepository.ListarMarcas(con, _categoriaId);
                RefreshService.RefrescarComboDT(CbMarcas, dtMarcas, "Nombre", "Id", Idiomas.OpcionSeleccione);

                if (VistaInventario.isEdit == true)
                    BtnGuardarPlus.Enabled = false;
                else
                    BtnGuardarPlus.Enabled = true;

                Articulos art = new Articulos();

                if (DatosEdicion != null)
                {
                    CbMarcas.SelectedValue = DatosEdicion.IdMarca;
                    CbEstadoArticulo.SelectedValue = DatosEdicion.IdEstado;
                    CbUbicacion.SelectedValue = DatosEdicion.IdUbicacion;
                    CbCondicion.SelectedValue = DatosEdicion.IdCondicion;

                    idEmpleadoActualTemporal = DatosEdicion.IdEmpleadoActual;
                    idEmpleadoAnteriorTemporal = DatosEdicion.IdEmpleadoAnterior;

                    if (idEmpleadoActualTemporal != null)
                    {
                        var empActual = EmpleadoRepository.ObtenerEmpleadoPorId(idEmpleadoActualTemporal.Value);
                        if (empActual != null)
                        {
                            TxtDniUsuarioActual.Text = empActual.DNI;
                            TxtNombreUsuarioActual.Text = ClassHelper.FormatearNombreCorto(empActual.Nombres, empActual.Apellidos);

                            // Asignamos directamente usando los IDs del empleado obtenido de la BD
                            TxtAreaUsuarioActual.Text = empActual.Area;
                            TxtCargoUsuarioActual.Text = empActual.Cargo;
                            dniTemporal = empActual.DNI;
                        }
                    }

                    // 4. Consultar y llenar datos visuales del Empleado Anterior (Si existe)
                    if (idEmpleadoAnteriorTemporal != null && idEmpleadoAnteriorTemporal > 0)
                    {
                        var empAnterior = EmpleadoRepository.ObtenerEmpleadoPorId(idEmpleadoAnteriorTemporal.Value);
                        if (empAnterior != null)
                        {
                            TxtDniUsuarioAnterior.Text = empAnterior.DNI;
                            TxtNombreUsuarioActual.Text = ClassHelper.FormatearNombreCorto(empAnterior.Nombres, empAnterior.Apellidos);

                            // Asignamos directamente usando los IDs del empleado obtenido de la BD
                            TxtAreaUsuarioAnterior.Text = empAnterior.Area;
                            TxtCargoUsuarioAnterior.Text = empAnterior.Cargo;
                        }
                    }

                    if (!string.IsNullOrEmpty(DatosEdicion.Caracteristicas))
                    {
                        try
                        {
                            caracteristicasTemporales = JsonSerializer.Deserialize<Dictionary<string, string>>(DatosEdicion.Caracteristicas);
                        }
                        catch
                        {
                            caracteristicasTemporales = new Dictionary<string, string>();
                        }
                    }
                    else
                    {
                        caracteristicasTemporales = new Dictionary<string, string>();
                    }

                    ActualizarBotonCaracteristicas();
                }
            }
            ClassHelper.AplicarTema(this);
            ClassHelper.AplicarFormatoFecha(DtpFechaFinGarantia);
            ClassHelper.AplicarFormatoFecha(DtpFechaAdquisicion);
        }

        private void BtnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (_categoriaId > 0)
            {
                var vistaAgregar = new VistaAgregarComponentes("Marca", this)
                {
                    CategoriaId = _categoriaId
                };
                vistaAgregar.ShowDialog();
            }
        }

        private void ChkFechaGarantia_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFechaGarantia.Checked)
                DtpFechaFinGarantia.Enabled = true;
            else
                DtpFechaFinGarantia.Enabled = false;
        }

        private void BtnAgregarEstado_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("EstadoArticulos", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnAgregarUbicacion_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Ubicacion", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnAgregarCondicion_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Condicion", this);
            vistaAgregar.ShowDialog();
        }

        private void CbEstadoArticulo_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbEstadoArticulo);
        }

        private void CbCondicion_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbCondicion);
        }

        private void CbMarcas_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbMarcas);
        }

        private void CbUbicacion_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbUbicacion);
        }

        private void BtnAgregarRUC_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Proveedor", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            VistaAgregarEmpleado vistaEmpleado = new VistaAgregarEmpleado();
            vistaEmpleado.ShowDialog();
        }

        private void TxtDniUsuarioActual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (TxtDniUsuarioActual.Text.Trim().Length == 8)
                {
                    var emp = EmpleadoRepository.ObtenerEmpleadoPorDni(TxtDniUsuarioActual.Text);
                    if (emp != null)
                    {
                        if (dniTemporal == TxtDniUsuarioActual.Text)
                        {
                            dniTemporal = "";
                        }
                        else
                        {
                            idEmpleadoAnteriorTemporal = idEmpleadoActualTemporal;
                        }

                        idEmpleadoActualTemporal = emp.Id;

                        TxtDniUsuarioAnterior.Text = dniTemporal;
                        var NombreAnterior = TxtNombreUsuarioActual.Text;
                        var AreaAnterior = TxtAreaUsuarioActual.Text;
                        var CargoAnterior = TxtCargoUsuarioActual.Text;

                        TxtNombreUsuarioActual.Text = ClassHelper.FormatearNombreCorto(emp.Nombres, emp.Apellidos);
                        TxtAreaUsuarioActual.Text = emp.Area;
                        TxtCargoUsuarioActual.Text = emp.Cargo;

                        dniTemporal = TxtDniUsuarioAnterior.Text;
                        TxtNombreUsuarioAnterior.Text = NombreAnterior;
                        TxtAreaUsuarioAnterior.Text = AreaAnterior;
                        TxtCargoUsuarioAnterior.Text = CargoAnterior;
                    }
                }
                else
                {
                    MessageBox.Show(Idiomas.MensajeErrorBuscarEmpleado,
                    Idiomas.MensajeBuscarEmpleado,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                }
            }
        }

        private void TxtDniUsuarioActual_Enter(object sender, EventArgs e)
        {
            dniTemporal = TxtDniUsuarioActual.Text;
        }

        private void TxtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (TxtRuc.Text.Trim().Length == 11)
                {
                    var prov = ProveedorRepository.ObtenerProveedorPorRUC(TxtRuc.Text);
                    if (prov != null)
                    {
                        TxtRazonSocial.Text = prov.RazonSocial;
                    }
                }
                else
                {
                    MessageBox.Show(Idiomas.MensajeErrorBuscarRuc,
                    Idiomas.MensajeBuscarEmpleado,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                }
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            TextBox txt = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txt.Text.IndexOf('.') > -1 || txt.Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtPrecio_Enter(object sender, EventArgs e)
        {
            decimal? numeroPuro = ClassHelper.LimpiarTextoParaEdicion(TxtPrecio.Text);
            TxtPrecio.Text = numeroPuro.HasValue ? numeroPuro.Value.ToString("0.00") : "";
        }

        private void TxtPrecio_Leave(object sender, EventArgs e)
        {
            decimal? numeroPuro = ClassHelper.LimpiarTextoParaEdicion(TxtPrecio.Text);
            TxtPrecio.Text = ClassHelper.AgregarSimboloVisual(numeroPuro);
        }

        private void Fondo_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void ConfigurarPerdidaDeFoco(Control contenedorPadre)
        {
            foreach (Control c in contenedorPadre.Controls)
            {
                if (c is GroupBox || c is Panel || c is Label || c is PictureBox)
                {
                    c.Click += Fondo_Click;

                    ConfigurarPerdidaDeFoco(c);
                }
            }
        }

        private void ChkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAutoCodigo.Checked)
            {
                TxtCodigo.Enabled = false;
                TxtCodigo.BackColor = Color.LightGray;
                ActualizarCodigo();
            }
            else
            {
                TxtCodigo.Enabled = true;
                TxtCodigo.BackColor = Color.White;
                TxtCodigo.Clear();
                TxtCodigo.Focus();
            }
        }

        private void ActualizarCodigo()
        {
            if (ChkAutoCodigo.Checked)
            {
                if (string.IsNullOrWhiteSpace(nombreCategoriaActual))
                {
                    TxtCodigo.Text = Idiomas.MensajeCodigoNoAutomatico;
                    return;
                }

                string prefijo = nombreCategoriaActual.Length >= 3 ?
                                 nombreCategoriaActual.Substring(0, 3).ToUpper() :
                                 nombreCategoriaActual.ToUpper();

                string siguienteCodigo = ArticuloRepository.GenerarCodigoArticulo(prefijo, UsuarioSesion.InventarioId);

                TxtCodigo.Text = siguienteCodigo;
            }
        }

        private void ActualizarSerie()
        {
            if (ChkAutoSerie.Checked)
            {
                if (string.IsNullOrWhiteSpace(nombreCategoriaActual))
                {
                    TxtSerie.Text = Idiomas.MensajeCodigoNoAutomatico;
                    return;
                }

                if (string.IsNullOrEmpty(serieAutomaticaGenerada))
                {
                    int idUsuarioActual = UsuarioSesion.UsuarioId;
                    serieAutomaticaGenerada = ArticuloRepository.GenerarSerieAutomatica(nombreCategoriaActual, idUsuarioActual);
                }

                TxtSerie.Text = serieAutomaticaGenerada;
            }
        }

        private void ChkAutoSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAutoSerie.Checked)
            {
                TxtSerie.Enabled = false;
                TxtSerie.BackColor = Color.LightGray;
                ActualizarSerie();
            }
            else
            {
                TxtSerie.Enabled = true;
                TxtSerie.BackColor = Color.White;
                TxtSerie.Clear();
                TxtSerie.Focus();
            }
        }

        private void ActualizarModelo()
        {
            if (ChkAutoModelo.Checked)
            {
                if (string.IsNullOrWhiteSpace(nombreCategoriaActual))
                {
                    TxtModelo.Text = "Esperando categoría...";
                    return;
                }

                if (string.IsNullOrEmpty(modeloAutomaticoGenerado))
                {
                    modeloAutomaticoGenerado = ArticuloRepository.GenerarModeloAutomatico(nombreCategoriaActual);
                }

                TxtModelo.Text = modeloAutomaticoGenerado;
            }
        }

        private void ChkAutoModelo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAutoModelo.Checked)
            {
                TxtModelo.Enabled = false;
                TxtModelo.BackColor = Color.LightGray;
                ActualizarModelo();
            }
            else
            {
                TxtModelo.Enabled = true;
                TxtModelo.BackColor = Color.White;
                TxtModelo.Clear();
                TxtModelo.Focus();
            }
        }

        private void TxtModelo_Leave(object sender, EventArgs e)
        {
            if (ChkAutoModelo.Checked || string.IsNullOrWhiteSpace(TxtModelo.Text) || string.IsNullOrWhiteSpace(ultimoModeloGuardado) || rechazoSugerenciaModelo)
                return;

            string tipeado = TxtModelo.Text.Trim().ToUpper();
            string enMemoria = ultimoModeloGuardado.ToUpper();

            if (tipeado == enMemoria) return;

            int distancia = ClassHelper.CalcularDistancia(tipeado, enMemoria);

            if (distancia > 0 && distancia <= 2)
            {
                var result = MessageBox.Show($"El modelo ingresado ('{TxtModelo.Text}') se parece mucho al modelo anterior ('{ultimoModeloGuardado}').\n\n¿Desea corregirlo y usar el modelo guardado en memoria?",
                                             "Sugerencia de Modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    TxtModelo.Text = ultimoModeloGuardado;
                    rechazoSugerenciaModelo = false;
                }
                else
                {
                    ultimoModeloGuardado = TxtModelo.Text.Trim();
                    rechazoSugerenciaModelo = true;
                }
            }
            else
            {
                ultimoModeloGuardado = TxtModelo.Text.Trim();
                rechazoSugerenciaModelo = false;
            }
        }

        private void BtnDepreciacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }
    }
}

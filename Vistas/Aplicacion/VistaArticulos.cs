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

namespace ControlInventario.Vistas
{
    public partial class VistaArticulos : Form, IMarcasRefrescable, IEstadoArticulosRefrescable, ICondicionRefrescable, IUbicacionRefrescable
    {
        private PdfViewer pdfViewer;
        private readonly int _categoriaId;
        private readonly string _categoria;
        private readonly int _articuloId;
        private string dniTemporal;
        public ComboBox CbMarcasPublic => CbMarcas;
        public ComboBox CbEstadoArticulosPublic => CbEstadoArticulo;
        public ComboBox CbCondicionPublic => CbCondicion;
        public ComboBox CbUbicacionPublic => CbUbicacion;
        public PdfViewer PdfViewerControl => pdfViewer;
        public EdicionArticulo DatosEdicion { get; set; }
        private bool generarCodigoAutomatico = false;
        private string nombreCategoriaActual = "";

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
            }

            if (CbMarcas.Text == Idiomas.OpcionSeleccione || CbMarcas.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbMarcas, Idiomas.MensajeErrorAgregarMarcaArticulo);
            }

            if (ChkFechaBaja.Checked || ChkFechaGarantia.Checked)
            {
                if (DtpFechaBaja.Value < DtpFechaAdquisicion.Value)
                    ErrorArticulos.SetError(DtpFechaBaja, Idiomas.MensajeErrorAgregarFechaBajaArticulo);

                if (DtpFechaFinGarantia.Value < DtpFechaAdquisicion.Value)
                    ErrorArticulos.SetError(DtpFechaFinGarantia, Idiomas.MensajeErrorAgregarFechaGarantiaArticulo);
            }

            if (string.IsNullOrWhiteSpace(TxtDniUsuarioActual.Text))
            {
                ErrorArticulos.SetError(TxtDniUsuarioActual, Idiomas.MensajeErrorAgregarDniArticulo);
            }

            if (CbEstadoArticulo.Text == Idiomas.OpcionSeleccione || CbEstadoArticulo.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbEstadoArticulo, Idiomas.MensajeErrorAgregarEstadoArticulo);
            }

            if (CbUbicacion.Text == Idiomas.OpcionSeleccione || CbUbicacion.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbUbicacion, Idiomas.MensajeErrorAgregarUbicacionArticulo);
            }

            if (CbCondicion.Text == Idiomas.OpcionSeleccione || CbCondicion.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbCondicion, Idiomas.MensajeErrorAgregarCondicionArticulo);
            }

            if (string.IsNullOrWhiteSpace(TxtDireccionImagen.Text))
            {
                ErrorArticulos.SetError(TxtDireccionImagen, Idiomas.MensajeErrorAgregarFotoArticulo);
            }

            return valido;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VistaCaracteristicas caracteristicas = new VistaCaracteristicas();
            caracteristicas.CaracteristicasGuardadas += AgregarCaracteristicas;
            caracteristicas.ShowDialog();
            FlCaracteristicas.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FlCaracteristicas.Controls.Clear();
            FlCaracteristicas.Visible = false;
        }

        public void AgregarCaracteristicas(GroupBox grupo)
        {
            FlCaracteristicas.Controls.Clear();

            var controles = new List<Control>();
            RecolectarControles(grupo, controles);

            var labelsAgregados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var ctrl in controles)
            {
                string nombreBase = ObtenerNombreBase(ctrl);

                Label lbl = BuscarLabelRecursivo(grupo, nombreBase);
                if (lbl != null && !labelsAgregados.Contains(lbl.Name))
                {
                    lbl.AutoSize = false;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Margin = new Padding(5, 3, 10, 0);

                    int panelWidth = FlCaracteristicas.ClientSize.Width;
                    int marginSum = (lbl.Margin.Left + lbl.Margin.Right) + (ctrl.Margin.Left + ctrl.Margin.Right);

                    int lblPreferred = lbl.AutoSize ? lbl.PreferredSize.Width : lbl.Width;
                    int ctrlPreferred = ctrl.AutoSize ? ctrl.PreferredSize.Width : ctrl.Width;

                    int totalNecesario = lblPreferred + ctrlPreferred + marginSum;

                    if (totalNecesario > panelWidth)
                    {
                        int minimoControl = Math.Min(ctrlPreferred, 80);
                        int nuevoLblWidth = Math.Max(40, panelWidth - minimoControl - marginSum);

                        if (nuevoLblWidth < lblPreferred)
                        {
                            lbl.AutoSize = false;
                            lbl.Width = nuevoLblWidth;
                        }
                    }

                    FlCaracteristicas.Controls.Add(lbl);
                    labelsAgregados.Add(lbl.Name);
                }

                ctrl.Margin = new Padding(5, 0, 10, 8);
                FlCaracteristicas.Controls.Add(ctrl);
            }
        }

        // Recolecta TextBox y ComboBox recursivamente (mantiene orden visual)
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

        // Normaliza el nombre del control para buscar su label asociado
        private string ObtenerNombreBase(Control ctrl)
        {
            if (string.IsNullOrEmpty(ctrl?.Name)) return string.Empty;
            string n = ctrl.Name.ToLowerInvariant();
            n = n.Replace("txt", "").Replace("cb", "");
            return n;
        }

        // Busca un Label cuyo Name contenga nombreBase en todo el árbol (recursivo)
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
            DtpFechaBaja.Value = DateTime.Now;
            DtpFechaFinGarantia.Value = DateTime.Now;

            TxtDniUsuarioActual.Text = "";
            TxtNombreUsuarioActual.Text = "";
            CbAreaUsuarioActual.SelectedIndex = -1;
            CbCargoUsuarioActual.SelectedIndex = -1;

            TxtDniUsuarioAnterior.Text = "";
            TxtNombreUsuarioAnterior.Text = "";
            CbAreaUsuarioAnterior.SelectedIndex = -1;
            CbCargoUsuarioAnterior.SelectedIndex = -1;

            CbEstadoArticulo.SelectedIndex = -1;
            CbUbicacion.SelectedIndex = -1;
            CbCondicion.SelectedIndex = -1;
            TxtActivoFijo.Text = "";
            TxtObservaciones.Text = "";

            TxtRuc.Text = "";
            TxtRazonSocial.Text = "";
            TxtPrecio.Text = "";

            TxtRutaComprobante.Text = "";
            TxtDireccionImagen.Text = "";

            PbFotoArticulo.Image = null;
            PanelComprobante.Controls.Clear();

            FlCaracteristicas.Controls.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                string codigoFinal = TxtCodigo.Text.Trim();
                string carpetaComprobantes = ConexionGlobal.ObtenerCarpetaComprobantes();
                string carpetaImagenes = ConexionGlobal.ObtenerCarpetaImagenes();

                string codigoActivoFijo = TxtActivoFijo.Text.Trim();
                string precioTexto = TxtPrecio.Text.Trim().Replace(".", ",");
                decimal? precioFinal = ClassHelper.ConvertirTextoAMoneda(precioTexto);

                // Verificar ActivoFijo
                if (!string.IsNullOrEmpty(codigoActivoFijo))
                {
                    if (ClassHelper.ExisteComponenteDuplicado("Articulos", codigoActivoFijo, _articuloId, "ActivoFijo"))
                    {
                        string mensajeArmado = string.Format(Idiomas.MensajeAdvertenciaActivoFijo, codigoActivoFijo);

                        MessageBox.Show(mensajeArmado, Idiomas.MensajeCodigoDuplicado,
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtActivoFijo.Focus();
                        return;
                    }
                }

                // Mapear Codigo automatico
                if (generarCodigoAutomatico)
                {
                    string prefijo = nombreCategoriaActual.Length >= 3 ?
                                     nombreCategoriaActual.Substring(0, 3).ToUpper() :
                                     nombreCategoriaActual.ToUpper();

                    codigoFinal = ArticuloRepository.GenerarCodigoArticulo(prefijo, UsuarioSesion.InventarioId);
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
                                FechaBaja = ChkFechaBaja.Checked ? DtpFechaBaja.Value.Date : (DateTime?)null,
                                FechaFinGarantia = ChkFechaGarantia.Checked ? DtpFechaFinGarantia.Value.Date : (DateTime?)null,

                                DniUsuarioActual = string.IsNullOrWhiteSpace(TxtDniUsuarioActual.Text) ? null : TxtDniUsuarioActual.Text,
                                NombreUsuarioActual = string.IsNullOrWhiteSpace(TxtNombreUsuarioActual.Text) ? null : TxtNombreUsuarioActual.Text,
                                IdAreaUsuarioActual = Convert.ToInt32(CbAreaUsuarioActual.SelectedValue),
                                AreaUsuarioActual = ClassHelper.NormalizarCombo(CbAreaUsuarioActual),
                                IdCargoUsuarioActual = Convert.ToInt32(CbCargoUsuarioActual.SelectedValue),
                                CargoUsuarioActual = ClassHelper.NormalizarCombo(CbCargoUsuarioActual),

                                DniUsuarioAnterior = string.IsNullOrWhiteSpace(TxtDniUsuarioAnterior.Text) ? null : TxtDniUsuarioAnterior.Text,
                                NombreUsuarioAnterior = string.IsNullOrWhiteSpace(TxtNombreUsuarioAnterior.Text) ? null : TxtNombreUsuarioAnterior.Text,
                                IdAreaUsuarioAnterior = Convert.ToInt32(CbAreaUsuarioAnterior.SelectedValue),
                                AreaUsuarioAnterior = ClassHelper.NormalizarCombo(CbAreaUsuarioAnterior),
                                IdCargoUsuarioAnterior = Convert.ToInt32(CbCargoUsuarioAnterior.SelectedValue),
                                CargoUsuarioAnterior = ClassHelper.NormalizarCombo(CbCargoUsuarioAnterior),

                                IdEstado = Convert.ToInt32(CbEstadoArticulo.SelectedValue),
                                Estado = string.IsNullOrWhiteSpace(CbEstadoArticulo.Text) ? null : CbEstadoArticulo.Text,
                                IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                                Ubicacion = ClassHelper.NormalizarCombo(CbUbicacion),
                                IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),
                                Condicion = ClassHelper.NormalizarCombo(CbCondicion),
                                ActivoFijo = string.IsNullOrEmpty(codigoActivoFijo) ? null : codigoActivoFijo,
                                Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                                RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                                Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                                PrecioAdquisicion = precioFinal,

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
                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show(Idiomas.MensajeAdvertenciaAgregarFechasArticulo, Idiomas.TituloAdvertencia, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            ArticuloRepository.InsertarArticulo(art, con);
                            LogsRepository.InsertarLogs("Artículos", "Crear", $"Se registró un nuevo artículo con el código: {art.Codigo}");

                            MessageBox.Show(Idiomas.MensajeAgregarArticulo, Idiomas.TituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                Id = _articuloId,
                                Codigo = codigoFinal,
                                Modelo = TxtModelo.Text,
                                Serie = TxtSerie.Text,
                                IdMarca = Convert.ToInt32(CbMarcas.SelectedValue),
                                Marca = ClassHelper.NormalizarCombo(CbMarcas),
                                FechaAdquisicion = DtpFechaAdquisicion.Value,
                                FechaBaja = ChkFechaBaja.Checked ? DtpFechaBaja.Value.Date : (DateTime?)null,
                                FechaFinGarantia = ChkFechaGarantia.Checked ? DtpFechaFinGarantia.Value.Date : (DateTime?)null,

                                DniUsuarioActual = string.IsNullOrWhiteSpace(TxtDniUsuarioActual.Text) ? null : TxtDniUsuarioActual.Text,
                                NombreUsuarioActual = string.IsNullOrWhiteSpace(TxtNombreUsuarioActual.Text) ? null : TxtNombreUsuarioActual.Text,
                                IdAreaUsuarioActual = Convert.ToInt32(CbAreaUsuarioActual.SelectedValue),
                                AreaUsuarioActual = ClassHelper.NormalizarCombo(CbAreaUsuarioActual),
                                IdCargoUsuarioActual = Convert.ToInt32(CbCargoUsuarioActual.SelectedValue),
                                CargoUsuarioActual = ClassHelper.NormalizarCombo(CbCargoUsuarioActual),

                                DniUsuarioAnterior = string.IsNullOrWhiteSpace(TxtDniUsuarioAnterior.Text) ? null : TxtDniUsuarioAnterior.Text,
                                NombreUsuarioAnterior = string.IsNullOrWhiteSpace(TxtNombreUsuarioAnterior.Text) ? null : TxtNombreUsuarioAnterior.Text,
                                IdAreaUsuarioAnterior = Convert.ToInt32(CbAreaUsuarioAnterior.SelectedValue),
                                AreaUsuarioAnterior = ClassHelper.NormalizarCombo(CbAreaUsuarioAnterior),
                                IdCargoUsuarioAnterior = Convert.ToInt32(CbCargoUsuarioAnterior.SelectedValue),
                                CargoUsuarioAnterior = ClassHelper.NormalizarCombo(CbCargoUsuarioAnterior),

                                IdEstado = Convert.ToInt32(CbEstadoArticulo.SelectedValue),
                                Estado = string.IsNullOrWhiteSpace(CbEstadoArticulo.Text) ? null : CbEstadoArticulo.Text,
                                IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                                Ubicacion = ClassHelper.NormalizarCombo(CbUbicacion),
                                IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),
                                Condicion = ClassHelper.NormalizarCombo(CbCondicion),
                                ActivoFijo = string.IsNullOrEmpty(codigoActivoFijo) ? null : codigoActivoFijo,
                                Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                                RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                                Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                                PrecioAdquisicion = precioFinal,

                                FechaModificacion = DateTime.Now,

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
                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show(Idiomas.MensajeAdvertenciaAgregarFechasArticulo, Idiomas.TituloAdvertencia, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            ArticuloRepository.ActualizarArticulo(art);
                            LogsRepository.InsertarLogs("Artículos", "Actualizar", $"Se actualizó un nuevo artículo con el código: {art.Codigo}");

                            MessageBox.Show("Artículo actualizado correctamente.", "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

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

                string codigoActivoFijo = TxtActivoFijo.Text.Trim();
                string precioTexto = TxtPrecio.Text.Trim().Replace(".", ",");
                decimal? precioFinal = null;

                // Verificar ActivoFijo
                if (!string.IsNullOrEmpty(codigoActivoFijo))
                {
                    if (ClassHelper.ExisteComponenteDuplicado("Articulos", codigoActivoFijo, _articuloId, "ActivoFijo"))
                    {
                        string mensajeArmado = string.Format(Idiomas.MensajeAdvertenciaActivoFijo, codigoActivoFijo);

                        MessageBox.Show(mensajeArmado, Idiomas.MensajeCodigoDuplicado,
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtActivoFijo.Focus();
                        return;
                    }
                }

                // Verificar Precio
                if (decimal.TryParse(precioTexto, out decimal resultadoDecimal))
                {
                    precioFinal = resultadoDecimal;
                }

                // Mapear Codigo automatico
                if (generarCodigoAutomatico)
                {
                    string prefijo = nombreCategoriaActual.Length >= 3 ?
                                     nombreCategoriaActual.Substring(0, 3).ToUpper() :
                                     nombreCategoriaActual.ToUpper();

                    codigoFinal = ArticuloRepository.GenerarCodigoArticulo(prefijo, UsuarioSesion.InventarioId);
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
                            Marca = ClassHelper.NormalizarCombo(CbMarcas),
                            FechaAdquisicion = DtpFechaAdquisicion.Value,
                            FechaBaja = ChkFechaBaja.Checked ? DtpFechaBaja.Value.Date : (DateTime?)null,
                            FechaFinGarantia = ChkFechaGarantia.Checked ? DtpFechaFinGarantia.Value.Date : (DateTime?)null,

                            DniUsuarioActual = string.IsNullOrWhiteSpace(TxtDniUsuarioActual.Text) ? null : TxtDniUsuarioActual.Text,
                            NombreUsuarioActual = string.IsNullOrWhiteSpace(TxtNombreUsuarioActual.Text) ? null : TxtNombreUsuarioActual.Text,
                            IdAreaUsuarioActual = Convert.ToInt32(CbAreaUsuarioActual.SelectedValue),
                            AreaUsuarioActual = ClassHelper.NormalizarCombo(CbAreaUsuarioActual),
                            CargoUsuarioActual = ClassHelper.NormalizarCombo(CbCargoUsuarioActual),

                            DniUsuarioAnterior = string.IsNullOrWhiteSpace(TxtDniUsuarioAnterior.Text) ? null : TxtDniUsuarioAnterior.Text,
                            NombreUsuarioAnterior = string.IsNullOrWhiteSpace(TxtNombreUsuarioAnterior.Text) ? null : TxtNombreUsuarioAnterior.Text,
                            IdAreaUsuarioAnterior = Convert.ToInt32(CbAreaUsuarioAnterior.SelectedValue),
                            AreaUsuarioAnterior = ClassHelper.NormalizarCombo(CbAreaUsuarioAnterior),
                            CargoUsuarioAnterior = ClassHelper.NormalizarCombo(CbCargoUsuarioAnterior),

                            IdEstado = Convert.ToInt32(CbEstadoArticulo.SelectedValue),
                            Estado = ClassHelper.NormalizarCombo(CbEstadoArticulo),
                            IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                            Ubicacion = ClassHelper.NormalizarCombo(CbUbicacion),
                            IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),
                            Condicion = ClassHelper.NormalizarCombo(CbCondicion),
                            ActivoFijo = string.IsNullOrWhiteSpace(TxtActivoFijo.Text) ? null : TxtActivoFijo.Text,
                            Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                            RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                            Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                            PrecioAdquisicion = precioFinal,

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

                        // verificar fecha garantía y fecha baja
                        if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
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
                        ChkAuto.Checked = perfil.GeneracionCodigos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar configuración: " + ex.Message);
            }

            this.Click += Fondo_Click; 
            ConfigurarPerdidaDeFoco(this);

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                var dtAreaActual = AreaRepository.ListarAreas(con);
                RefreshService.RefrescarComboDT(CbAreaUsuarioActual, dtAreaActual, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtAreaAnterior = AreaRepository.ListarAreas(con);
                RefreshService.RefrescarComboDT(CbAreaUsuarioAnterior, dtAreaAnterior, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtCargoActual = CargoRepository.ListarCargos(con);
                RefreshService.RefrescarComboDT(CbCargoUsuarioActual, dtCargoActual, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtCargoAnterior = CargoRepository.ListarCargos(con);
                RefreshService.RefrescarComboDT(CbCargoUsuarioAnterior, dtCargoAnterior, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtEstadoArticulos = EstadoRepository.ListarEstadosArticulos(con);
                RefreshService.RefrescarComboDT(CbEstadoArticulo, dtEstadoArticulos, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtCondicion = CondicionRepository.ListarCondicion(con);
                RefreshService.RefrescarComboDT(CbCondicion, dtCondicion, "Nombre", "Id", Idiomas.OpcionSeleccione);

                var dtUbicacion = UbicacionRepository.ListarUbicacion(con);
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
                    CbMarcas.SelectedIndex = CbMarcas.FindStringExact(DatosEdicion.Marca);
                    CbAreaUsuarioActual.SelectedIndex = CbAreaUsuarioActual.FindStringExact(DatosEdicion.Area1);
                    CbCargoUsuarioActual.SelectedIndex = CbCargoUsuarioActual.FindStringExact(DatosEdicion.Cargo1);
                    CbAreaUsuarioAnterior.SelectedIndex = CbAreaUsuarioAnterior.FindStringExact(DatosEdicion.Area2);
                    CbCargoUsuarioAnterior.SelectedIndex = CbCargoUsuarioAnterior.FindStringExact(DatosEdicion.Cargo2);
                    CbEstadoArticulo.SelectedIndex = CbEstadoArticulo.FindStringExact(DatosEdicion.Estado);
                    CbUbicacion.SelectedIndex = CbUbicacion.FindStringExact(DatosEdicion.Ubicacion);
                    CbCondicion.SelectedIndex = CbCondicion.FindStringExact(DatosEdicion.Condicion);
                }
            }
            ClassHelper.AplicarTema(this);
            ClassHelper.AplicarFormatoFecha(DtpFechaFinGarantia);
            ClassHelper.AplicarFormatoFecha(DtpFechaBaja);
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

        private void ChkFechaBaja_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFechaBaja.Checked)
                DtpFechaBaja.Enabled = true;
            else
                DtpFechaBaja.Enabled = false;
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

        private void CbAreaUsuarioAnterior_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbAreaUsuarioAnterior);
        }

        private void CbAreaUsuarioActual_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexto(CbAreaUsuarioActual);
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
                        // Guardar valores actuales
                        TxtDniUsuarioAnterior.Text = dniTemporal;
                        var Nombre1 = TxtNombreUsuarioActual.Text;
                        var IdArea1 = CbAreaUsuarioActual.SelectedValue;
                        var Area1 = CbAreaUsuarioActual.Text;
                        var IdCargo1 = CbCargoUsuarioActual.SelectedValue;
                        var Cargo1 = CbCargoUsuarioActual.Text;

                        // Cargar usaurio actual
                        TxtNombreUsuarioActual.Text = emp.Nombres;
                        CbAreaUsuarioActual.SelectedValue = emp.IdArea;
                        CbAreaUsuarioActual.Text = emp.Area;
                        CbCargoUsuarioActual.Text = emp.Cargo;
                        CbCargoUsuarioActual.SelectedValue = emp.IdCargo;

                        // Cargar usuario anterior
                        if (dniTemporal == TxtDniUsuarioActual.Text)
                        {
                            dniTemporal = "";
                        }

                        dniTemporal = TxtDniUsuarioAnterior.Text;
                        TxtNombreUsuarioAnterior.Text = Nombre1;
                        CbAreaUsuarioAnterior.SelectedValue = IdArea1;
                        CbAreaUsuarioAnterior.Text = Area1;
                        CbCargoUsuarioAnterior.SelectedValue = IdCargo1;
                        CbCargoUsuarioAnterior.Text = Cargo1;
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
            if (ChkAuto.Checked)
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
            if (ChkAuto.Checked)
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
    }
}

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
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text))
            {
                ErrorArticulos.SetError(TxtCodigo, "El campo código no puede quedar vacío.");
                valido = false;
            }
            
            if (string.IsNullOrWhiteSpace(TxtModelo.Text))
            {
                ErrorArticulos.SetError(TxtModelo, "El campo modelo no puede quedar vacío.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(TxtSerie.Text))
            {
                ErrorArticulos.SetError(TxtSerie, "El campo serie no puede quedar vacío.");
            }

            if (CbMarcas.Text == "SELECCIONE" || CbMarcas.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbMarcas, "Debe seleccionar una marca válida.");
            }

            if (ChkFechaBaja.Checked || ChkFechaGarantia.Checked)
            {
                if (DtpFechaBaja.Value < DtpFechaAdquisicion.Value)
                {
                    ErrorArticulos.SetError(DtpFechaBaja, "La fecha de baja no puede ser menor a la fecha de adquisición.");
                }

                if (DtpFechaFinGarantia.Value < DtpFechaAdquisicion.Value)
                {
                    ErrorArticulos.SetError(DtpFechaFinGarantia, "La fecha del fin de garantía no puede ser menor a la fecha de adquisición.");
                }
            }
            
            if (string.IsNullOrWhiteSpace(TxtDniUsuarioActual.Text))
            {
                ErrorArticulos.SetError(TxtDniUsuarioActual, "El campo DNI no puede quedar vacío.");
            }

            if (CbEstadoArticulo.Text == "SELECCIONE" || CbEstadoArticulo.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbEstadoArticulo, "Debe seleccionar un estado válido.");
            }

            if (CbUbicacion.Text == "SELECCIONE" || CbUbicacion.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbUbicacion, "Debe seleccionar una ubicación válida.");
            }

            if (CbCondicion.Text == "SELECCIONE" || CbCondicion.SelectedIndex == 0)
            {
                ErrorArticulos.SetError(CbCondicion, "Debe seleccionar una condición válida.");
            }

            if (string.IsNullOrWhiteSpace(TxtDireccionImagen.Text))
            {
                ErrorArticulos.SetError(TxtDireccionImagen, "Debe seleccionar una foto para el articulo.");
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

                        if(nuevoLblWidth < lblPreferred)
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
                string carpetaComprobantes = ConexionGlobal.ObtenerCarpetaComprobantes();
                string carpetaImagenes = ConexionGlobal.ObtenerCarpetaImagenes();
                if (VistaInventario.isEdit == false)
                {
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
                                ActivoFijo = string.IsNullOrWhiteSpace(TxtActivoFijo.Text) ? null : TxtActivoFijo.Text,
                                Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                                RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                                Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                                PrecioAdquisicion = string.IsNullOrWhiteSpace(TxtPrecio.Text) ? (decimal?)null : Convert.ToDecimal(TxtPrecio.Text),

                                FechaRegistro = DateTime.Now,

                                CategoriaId = _categoriaId,
                                Categoria = _categoria
                            };

                            // guardar Foto
                            if(!string.IsNullOrWhiteSpace(TxtDireccionImagen.Text)&& File.Exists(TxtDireccionImagen.Text))
                            {
                                string nombreImagen = Path.GetFileName(TxtDireccionImagen.Text);
                                string destinoImagen = Path.Combine(carpetaImagenes, nombreImagen);

                                File.Copy(TxtDireccionImagen.Text, destinoImagen, true);
                                art.FotoPrincipal = TxtDireccionImagen.Text;
                                art.FotoSecundaria = destinoImagen;
                            }

                            // guardar comprobante
                            if(!string.IsNullOrWhiteSpace(TxtRutaComprobante.Text) && File.Exists(TxtRutaComprobante.Text))
                            {
                                string nombreComprobate = Path.GetFileName(TxtRutaComprobante.Text);
                                string destinoComprobante = Path.Combine(carpetaComprobantes, nombreComprobate);

                                File.Copy(TxtRutaComprobante.Text, destinoComprobante, true);
                                art.ComprobantePrincipal = TxtRutaComprobante.Text;
                                art.ComprobanteSecundaria = destinoComprobante;
                            }

                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show("La fecha de garantía o fecha de baja es anterior a la fecha actual. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            ArticuloRepository.InsertarArticulo(art, con);

                            MessageBox.Show("Artículo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el artículo: " + ex.Message, "Error",
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
                                ActivoFijo = string.IsNullOrWhiteSpace(TxtActivoFijo.Text) ? null : TxtActivoFijo.Text,
                                Observacion = string.IsNullOrWhiteSpace(TxtObservaciones.Text) ? null : TxtObservaciones.Text,

                                RucProveedor = string.IsNullOrWhiteSpace(TxtRuc.Text) ? null : TxtRuc.Text,
                                Proveedor = string.IsNullOrWhiteSpace(TxtRazonSocial.Text) ? null : TxtRazonSocial.Text,
                                PrecioAdquisicion = string.IsNullOrWhiteSpace(TxtPrecio.Text) ? (decimal?)null : Convert.ToDecimal(TxtPrecio.Text),

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

                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show("La fecha de garantía o fecha de baja es anterior a la fecha actual. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                            {
                                var result = MessageBox.Show("La fecha de garantía o fecha de baja es anterior a la fecha actual. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }

                            ArticuloRepository.ActualizarArticulo(art);

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
                        MessageBox.Show("Error al actualizar el artículo: " + ex.Message, "Error",
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
                string carpetaComprobantes = ConexionGlobal.ObtenerCarpetaComprobantes();
                string carpetaImagenes = ConexionGlobal.ObtenerCarpetaImagenes();
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
                            PrecioAdquisicion = string.IsNullOrWhiteSpace(TxtPrecio.Text) ? (decimal?)null : Convert.ToDecimal(TxtPrecio.Text),

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

                        if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                        {
                            var result = MessageBox.Show("La fecha de garantía o fecha de baja es anterior a la fecha actual. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                                return;
                        }

                        if ((ChkFechaGarantia.Checked && DtpFechaFinGarantia.Value < DateTime.Now) || (ChkFechaBaja.Checked && DtpFechaBaja.Value < DateTime.Now))
                        {
                            var result = MessageBox.Show("La fecha de garantía o fecha de baja es anterior a la fecha actual. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                                return;
                        }

                        ArticuloRepository.InsertarArticulo(art, con);

                        MessageBox.Show("Artículo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el artículo: " + ex.Message, "Error",
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
                        MessageBox.Show("No se pudo cargar el comprobante: " + ex.Message, "Error",
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
                        PbFotoArticulo.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen: " + ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void VistaArticulos_Load(object sender, EventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                var dtAreaActual = AreaRepository.ListarAreas(con); 
                RefreshService.RefrescarComboDT(CbAreaUsuarioActual, dtAreaActual, "Nombre", "Id", "SELECCIONE");

                var dtAreaAnterior = AreaRepository.ListarAreas(con);
                RefreshService.RefrescarComboDT(CbAreaUsuarioAnterior, dtAreaAnterior, "Nombre", "Id", "SELECCIONE");

                var dtCargoActual = CargoRepository.ListarCargos(con);
                RefreshService.RefrescarComboDT(CbCargoUsuarioActual, dtCargoActual, "Nombre", "Id", "SELECCIONE");

                var dtCargoAnterior = CargoRepository.ListarCargos(con);
                RefreshService.RefrescarComboDT(CbCargoUsuarioAnterior, dtCargoAnterior, "Nombre", "Id", "SELECCIONE");

                var dtEstadoArticulos = EstadoRepository.ListarEstadosArticulos(con);
                RefreshService.RefrescarComboDT(CbEstadoArticulo, dtEstadoArticulos, "Nombre", "Id", "SELECCIONE");

                var dtCondicion = CondicionRepository.ListarCondicion(con);
                RefreshService.RefrescarComboDT(CbCondicion, dtCondicion, "Nombre", "Id", "SELECCIONE");

                var dtUbicacion = UbicacionRepository.ListarUbicacion(con);
                RefreshService.RefrescarComboDT(CbUbicacion, dtUbicacion, "Nombre", "Id", "SELECCIONE");

                var dtMarcas = MarcasRepository.ListarMarcas(con, _categoriaId);
                RefreshService.RefrescarComboDT(CbMarcas, dtMarcas, "Nombre", "Id", "SELECCIONE");

                if(VistaInventario.isEdit==true)
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
            if(ChkFechaGarantia.Checked)
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
            ClassHelper.NormalizarTexro(CbEstadoArticulo);
        }

        private void CbAreaUsuarioAnterior_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexro(CbAreaUsuarioAnterior);
        }

        private void CbAreaUsuarioActual_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexro(CbAreaUsuarioActual);
        }

        private void CbCondicion_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexro(CbCondicion);
        }

        private void CbMarcas_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexro(CbMarcas);
        }

        private void CbUbicacion_TextUpdate(object sender, EventArgs e)
        {
            ClassHelper.NormalizarTexro(CbUbicacion);
        }

        private void BtnAgregarRUC_Click(object sender, EventArgs e)
        {
            // En desarrollo
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
                        if(dniTemporal == TxtDniUsuarioActual.Text)
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
                    MessageBox.Show("No se encontró ningún empleado con el DNI ingresado. Por favor, verifique el número.",
                    "Búsqueda de Empleado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                }
            }
        }

        private void TxtDniUsuarioActual_Enter(object sender, EventArgs e)
        {
            dniTemporal = TxtDniUsuarioActual.Text;
        }
    }
}

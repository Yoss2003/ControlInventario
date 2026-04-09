using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.API;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Aplicacion
{
    public partial class VistaVentas : Form
    {
        private DataTable dtStockDisponible;
        private decimal totalVenta = 0m;
        public EdicionArticulo DatosEdicion { get; set; }
        public VistaVentas()
        {
            InitializeComponent();
        }

        private void BtnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            using (VistaBusquedaAvanzada buscador = new VistaBusquedaAvanzada())
            {
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    TxtBuscarArticulo.Text = buscador.CodigoSeleccionado;
                    TxtBuscarArticulo_KeyDown(this, new KeyEventArgs(Keys.Enter));
                }
            }
        }

        private void VistaVentas_Load(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Now;
            BtnCompletarVenta.Enabled = false;

            CbTipoComprobante.Items.AddRange(new string[] { "Boleta", "Factura" });
            CbTipoComprobante.SelectedIndex = 0;

            CbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia", "Yape/Plin" });
            CbMetodoPago.SelectedIndex = 0;

            DgvArticulos.AutoGenerateColumns = false;
            DgvArticulos.AllowUserToAddRows = false;
            DgvArticulos.ReadOnly = false;

            LblTotal.TextAlign = ContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in DgvArticulos.Columns)
            {
                if (col.Name != "CantidadArticulo") col.ReadOnly = true;

                if (col is DataGridViewButtonColumn btnCol)
                {
                    btnCol.UseColumnTextForButtonValue = true;
                    btnCol.Text = "Quitar";
                    btnCol.FlatStyle = FlatStyle.Flat;
                }
            }

            dtStockDisponible = ArticuloRepository.ListarInventarioCompleto(UsuarioSesion.InventarioId);
            LblVuelto.Text = $"{ClassHelper.ObtenerSimboloMoneda()} 0,00";
            TxtMontoRecibido.Text = $"{ClassHelper.ObtenerSimboloMoneda()} 0,00";

            this.Click += Fondo_Click;
            ConfigurarPerdidaDeFoco(this);
        }

        private void ActualizarLabelTotal()
        {
            LblTotal.Text = $"TOTAL: {ClassHelper.ObtenerSimboloMoneda()} {totalVenta:N2}";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarYAgregarAlCarrito();
        }

        private void BuscarYAgregarAlCarrito()
        {
            string codigoBuscado = TxtBuscarArticulo.Text.Trim();
            if (string.IsNullOrEmpty(codigoBuscado)) return;

            DataRow[] resultados = dtStockDisponible.Select($"Codigo = '{codigoBuscado}'");
            if (resultados.Length == 0)
            {
                MessageBox.Show("Equipo no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtBuscarArticulo.SelectAll();
                return;
            }

            DataRow art = resultados[0];
            string modeloArticulo = art["Modelo"].ToString();

            bool existeEnCarrito = false;
            foreach (DataGridViewRow fila in DgvArticulos.Rows)
            {
                if (fila.Cells["ModeloArticulo"].Value?.ToString() == modeloArticulo)
                {
                    int cantActual = Convert.ToInt32(fila.Cells["CantidadArticulo"].Value);
                    fila.Cells["CantidadArticulo"].Value = cantActual + 1;
                    existeEnCarrito = true;
                    break;
                }
            }

            if (!existeEnCarrito)
            {
                int idArticulo = Convert.ToInt32(art["Id"]);
                decimal precioBD = art["PrecioAdquisicion"] != DBNull.Value ? Convert.ToDecimal(art["PrecioAdquisicion"]) : 0m;

                string monedaBD = art["MonedaAdquisicion"] != DBNull.Value ? art["MonedaAdquisicion"].ToString() : "Soles";
                decimal precioLocal = ClassHelper.ConvertirBDAMonedaLocal(precioBD, monedaBD) ?? 0m;
                int rowIndex = DgvArticulos.Rows.Add(modeloArticulo, precioLocal, 1, precioLocal);
                DgvArticulos.Rows[rowIndex].Tag = idArticulo;
            }

            TxtBuscarArticulo.Clear();
            CalcularTotalesGlobales();
        }

        private void DgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvArticulos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DgvArticulos.EndEdit();
                DgvArticulos.Rows.RemoveAt(e.RowIndex);
                CalcularTotalesGlobales();
            }
        }

        private void CalcularTotalesGlobales()
        {
            totalVenta = 0m;
            foreach (DataGridViewRow row in DgvArticulos.Rows)
            {
                if (row.Cells["SubtotalArticulo"].Value != null)
                {
                    totalVenta += Convert.ToDecimal(row.Cells["SubtotalArticulo"].Value);
                }
            }

            ActualizarLabelTotal();
            BtnCompletarVenta.Enabled = (DgvArticulos.Rows.Count > 0);
            CalcularVuelto();
        }

        private void CalcularVuelto()
        {
            decimal? montoRecibido = ClassHelper.LimpiarTextoParaEdicion(TxtMontoRecibido.Text);

            if (montoRecibido.HasValue)
            {
                decimal vuelto = montoRecibido.Value - totalVenta;
                if (vuelto < 0)
                {
                    LblVuelto.Text = $"Faltan: {ClassHelper.ObtenerSimboloMoneda()} {Math.Abs(vuelto):N2}";
                    LblVuelto.ForeColor = Color.Red;
                }
                else
                {
                    LblVuelto.Text = $"{ClassHelper.ObtenerSimboloMoneda()} {vuelto:N2}";
                    LblVuelto.ForeColor = Color.Green;
                }
            }
            else
            {
                LblVuelto.Text = $"{ClassHelper.ObtenerSimboloMoneda()} 0,00";
                LblVuelto.ForeColor = Color.Black;
            }
        }

        private void LblVuelto_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }

        private void BtnCompletarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCliente.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del cliente.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCliente.Focus();
                return;
            }

            if (CbMetodoPago.Text == "Efectivo")
            {
                decimal? pago = ClassHelper.LimpiarTextoParaEdicion(TxtMontoRecibido.Text);

                if (!pago.HasValue || Math.Round(pago.Value, 2) < Math.Round(totalVenta, 2))
                {
                    decimal falta = Math.Round(totalVenta, 2) - Math.Round((pago ?? 0), 2);
                    MessageBox.Show($"El monto recibido no cubre el total de la venta.\n\nFalta: {ClassHelper.ObtenerSimboloMoneda()} {falta:N2}", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMontoRecibido.Focus();
                    return;
                }
            }

            DialogResult confirmacion = MessageBox.Show($"¿Desea completar la venta a {TxtCliente.Text} por {LblTotal.Text}?", "Confirmar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                GuardarVentaEnBD();
            }
        }

        private void GuardarVentaEnBD()
        {
            string cliente = TxtCliente.Text.Trim();
            string doc = TxtDocumento.Text.Trim();
            string comprobante = CbTipoComprobante.Text;
            string metodoPago = CbMetodoPago.Text;
            string obsGeneral = TxtObservaciones.Text.Trim();

            List<Movimiento> movimientosVenta = new List<Movimiento>();

            foreach (DataGridViewRow row in DgvArticulos.Rows)
            {
                string modeloArt = row.Cells["ModeloArticulo"].Value.ToString();
                int cantidadVendida = Convert.ToInt32(row.Cells["CantidadArticulo"].Value);
                decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioArticulo"].Value);

                List<int> idsFisicosSeleccionados = MostrarSelectorDeCodigos(modeloArt, cantidadVendida);

                if (idsFisicosSeleccionados == null)
                {
                    MessageBox.Show("Venta cancelada. Debe seleccionar los códigos a entregar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (int idFisico in idsFisicosSeleccionados)
                {
                    movimientosVenta.Add(new Movimiento
                    {
                        ArticuloId = idFisico,
                        IdAccion = 2,
                        FechaMovimiento = DtpFecha.Value,
                        Observacion = obsGeneral,
                        Monto = precioUnitario,
                        Destinatario = cliente,
                        PrecioVenta = precioUnitario,
                        Documento = doc,
                        MetodoPago = metodoPago,
                        TipoComprobante = comprobante
                    });
                }
            }

            try
            {
                MovimientoRepository.RegistrarVenta(movimientosVenta);
                MessageBox.Show("¡Venta procesada y registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBuscarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarYAgregarAlCarrito();
            }
        }

        private void DgvArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && (DgvArticulos.Columns[e.ColumnIndex].Name == "PrecioArticulo" || DgvArticulos.Columns[e.ColumnIndex].Name == "SubtotalArticulo"))
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    e.Value = $"{ClassHelper.ObtenerSimboloMoneda()} {valor:N2}";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DgvArticulos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvArticulos.Columns[e.ColumnIndex].Name == "CantidadArticulo")
            {
                var row = DgvArticulos.Rows[e.RowIndex];
                string modeloActual = row.Cells["ModeloArticulo"].Value?.ToString();
                int stockMaximo = dtStockDisponible.Select($"Modelo = '{modeloActual}'").Length;

                if (int.TryParse(row.Cells["CantidadArticulo"].Value?.ToString(), out int cantidad))
                {
                    if (cantidad > stockMaximo)
                    {
                        MessageBox.Show($"Stock insuficiente. Solo hay {stockMaximo} unidades disponibles.", "Límite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["CantidadArticulo"].Value = stockMaximo;
                        return;
                    }
                    else if (cantidad > 0)
                    {
                        decimal precio = Convert.ToDecimal(row.Cells["PrecioArticulo"].Value);
                        row.Cells["SubtotalArticulo"].Value = precio * cantidad;
                        CalcularTotalesGlobales();
                    }
                    else
                    {
                        row.Cells["CantidadArticulo"].Value = 1;
                    }
                }
            }
        }

        private async void TxtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string doc = TxtDocumento.Text.Trim();
                if (string.IsNullOrEmpty(doc)) return;

                if (doc.Length == 8)
                {
                    var emp = EmpleadoRepository.ObtenerEmpleadoPorDni(doc);
                    if (emp != null)
                    {
                        TxtCliente.Text = $"{emp.Nombres} {emp.Apellidos}";
                        TxtBuscarArticulo.Focus();
                        return;
                    }

                    var overlay = new OverlayCarga(this);
                    overlay.Mostrar();
                    try
                    {
                        var personaApi = await ApiHelper.ConsultarDniAsync(doc);
                        if (personaApi != null)
                        {
                            TxtCliente.Text = $"{personaApi.nombres} {personaApi.apellidoPaterno} {personaApi.apellidoMaterno}";
                            TxtBuscarArticulo.Focus();
                            return;
                        }
                    }
                    finally
                    {
                        overlay.Ocultar();
                    }
                }
                else if (doc.Length == 11)
                {
                    var prov = ProveedorRepository.ObtenerProveedorPorRUC(doc);
                    if (prov != null)
                    {
                        TxtCliente.Text = prov.RazonSocial;
                        TxtBuscarArticulo.Focus();
                        return;
                    }

                    var overlay = new OverlayCarga(this);
                    overlay.Mostrar();
                    try
                    {
                        var empresaApi = await ApiHelper.ConsultarRucAsync(doc);
                        if (empresaApi != null)
                        {
                            TxtCliente.Text = empresaApi.nombre;
                            TxtBuscarArticulo.Focus();
                            return;
                        }
                    }
                    finally
                    {
                        overlay.Ocultar();
                    }
                }

                MessageBox.Show("Documento no encontrado en los registros ni en la API.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCliente.Focus();
            }
        }

        private void TxtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }

        private void TxtMontoRecibido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtMontoRecibido_Enter(object sender, EventArgs e)
        {
            decimal? numeroPuro = ClassHelper.LimpiarTextoParaEdicion(TxtMontoRecibido.Text);

            if (numeroPuro.HasValue)
            {
                if (numeroPuro.Value == 0)
                {
                    TxtMontoRecibido.Text = "";
                }
                else if (numeroPuro.Value % 1 == 0)
                {
                    TxtMontoRecibido.Text = numeroPuro.Value.ToString("0");
                }                
                else
                {
                    TxtMontoRecibido.Text = numeroPuro.Value.ToString("0,00");
                }
            }
            else
            {
                TxtMontoRecibido.Text = "";
            }
        }

        private void TxtMontoRecibido_Leave(object sender, EventArgs e)
        {
            decimal? numeroPuro = ClassHelper.LimpiarTextoParaEdicion(TxtMontoRecibido.Text);

            if (numeroPuro.HasValue)
                TxtMontoRecibido.Text = $"{ClassHelper.ObtenerSimboloMoneda()} {numeroPuro.Value:N2}";
            else
                TxtMontoRecibido.Text = $"{ClassHelper.ObtenerSimboloMoneda()} 0,00";

            CalcularVuelto();
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

        private void TxtMontoRecibido_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private List<int> MostrarSelectorDeCodigos(string modelo, int cantidadRequerida)
        {
            List<int> idsSeleccionados = new List<int>();
            DataRow[] disponibles = dtStockDisponible.Select($"Modelo = '{modelo}'");

            Form selector = new Form()
            {
                Text = $"Seleccione {cantidadRequerida} código(s) para: {modelo}",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            CheckedListBox checklist = new CheckedListBox()
            {
                Dock = DockStyle.Top,
                Height = 200,
                CheckOnClick = true
            };

            foreach (DataRow fila in disponibles)
            {
                string serie = fila["Serie"] != DBNull.Value ? fila["Serie"].ToString() : "N/A";
                checklist.Items.Add(new KeyValuePair<int, string>(
                    Convert.ToInt32(fila["Id"]),
                    $"{fila["Codigo"]} - Serie: {serie}"
                ));
            }

            checklist.DisplayMember = "Value";
            checklist.ValueMember = "Key";

            Button btnConfirmar = new Button() { Text = "Confirmar Selección", Dock = DockStyle.Bottom, Height = 40, BackColor = Color.LightGreen };

            btnConfirmar.Click += (s, ev) =>
            {
                if (checklist.CheckedItems.Count != cantidadRequerida)
                {
                    MessageBox.Show($"Debe marcar exactamente {cantidadRequerida} artículos de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var item in checklist.CheckedItems)
                {
                    var articuloSeleccionado = (KeyValuePair<int, string>)item;
                    idsSeleccionados.Add(articuloSeleccionado.Key);
                }

                selector.DialogResult = DialogResult.OK;
            };

            selector.Controls.Add(checklist);
            selector.Controls.Add(btnConfirmar);

            if (selector.ShowDialog() == DialogResult.OK)
                return idsSeleccionados;
            else
                return null;
        }
    }
}

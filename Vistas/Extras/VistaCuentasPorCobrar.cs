using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Aplicacion
{
    public partial class VistaCuentasPorCobrar : Form
    {
        private DataTable dtCuentas;
        private TextBox TxtFiltroCliente;
        private ComboBox CbFiltroEstado;
        private DataGridView DgvCuentas;
        private Label LblResumen;
        private Button BtnRegistrarAbono;
        private Button BtnRenegociar;
        private Button BtnRecuperarArticulo;
        private Button BtnMarcarPerdida;
        private Button BtnBuscar;
        private Button BtnLimpiar;

        public VistaCuentasPorCobrar()
        {
            InitializeComponent();
            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            this.Text = "Cuentas por Cobrar";
            this.ClientSize = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ShowIcon = false;

            // === PANEL FILTROS ===
            GroupBox grpFiltros = new GroupBox
            {
                Text = "Filtros de Búsqueda",
                Location = new Point(12, 8),
                Size = new Size(1070, 70)
            };

            Label lblCliente = new Label { Text = "Cliente / Documento:", Location = new Point(10, 28), AutoSize = true };
            TxtFiltroCliente = new TextBox
            {
                Location = new Point(170, 25),
                Size = new Size(250, 26),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblEstado = new Label { Text = "Estado:", Location = new Point(440, 28), AutoSize = true };
            CbFiltroEstado = new ComboBox
            {
                Location = new Point(500, 25),
                Size = new Size(150, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            CbFiltroEstado.Items.AddRange(new string[] { "Todos", "Pendiente", "Vencida", "Pagada", "Renegociada", "Cancelada" });
            CbFiltroEstado.SelectedIndex = 0;

            BtnBuscar = new Button { Text = "Buscar", Location = new Point(680, 22), Size = new Size(100, 35), Cursor = Cursors.Hand };
            BtnBuscar.Click += (s, e) => CargarCuentas();

            BtnLimpiar = new Button { Text = "Limpiar", Location = new Point(790, 22), Size = new Size(100, 35), Cursor = Cursors.Hand };
            BtnLimpiar.Click += (s, e) => { TxtFiltroCliente.Clear(); CbFiltroEstado.SelectedIndex = 0; CargarCuentas(); };

            grpFiltros.Controls.AddRange(new Control[] { lblCliente, TxtFiltroCliente, lblEstado, CbFiltroEstado, BtnBuscar, BtnLimpiar });
            this.Controls.Add(grpFiltros);

            // === GRILLA ===
            DgvCuentas = new DataGridView
            {
                Location = new Point(12, 85),
                Size = new Size(1070, 420),
                AllowUserToAddRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            DgvCuentas.SelectionChanged += DgvCuentas_SelectionChanged;
            ClassHelper.AplicarEstilosGrillas(DgvCuentas);
            this.Controls.Add(DgvCuentas);

            // === RESUMEN ===
            LblResumen = new Label
            {
                Location = new Point(12, 515),
                Size = new Size(700, 25),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            this.Controls.Add(LblResumen);

            // === PANEL ACCIONES ===
            GroupBox grpAcciones = new GroupBox
            {
                Text = "Acciones",
                Location = new Point(12, 545),
                Size = new Size(1070, 90)
            };

            BtnRegistrarAbono = new Button
            {
                Text = "💰 Registrar Abono",
                Location = new Point(15, 30),
                Size = new Size(200, 45),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            BtnRegistrarAbono.Click += BtnRegistrarAbono_Click;

            BtnRenegociar = new Button
            {
                Text = "📋 Renegociar Cuotas",
                Location = new Point(230, 30),
                Size = new Size(200, 45),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            BtnRenegociar.Click += BtnRenegociar_Click;

            BtnRecuperarArticulo = new Button
            {
                Text = "🔄 Recuperar Artículo",
                Location = new Point(445, 30),
                Size = new Size(200, 45),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            BtnRecuperarArticulo.Click += BtnRecuperarArticulo_Click;

            BtnMarcarPerdida = new Button
            {
                Text = "❌ Marcar como Pérdida",
                Location = new Point(660, 30),
                Size = new Size(200, 45),
                Cursor = Cursors.Hand,
                Enabled = false,
                ForeColor = Color.DarkRed
            };
            BtnMarcarPerdida.Click += BtnMarcarPerdida_Click;

            grpAcciones.Controls.AddRange(new Control[] { BtnRegistrarAbono, BtnRenegociar, BtnRecuperarArticulo, BtnMarcarPerdida });
            this.Controls.Add(grpAcciones);

            this.Load += VistaCuentasPorCobrar_Load;
        }

        private void VistaCuentasPorCobrar_Load(object sender, EventArgs e)
        {
            // Aplicar moras si está configurado
            var config = UsuarioSesion.Configuracion;
            if (config != null && config.AplicarMora)
            {
                CuentasPorCobrarRepository.AplicarMoras(UsuarioSesion.InventarioId, config.PorcentajeMora, config.DiasGracia);
            }

            CargarCuentas();
            ClassHelper.AplicarTema(this);
        }

        private void CargarCuentas()
        {
            string cliente = TxtFiltroCliente.Text.Trim();
            string estado = CbFiltroEstado.GetItemText(CbFiltroEstado.SelectedItem);

            dtCuentas = CuentasPorCobrarRepository.ListarResumenCuentas(UsuarioSesion.InventarioId, estado, cliente);

            DgvCuentas.DataSource = null;
            DgvCuentas.Columns.Clear();
            DgvCuentas.AutoGenerateColumns = false;

            // Crear columnas manualmente para control total
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCliente", HeaderText = "Cliente", DataPropertyName = "Destinatario" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColDocumento", HeaderText = "Documento", DataPropertyName = "Documento" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColArticulo", HeaderText = "Artículo", DataPropertyName = "ArticuloCodigo" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColModelo", HeaderText = "Modelo", DataPropertyName = "ArticuloModelo" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCuota", HeaderText = "N°", DataPropertyName = "NumeroCuota", Width = 40 });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColMonto", HeaderText = "Monto", DataPropertyName = "MontoCuota" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColPagado", HeaderText = "Pagado", DataPropertyName = "MontoPagado" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColMora", HeaderText = "Mora", DataPropertyName = "MontoMora" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColSaldo", HeaderText = "Saldo", DataPropertyName = "Saldo" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColVencimiento", HeaderText = "Vencimiento", DataPropertyName = "FechaVencimiento" });
            DgvCuentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColEstado", HeaderText = "Estado", DataPropertyName = "Estado" });

            DgvCuentas.DataSource = dtCuentas;

            // Formato visual
            DgvCuentas.CellFormatting += DgvCuentas_CellFormatting;

            // Resumen
            decimal totalPendiente = 0;
            int cuotasVencidas = 0;
            foreach (DataRow row in dtCuentas.Rows)
            {
                decimal saldo = Convert.ToDecimal(row["Saldo"]);
                string est = row["Estado"].ToString();
                if (est == "Pendiente" || est == "Vencida") totalPendiente += saldo;
                if (est == "Vencida") cuotasVencidas++;
            }

            string simbolo = ClassHelper.ObtenerSimboloMoneda();
            LblResumen.Text = $"Total pendiente: {simbolo} {totalPendiente:N2}  |  Cuotas vencidas: {cuotasVencidas}";
        }

        private void DgvCuentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = DgvCuentas.Columns[e.ColumnIndex].Name;
            string simbolo = ClassHelper.ObtenerSimboloMoneda();
            string formato = UsuarioSesion.Configuracion?.FormatoFecha ?? "dd/MM/yyyy";

            // Formato moneda
            if (colName == "ColMonto" || colName == "ColPagado" || colName == "ColMora" || colName == "ColSaldo")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = $"{simbolo} {val:N2}";
                    e.FormattingApplied = true;
                }
            }

            // Formato fecha
            if (colName == "ColVencimiento" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime fecha))
                {
                    e.Value = fecha.ToString(formato);
                    e.FormattingApplied = true;
                }
            }

            // Color por estado
            if (colName == "ColEstado" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "Vencida":
                        DgvCuentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        DgvCuentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "Pagada":
                        DgvCuentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                        DgvCuentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case "Renegociada":
                        DgvCuentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 220);
                        DgvCuentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                        break;
                }
            }
        }

        private void DgvCuentas_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = DgvCuentas.CurrentRow != null;
            string estado = haySeleccion ? DgvCuentas.CurrentRow.Cells["ColEstado"].Value?.ToString() : "";
            bool esPendienteOVencida = estado == "Pendiente" || estado == "Vencida";

            BtnRegistrarAbono.Enabled = esPendienteOVencida;
            BtnRenegociar.Enabled = esPendienteOVencida;
            BtnMarcarPerdida.Enabled = esPendienteOVencida;

            // Recuperar solo si es devolvible
            if (haySeleccion && esPendienteOVencida)
            {
                bool esDevolvible = Convert.ToBoolean(DgvCuentas.CurrentRow.Cells["ColEstado"].DataGridView.Rows[DgvCuentas.CurrentRow.Index].DataBoundItem is DataRowView drv
                    && dtCuentas.Columns.Contains("EsDevolvible")
                    && drv["EsDevolvible"] != DBNull.Value
                    && Convert.ToInt32(drv["EsDevolvible"]) == 1);
                BtnRecuperarArticulo.Enabled = esDevolvible;
            }
            else
            {
                BtnRecuperarArticulo.Enabled = false;
            }
        }

        private void BtnRegistrarAbono_Click(object sender, EventArgs e)
        {
            if (DgvCuentas.CurrentRow == null) return;

            var drv = (DataRowView)DgvCuentas.CurrentRow.DataBoundItem;
            int cuotaId = Convert.ToInt32(drv["Id"]);
            decimal saldo = Convert.ToDecimal(drv["Saldo"]);
            string cliente = drv["Destinatario"].ToString();
            int numCuota = Convert.ToInt32(drv["NumeroCuota"]);
            string simbolo = ClassHelper.ObtenerSimboloMoneda();

            using (Form frmAbono = new Form
            {
                Text = $"Abonar a cuota #{numCuota} - {cliente}",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                Label lblSaldo = new Label { Text = $"Saldo pendiente: {simbolo} {saldo:N2}", Location = new Point(20, 20), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
                Label lblMonto = new Label { Text = "Monto a abonar:", Location = new Point(20, 60), AutoSize = true };
                TextBox txtMonto = new TextBox { Location = new Point(20, 85), Size = new Size(340, 26), BorderStyle = BorderStyle.FixedSingle };
                Label lblObs = new Label { Text = "Observación:", Location = new Point(20, 120), AutoSize = true };
                TextBox txtObs = new TextBox { Location = new Point(20, 145), Size = new Size(340, 26), BorderStyle = BorderStyle.FixedSingle };
                Button btnConfirmar = new Button { Text = "Confirmar Abono", Location = new Point(120, 185), Size = new Size(160, 40), BackColor = Color.LightGreen, Cursor = Cursors.Hand };

                btnConfirmar.Click += (s2, e2) =>
                {
                    decimal? monto = ClassHelper.LimpiarTextoParaEdicion(txtMonto.Text);
                    if (!monto.HasValue || monto.Value <= 0)
                    {
                        MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (monto.Value > saldo)
                    {
                        MessageBox.Show($"El abono no puede superar el saldo ({simbolo} {saldo:N2}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        using (var con = Database.ConexionGlobal.ObtenerConexion())
                        {
                            con.Open();
                            using (var transaction = con.BeginTransaction())
                            {
                                var pago = new PagoCuota
                                {
                                    CuotaId = cuotaId,
                                    MontoAbono = monto.Value,
                                    FechaPago = DateTime.Now,
                                    Observacion = txtObs.Text.Trim()
                                };
                                CuentasPorCobrarRepository.RegistrarAbono(pago, con, transaction);
                                transaction.Commit();
                            }
                        }

                        MessageBox.Show("Abono registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmAbono.Close();
                        CargarCuentas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                frmAbono.Controls.AddRange(new Control[] { lblSaldo, lblMonto, txtMonto, lblObs, txtObs, btnConfirmar });
                frmAbono.ShowDialog();
            }
        }

        private void BtnRenegociar_Click(object sender, EventArgs e)
        {
            if (DgvCuentas.CurrentRow == null) return;

            var drv = (DataRowView)DgvCuentas.CurrentRow.DataBoundItem;
            int movimientoId = Convert.ToInt32(drv["MovimientoId"]);
            string cliente = drv["Destinatario"].ToString();

            using (Form frmRenego = new Form
            {
                Text = $"Renegociar cuotas - {cliente}",
                Size = new Size(420, 280),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                Label lblCuotas = new Label { Text = "Nuevas cuotas:", Location = new Point(20, 25), AutoSize = true };
                NumericUpDown nudCuotas = new NumericUpDown { Location = new Point(20, 50), Size = new Size(120, 26), Minimum = 1, Maximum = 60, Value = 3 };

                Label lblFrec = new Label { Text = "Frecuencia:", Location = new Point(170, 25), AutoSize = true };
                ComboBox cbFrec = new ComboBox { Location = new Point(170, 50), Size = new Size(150, 28), DropDownStyle = ComboBoxStyle.DropDownList };
                cbFrec.Items.AddRange(new string[] { "Semanal", "Quincenal", "Mensual" });
                cbFrec.SelectedIndex = 2;

                Label lblFecha = new Label { Text = "Fecha 1ra nueva cuota:", Location = new Point(20, 95), AutoSize = true };
                DateTimePicker dtpFecha = new DateTimePicker { Location = new Point(20, 120), Size = new Size(200, 26), Format = DateTimePickerFormat.Short, Value = DateTime.Now.AddDays(15) };

                Button btnConfirmar = new Button { Text = "Confirmar Renegociación", Location = new Point(100, 170), Size = new Size(220, 45), BackColor = Color.LightYellow, Cursor = Cursors.Hand };

                btnConfirmar.Click += (s2, e2) =>
                {
                    if (dtpFecha.Value.Date <= DateTime.Now.Date)
                    {
                        MessageBox.Show("La fecha debe ser posterior a hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show("¿Confirmar la renegociación? Las cuotas pendientes se reemplazarán.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    try
                    {
                        CuentasPorCobrarRepository.RenegociarCuotas(movimientoId, (int)nudCuotas.Value, cbFrec.Text, dtpFecha.Value);
                        MessageBox.Show("Cuotas renegociadas exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmRenego.Close();
                        CargarCuentas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                frmRenego.Controls.AddRange(new Control[] { lblCuotas, nudCuotas, lblFrec, cbFrec, lblFecha, dtpFecha, btnConfirmar });
                frmRenego.ShowDialog();
            }
        }

        private void BtnRecuperarArticulo_Click(object sender, EventArgs e)
        {
            if (DgvCuentas.CurrentRow == null) return;

            var drv = (DataRowView)DgvCuentas.CurrentRow.DataBoundItem;
            int movimientoId = Convert.ToInt32(drv["MovimientoId"]);
            int articuloId = Convert.ToInt32(drv["ArticuloId"]);
            string codigo = drv["ArticuloCodigo"].ToString();
            string cliente = drv["Destinatario"].ToString();

            if (MessageBox.Show(
                $"¿Recuperar el artículo {codigo} de {cliente}?\n\nEsto cancelará todas las cuotas pendientes y devolverá el artículo al inventario.",
                "Confirmar Recuperación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                // 1. Cancelar cuotas pendientes
                CuentasPorCobrarRepository.CancelarCuotasPendientes(movimientoId, "Recuperación de artículo por impago");

                // 2. Devolver artículo al inventario
                ArticuloRepository.RegistrarDevolucion(articuloId, $"RECUPERACIÓN: Artículo {codigo} recuperado de {cliente} por incumplimiento de pago.");

                MessageBox.Show("Artículo recuperado y cuotas canceladas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCuentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMarcarPerdida_Click(object sender, EventArgs e)
        {
            if (DgvCuentas.CurrentRow == null) return;

            var drv = (DataRowView)DgvCuentas.CurrentRow.DataBoundItem;
            int movimientoId = Convert.ToInt32(drv["MovimientoId"]);
            int articuloId = Convert.ToInt32(drv["ArticuloId"]);
            string codigo = drv["ArticuloCodigo"].ToString();
            string cliente = drv["Destinatario"].ToString();

            if (MessageBox.Show(
                $"¿Marcar como PÉRDIDA el artículo {codigo} de {cliente}?\n\nEsto cancelará las cuotas y dará de baja el artículo.",
                "Confirmar Pérdida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                // 1. Cancelar cuotas
                CuentasPorCobrarRepository.CancelarCuotasPendientes(movimientoId, "Marcado como pérdida/deuda incobrable");

                // 2. Dar de baja el artículo (IdAccion = 6 = BAJA)
                using (var con = Database.ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        string queryArt = "UPDATE Articulos SET IdAccion = 6, FechaModificacion = @Fecha WHERE Id = @Id;";
                        using (var cmd = new System.Data.SQLite.SQLiteCommand(queryArt, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", articuloId);
                            cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.ExecuteNonQuery();
                        }

                        string queryMov = @"INSERT INTO Movimientos (ArticuloId, IdAccion, FechaMovimiento, Observacion, Monto)
                                            VALUES (@ArtId, 6, @Fecha, @Obs, 0);";
                        using (var cmd = new System.Data.SQLite.SQLiteCommand(queryMov, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ArtId", articuloId);
                            cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@Obs", $"PÉRDIDA: Deuda incobrable de {cliente} por artículo {codigo}");
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show("Artículo dado de baja y cuotas canceladas.", "Pérdida Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCuentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
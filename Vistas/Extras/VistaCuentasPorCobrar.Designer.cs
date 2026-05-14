namespace ControlInventario.Vistas.Aplicacion
{
    partial class VistaCuentasPorCobrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.CbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtFiltroCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.DgvCuentas = new System.Windows.Forms.DataGridView();
            this.LblResumen = new System.Windows.Forms.Label();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.BtnMarcarPerdida = new System.Windows.Forms.Button();
            this.BtnRecuperarArticulo = new System.Windows.Forms.Button();
            this.BtnRenegociar = new System.Windows.Forms.Button();
            this.BtnRegistrarAbono = new System.Windows.Forms.Button();
            this.Destinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCuentas)).BeginInit();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.BtnLimpiar);
            this.grpFiltros.Controls.Add(this.BtnBuscar);
            this.grpFiltros.Controls.Add(this.CbFiltroEstado);
            this.grpFiltros.Controls.Add(this.lblEstado);
            this.grpFiltros.Controls.Add(this.TxtFiltroCliente);
            this.grpFiltros.Controls.Add(this.lblCliente);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1054, 70);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de Búsqueda";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Location = new System.Drawing.Point(796, 22);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(100, 35);
            this.BtnLimpiar.TabIndex = 4;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Location = new System.Drawing.Point(680, 22);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(100, 35);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // CbFiltroEstado
            // 
            this.CbFiltroEstado.FormattingEnabled = true;
            this.CbFiltroEstado.Location = new System.Drawing.Point(510, 25);
            this.CbFiltroEstado.Name = "CbFiltroEstado";
            this.CbFiltroEstado.Size = new System.Drawing.Size(150, 28);
            this.CbFiltroEstado.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(440, 29);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            // 
            // TxtFiltroCliente
            // 
            this.TxtFiltroCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFiltroCliente.Location = new System.Drawing.Point(170, 26);
            this.TxtFiltroCliente.Name = "TxtFiltroCliente";
            this.TxtFiltroCliente.Size = new System.Drawing.Size(250, 26);
            this.TxtFiltroCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(10, 29);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(157, 20);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente / Documento:";
            // 
            // DgvCuentas
            // 
            this.DgvCuentas.AllowUserToAddRows = false;
            this.DgvCuentas.AllowUserToDeleteRows = false;
            this.DgvCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvCuentas.BackgroundColor = System.Drawing.Color.White;
            this.DgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destinatario,
            this.ColDocumento,
            this.ColArticulo,
            this.ColModelo,
            this.ColCuota,
            this.ColMonto,
            this.ColPagado,
            this.ColMora,
            this.ColSaldo,
            this.ColVencimiento,
            this.ColEstado});
            this.DgvCuentas.Location = new System.Drawing.Point(12, 88);
            this.DgvCuentas.Name = "DgvCuentas";
            this.DgvCuentas.ReadOnly = true;
            this.DgvCuentas.RowHeadersVisible = false;
            this.DgvCuentas.RowHeadersWidth = 62;
            this.DgvCuentas.RowTemplate.Height = 28;
            this.DgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCuentas.Size = new System.Drawing.Size(1054, 420);
            this.DgvCuentas.TabIndex = 1;
            this.DgvCuentas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvCuentas_CellFormatting);
            this.DgvCuentas.SelectionChanged += new System.EventHandler(this.DgvCuentas_SelectionChanged);
            // 
            // LblResumen
            // 
            this.LblResumen.AutoSize = true;
            this.LblResumen.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblResumen.ForeColor = System.Drawing.Color.DarkRed;
            this.LblResumen.Location = new System.Drawing.Point(12, 515);
            this.LblResumen.Name = "LblResumen";
            this.LblResumen.Size = new System.Drawing.Size(69, 28);
            this.LblResumen.TabIndex = 2;
            this.LblResumen.Text = "label1";
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.BtnMarcarPerdida);
            this.grpAcciones.Controls.Add(this.BtnRecuperarArticulo);
            this.grpAcciones.Controls.Add(this.BtnRenegociar);
            this.grpAcciones.Controls.Add(this.BtnRegistrarAbono);
            this.grpAcciones.Location = new System.Drawing.Point(12, 545);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(1070, 89);
            this.grpAcciones.TabIndex = 3;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Acciones";
            // 
            // BtnMarcarPerdida
            // 
            this.BtnMarcarPerdida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMarcarPerdida.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnMarcarPerdida.Location = new System.Drawing.Point(660, 30);
            this.BtnMarcarPerdida.Name = "BtnMarcarPerdida";
            this.BtnMarcarPerdida.Size = new System.Drawing.Size(200, 45);
            this.BtnMarcarPerdida.TabIndex = 3;
            this.BtnMarcarPerdida.Text = "Marcar como Pérdida";
            this.BtnMarcarPerdida.UseVisualStyleBackColor = true;
            this.BtnMarcarPerdida.Click += new System.EventHandler(this.BtnMarcarPerdida_Click);
            // 
            // BtnRecuperarArticulo
            // 
            this.BtnRecuperarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRecuperarArticulo.Location = new System.Drawing.Point(445, 30);
            this.BtnRecuperarArticulo.Name = "BtnRecuperarArticulo";
            this.BtnRecuperarArticulo.Size = new System.Drawing.Size(200, 45);
            this.BtnRecuperarArticulo.TabIndex = 2;
            this.BtnRecuperarArticulo.Text = "Recuperar Artículo";
            this.BtnRecuperarArticulo.UseVisualStyleBackColor = true;
            this.BtnRecuperarArticulo.Click += new System.EventHandler(this.BtnRecuperarArticulo_Click);
            // 
            // BtnRenegociar
            // 
            this.BtnRenegociar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRenegociar.Location = new System.Drawing.Point(230, 30);
            this.BtnRenegociar.Name = "BtnRenegociar";
            this.BtnRenegociar.Size = new System.Drawing.Size(200, 45);
            this.BtnRenegociar.TabIndex = 1;
            this.BtnRenegociar.Text = "Renegociar Cuotas";
            this.BtnRenegociar.UseVisualStyleBackColor = true;
            this.BtnRenegociar.Click += new System.EventHandler(this.BtnRenegociar_Click);
            // 
            // BtnRegistrarAbono
            // 
            this.BtnRegistrarAbono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegistrarAbono.Location = new System.Drawing.Point(15, 30);
            this.BtnRegistrarAbono.Name = "BtnRegistrarAbono";
            this.BtnRegistrarAbono.Size = new System.Drawing.Size(200, 45);
            this.BtnRegistrarAbono.TabIndex = 0;
            this.BtnRegistrarAbono.Text = "Registrar Abono";
            this.BtnRegistrarAbono.UseVisualStyleBackColor = true;
            this.BtnRegistrarAbono.Click += new System.EventHandler(this.BtnRegistrarAbono_Click);
            // 
            // Destinatario
            // 
            this.Destinatario.DataPropertyName = "Destinatario";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Destinatario.DefaultCellStyle = dataGridViewCellStyle1;
            this.Destinatario.HeaderText = "Cliente";
            this.Destinatario.MinimumWidth = 8;
            this.Destinatario.Name = "Destinatario";
            this.Destinatario.ReadOnly = true;
            this.Destinatario.Width = 94;
            // 
            // ColDocumento
            // 
            this.ColDocumento.DataPropertyName = "Documento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColDocumento.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColDocumento.HeaderText = "Documento";
            this.ColDocumento.MinimumWidth = 8;
            this.ColDocumento.Name = "ColDocumento";
            this.ColDocumento.ReadOnly = true;
            this.ColDocumento.Width = 128;
            // 
            // ColArticulo
            // 
            this.ColArticulo.DataPropertyName = "ArticuloCodigo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColArticulo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColArticulo.HeaderText = "Articulo";
            this.ColArticulo.MinimumWidth = 8;
            this.ColArticulo.Name = "ColArticulo";
            this.ColArticulo.ReadOnly = true;
            this.ColArticulo.Width = 98;
            // 
            // ColModelo
            // 
            this.ColModelo.DataPropertyName = "ArticuloModelo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColModelo.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColModelo.HeaderText = "Modelo";
            this.ColModelo.MinimumWidth = 8;
            this.ColModelo.Name = "ColModelo";
            this.ColModelo.ReadOnly = true;
            this.ColModelo.Width = 97;
            // 
            // ColCuota
            // 
            this.ColCuota.DataPropertyName = "NumeroCuota";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColCuota.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColCuota.HeaderText = "Cuota";
            this.ColCuota.MinimumWidth = 8;
            this.ColCuota.Name = "ColCuota";
            this.ColCuota.ReadOnly = true;
            this.ColCuota.Width = 88;
            // 
            // ColMonto
            // 
            this.ColMonto.DataPropertyName = "MontoCuota";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColMonto.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColMonto.HeaderText = "Monto";
            this.ColMonto.MinimumWidth = 8;
            this.ColMonto.Name = "ColMonto";
            this.ColMonto.ReadOnly = true;
            this.ColMonto.Width = 90;
            // 
            // ColPagado
            // 
            this.ColPagado.DataPropertyName = "MontoPagado";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColPagado.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColPagado.HeaderText = "Pagado";
            this.ColPagado.MinimumWidth = 8;
            this.ColPagado.Name = "ColPagado";
            this.ColPagado.ReadOnly = true;
            // 
            // ColMora
            // 
            this.ColMora.DataPropertyName = "MontoMora";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColMora.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColMora.HeaderText = "Mora";
            this.ColMora.MinimumWidth = 8;
            this.ColMora.Name = "ColMora";
            this.ColMora.ReadOnly = true;
            this.ColMora.Width = 81;
            // 
            // ColSaldo
            // 
            this.ColSaldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColSaldo.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColSaldo.HeaderText = "Saldo";
            this.ColSaldo.MinimumWidth = 8;
            this.ColSaldo.Name = "ColSaldo";
            this.ColSaldo.ReadOnly = true;
            this.ColSaldo.Width = 86;
            // 
            // ColVencimiento
            // 
            this.ColVencimiento.DataPropertyName = "FechaVencimiento";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColVencimiento.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColVencimiento.HeaderText = "Vencimiento";
            this.ColVencimiento.MinimumWidth = 8;
            this.ColVencimiento.Name = "ColVencimiento";
            this.ColVencimiento.ReadOnly = true;
            this.ColVencimiento.Width = 133;
            // 
            // ColEstado
            // 
            this.ColEstado.DataPropertyName = "Estado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColEstado.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.MinimumWidth = 8;
            this.ColEstado.Name = "ColEstado";
            this.ColEstado.ReadOnly = true;
            this.ColEstado.Width = 96;
            // 
            // VistaCuentasPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 646);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.LblResumen);
            this.Controls.Add(this.DgvCuentas);
            this.Controls.Add(this.grpFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaCuentasPorCobrar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por Cobrar";
            this.Load += new System.EventHandler(this.VistaCuentasPorCobrar_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCuentas)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox TxtFiltroCliente;
        private System.Windows.Forms.ComboBox CbFiltroEstado;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.DataGridView DgvCuentas;
        private System.Windows.Forms.Label LblResumen;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button BtnRecuperarArticulo;
        private System.Windows.Forms.Button BtnRenegociar;
        private System.Windows.Forms.Button BtnRegistrarAbono;
        private System.Windows.Forms.Button BtnMarcarPerdida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
    }
}
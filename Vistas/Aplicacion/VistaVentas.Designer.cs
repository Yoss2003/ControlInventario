namespace ControlInventario.Vistas.Aplicacion
{
    partial class VistaVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.TxtDocumento = new System.Windows.Forms.TextBox();
            this.CbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbMetodoPago = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DgvArticulos = new System.Windows.Forms.DataGridView();
            this.BtnBusquedaAvanzada = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtBuscarArticulo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtMontoRecibido = new System.Windows.Forms.TextBox();
            this.LblVuelto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCompletarVenta = new System.Windows.Forms.Button();
            this.LblTotal = new System.Windows.Forms.Label();
            this.ModeloArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubtotalArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccionArticulo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DtpFecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TxtObservaciones);
            this.groupBox1.Controls.Add(this.TxtCliente);
            this.groupBox1.Controls.Add(this.TxtDocumento);
            this.groupBox1.Controls.Add(this.CbTipoComprobante);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del cliente";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente / Razón Social";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(868, 51);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(134, 26);
            this.DtpFecha.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(864, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Observaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI / RUC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(652, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Tipo de comprobante";
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtObservaciones.Location = new System.Drawing.Point(18, 115);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(984, 54);
            this.TxtObservaciones.TabIndex = 0;
            // 
            // TxtCliente
            // 
            this.TxtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCliente.Location = new System.Drawing.Point(242, 51);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.Size = new System.Drawing.Size(396, 26);
            this.TxtCliente.TabIndex = 0;
            // 
            // TxtDocumento
            // 
            this.TxtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDocumento.Location = new System.Drawing.Point(18, 51);
            this.TxtDocumento.Name = "TxtDocumento";
            this.TxtDocumento.Size = new System.Drawing.Size(170, 26);
            this.TxtDocumento.TabIndex = 0;
            this.TxtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDocumento_KeyDown);
            // 
            // CbTipoComprobante
            // 
            this.CbTipoComprobante.FormattingEnabled = true;
            this.CbTipoComprobante.Location = new System.Drawing.Point(657, 49);
            this.CbTipoComprobante.Name = "CbTipoComprobante";
            this.CbTipoComprobante.Size = new System.Drawing.Size(192, 28);
            this.CbTipoComprobante.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Metodo de pago";
            // 
            // CbMetodoPago
            // 
            this.CbMetodoPago.FormattingEnabled = true;
            this.CbMetodoPago.Location = new System.Drawing.Point(23, 57);
            this.CbMetodoPago.Name = "CbMetodoPago";
            this.CbMetodoPago.Size = new System.Drawing.Size(192, 28);
            this.CbMetodoPago.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DgvArticulos);
            this.groupBox2.Controls.Add(this.BtnBusquedaAvanzada);
            this.groupBox2.Controls.Add(this.BtnBuscar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtBuscarArticulo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1016, 268);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Articulo";
            // 
            // DgvArticulos
            // 
            this.DgvArticulos.AllowUserToAddRows = false;
            this.DgvArticulos.AllowUserToDeleteRows = false;
            this.DgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModeloArticulo,
            this.PrecioArticulo,
            this.CantidadArticulo,
            this.SubtotalArticulo,
            this.AccionArticulo});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvArticulos.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvArticulos.Location = new System.Drawing.Point(18, 108);
            this.DgvArticulos.Name = "DgvArticulos";
            this.DgvArticulos.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvArticulos.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvArticulos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvArticulos.RowTemplate.Height = 28;
            this.DgvArticulos.Size = new System.Drawing.Size(986, 148);
            this.DgvArticulos.TabIndex = 4;
            this.DgvArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticulos_CellContentClick);
            this.DgvArticulos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvArticulos_CellFormatting);
            this.DgvArticulos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticulos_CellValueChanged);
            // 
            // BtnBusquedaAvanzada
            // 
            this.BtnBusquedaAvanzada.Location = new System.Drawing.Point(504, 37);
            this.BtnBusquedaAvanzada.Name = "BtnBusquedaAvanzada";
            this.BtnBusquedaAvanzada.Size = new System.Drawing.Size(184, 34);
            this.BtnBusquedaAvanzada.TabIndex = 3;
            this.BtnBusquedaAvanzada.Text = "Búsqueda avanzada";
            this.BtnBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.BtnBusquedaAvanzada.Click += new System.EventHandler(this.BtnBusquedaAvanzada_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(410, 37);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(86, 34);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "CARRITO DE COMPRAS:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Escanear / Buscar Código:";
            // 
            // TxtBuscarArticulo
            // 
            this.TxtBuscarArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarArticulo.Location = new System.Drawing.Point(222, 38);
            this.TxtBuscarArticulo.Name = "TxtBuscarArticulo";
            this.TxtBuscarArticulo.Size = new System.Drawing.Size(178, 26);
            this.TxtBuscarArticulo.TabIndex = 0;
            this.TxtBuscarArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuscarArticulo_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtMontoRecibido);
            this.groupBox3.Controls.Add(this.LblVuelto);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.BtnCompletarVenta);
            this.groupBox3.Controls.Add(this.LblTotal);
            this.groupBox3.Controls.Add(this.CbMetodoPago);
            this.groupBox3.Location = new System.Drawing.Point(0, 443);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1016, 118);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información de pago";
            // 
            // TxtMontoRecibido
            // 
            this.TxtMontoRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMontoRecibido.Location = new System.Drawing.Point(286, 57);
            this.TxtMontoRecibido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtMontoRecibido.Name = "TxtMontoRecibido";
            this.TxtMontoRecibido.Size = new System.Drawing.Size(172, 26);
            this.TxtMontoRecibido.TabIndex = 8;
            this.TxtMontoRecibido.TextChanged += new System.EventHandler(this.TxtMontoRecibido_TextChanged);
            this.TxtMontoRecibido.Enter += new System.EventHandler(this.TxtMontoRecibido_Enter);
            this.TxtMontoRecibido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMontoRecibido_KeyDown);
            this.TxtMontoRecibido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoRecibido_KeyPress);
            this.TxtMontoRecibido.Leave += new System.EventHandler(this.TxtMontoRecibido_Leave);
            // 
            // LblVuelto
            // 
            this.LblVuelto.AutoSize = true;
            this.LblVuelto.Location = new System.Drawing.Point(660, 56);
            this.LblVuelto.Name = "LblVuelto";
            this.LblVuelto.Size = new System.Drawing.Size(67, 20);
            this.LblVuelto.TabIndex = 7;
            this.LblVuelto.Text = "*Vuelto*";
            this.LblVuelto.TextChanged += new System.EventHandler(this.LblVuelto_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(529, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Vuelto / Cambio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Monto recibido:";
            // 
            // BtnCompletarVenta
            // 
            this.BtnCompletarVenta.Location = new System.Drawing.Point(830, 65);
            this.BtnCompletarVenta.Name = "BtnCompletarVenta";
            this.BtnCompletarVenta.Size = new System.Drawing.Size(174, 42);
            this.BtnCompletarVenta.TabIndex = 1;
            this.BtnCompletarVenta.Text = "Finalizar Compra";
            this.BtnCompletarVenta.UseVisualStyleBackColor = true;
            this.BtnCompletarVenta.Click += new System.EventHandler(this.BtnCompletarVenta_Click);
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(850, 32);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(83, 20);
            this.LblTotal.TabIndex = 0;
            this.LblTotal.Text = "Total: 0,00";
            // 
            // ModeloArticulo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ModeloArticulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ModeloArticulo.HeaderText = "MODELO";
            this.ModeloArticulo.MinimumWidth = 8;
            this.ModeloArticulo.Name = "ModeloArticulo";
            this.ModeloArticulo.ReadOnly = true;
            // 
            // PrecioArticulo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PrecioArticulo.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioArticulo.HeaderText = "PRECIO";
            this.PrecioArticulo.MinimumWidth = 8;
            this.PrecioArticulo.Name = "PrecioArticulo";
            this.PrecioArticulo.ReadOnly = true;
            // 
            // CantidadArticulo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CantidadArticulo.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadArticulo.HeaderText = "CANTIDAD";
            this.CantidadArticulo.MinimumWidth = 8;
            this.CantidadArticulo.Name = "CantidadArticulo";
            this.CantidadArticulo.ReadOnly = true;
            // 
            // SubtotalArticulo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SubtotalArticulo.DefaultCellStyle = dataGridViewCellStyle5;
            this.SubtotalArticulo.HeaderText = "SUBTOTAL";
            this.SubtotalArticulo.MinimumWidth = 8;
            this.SubtotalArticulo.Name = "SubtotalArticulo";
            this.SubtotalArticulo.ReadOnly = true;
            // 
            // AccionArticulo
            // 
            this.AccionArticulo.HeaderText = "ACCIÓN";
            this.AccionArticulo.MinimumWidth = 8;
            this.AccionArticulo.Name = "AccionArticulo";
            this.AccionArticulo.ReadOnly = true;
            this.AccionArticulo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccionArticulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // VistaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 560);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaVentas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Venta";
            this.Load += new System.EventHandler(this.VistaVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.TextBox TxtDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbMetodoPago;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtBuscarArticulo;
        private System.Windows.Forms.DataGridView DgvArticulos;
        private System.Windows.Forms.Button BtnBusquedaAvanzada;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnCompletarVenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblVuelto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.ComboBox CbTipoComprobante;
        private System.Windows.Forms.TextBox TxtMontoRecibido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubtotalArticulo;
        private System.Windows.Forms.DataGridViewButtonColumn AccionArticulo;
    }
}
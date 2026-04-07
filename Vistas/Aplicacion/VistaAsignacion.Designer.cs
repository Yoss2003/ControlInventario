namespace ControlInventario.Vistas.Aplicacion
{
    partial class VistaAsignacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.BtnBuscarEmpleado = new System.Windows.Forms.Button();
            this.BtnNuevoEmpleado = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtArea = new System.Windows.Forms.TextBox();
            this.TxtCargo = new System.Windows.Forms.TextBox();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.PbFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnBuscarArticulo = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscarArticulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DgvArticulos = new System.Windows.Forms.DataGridView();
            this.CodigoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccionArticulo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoEmpleado)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBuscarEmpleado);
            this.groupBox1.Controls.Add(this.BtnBuscarEmpleado);
            this.groupBox1.Controls.Add(this.BtnNuevoEmpleado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(197, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar empleado";
            // 
            // TxtBuscarEmpleado
            // 
            this.TxtBuscarEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarEmpleado.Location = new System.Drawing.Point(4, 36);
            this.TxtBuscarEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtBuscarEmpleado.Name = "TxtBuscarEmpleado";
            this.TxtBuscarEmpleado.Size = new System.Drawing.Size(101, 20);
            this.TxtBuscarEmpleado.TabIndex = 1;
            this.TxtBuscarEmpleado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuscarEmpleado_KeyDown);
            // 
            // BtnBuscarEmpleado
            // 
            this.BtnBuscarEmpleado.Location = new System.Drawing.Point(108, 35);
            this.BtnBuscarEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBuscarEmpleado.Name = "BtnBuscarEmpleado";
            this.BtnBuscarEmpleado.Size = new System.Drawing.Size(50, 20);
            this.BtnBuscarEmpleado.TabIndex = 2;
            this.BtnBuscarEmpleado.Text = "Buscar";
            this.BtnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.BtnBuscarEmpleado.Click += new System.EventHandler(this.BtnBuscarEmpleado_Click);
            // 
            // BtnNuevoEmpleado
            // 
            this.BtnNuevoEmpleado.Location = new System.Drawing.Point(165, 35);
            this.BtnNuevoEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnNuevoEmpleado.Name = "BtnNuevoEmpleado";
            this.BtnNuevoEmpleado.Size = new System.Drawing.Size(19, 20);
            this.BtnNuevoEmpleado.TabIndex = 2;
            this.BtnNuevoEmpleado.Text = "+";
            this.BtnNuevoEmpleado.UseVisualStyleBackColor = true;
            this.BtnNuevoEmpleado.Click += new System.EventHandler(this.BtnNuevoEmpleado_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscar DNI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtArea);
            this.groupBox2.Controls.Add(this.TxtCargo);
            this.groupBox2.Controls.Add(this.TxtDNI);
            this.groupBox2.Controls.Add(this.TxtNombreCompleto);
            this.groupBox2.Controls.Add(this.PbFotoEmpleado);
            this.groupBox2.Location = new System.Drawing.Point(8, 77);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(197, 262);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos empleado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 226);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Area:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cargo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "DNI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre Completo:";
            // 
            // TxtArea
            // 
            this.TxtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtArea.Location = new System.Drawing.Point(27, 240);
            this.TxtArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtArea.Name = "TxtArea";
            this.TxtArea.Size = new System.Drawing.Size(144, 20);
            this.TxtArea.TabIndex = 1;
            // 
            // TxtCargo
            // 
            this.TxtCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCargo.Location = new System.Drawing.Point(27, 205);
            this.TxtCargo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtCargo.Name = "TxtCargo";
            this.TxtCargo.Size = new System.Drawing.Size(144, 20);
            this.TxtCargo.TabIndex = 1;
            // 
            // TxtDNI
            // 
            this.TxtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDNI.Location = new System.Drawing.Point(27, 166);
            this.TxtDNI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(144, 20);
            this.TxtDNI.TabIndex = 1;
            // 
            // TxtNombreCompleto
            // 
            this.TxtNombreCompleto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombreCompleto.Location = new System.Drawing.Point(27, 128);
            this.TxtNombreCompleto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtNombreCompleto.Name = "TxtNombreCompleto";
            this.TxtNombreCompleto.Size = new System.Drawing.Size(144, 20);
            this.TxtNombreCompleto.TabIndex = 1;
            // 
            // PbFotoEmpleado
            // 
            this.PbFotoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbFotoEmpleado.Location = new System.Drawing.Point(40, 17);
            this.PbFotoEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PbFotoEmpleado.Name = "PbFotoEmpleado";
            this.PbFotoEmpleado.Size = new System.Drawing.Size(118, 94);
            this.PbFotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbFotoEmpleado.TabIndex = 0;
            this.PbFotoEmpleado.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnBuscarArticulo);
            this.groupBox3.Controls.Add(this.BtnBuscar);
            this.groupBox3.Controls.Add(this.TxtBuscarArticulo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(209, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(333, 65);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar articulo";
            // 
            // BtnBuscarArticulo
            // 
            this.BtnBuscarArticulo.Location = new System.Drawing.Point(215, 36);
            this.BtnBuscarArticulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBuscarArticulo.Name = "BtnBuscarArticulo";
            this.BtnBuscarArticulo.Size = new System.Drawing.Size(114, 20);
            this.BtnBuscarArticulo.TabIndex = 2;
            this.BtnBuscarArticulo.Text = "Búsqueda avanzada";
            this.BtnBuscarArticulo.UseVisualStyleBackColor = true;
            this.BtnBuscarArticulo.Click += new System.EventHandler(this.BtnBuscarArticulo_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(161, 36);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(50, 20);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscarArticulo
            // 
            this.TxtBuscarArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarArticulo.Location = new System.Drawing.Point(9, 38);
            this.TxtBuscarArticulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtBuscarArticulo.Name = "TxtBuscarArticulo";
            this.TxtBuscarArticulo.Size = new System.Drawing.Size(148, 20);
            this.TxtBuscarArticulo.TabIndex = 1;
            this.TxtBuscarArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuscarArticulo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Escanear / Buscar articulo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DgvArticulos);
            this.groupBox4.Location = new System.Drawing.Point(209, 77);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(333, 126);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos articulo";
            // 
            // DgvArticulos
            // 
            this.DgvArticulos.AllowUserToAddRows = false;
            this.DgvArticulos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvArticulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoArticulo,
            this.DescripcionArticulo,
            this.EstadoArticulo,
            this.AccionArticulo});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvArticulos.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvArticulos.Location = new System.Drawing.Point(2, 15);
            this.DgvArticulos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DgvArticulos.Name = "DgvArticulos";
            this.DgvArticulos.ReadOnly = true;
            this.DgvArticulos.RowHeadersVisible = false;
            this.DgvArticulos.RowHeadersWidth = 62;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvArticulos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvArticulos.RowTemplate.Height = 28;
            this.DgvArticulos.Size = new System.Drawing.Size(329, 109);
            this.DgvArticulos.TabIndex = 0;
            this.DgvArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticulos_CellContentClick);
            // 
            // CodigoArticulo
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CodigoArticulo.DefaultCellStyle = dataGridViewCellStyle8;
            this.CodigoArticulo.HeaderText = "CÓDIGO";
            this.CodigoArticulo.MinimumWidth = 8;
            this.CodigoArticulo.Name = "CodigoArticulo";
            this.CodigoArticulo.ReadOnly = true;
            // 
            // DescripcionArticulo
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DescripcionArticulo.DefaultCellStyle = dataGridViewCellStyle9;
            this.DescripcionArticulo.HeaderText = "DESCRIPCIÓN";
            this.DescripcionArticulo.MinimumWidth = 8;
            this.DescripcionArticulo.Name = "DescripcionArticulo";
            this.DescripcionArticulo.ReadOnly = true;
            // 
            // EstadoArticulo
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EstadoArticulo.DefaultCellStyle = dataGridViewCellStyle10;
            this.EstadoArticulo.HeaderText = "ESTADO";
            this.EstadoArticulo.MinimumWidth = 8;
            this.EstadoArticulo.Name = "EstadoArticulo";
            this.EstadoArticulo.ReadOnly = true;
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtObservaciones);
            this.groupBox5.Controls.Add(this.BtnAsignar);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.DtpFechaEntrega);
            this.groupBox5.Location = new System.Drawing.Point(209, 205);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(333, 134);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalles entrega";
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtObservaciones.Location = new System.Drawing.Point(7, 57);
            this.TxtObservaciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(323, 38);
            this.TxtObservaciones.TabIndex = 3;
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignar.Location = new System.Drawing.Point(155, 102);
            this.BtnAsignar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(174, 30);
            this.BtnAsignar.TabIndex = 2;
            this.BtnAsignar.Text = "Confirmar asignación";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalles adicionales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha entrega";
            // 
            // DtpFechaEntrega
            // 
            this.DtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaEntrega.Location = new System.Drawing.Point(83, 16);
            this.DtpFechaEntrega.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DtpFechaEntrega.Name = "DtpFechaEntrega";
            this.DtpFechaEntrega.Size = new System.Drawing.Size(91, 20);
            this.DtpFechaEntrega.TabIndex = 0;
            // 
            // VistaAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 346);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaAsignacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de articulos";
            this.Load += new System.EventHandler(this.VistaAsignacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoEmpleado)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView DgvArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoArticulo;
        private System.Windows.Forms.DataGridViewButtonColumn AccionArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaEntrega;
        private System.Windows.Forms.Button BtnBuscarArticulo;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscarArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBuscarEmpleado;
        private System.Windows.Forms.Button BtnNuevoEmpleado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnBuscarEmpleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtArea;
        private System.Windows.Forms.TextBox TxtCargo;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.TextBox TxtNombreCompleto;
        private System.Windows.Forms.PictureBox PbFotoEmpleado;
        private System.Windows.Forms.Button BtnAsignar;
    }
}
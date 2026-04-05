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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DgvArticulos = new System.Windows.Forms.DataGridView();
            this.CodigoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccionArticulo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBuscarArticulo = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnBuscarArticulo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.BtnNuevoEmpleado = new System.Windows.Forms.Button();
            this.BtnBuscarEmpleado = new System.Windows.Forms.Button();
            this.PbFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.TxtCargo = new System.Windows.Forms.TextBox();
            this.TxtArea = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBuscarEmpleado);
            this.groupBox1.Controls.Add(this.BtnBuscarEmpleado);
            this.groupBox1.Controls.Add(this.BtnNuevoEmpleado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar empleado";
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
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 403);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos empleado";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnBuscarArticulo);
            this.groupBox3.Controls.Add(this.BtnBuscar);
            this.groupBox3.Controls.Add(this.TxtBuscarArticulo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(313, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar articulo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DgvArticulos);
            this.groupBox4.Location = new System.Drawing.Point(313, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(499, 194);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos articulo";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtObservaciones);
            this.groupBox5.Controls.Add(this.BtnAsignar);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.DtpFechaEntrega);
            this.groupBox5.Location = new System.Drawing.Point(313, 315);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(499, 206);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalles entrega";
            // 
            // DgvArticulos
            // 
            this.DgvArticulos.AllowUserToAddRows = false;
            this.DgvArticulos.AllowUserToDeleteRows = false;
            this.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoArticulo,
            this.DescripcionArticulo,
            this.EstadoArticulo,
            this.AccionArticulo});
            this.DgvArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvArticulos.Location = new System.Drawing.Point(3, 22);
            this.DgvArticulos.Name = "DgvArticulos";
            this.DgvArticulos.ReadOnly = true;
            this.DgvArticulos.RowHeadersWidth = 62;
            this.DgvArticulos.RowTemplate.Height = 28;
            this.DgvArticulos.Size = new System.Drawing.Size(493, 169);
            this.DgvArticulos.TabIndex = 0;
            // 
            // CodigoArticulo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CodigoArticulo.DefaultCellStyle = dataGridViewCellStyle4;
            this.CodigoArticulo.HeaderText = "CÓDIGO";
            this.CodigoArticulo.MinimumWidth = 8;
            this.CodigoArticulo.Name = "CodigoArticulo";
            this.CodigoArticulo.ReadOnly = true;
            this.CodigoArticulo.Width = 150;
            // 
            // DescripcionArticulo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DescripcionArticulo.DefaultCellStyle = dataGridViewCellStyle5;
            this.DescripcionArticulo.HeaderText = "DESCRIPCIÓN";
            this.DescripcionArticulo.MinimumWidth = 8;
            this.DescripcionArticulo.Name = "DescripcionArticulo";
            this.DescripcionArticulo.ReadOnly = true;
            this.DescripcionArticulo.Width = 150;
            // 
            // EstadoArticulo
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EstadoArticulo.DefaultCellStyle = dataGridViewCellStyle6;
            this.EstadoArticulo.HeaderText = "ESTADO";
            this.EstadoArticulo.MinimumWidth = 8;
            this.EstadoArticulo.Name = "EstadoArticulo";
            this.EstadoArticulo.ReadOnly = true;
            this.EstadoArticulo.Width = 150;
            // 
            // AccionArticulo
            // 
            this.AccionArticulo.HeaderText = "ACCIÓN";
            this.AccionArticulo.MinimumWidth = 8;
            this.AccionArticulo.Name = "AccionArticulo";
            this.AccionArticulo.ReadOnly = true;
            this.AccionArticulo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccionArticulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AccionArticulo.Width = 150;
            // 
            // DtpFechaEntrega
            // 
            this.DtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaEntrega.Location = new System.Drawing.Point(125, 25);
            this.DtpFechaEntrega.Name = "DtpFechaEntrega";
            this.DtpFechaEntrega.Size = new System.Drawing.Size(135, 26);
            this.DtpFechaEntrega.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha entrega";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalles adicionales";
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtObservaciones.Location = new System.Drawing.Point(10, 88);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(483, 57);
            this.TxtObservaciones.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Escanear / Buscar articulo";
            // 
            // TxtBuscarArticulo
            // 
            this.TxtBuscarArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarArticulo.Location = new System.Drawing.Point(14, 58);
            this.TxtBuscarArticulo.Name = "TxtBuscarArticulo";
            this.TxtBuscarArticulo.Size = new System.Drawing.Size(221, 26);
            this.TxtBuscarArticulo.TabIndex = 1;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(241, 56);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 30);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBuscarArticulo
            // 
            this.BtnBuscarArticulo.Location = new System.Drawing.Point(322, 56);
            this.BtnBuscarArticulo.Name = "BtnBuscarArticulo";
            this.BtnBuscarArticulo.Size = new System.Drawing.Size(171, 30);
            this.BtnBuscarArticulo.TabIndex = 2;
            this.BtnBuscarArticulo.Text = "Búsqueda avanzada";
            this.BtnBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscar DNI";
            // 
            // TxtBuscarEmpleado
            // 
            this.TxtBuscarEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarEmpleado.Location = new System.Drawing.Point(6, 56);
            this.TxtBuscarEmpleado.Name = "TxtBuscarEmpleado";
            this.TxtBuscarEmpleado.Size = new System.Drawing.Size(150, 26);
            this.TxtBuscarEmpleado.TabIndex = 1;
            // 
            // BtnNuevoEmpleado
            // 
            this.BtnNuevoEmpleado.Location = new System.Drawing.Point(247, 54);
            this.BtnNuevoEmpleado.Name = "BtnNuevoEmpleado";
            this.BtnNuevoEmpleado.Size = new System.Drawing.Size(28, 30);
            this.BtnNuevoEmpleado.TabIndex = 2;
            this.BtnNuevoEmpleado.Text = "+";
            this.BtnNuevoEmpleado.UseVisualStyleBackColor = true;
            // 
            // BtnBuscarEmpleado
            // 
            this.BtnBuscarEmpleado.Location = new System.Drawing.Point(162, 54);
            this.BtnBuscarEmpleado.Name = "BtnBuscarEmpleado";
            this.BtnBuscarEmpleado.Size = new System.Drawing.Size(75, 30);
            this.BtnBuscarEmpleado.TabIndex = 2;
            this.BtnBuscarEmpleado.Text = "Buscar";
            this.BtnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.BtnBuscarEmpleado.Click += new System.EventHandler(this.button1_Click);
            // 
            // PbFotoEmpleado
            // 
            this.PbFotoEmpleado.Location = new System.Drawing.Point(70, 29);
            this.PbFotoEmpleado.Name = "PbFotoEmpleado";
            this.PbFotoEmpleado.Size = new System.Drawing.Size(156, 136);
            this.PbFotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbFotoEmpleado.TabIndex = 0;
            this.PbFotoEmpleado.TabStop = false;
            // 
            // TxtNombreCompleto
            // 
            this.TxtNombreCompleto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombreCompleto.Location = new System.Drawing.Point(40, 197);
            this.TxtNombreCompleto.Name = "TxtNombreCompleto";
            this.TxtNombreCompleto.Size = new System.Drawing.Size(215, 26);
            this.TxtNombreCompleto.TabIndex = 1;
            // 
            // TxtDNI
            // 
            this.TxtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDNI.Location = new System.Drawing.Point(40, 256);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(215, 26);
            this.TxtDNI.TabIndex = 1;
            // 
            // TxtCargo
            // 
            this.TxtCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCargo.Location = new System.Drawing.Point(40, 316);
            this.TxtCargo.Name = "TxtCargo";
            this.TxtCargo.Size = new System.Drawing.Size(215, 26);
            this.TxtCargo.TabIndex = 1;
            // 
            // TxtArea
            // 
            this.TxtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtArea.Location = new System.Drawing.Point(40, 370);
            this.TxtArea.Name = "TxtArea";
            this.TxtArea.Size = new System.Drawing.Size(215, 26);
            this.TxtArea.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre Completo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "DNI:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cargo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Area:";
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsignar.Location = new System.Drawing.Point(232, 160);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(261, 39);
            this.BtnAsignar.TabIndex = 2;
            this.BtnAsignar.Text = "Confirmar asignación";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.button1_Click);
            // 
            // VistaAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 533);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaAsignacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de articulos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoEmpleado)).EndInit();
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
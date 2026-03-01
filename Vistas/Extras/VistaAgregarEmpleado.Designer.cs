namespace ControlInventario.Vistas.Extras
{
    partial class VistaAgregarEmpleado
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
            this.BtnNewEstado = new System.Windows.Forms.Button();
            this.BtnNewArea = new System.Windows.Forms.Button();
            this.BtnNewCargo = new System.Windows.Forms.Button();
            this.CbCargo = new System.Windows.Forms.ComboBox();
            this.CbArea = new System.Windows.Forms.ComboBox();
            this.CbEstadoEmpleados = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.TxtNombres = new System.Windows.Forms.TextBox();
            this.DgEmpleados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAgregarEmpleado = new System.Windows.Forms.Button();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.IdEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DniEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNewEstado
            // 
            this.BtnNewEstado.Location = new System.Drawing.Point(265, 178);
            this.BtnNewEstado.Name = "BtnNewEstado";
            this.BtnNewEstado.Size = new System.Drawing.Size(31, 21);
            this.BtnNewEstado.TabIndex = 24;
            this.BtnNewEstado.Text = "...";
            this.BtnNewEstado.UseVisualStyleBackColor = true;
            this.BtnNewEstado.Click += new System.EventHandler(this.BtnNewEstado_Click);
            // 
            // BtnNewArea
            // 
            this.BtnNewArea.Location = new System.Drawing.Point(265, 127);
            this.BtnNewArea.Name = "BtnNewArea";
            this.BtnNewArea.Size = new System.Drawing.Size(31, 21);
            this.BtnNewArea.TabIndex = 25;
            this.BtnNewArea.Text = "...";
            this.BtnNewArea.UseVisualStyleBackColor = true;
            this.BtnNewArea.Click += new System.EventHandler(this.BtnNewArea_Click);
            // 
            // BtnNewCargo
            // 
            this.BtnNewCargo.Location = new System.Drawing.Point(265, 75);
            this.BtnNewCargo.Name = "BtnNewCargo";
            this.BtnNewCargo.Size = new System.Drawing.Size(31, 21);
            this.BtnNewCargo.TabIndex = 26;
            this.BtnNewCargo.Text = "...";
            this.BtnNewCargo.UseVisualStyleBackColor = true;
            this.BtnNewCargo.Click += new System.EventHandler(this.BtnNewCargo_Click);
            // 
            // CbCargo
            // 
            this.CbCargo.FormattingEnabled = true;
            this.CbCargo.Location = new System.Drawing.Point(155, 75);
            this.CbCargo.Name = "CbCargo";
            this.CbCargo.Size = new System.Drawing.Size(103, 21);
            this.CbCargo.TabIndex = 21;
            this.CbCargo.Text = "SELECCIONE";
            // 
            // CbArea
            // 
            this.CbArea.FormattingEnabled = true;
            this.CbArea.Location = new System.Drawing.Point(155, 127);
            this.CbArea.Name = "CbArea";
            this.CbArea.Size = new System.Drawing.Size(103, 21);
            this.CbArea.TabIndex = 22;
            this.CbArea.Text = "SELECCIONE";
            // 
            // CbEstadoEmpleados
            // 
            this.CbEstadoEmpleados.FormattingEnabled = true;
            this.CbEstadoEmpleados.Location = new System.Drawing.Point(155, 178);
            this.CbEstadoEmpleados.Name = "CbEstadoEmpleados";
            this.CbEstadoEmpleados.Size = new System.Drawing.Size(103, 21);
            this.CbEstadoEmpleados.TabIndex = 23;
            this.CbEstadoEmpleados.Text = "SELECCIONE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "DNI:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cargo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Área:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Apellidos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Nombres:";
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.Location = new System.Drawing.Point(12, 127);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(103, 20);
            this.TxtApellidos.TabIndex = 12;
            // 
            // TxtDNI
            // 
            this.TxtDNI.Location = new System.Drawing.Point(12, 179);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(103, 20);
            this.TxtDNI.TabIndex = 13;
            // 
            // TxtNombres
            // 
            this.TxtNombres.Location = new System.Drawing.Point(12, 76);
            this.TxtNombres.Name = "TxtNombres";
            this.TxtNombres.Size = new System.Drawing.Size(103, 20);
            this.TxtNombres.TabIndex = 14;
            // 
            // DgEmpleados
            // 
            this.DgEmpleados.AllowUserToAddRows = false;
            this.DgEmpleados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.DgEmpleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEmpleado,
            this.NombreEmpleado,
            this.ApellidoEmpleado,
            this.DniEmpleado,
            this.CargoEmpleado,
            this.AreaEmpleado,
            this.EstadoEmpleado});
            this.DgEmpleados.Location = new System.Drawing.Point(12, 251);
            this.DgEmpleados.Name = "DgEmpleados";
            this.DgEmpleados.ReadOnly = true;
            this.DgEmpleados.Size = new System.Drawing.Size(284, 187);
            this.DgEmpleados.TabIndex = 27;
            this.DgEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgEmpleados_CellDoubleClick);
            this.DgEmpleados.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.DgEmpleados_CellStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "CONTROL DE EMPLEADOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnAgregarEmpleado
            // 
            this.BtnAgregarEmpleado.Location = new System.Drawing.Point(12, 213);
            this.BtnAgregarEmpleado.Name = "BtnAgregarEmpleado";
            this.BtnAgregarEmpleado.Size = new System.Drawing.Size(75, 23);
            this.BtnAgregarEmpleado.TabIndex = 29;
            this.BtnAgregarEmpleado.Text = "Agregar";
            this.BtnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.BtnAgregarEmpleado.Click += new System.EventHandler(this.BtnAgregarEmpleado_Click);
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Location = new System.Drawing.Point(116, 213);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(75, 23);
            this.BtnBorrar.TabIndex = 29;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(220, 213);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 29;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // IdEmpleado
            // 
            this.IdEmpleado.HeaderText = "id";
            this.IdEmpleado.Name = "IdEmpleado";
            this.IdEmpleado.ReadOnly = true;
            this.IdEmpleado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdEmpleado.Visible = false;
            this.IdEmpleado.Width = 40;
            // 
            // NombreEmpleado
            // 
            this.NombreEmpleado.HeaderText = "Nombres";
            this.NombreEmpleado.Name = "NombreEmpleado";
            this.NombreEmpleado.ReadOnly = true;
            this.NombreEmpleado.Width = 74;
            // 
            // ApellidoEmpleado
            // 
            this.ApellidoEmpleado.HeaderText = "Apellidos";
            this.ApellidoEmpleado.Name = "ApellidoEmpleado";
            this.ApellidoEmpleado.ReadOnly = true;
            this.ApellidoEmpleado.Width = 74;
            // 
            // DniEmpleado
            // 
            this.DniEmpleado.HeaderText = "DNI";
            this.DniEmpleado.Name = "DniEmpleado";
            this.DniEmpleado.ReadOnly = true;
            this.DniEmpleado.Width = 51;
            // 
            // CargoEmpleado
            // 
            this.CargoEmpleado.HeaderText = "Cargo";
            this.CargoEmpleado.Name = "CargoEmpleado";
            this.CargoEmpleado.ReadOnly = true;
            this.CargoEmpleado.Width = 60;
            // 
            // AreaEmpleado
            // 
            this.AreaEmpleado.HeaderText = "Área";
            this.AreaEmpleado.Name = "AreaEmpleado";
            this.AreaEmpleado.ReadOnly = true;
            this.AreaEmpleado.Width = 54;
            // 
            // EstadoEmpleado
            // 
            this.EstadoEmpleado.HeaderText = "Estado";
            this.EstadoEmpleado.Name = "EstadoEmpleado";
            this.EstadoEmpleado.ReadOnly = true;
            this.EstadoEmpleado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EstadoEmpleado.Width = 65;
            // 
            // VistaAgregarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 450);
            this.Controls.Add(this.DgEmpleados);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnBorrar);
            this.Controls.Add(this.BtnAgregarEmpleado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNewEstado);
            this.Controls.Add(this.BtnNewArea);
            this.Controls.Add(this.BtnNewCargo);
            this.Controls.Add(this.CbCargo);
            this.Controls.Add(this.CbArea);
            this.Controls.Add(this.CbEstadoEmpleados);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtApellidos);
            this.Controls.Add(this.TxtDNI);
            this.Controls.Add(this.TxtNombres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaAgregarEmpleado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Empleado";
            this.Load += new System.EventHandler(this.VistaAgregarEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNewEstado;
        private System.Windows.Forms.Button BtnNewArea;
        private System.Windows.Forms.Button BtnNewCargo;
        public System.Windows.Forms.ComboBox CbCargo;
        public System.Windows.Forms.ComboBox CbArea;
        public System.Windows.Forms.ComboBox CbEstadoEmpleados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.TextBox TxtNombres;
        private System.Windows.Forms.DataGridView DgEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAgregarEmpleado;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DniEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CargoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoEmpleado;
    }
}
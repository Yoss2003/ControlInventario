namespace ControlInventario.Vistas.Extras
{
    partial class VistaCaracteristicas
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAgregarFila = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvCaracteristicas = new System.Windows.Forms.DataGridView();
            this.BtnEliminarFila = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.NombreCaracteristica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorCaracteristica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCaracteristicas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preparando caracteristicas para el articulo \"Code\":";
            // 
            // BtnAgregarFila
            // 
            this.BtnAgregarFila.Location = new System.Drawing.Point(265, 13);
            this.BtnAgregarFila.Name = "BtnAgregarFila";
            this.BtnAgregarFila.Size = new System.Drawing.Size(21, 23);
            this.BtnAgregarFila.TabIndex = 1;
            this.BtnAgregarFila.Text = "+";
            this.BtnAgregarFila.UseVisualStyleBackColor = true;
            this.BtnAgregarFila.Click += new System.EventHandler(this.btnAgregarFila_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvCaracteristicas);
            this.groupBox1.Location = new System.Drawing.Point(15, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 333);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caracteristicas agregadas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CATEGORIA: \"name\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "FECHA: \"fecha\"";
            // 
            // DgvCaracteristicas
            // 
            this.DgvCaracteristicas.AllowUserToAddRows = false;
            this.DgvCaracteristicas.AllowUserToDeleteRows = false;
            this.DgvCaracteristicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCaracteristicas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCaracteristicas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCaracteristicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCaracteristicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCaracteristica,
            this.ValorCaracteristica});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCaracteristicas.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCaracteristicas.GridColor = System.Drawing.Color.DarkGray;
            this.DgvCaracteristicas.Location = new System.Drawing.Point(7, 20);
            this.DgvCaracteristicas.Name = "DgvCaracteristicas";
            this.DgvCaracteristicas.ReadOnly = true;
            this.DgvCaracteristicas.Size = new System.Drawing.Size(423, 307);
            this.DgvCaracteristicas.TabIndex = 0;
            // 
            // BtnEliminarFila
            // 
            this.BtnEliminarFila.Location = new System.Drawing.Point(292, 13);
            this.BtnEliminarFila.Name = "BtnEliminarFila";
            this.BtnEliminarFila.Size = new System.Drawing.Size(21, 23);
            this.BtnEliminarFila.TabIndex = 4;
            this.BtnEliminarFila.Text = "-";
            this.BtnEliminarFila.UseVisualStyleBackColor = true;
            this.BtnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(152, 441);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 5;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // NombreCaracteristica
            // 
            this.NombreCaracteristica.HeaderText = "Nombre";
            this.NombreCaracteristica.Name = "NombreCaracteristica";
            this.NombreCaracteristica.ReadOnly = true;
            // 
            // ValorCaracteristica
            // 
            this.ValorCaracteristica.HeaderText = "Valor";
            this.ValorCaracteristica.Name = "ValorCaracteristica";
            this.ValorCaracteristica.ReadOnly = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(238, 441);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Guardar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(22, 76);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(100, 20);
            this.TxtNombre.TabIndex = 2;
            this.TxtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValor_KeyDown);
            // 
            // TxtValor
            // 
            this.TxtValor.Location = new System.Drawing.Point(164, 76);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(100, 20);
            this.TxtValor.TabIndex = 3;
            this.TxtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValor_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre caracteristica";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Valor caracteristica";
            // 
            // VistaCaracteristicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 476);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnEliminarFila);
            this.Controls.Add(this.BtnAgregarFila);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaCaracteristicas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caracteristicas articulos";
            this.Load += new System.EventHandler(this.VistaCaracteristicas_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCaracteristicas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAgregarFila;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvCaracteristicas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCaracteristica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorCaracteristica;
        private System.Windows.Forms.Button BtnEliminarFila;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
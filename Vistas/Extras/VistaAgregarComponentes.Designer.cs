namespace ControlInventario.Vistas.Extras
{
    partial class VistaAgregarComponentes
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
            this.DgComponentes = new System.Windows.Forms.DataGridView();
            this.LblNuevoComponente = new System.Windows.Forms.Label();
            this.TxtNombreComponente = new System.Windows.Forms.TextBox();
            this.LblDescripcionComponente = new System.Windows.Forms.Label();
            this.TxtDescripcionComponente = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblFecha = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultarRUC = new System.Windows.Forms.Button();
            this.ChkPermitirDevolucion = new System.Windows.Forms.CheckBox();
            this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EsDevolvible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgComponentes)).BeginInit();
            this.SuspendLayout();
            // 
            // DgComponentes
            // 
            this.DgComponentes.AllowUserToAddRows = false;
            this.DgComponentes.AllowUserToDeleteRows = false;
            this.DgComponentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgComponentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgComponentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgComponentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdComponente,
            this.NombreComponente,
            this.DescripcionComponente,
            this.EsDevolvible});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgComponentes.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgComponentes.Location = new System.Drawing.Point(18, 255);
            this.DgComponentes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DgComponentes.MultiSelect = false;
            this.DgComponentes.Name = "DgComponentes";
            this.DgComponentes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgComponentes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgComponentes.RowHeadersVisible = false;
            this.DgComponentes.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgComponentes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgComponentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgComponentes.Size = new System.Drawing.Size(410, 197);
            this.DgComponentes.TabIndex = 6;
            this.DgComponentes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgComponentes_CellDoubleClick);
            this.DgComponentes.SelectionChanged += new System.EventHandler(this.DgComponentes_SelectionChanged);
            // 
            // LblNuevoComponente
            // 
            this.LblNuevoComponente.AutoSize = true;
            this.LblNuevoComponente.Location = new System.Drawing.Point(20, 20);
            this.LblNuevoComponente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNuevoComponente.Name = "LblNuevoComponente";
            this.LblNuevoComponente.Size = new System.Drawing.Size(154, 20);
            this.LblNuevoComponente.TabIndex = 1;
            this.LblNuevoComponente.Text = "Nuevo Componente:";
            // 
            // TxtNombreComponente
            // 
            this.TxtNombreComponente.Location = new System.Drawing.Point(18, 45);
            this.TxtNombreComponente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtNombreComponente.Name = "TxtNombreComponente";
            this.TxtNombreComponente.Size = new System.Drawing.Size(196, 26);
            this.TxtNombreComponente.TabIndex = 0;
            // 
            // LblDescripcionComponente
            // 
            this.LblDescripcionComponente.AutoSize = true;
            this.LblDescripcionComponente.Location = new System.Drawing.Point(20, 88);
            this.LblDescripcionComponente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDescripcionComponente.Name = "LblDescripcionComponente";
            this.LblDescripcionComponente.Size = new System.Drawing.Size(192, 20);
            this.LblDescripcionComponente.TabIndex = 1;
            this.LblDescripcionComponente.Text = "Descripción Componente:";
            // 
            // TxtDescripcionComponente
            // 
            this.TxtDescripcionComponente.Location = new System.Drawing.Point(18, 112);
            this.TxtDescripcionComponente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtDescripcionComponente.Multiline = true;
            this.TxtDescripcionComponente.Name = "TxtDescripcionComponente";
            this.TxtDescripcionComponente.Size = new System.Drawing.Size(408, 59);
            this.TxtDescripcionComponente.TabIndex = 2;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(18, 211);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(112, 35);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(315, 211);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(112, 35);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(336, 49);
            this.LblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(54, 20);
            this.LblFecha.TabIndex = 4;
            this.LblFecha.Text = "Fecha";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.Location = new System.Drawing.Point(166, 211);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(112, 35);
            this.BtnEliminar.TabIndex = 7;
            this.BtnEliminar.Text = "Borrar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha:";
            // 
            // BtnConsultarRUC
            // 
            this.BtnConsultarRUC.Location = new System.Drawing.Point(225, 42);
            this.BtnConsultarRUC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnConsultarRUC.Name = "BtnConsultarRUC";
            this.BtnConsultarRUC.Size = new System.Drawing.Size(102, 35);
            this.BtnConsultarRUC.TabIndex = 1;
            this.BtnConsultarRUC.Text = "Consultar";
            this.BtnConsultarRUC.UseVisualStyleBackColor = true;
            this.BtnConsultarRUC.Click += new System.EventHandler(this.BtnConsultarRUC_Click);
            // 
            // ChkPermitirDevolucion
            // 
            this.ChkPermitirDevolucion.AutoSize = true;
            this.ChkPermitirDevolucion.Location = new System.Drawing.Point(18, 179);
            this.ChkPermitirDevolucion.Name = "ChkPermitirDevolucion";
            this.ChkPermitirDevolucion.Size = new System.Drawing.Size(177, 24);
            this.ChkPermitirDevolucion.TabIndex = 3;
            this.ChkPermitirDevolucion.Text = "Permite devolución?";
            this.ChkPermitirDevolucion.UseVisualStyleBackColor = true;
            this.ChkPermitirDevolucion.Visible = false;
            // 
            // IdComponente
            // 
            this.IdComponente.Frozen = true;
            this.IdComponente.HeaderText = "Id";
            this.IdComponente.MinimumWidth = 8;
            this.IdComponente.Name = "IdComponente";
            this.IdComponente.ReadOnly = true;
            this.IdComponente.Visible = false;
            // 
            // NombreComponente
            // 
            this.NombreComponente.HeaderText = "Nombre";
            this.NombreComponente.MinimumWidth = 8;
            this.NombreComponente.Name = "NombreComponente";
            this.NombreComponente.ReadOnly = true;
            // 
            // DescripcionComponente
            // 
            this.DescripcionComponente.HeaderText = "Descripcion";
            this.DescripcionComponente.MinimumWidth = 8;
            this.DescripcionComponente.Name = "DescripcionComponente";
            this.DescripcionComponente.ReadOnly = true;
            // 
            // EsDevolvible
            // 
            this.EsDevolvible.HeaderText = "Devolvible";
            this.EsDevolvible.MinimumWidth = 8;
            this.EsDevolvible.Name = "EsDevolvible";
            this.EsDevolvible.ReadOnly = true;
            this.EsDevolvible.Visible = false;
            // 
            // VistaAgregarComponentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 471);
            this.Controls.Add(this.ChkPermitirDevolucion);
            this.Controls.Add(this.BtnConsultarRUC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TxtDescripcionComponente);
            this.Controls.Add(this.TxtNombreComponente);
            this.Controls.Add(this.LblDescripcionComponente);
            this.Controls.Add(this.LblNuevoComponente);
            this.Controls.Add(this.DgComponentes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaAgregarComponentes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VistaAgregarComponentes_FormClosed);
            this.Load += new System.EventHandler(this.VistaAgregarComponentes_Load);
            this.Click += new System.EventHandler(this.VistaAgregarComponentes_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DgComponentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgComponentes;
        private System.Windows.Forms.TextBox TxtNombreComponente;
        private System.Windows.Forms.TextBox TxtDescripcionComponente;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        public System.Windows.Forms.Label LblNuevoComponente;
        public System.Windows.Forms.Label LblDescripcionComponente;
        public System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Button BtnEliminar;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConsultarRUC;
        private System.Windows.Forms.CheckBox ChkPermitirDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsDevolvible;
    }
}
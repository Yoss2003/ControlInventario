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
            this.DgComponentes = new System.Windows.Forms.DataGridView();
            this.LblNuevoComponente = new System.Windows.Forms.Label();
            this.TxtNombreComponente = new System.Windows.Forms.TextBox();
            this.LblDescripcionComponente = new System.Windows.Forms.Label();
            this.TxtDescripcionComponente = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblFecha = new System.Windows.Forms.Label();
            this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgComponentes)).BeginInit();
            this.SuspendLayout();
            // 
            // DgComponentes
            // 
            this.DgComponentes.AllowUserToAddRows = false;
            this.DgComponentes.AllowUserToDeleteRows = false;
            this.DgComponentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgComponentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdComponente,
            this.NombreComponente,
            this.DescripcionComponente});
            this.DgComponentes.Location = new System.Drawing.Point(12, 166);
            this.DgComponentes.MultiSelect = false;
            this.DgComponentes.Name = "DgComponentes";
            this.DgComponentes.ReadOnly = true;
            this.DgComponentes.Size = new System.Drawing.Size(254, 128);
            this.DgComponentes.TabIndex = 0;
            this.DgComponentes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgComponentes_CellDoubleClick);
            // 
            // LblNuevoComponente
            // 
            this.LblNuevoComponente.AutoSize = true;
            this.LblNuevoComponente.Location = new System.Drawing.Point(13, 13);
            this.LblNuevoComponente.Name = "LblNuevoComponente";
            this.LblNuevoComponente.Size = new System.Drawing.Size(105, 13);
            this.LblNuevoComponente.TabIndex = 1;
            this.LblNuevoComponente.Text = "Nuevo Componente:";
            // 
            // TxtNombreComponente
            // 
            this.TxtNombreComponente.Location = new System.Drawing.Point(12, 29);
            this.TxtNombreComponente.Name = "TxtNombreComponente";
            this.TxtNombreComponente.Size = new System.Drawing.Size(132, 20);
            this.TxtNombreComponente.TabIndex = 1;
            // 
            // LblDescripcionComponente
            // 
            this.LblDescripcionComponente.AutoSize = true;
            this.LblDescripcionComponente.Location = new System.Drawing.Point(13, 57);
            this.LblDescripcionComponente.Name = "LblDescripcionComponente";
            this.LblDescripcionComponente.Size = new System.Drawing.Size(129, 13);
            this.LblDescripcionComponente.TabIndex = 1;
            this.LblDescripcionComponente.Text = "Descripción Componente:";
            // 
            // TxtDescripcionComponente
            // 
            this.TxtDescripcionComponente.Location = new System.Drawing.Point(12, 73);
            this.TxtDescripcionComponente.Multiline = true;
            this.TxtDescripcionComponente.Name = "TxtDescripcionComponente";
            this.TxtDescripcionComponente.Size = new System.Drawing.Size(254, 58);
            this.TxtDescripcionComponente.TabIndex = 2;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(43, 137);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(156, 137);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(196, 32);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(37, 13);
            this.LblFecha.TabIndex = 4;
            this.LblFecha.Text = "Fecha";
            // 
            // IdComponente
            // 
            this.IdComponente.Frozen = true;
            this.IdComponente.HeaderText = "Id";
            this.IdComponente.Name = "IdComponente";
            this.IdComponente.ReadOnly = true;
            this.IdComponente.Visible = false;
            this.IdComponente.Width = 41;
            // 
            // NombreComponente
            // 
            this.NombreComponente.HeaderText = "Nombre";
            this.NombreComponente.Name = "NombreComponente";
            this.NombreComponente.ReadOnly = true;
            this.NombreComponente.Width = 123;
            // 
            // DescripcionComponente
            // 
            this.DescripcionComponente.HeaderText = "Descripcion";
            this.DescripcionComponente.Name = "DescripcionComponente";
            this.DescripcionComponente.ReadOnly = true;
            this.DescripcionComponente.Width = 88;
            // 
            // VistaAgregarComponentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 306);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TxtDescripcionComponente);
            this.Controls.Add(this.TxtNombreComponente);
            this.Controls.Add(this.LblDescripcionComponente);
            this.Controls.Add(this.LblNuevoComponente);
            this.Controls.Add(this.DgComponentes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaAgregarComponentes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VistaAgregarComponentes_FormClosed);
            this.Load += new System.EventHandler(this.VistaAgregarComponentes_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionComponente;
    }
}
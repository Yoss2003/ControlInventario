namespace ControlInventario.Vistas.Extras
{
    partial class VistaVentaAvanzado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvArticulosBusquedaAvanzada = new System.Windows.Forms.DataGridView();
            this.CodigoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcaArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcciónArticulo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbBuscarPorMarca = new System.Windows.Forms.ComboBox();
            this.CbBuscarPorCategoria = new System.Windows.Forms.ComboBox();
            this.TxtBuscarPorNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBuscarPorDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulosBusquedaAvanzada)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvArticulosBusquedaAvanzada
            // 
            this.DgvArticulosBusquedaAvanzada.AllowUserToAddRows = false;
            this.DgvArticulosBusquedaAvanzada.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticulosBusquedaAvanzada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvArticulosBusquedaAvanzada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArticulosBusquedaAvanzada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoArticulo,
            this.DescripcionArticulo,
            this.MarcaArticulo,
            this.PrecioArticulo,
            this.StockArticulo,
            this.AcciónArticulo});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvArticulosBusquedaAvanzada.DefaultCellStyle = dataGridViewCellStyle15;
            this.DgvArticulosBusquedaAvanzada.Location = new System.Drawing.Point(12, 119);
            this.DgvArticulosBusquedaAvanzada.Name = "DgvArticulosBusquedaAvanzada";
            this.DgvArticulosBusquedaAvanzada.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticulosBusquedaAvanzada.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DgvArticulosBusquedaAvanzada.RowHeadersVisible = false;
            this.DgvArticulosBusquedaAvanzada.RowHeadersWidth = 62;
            this.DgvArticulosBusquedaAvanzada.RowTemplate.Height = 28;
            this.DgvArticulosBusquedaAvanzada.Size = new System.Drawing.Size(776, 261);
            this.DgvArticulosBusquedaAvanzada.TabIndex = 5;
            // 
            // CodigoArticulo
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CodigoArticulo.DefaultCellStyle = dataGridViewCellStyle10;
            this.CodigoArticulo.HeaderText = "Código";
            this.CodigoArticulo.MinimumWidth = 8;
            this.CodigoArticulo.Name = "CodigoArticulo";
            this.CodigoArticulo.ReadOnly = true;
            this.CodigoArticulo.Width = 150;
            // 
            // DescripcionArticulo
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DescripcionArticulo.DefaultCellStyle = dataGridViewCellStyle11;
            this.DescripcionArticulo.HeaderText = "Descripción";
            this.DescripcionArticulo.MinimumWidth = 8;
            this.DescripcionArticulo.Name = "DescripcionArticulo";
            this.DescripcionArticulo.ReadOnly = true;
            this.DescripcionArticulo.Width = 150;
            // 
            // MarcaArticulo
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MarcaArticulo.DefaultCellStyle = dataGridViewCellStyle12;
            this.MarcaArticulo.HeaderText = "Marca";
            this.MarcaArticulo.MinimumWidth = 8;
            this.MarcaArticulo.Name = "MarcaArticulo";
            this.MarcaArticulo.ReadOnly = true;
            this.MarcaArticulo.Width = 150;
            // 
            // PrecioArticulo
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PrecioArticulo.DefaultCellStyle = dataGridViewCellStyle13;
            this.PrecioArticulo.HeaderText = "Precio";
            this.PrecioArticulo.MinimumWidth = 8;
            this.PrecioArticulo.Name = "PrecioArticulo";
            this.PrecioArticulo.ReadOnly = true;
            this.PrecioArticulo.Width = 150;
            // 
            // StockArticulo
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StockArticulo.DefaultCellStyle = dataGridViewCellStyle14;
            this.StockArticulo.HeaderText = "Stock";
            this.StockArticulo.MinimumWidth = 8;
            this.StockArticulo.Name = "StockArticulo";
            this.StockArticulo.ReadOnly = true;
            this.StockArticulo.Width = 150;
            // 
            // AcciónArticulo
            // 
            this.AcciónArticulo.HeaderText = "Acción";
            this.AcciónArticulo.MinimumWidth = 8;
            this.AcciónArticulo.Name = "AcciónArticulo";
            this.AcciónArticulo.ReadOnly = true;
            this.AcciónArticulo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AcciónArticulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AcciónArticulo.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbBuscarPorMarca);
            this.groupBox1.Controls.Add(this.CbBuscarPorCategoria);
            this.groupBox1.Controls.Add(this.TxtBuscarPorDescripcion);
            this.groupBox1.Controls.Add(this.TxtBuscarPorNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // CbBuscarPorMarca
            // 
            this.CbBuscarPorMarca.FormattingEnabled = true;
            this.CbBuscarPorMarca.Location = new System.Drawing.Point(591, 48);
            this.CbBuscarPorMarca.Name = "CbBuscarPorMarca";
            this.CbBuscarPorMarca.Size = new System.Drawing.Size(172, 28);
            this.CbBuscarPorMarca.TabIndex = 12;
            // 
            // CbBuscarPorCategoria
            // 
            this.CbBuscarPorCategoria.FormattingEnabled = true;
            this.CbBuscarPorCategoria.Location = new System.Drawing.Point(396, 48);
            this.CbBuscarPorCategoria.Name = "CbBuscarPorCategoria";
            this.CbBuscarPorCategoria.Size = new System.Drawing.Size(172, 28);
            this.CbBuscarPorCategoria.TabIndex = 11;
            // 
            // TxtBuscarPorNombre
            // 
            this.TxtBuscarPorNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarPorNombre.Location = new System.Drawing.Point(6, 49);
            this.TxtBuscarPorNombre.Name = "TxtBuscarPorNombre";
            this.TxtBuscarPorNombre.Size = new System.Drawing.Size(172, 26);
            this.TxtBuscarPorNombre.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Marca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Categoria:";
            // 
            // TxtBuscarPorDescripcion
            // 
            this.TxtBuscarPorDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarPorDescripcion.Location = new System.Drawing.Point(201, 49);
            this.TxtBuscarPorDescripcion.Name = "TxtBuscarPorDescripcion";
            this.TxtBuscarPorDescripcion.Size = new System.Drawing.Size(172, 26);
            this.TxtBuscarPorDescripcion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripción";
            // 
            // VistaVentaAvanzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvArticulosBusquedaAvanzada);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaVentaAvanzado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda avanzada";
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulosBusquedaAvanzada)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DgvArticulosBusquedaAvanzada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcaArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockArticulo;
        private System.Windows.Forms.DataGridViewButtonColumn AcciónArticulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CbBuscarPorMarca;
        private System.Windows.Forms.ComboBox CbBuscarPorCategoria;
        private System.Windows.Forms.TextBox TxtBuscarPorNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBuscarPorDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}
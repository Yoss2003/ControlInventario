namespace ControlInventario.Vistas.Extras
{
    partial class VistaBusquedaAvanzada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.TxtBuscarPorDescripcion = new System.Windows.Forms.TextBox();
            this.TxtBuscarPorNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulosBusquedaAvanzada)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvArticulosBusquedaAvanzada
            // 
            this.DgvArticulosBusquedaAvanzada.AllowUserToAddRows = false;
            this.DgvArticulosBusquedaAvanzada.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticulosBusquedaAvanzada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvArticulosBusquedaAvanzada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArticulosBusquedaAvanzada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoArticulo,
            this.DescripcionArticulo,
            this.MarcaArticulo,
            this.PrecioArticulo,
            this.StockArticulo,
            this.AcciónArticulo});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvArticulosBusquedaAvanzada.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvArticulosBusquedaAvanzada.Location = new System.Drawing.Point(8, 77);
            this.DgvArticulosBusquedaAvanzada.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DgvArticulosBusquedaAvanzada.Name = "DgvArticulosBusquedaAvanzada";
            this.DgvArticulosBusquedaAvanzada.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticulosBusquedaAvanzada.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvArticulosBusquedaAvanzada.RowHeadersVisible = false;
            this.DgvArticulosBusquedaAvanzada.RowHeadersWidth = 62;
            this.DgvArticulosBusquedaAvanzada.RowTemplate.Height = 28;
            this.DgvArticulosBusquedaAvanzada.Size = new System.Drawing.Size(517, 170);
            this.DgvArticulosBusquedaAvanzada.TabIndex = 5;
            this.DgvArticulosBusquedaAvanzada.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticulosBusquedaAvanzada_CellContentClick);
            this.DgvArticulosBusquedaAvanzada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticulosBusquedaAvanzada_CellDoubleClick);
            // 
            // CodigoArticulo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CodigoArticulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodigoArticulo.HeaderText = "Código";
            this.CodigoArticulo.MinimumWidth = 8;
            this.CodigoArticulo.Name = "CodigoArticulo";
            this.CodigoArticulo.ReadOnly = true;
            this.CodigoArticulo.Width = 150;
            // 
            // DescripcionArticulo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DescripcionArticulo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DescripcionArticulo.HeaderText = "Descripción";
            this.DescripcionArticulo.MinimumWidth = 8;
            this.DescripcionArticulo.Name = "DescripcionArticulo";
            this.DescripcionArticulo.ReadOnly = true;
            this.DescripcionArticulo.Width = 150;
            // 
            // MarcaArticulo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MarcaArticulo.DefaultCellStyle = dataGridViewCellStyle4;
            this.MarcaArticulo.HeaderText = "Marca";
            this.MarcaArticulo.MinimumWidth = 8;
            this.MarcaArticulo.Name = "MarcaArticulo";
            this.MarcaArticulo.ReadOnly = true;
            this.MarcaArticulo.Width = 150;
            // 
            // PrecioArticulo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PrecioArticulo.DefaultCellStyle = dataGridViewCellStyle5;
            this.PrecioArticulo.HeaderText = "Precio";
            this.PrecioArticulo.MinimumWidth = 8;
            this.PrecioArticulo.Name = "PrecioArticulo";
            this.PrecioArticulo.ReadOnly = true;
            this.PrecioArticulo.Width = 150;
            // 
            // StockArticulo
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StockArticulo.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(517, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // CbBuscarPorMarca
            // 
            this.CbBuscarPorMarca.FormattingEnabled = true;
            this.CbBuscarPorMarca.Location = new System.Drawing.Point(394, 31);
            this.CbBuscarPorMarca.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CbBuscarPorMarca.Name = "CbBuscarPorMarca";
            this.CbBuscarPorMarca.Size = new System.Drawing.Size(116, 21);
            this.CbBuscarPorMarca.TabIndex = 12;
            // 
            // CbBuscarPorCategoria
            // 
            this.CbBuscarPorCategoria.FormattingEnabled = true;
            this.CbBuscarPorCategoria.Location = new System.Drawing.Point(264, 31);
            this.CbBuscarPorCategoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CbBuscarPorCategoria.Name = "CbBuscarPorCategoria";
            this.CbBuscarPorCategoria.Size = new System.Drawing.Size(116, 21);
            this.CbBuscarPorCategoria.TabIndex = 11;
            // 
            // TxtBuscarPorDescripcion
            // 
            this.TxtBuscarPorDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarPorDescripcion.Location = new System.Drawing.Point(134, 32);
            this.TxtBuscarPorDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtBuscarPorDescripcion.Name = "TxtBuscarPorDescripcion";
            this.TxtBuscarPorDescripcion.Size = new System.Drawing.Size(115, 20);
            this.TxtBuscarPorDescripcion.TabIndex = 10;
            // 
            // TxtBuscarPorNombre
            // 
            this.TxtBuscarPorNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscarPorNombre.Location = new System.Drawing.Point(4, 32);
            this.TxtBuscarPorNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtBuscarPorNombre.Name = "TxtBuscarPorNombre";
            this.TxtBuscarPorNombre.Size = new System.Drawing.Size(115, 20);
            this.TxtBuscarPorNombre.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre";
            // 
            // VistaBusquedaAvanzada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 260);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvArticulosBusquedaAvanzada);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaBusquedaAvanzada";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda avanzada";
            this.Load += new System.EventHandler(this.VistaBusquedaAvanzada_Load);
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
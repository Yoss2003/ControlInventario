namespace ControlInventario.Vistas
{
    partial class VistaInventario
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
            this.TbPrincipal = new System.Windows.Forms.TabControl();
            this.TabInventario = new System.Windows.Forms.TabPage();
            this.LstArticulos = new System.Windows.Forms.ListView();
            this.FlCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.TabAvanzado = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NuAccionInventario = new System.Windows.Forms.NumericUpDown();
            this.LblAccionDecription = new System.Windows.Forms.Label();
            this.BtnNuevaCategoria = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnEliminarArticulo = new System.Windows.Forms.Button();
            this.BtnEditarArticulo = new System.Windows.Forms.Button();
            this.BtnAgregarArticulo = new System.Windows.Forms.Button();
            this.IdArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CodigoArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModeloArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MarcaArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaAdquisicionArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaBajaArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaFinGarantiaArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DniUsuarioActualArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NombreUsuarioActualArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AreaUsuarioActualArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CargoUsuarioActualArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DniUsuarioAnteriorArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NombreUsuarioAnteriorArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AreaUsuarioAnteriorArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CargoUsuarioAnteriorArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EstadoArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UbicacionArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CondicionArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RucArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProveedorArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrecioArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ActivoFijoArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObservacionArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImagenArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ComprobanteArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TbPrincipal.SuspendLayout();
            this.TabInventario.SuspendLayout();
            this.TabAvanzado.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NuAccionInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // TbPrincipal
            // 
            this.TbPrincipal.Controls.Add(this.TabInventario);
            this.TbPrincipal.Controls.Add(this.TabAvanzado);
            this.TbPrincipal.Cursor = System.Windows.Forms.Cursors.Default;
            this.TbPrincipal.Location = new System.Drawing.Point(13, 13);
            this.TbPrincipal.Name = "TbPrincipal";
            this.TbPrincipal.SelectedIndex = 0;
            this.TbPrincipal.Size = new System.Drawing.Size(775, 425);
            this.TbPrincipal.TabIndex = 0;
            // 
            // TabInventario
            // 
            this.TabInventario.Controls.Add(this.LstArticulos);
            this.TabInventario.Controls.Add(this.FlCategorias);
            this.TabInventario.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabInventario.Location = new System.Drawing.Point(4, 22);
            this.TabInventario.Name = "TabInventario";
            this.TabInventario.Padding = new System.Windows.Forms.Padding(3);
            this.TabInventario.Size = new System.Drawing.Size(767, 399);
            this.TabInventario.TabIndex = 0;
            this.TabInventario.Text = "Inventario";
            this.TabInventario.UseVisualStyleBackColor = true;
            // 
            // LstArticulos
            // 
            this.LstArticulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstArticulos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdArticulo,
            this.CodigoArticulo,
            this.ModeloArticulo,
            this.MarcaArticulo,
            this.FechaAdquisicionArticulo,
            this.FechaBajaArticulo,
            this.FechaFinGarantiaArticulo,
            this.DniUsuarioActualArticulo,
            this.NombreUsuarioActualArticulo,
            this.AreaUsuarioActualArticulo,
            this.CargoUsuarioActualArticulo,
            this.DniUsuarioAnteriorArticulo,
            this.NombreUsuarioAnteriorArticulo,
            this.AreaUsuarioAnteriorArticulo,
            this.CargoUsuarioAnteriorArticulo,
            this.EstadoArticulo,
            this.UbicacionArticulo,
            this.CondicionArticulo,
            this.RucArticulo,
            this.ProveedorArticulo,
            this.PrecioArticulo,
            this.ActivoFijoArticulo,
            this.ObservacionArticulo,
            this.ImagenArticulo,
            this.ComprobanteArticulo});
            this.LstArticulos.HideSelection = false;
            this.LstArticulos.Location = new System.Drawing.Point(98, 7);
            this.LstArticulos.Name = "LstArticulos";
            this.LstArticulos.Size = new System.Drawing.Size(663, 386);
            this.LstArticulos.TabIndex = 1;
            this.LstArticulos.UseCompatibleStateImageBehavior = false;
            this.LstArticulos.View = System.Windows.Forms.View.Details;
            // 
            // FlCategorias
            // 
            this.FlCategorias.AutoScroll = true;
            this.FlCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlCategorias.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlCategorias.Location = new System.Drawing.Point(6, 7);
            this.FlCategorias.Name = "FlCategorias";
            this.FlCategorias.Size = new System.Drawing.Size(86, 386);
            this.FlCategorias.TabIndex = 0;
            this.FlCategorias.WrapContents = false;
            // 
            // TabAvanzado
            // 
            this.TabAvanzado.Controls.Add(this.treeView1);
            this.TabAvanzado.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabAvanzado.Location = new System.Drawing.Point(4, 22);
            this.TabAvanzado.Name = "TabAvanzado";
            this.TabAvanzado.Padding = new System.Windows.Forms.Padding(3);
            this.TabAvanzado.Size = new System.Drawing.Size(767, 399);
            this.TabAvanzado.TabIndex = 1;
            this.TabAvanzado.Text = "Avanzado";
            this.TabAvanzado.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(761, 393);
            this.treeView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NuAccionInventario);
            this.groupBox1.Controls.Add(this.LblAccionDecription);
            this.groupBox1.Controls.Add(this.BtnNuevaCategoria);
            this.groupBox1.Controls.Add(this.BtnExportar);
            this.groupBox1.Controls.Add(this.BtnEliminarArticulo);
            this.groupBox1.Controls.Add(this.BtnEditarArticulo);
            this.groupBox1.Controls.Add(this.BtnAgregarArticulo);
            this.groupBox1.Location = new System.Drawing.Point(17, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // NuAccionInventario
            // 
            this.NuAccionInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NuAccionInventario.Location = new System.Drawing.Point(6, 22);
            this.NuAccionInventario.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NuAccionInventario.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NuAccionInventario.Name = "NuAccionInventario";
            this.NuAccionInventario.Size = new System.Drawing.Size(37, 20);
            this.NuAccionInventario.TabIndex = 2;
            this.NuAccionInventario.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NuAccionInventario.ValueChanged += new System.EventHandler(this.NuAccionInventario_ValueChanged);
            // 
            // LblAccionDecription
            // 
            this.LblAccionDecription.AutoSize = true;
            this.LblAccionDecription.Location = new System.Drawing.Point(57, 24);
            this.LblAccionDecription.Name = "LblAccionDecription";
            this.LblAccionDecription.Size = new System.Drawing.Size(35, 13);
            this.LblAccionDecription.TabIndex = 1;
            this.LblAccionDecription.Text = "label1";
            // 
            // BtnNuevaCategoria
            // 
            this.BtnNuevaCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNuevaCategoria.Location = new System.Drawing.Point(287, 19);
            this.BtnNuevaCategoria.Name = "BtnNuevaCategoria";
            this.BtnNuevaCategoria.Size = new System.Drawing.Size(95, 23);
            this.BtnNuevaCategoria.TabIndex = 0;
            this.BtnNuevaCategoria.Text = "Nueva Categoria";
            this.BtnNuevaCategoria.UseVisualStyleBackColor = true;
            this.BtnNuevaCategoria.Click += new System.EventHandler(this.BtnNuevaCategoria_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportar.Location = new System.Drawing.Point(106, 19);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(57, 23);
            this.BtnExportar.TabIndex = 0;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // BtnEliminarArticulo
            // 
            this.BtnEliminarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEliminarArticulo.Location = new System.Drawing.Point(476, 19);
            this.BtnEliminarArticulo.Name = "BtnEliminarArticulo";
            this.BtnEliminarArticulo.Size = new System.Drawing.Size(91, 23);
            this.BtnEliminarArticulo.TabIndex = 0;
            this.BtnEliminarArticulo.Text = "EliminarArticulo";
            this.BtnEliminarArticulo.UseVisualStyleBackColor = true;
            this.BtnEliminarArticulo.Click += new System.EventHandler(this.BtnEliminarArticulo_Click);
            // 
            // BtnEditarArticulo
            // 
            this.BtnEditarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditarArticulo.Location = new System.Drawing.Point(573, 19);
            this.BtnEditarArticulo.Name = "BtnEditarArticulo";
            this.BtnEditarArticulo.Size = new System.Drawing.Size(91, 23);
            this.BtnEditarArticulo.TabIndex = 0;
            this.BtnEditarArticulo.Text = "Editar Articulo";
            this.BtnEditarArticulo.UseVisualStyleBackColor = true;
            this.BtnEditarArticulo.Click += new System.EventHandler(this.BtnEditarArticulo_Click);
            // 
            // BtnAgregarArticulo
            // 
            this.BtnAgregarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarArticulo.Location = new System.Drawing.Point(670, 19);
            this.BtnAgregarArticulo.Name = "BtnAgregarArticulo";
            this.BtnAgregarArticulo.Size = new System.Drawing.Size(91, 23);
            this.BtnAgregarArticulo.TabIndex = 0;
            this.BtnAgregarArticulo.Text = "Agregar Articulo";
            this.BtnAgregarArticulo.UseVisualStyleBackColor = true;
            this.BtnAgregarArticulo.Click += new System.EventHandler(this.BtnAgregarArticulo_Click);
            // 
            // IdArticulo
            // 
            this.IdArticulo.Text = "Id";
            // 
            // CodigoArticulo
            // 
            this.CodigoArticulo.Text = "Codigo";
            this.CodigoArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ModeloArticulo
            // 
            this.ModeloArticulo.Text = "Modelo";
            this.ModeloArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MarcaArticulo
            // 
            this.MarcaArticulo.Text = "Marca";
            this.MarcaArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FechaAdquisicionArticulo
            // 
            this.FechaAdquisicionArticulo.Text = "Fecha adquisicion";
            this.FechaAdquisicionArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FechaBajaArticulo
            // 
            this.FechaBajaArticulo.Text = "FechaBaja";
            this.FechaBajaArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FechaFinGarantiaArticulo
            // 
            this.FechaFinGarantiaArticulo.Text = "Fecha fin garantia";
            this.FechaFinGarantiaArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DniUsuarioActualArticulo
            // 
            this.DniUsuarioActualArticulo.Text = "Dni usuario actual";
            this.DniUsuarioActualArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NombreUsuarioActualArticulo
            // 
            this.NombreUsuarioActualArticulo.Text = "Usuario actual";
            this.NombreUsuarioActualArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AreaUsuarioActualArticulo
            // 
            this.AreaUsuarioActualArticulo.Text = "Area usuario actual";
            // 
            // CargoUsuarioActualArticulo
            // 
            this.CargoUsuarioActualArticulo.Text = "Cargo usuario actual";
            this.CargoUsuarioActualArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DniUsuarioAnteriorArticulo
            // 
            this.DniUsuarioAnteriorArticulo.Text = "Dni usuario anterior";
            this.DniUsuarioAnteriorArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NombreUsuarioAnteriorArticulo
            // 
            this.NombreUsuarioAnteriorArticulo.Text = "Usuario anterior";
            // 
            // AreaUsuarioAnteriorArticulo
            // 
            this.AreaUsuarioAnteriorArticulo.Text = "Area usuario anterior";
            // 
            // CargoUsuarioAnteriorArticulo
            // 
            this.CargoUsuarioAnteriorArticulo.Text = "Cargo usuario anterior";
            // 
            // EstadoArticulo
            // 
            this.EstadoArticulo.Text = "Estado";
            // 
            // UbicacionArticulo
            // 
            this.UbicacionArticulo.Text = "Ubicación";
            // 
            // CondicionArticulo
            // 
            this.CondicionArticulo.Text = "Condición";
            // 
            // RucArticulo
            // 
            this.RucArticulo.Text = "Ruc proveedor";
            // 
            // ProveedorArticulo
            // 
            this.ProveedorArticulo.Text = "Razón social";
            // 
            // PrecioArticulo
            // 
            this.PrecioArticulo.Text = "Precio adquirido";
            // 
            // ActivoFijoArticulo
            // 
            this.ActivoFijoArticulo.Text = "Activo fijo";
            // 
            // ObservacionArticulo
            // 
            this.ObservacionArticulo.Text = "Observacion";
            // 
            // ImagenArticulo
            // 
            this.ImagenArticulo.Text = "Imagen";
            // 
            // ComprobanteArticulo
            // 
            this.ComprobanteArticulo.Text = "Comprobante";
            // 
            // VistaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TbPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VistaInventario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.VistaInventario_Load);
            this.TbPrincipal.ResumeLayout(false);
            this.TabInventario.ResumeLayout(false);
            this.TabAvanzado.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NuAccionInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbPrincipal;
        private System.Windows.Forms.TabPage TabAvanzado;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Button BtnEliminarArticulo;
        private System.Windows.Forms.Button BtnEditarArticulo;
        private System.Windows.Forms.Button BtnAgregarArticulo;
        private System.Windows.Forms.Label LblAccionDecription;
        private System.Windows.Forms.Button BtnNuevaCategoria;
        public System.Windows.Forms.NumericUpDown NuAccionInventario;
        public System.Windows.Forms.TabPage TabInventario;
        public System.Windows.Forms.FlowLayoutPanel FlCategorias;
        public System.Windows.Forms.ListView LstArticulos;
        private System.Windows.Forms.ColumnHeader IdArticulo;
        private System.Windows.Forms.ColumnHeader CodigoArticulo;
        private System.Windows.Forms.ColumnHeader ModeloArticulo;
        private System.Windows.Forms.ColumnHeader MarcaArticulo;
        private System.Windows.Forms.ColumnHeader FechaAdquisicionArticulo;
        private System.Windows.Forms.ColumnHeader FechaBajaArticulo;
        private System.Windows.Forms.ColumnHeader FechaFinGarantiaArticulo;
        private System.Windows.Forms.ColumnHeader DniUsuarioActualArticulo;
        private System.Windows.Forms.ColumnHeader NombreUsuarioActualArticulo;
        private System.Windows.Forms.ColumnHeader AreaUsuarioActualArticulo;
        private System.Windows.Forms.ColumnHeader CargoUsuarioActualArticulo;
        private System.Windows.Forms.ColumnHeader DniUsuarioAnteriorArticulo;
        private System.Windows.Forms.ColumnHeader NombreUsuarioAnteriorArticulo;
        private System.Windows.Forms.ColumnHeader AreaUsuarioAnteriorArticulo;
        private System.Windows.Forms.ColumnHeader CargoUsuarioAnteriorArticulo;
        private System.Windows.Forms.ColumnHeader EstadoArticulo;
        private System.Windows.Forms.ColumnHeader UbicacionArticulo;
        private System.Windows.Forms.ColumnHeader CondicionArticulo;
        private System.Windows.Forms.ColumnHeader RucArticulo;
        private System.Windows.Forms.ColumnHeader ProveedorArticulo;
        private System.Windows.Forms.ColumnHeader PrecioArticulo;
        private System.Windows.Forms.ColumnHeader ActivoFijoArticulo;
        private System.Windows.Forms.ColumnHeader ObservacionArticulo;
        private System.Windows.Forms.ColumnHeader ImagenArticulo;
        private System.Windows.Forms.ColumnHeader ComprobanteArticulo;
    }
}
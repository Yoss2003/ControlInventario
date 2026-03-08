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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInventario));
            this.TbPrincipal = new System.Windows.Forms.TabControl();
            this.TabInventario = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkUsarFechas = new System.Windows.Forms.CheckBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbBuscarMarcaArticulo = new System.Windows.Forms.ComboBox();
            this.TxtBuscarCodArticulo = new System.Windows.Forms.TextBox();
            this.DtBuscarFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.DtBuscarFechaFin = new System.Windows.Forms.DateTimePicker();
            this.LstArticulos = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CodigoArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModeloArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SerieArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.LstDefault = new System.Windows.Forms.ListView();
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
            this.TbPrincipal.SuspendLayout();
            this.TabInventario.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            resources.ApplyResources(this.TbPrincipal, "TbPrincipal");
            this.TbPrincipal.Name = "TbPrincipal";
            this.TbPrincipal.SelectedIndex = 0;
            // 
            // TabInventario
            // 
            this.TabInventario.Controls.Add(this.groupBox2);
            this.TabInventario.Controls.Add(this.LstArticulos);
            this.TabInventario.Controls.Add(this.LstDefault);
            this.TabInventario.Controls.Add(this.FlCategorias);
            this.TabInventario.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.TabInventario, "TabInventario");
            this.TabInventario.Name = "TabInventario";
            this.TabInventario.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkUsarFechas);
            this.groupBox2.Controls.Add(this.BtnLimpiar);
            this.groupBox2.Controls.Add(this.BtnBuscar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CbBuscarMarcaArticulo);
            this.groupBox2.Controls.Add(this.TxtBuscarCodArticulo);
            this.groupBox2.Controls.Add(this.DtBuscarFechaInicio);
            this.groupBox2.Controls.Add(this.DtBuscarFechaFin);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ChkUsarFechas
            // 
            resources.ApplyResources(this.ChkUsarFechas, "ChkUsarFechas");
            this.ChkUsarFechas.Name = "ChkUsarFechas";
            this.ChkUsarFechas.UseVisualStyleBackColor = true;
            this.ChkUsarFechas.CheckedChanged += new System.EventHandler(this.ChkUsarFechas_CheckedChanged);
            // 
            // BtnLimpiar
            // 
            resources.ApplyResources(this.BtnLimpiar, "BtnLimpiar");
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            resources.ApplyResources(this.BtnBuscar, "BtnBuscar");
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CbBuscarMarcaArticulo
            // 
            this.CbBuscarMarcaArticulo.FormattingEnabled = true;
            resources.ApplyResources(this.CbBuscarMarcaArticulo, "CbBuscarMarcaArticulo");
            this.CbBuscarMarcaArticulo.Name = "CbBuscarMarcaArticulo";
            this.CbBuscarMarcaArticulo.SelectedIndexChanged += new System.EventHandler(this.CbBuscarMarcaArticulo_SelectedIndexChanged);
            this.CbBuscarMarcaArticulo.TextUpdate += new System.EventHandler(this.CbBuscarMarcaArticulo_TextUpdate);
            // 
            // TxtBuscarCodArticulo
            // 
            resources.ApplyResources(this.TxtBuscarCodArticulo, "TxtBuscarCodArticulo");
            this.TxtBuscarCodArticulo.Name = "TxtBuscarCodArticulo";
            this.TxtBuscarCodArticulo.TextChanged += new System.EventHandler(this.TxtBuscarCodArticulo_TextChanged);
            // 
            // DtBuscarFechaInicio
            // 
            resources.ApplyResources(this.DtBuscarFechaInicio, "DtBuscarFechaInicio");
            this.DtBuscarFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBuscarFechaInicio.Name = "DtBuscarFechaInicio";
            // 
            // DtBuscarFechaFin
            // 
            resources.ApplyResources(this.DtBuscarFechaFin, "DtBuscarFechaFin");
            this.DtBuscarFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBuscarFechaFin.Name = "DtBuscarFechaFin";
            // 
            // LstArticulos
            // 
            this.LstArticulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstArticulos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.CodigoArticulo,
            this.ModeloArticulo,
            this.SerieArticulo,
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
            this.LstArticulos.FullRowSelect = true;
            this.LstArticulos.GridLines = true;
            this.LstArticulos.HideSelection = false;
            resources.ApplyResources(this.LstArticulos, "LstArticulos");
            this.LstArticulos.Name = "LstArticulos";
            this.LstArticulos.UseCompatibleStateImageBehavior = false;
            this.LstArticulos.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            resources.ApplyResources(this.Id, "Id");
            // 
            // CodigoArticulo
            // 
            resources.ApplyResources(this.CodigoArticulo, "CodigoArticulo");
            // 
            // ModeloArticulo
            // 
            resources.ApplyResources(this.ModeloArticulo, "ModeloArticulo");
            // 
            // SerieArticulo
            // 
            resources.ApplyResources(this.SerieArticulo, "SerieArticulo");
            // 
            // MarcaArticulo
            // 
            resources.ApplyResources(this.MarcaArticulo, "MarcaArticulo");
            // 
            // FechaAdquisicionArticulo
            // 
            resources.ApplyResources(this.FechaAdquisicionArticulo, "FechaAdquisicionArticulo");
            // 
            // FechaBajaArticulo
            // 
            resources.ApplyResources(this.FechaBajaArticulo, "FechaBajaArticulo");
            // 
            // FechaFinGarantiaArticulo
            // 
            resources.ApplyResources(this.FechaFinGarantiaArticulo, "FechaFinGarantiaArticulo");
            // 
            // DniUsuarioActualArticulo
            // 
            resources.ApplyResources(this.DniUsuarioActualArticulo, "DniUsuarioActualArticulo");
            // 
            // NombreUsuarioActualArticulo
            // 
            resources.ApplyResources(this.NombreUsuarioActualArticulo, "NombreUsuarioActualArticulo");
            // 
            // AreaUsuarioActualArticulo
            // 
            resources.ApplyResources(this.AreaUsuarioActualArticulo, "AreaUsuarioActualArticulo");
            // 
            // CargoUsuarioActualArticulo
            // 
            resources.ApplyResources(this.CargoUsuarioActualArticulo, "CargoUsuarioActualArticulo");
            // 
            // DniUsuarioAnteriorArticulo
            // 
            resources.ApplyResources(this.DniUsuarioAnteriorArticulo, "DniUsuarioAnteriorArticulo");
            // 
            // NombreUsuarioAnteriorArticulo
            // 
            resources.ApplyResources(this.NombreUsuarioAnteriorArticulo, "NombreUsuarioAnteriorArticulo");
            // 
            // AreaUsuarioAnteriorArticulo
            // 
            resources.ApplyResources(this.AreaUsuarioAnteriorArticulo, "AreaUsuarioAnteriorArticulo");
            // 
            // CargoUsuarioAnteriorArticulo
            // 
            resources.ApplyResources(this.CargoUsuarioAnteriorArticulo, "CargoUsuarioAnteriorArticulo");
            // 
            // EstadoArticulo
            // 
            resources.ApplyResources(this.EstadoArticulo, "EstadoArticulo");
            // 
            // UbicacionArticulo
            // 
            resources.ApplyResources(this.UbicacionArticulo, "UbicacionArticulo");
            // 
            // CondicionArticulo
            // 
            resources.ApplyResources(this.CondicionArticulo, "CondicionArticulo");
            // 
            // RucArticulo
            // 
            resources.ApplyResources(this.RucArticulo, "RucArticulo");
            // 
            // ProveedorArticulo
            // 
            resources.ApplyResources(this.ProveedorArticulo, "ProveedorArticulo");
            // 
            // PrecioArticulo
            // 
            resources.ApplyResources(this.PrecioArticulo, "PrecioArticulo");
            // 
            // ActivoFijoArticulo
            // 
            resources.ApplyResources(this.ActivoFijoArticulo, "ActivoFijoArticulo");
            // 
            // ObservacionArticulo
            // 
            resources.ApplyResources(this.ObservacionArticulo, "ObservacionArticulo");
            // 
            // ImagenArticulo
            // 
            resources.ApplyResources(this.ImagenArticulo, "ImagenArticulo");
            // 
            // ComprobanteArticulo
            // 
            resources.ApplyResources(this.ComprobanteArticulo, "ComprobanteArticulo");
            // 
            // LstDefault
            // 
            this.LstDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstDefault.HideSelection = false;
            resources.ApplyResources(this.LstDefault, "LstDefault");
            this.LstDefault.Name = "LstDefault";
            this.LstDefault.UseCompatibleStateImageBehavior = false;
            // 
            // FlCategorias
            // 
            resources.ApplyResources(this.FlCategorias, "FlCategorias");
            this.FlCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlCategorias.Name = "FlCategorias";
            // 
            // TabAvanzado
            // 
            this.TabAvanzado.Controls.Add(this.treeView1);
            this.TabAvanzado.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.TabAvanzado, "TabAvanzado");
            this.TabAvanzado.Name = "TabAvanzado";
            this.TabAvanzado.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // NuAccionInventario
            // 
            this.NuAccionInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.NuAccionInventario, "NuAccionInventario");
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
            this.NuAccionInventario.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NuAccionInventario.ValueChanged += new System.EventHandler(this.NuAccionInventario_ValueChanged);
            // 
            // LblAccionDecription
            // 
            resources.ApplyResources(this.LblAccionDecription, "LblAccionDecription");
            this.LblAccionDecription.Name = "LblAccionDecription";
            // 
            // BtnNuevaCategoria
            // 
            this.BtnNuevaCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnNuevaCategoria, "BtnNuevaCategoria");
            this.BtnNuevaCategoria.Name = "BtnNuevaCategoria";
            this.BtnNuevaCategoria.UseVisualStyleBackColor = true;
            this.BtnNuevaCategoria.Click += new System.EventHandler(this.BtnNuevaCategoria_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnExportar, "BtnExportar");
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // BtnEliminarArticulo
            // 
            this.BtnEliminarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnEliminarArticulo, "BtnEliminarArticulo");
            this.BtnEliminarArticulo.Name = "BtnEliminarArticulo";
            this.BtnEliminarArticulo.UseVisualStyleBackColor = true;
            this.BtnEliminarArticulo.Click += new System.EventHandler(this.BtnEliminarArticulo_Click);
            // 
            // BtnEditarArticulo
            // 
            this.BtnEditarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnEditarArticulo, "BtnEditarArticulo");
            this.BtnEditarArticulo.Name = "BtnEditarArticulo";
            this.BtnEditarArticulo.UseVisualStyleBackColor = true;
            this.BtnEditarArticulo.Click += new System.EventHandler(this.BtnEditarArticulo_Click);
            // 
            // BtnAgregarArticulo
            // 
            this.BtnAgregarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnAgregarArticulo, "BtnAgregarArticulo");
            this.BtnAgregarArticulo.Name = "BtnAgregarArticulo";
            this.BtnAgregarArticulo.UseVisualStyleBackColor = true;
            this.BtnAgregarArticulo.Click += new System.EventHandler(this.BtnAgregarArticulo_Click);
            // 
            // VistaInventario
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TbPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VistaInventario";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.VistaInventario_Load);
            this.TbPrincipal.ResumeLayout(false);
            this.TabInventario.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader CodigoArticulo;
        private System.Windows.Forms.ColumnHeader ModeloArticulo;
        private System.Windows.Forms.ColumnHeader SerieArticulo;
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
        private System.Windows.Forms.ListView LstDefault;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker DtBuscarFechaInicio;
        private System.Windows.Forms.DateTimePicker DtBuscarFechaFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbBuscarMarcaArticulo;
        private System.Windows.Forms.TextBox TxtBuscarCodArticulo;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.CheckBox ChkUsarFechas;
        private System.Windows.Forms.Label label5;
    }
}
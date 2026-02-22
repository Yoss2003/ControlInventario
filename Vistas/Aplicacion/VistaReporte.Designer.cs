namespace ControlInventario.Vistas
{
    partial class VistaReporte
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Inventario general");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Stock actual por artículo");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Stock min/max");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reporte de existencias", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Entradas de artículos");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Salidas de artículos");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Movimientos", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Transferencias internas");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Movientos generales");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Movimientos recientes");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Movientos antiguos");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Historial", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Reporte de movimientos", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Vigentes");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Por vencer");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Expiradas");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Estado de garantías", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Artículos congelados");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Reportes de estados", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Categorías");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Marcas");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Áreas de uso");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Usuarios responsables");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Reportes de clasificación", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Valor total del inventario");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Valor por categoría/marca");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Valor por área de uso");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Reportes de valorización", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Artículos nuevos en el periodo");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Artículos obsoletos o dados de baja");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Pedidos pendientes");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Exportación de consultas personalizadas");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Reportes Extras", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32});
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabInformación = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TabGráfica = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TreeReports = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TabInformación.SuspendLayout();
            this.TabGráfica.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabInformación);
            this.tabControl1.Controls.Add(this.TabGráfica);
            this.tabControl1.Location = new System.Drawing.Point(286, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // TabInformación
            // 
            this.TabInformación.Controls.Add(this.groupBox1);
            this.TabInformación.Location = new System.Drawing.Point(4, 22);
            this.TabInformación.Name = "TabInformación";
            this.TabInformación.Padding = new System.Windows.Forms.Padding(3);
            this.TabInformación.Size = new System.Drawing.Size(680, 447);
            this.TabInformación.TabIndex = 0;
            this.TabInformación.Text = "Información";
            this.TabInformación.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 441);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TabGráfica
            // 
            this.TabGráfica.Controls.Add(this.groupBox2);
            this.TabGráfica.Location = new System.Drawing.Point(4, 22);
            this.TabGráfica.Name = "TabGráfica";
            this.TabGráfica.Padding = new System.Windows.Forms.Padding(3);
            this.TabGráfica.Size = new System.Drawing.Size(680, 447);
            this.TabGráfica.TabIndex = 1;
            this.TabGráfica.Text = "Gráfica";
            this.TabGráfica.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 441);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TreeReports);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 442);
            this.panel1.TabIndex = 1;
            // 
            // TreeReports
            // 
            this.TreeReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeReports.Location = new System.Drawing.Point(0, 0);
            this.TreeReports.Margin = new System.Windows.Forms.Padding(3, 55, 3, 3);
            this.TreeReports.Name = "TreeReports";
            treeNode1.Name = "ReportInventGen";
            treeNode1.Text = "Inventario general";
            treeNode2.Name = "ReportStockActual";
            treeNode2.Text = "Stock actual por artículo";
            treeNode3.Name = "ReportStok";
            treeNode3.Text = "Stock min/max";
            treeNode4.Name = "";
            treeNode4.Text = "Reporte de existencias";
            treeNode5.Name = "RerportEntradas";
            treeNode5.Text = "Entradas de artículos";
            treeNode6.Name = "ReportSalidas";
            treeNode6.Text = "Salidas de artículos";
            treeNode7.Name = "Nodo32";
            treeNode7.Text = "Movimientos";
            treeNode8.Name = "ReportTransferencias";
            treeNode8.Text = "Transferencias internas";
            treeNode9.Name = "ReportHistorialGen";
            treeNode9.Text = "Movientos generales";
            treeNode10.Name = "ReportHistorialRecent";
            treeNode10.Text = "Movimientos recientes";
            treeNode11.Name = "ReportHistorialOld";
            treeNode11.Text = "Movientos antiguos";
            treeNode12.Name = "";
            treeNode12.Text = "Historial";
            treeNode13.Name = "Nodo1";
            treeNode13.Text = "Reporte de movimientos";
            treeNode14.Name = "ReportEstVigenete";
            treeNode14.Text = "Vigentes";
            treeNode15.Name = "ReportEstPorVencer";
            treeNode15.Text = "Por vencer";
            treeNode16.Name = "ReportEstExpirado";
            treeNode16.Text = "Expiradas";
            treeNode17.Name = "Garantias";
            treeNode17.Text = "Estado de garantías";
            treeNode18.Name = "ReportConge";
            treeNode18.Text = "Artículos congelados";
            treeNode19.Name = "Nodo2";
            treeNode19.Text = "Reportes de estados";
            treeNode20.Name = "ReportCategoria";
            treeNode20.Text = "Categorías";
            treeNode21.Name = "ReportMarca";
            treeNode21.Text = "Marcas";
            treeNode22.Name = "ReportArea";
            treeNode22.Text = "Áreas de uso";
            treeNode23.Name = "ReportUsuario";
            treeNode23.Text = "Usuarios responsables";
            treeNode24.Name = "Nodo3";
            treeNode24.Text = "Reportes de clasificación";
            treeNode25.Name = "ReportValorizacionInventario";
            treeNode25.Text = "Valor total del inventario";
            treeNode26.Name = "ReportValorizacionCategoria";
            treeNode26.Text = "Valor por categoría/marca";
            treeNode27.Name = "ReportValorizacionArea";
            treeNode27.Text = "Valor por área de uso";
            treeNode28.Name = "Nodo4";
            treeNode28.Text = "Reportes de valorización";
            treeNode29.Name = "Nodo24";
            treeNode29.Text = "Artículos nuevos en el periodo";
            treeNode30.Name = "Nodo25";
            treeNode30.Text = "Artículos obsoletos o dados de baja";
            treeNode31.Name = "Nodo26";
            treeNode31.Text = "Pedidos pendientes";
            treeNode32.Name = "Nodo27";
            treeNode32.Text = "Exportación de consultas personalizadas";
            treeNode33.Name = "Nodo5";
            treeNode33.Text = "Reportes Extras";
            this.TreeReports.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode13,
            treeNode19,
            treeNode24,
            treeNode28,
            treeNode33});
            this.TreeReports.Size = new System.Drawing.Size(268, 442);
            this.TreeReports.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // VistaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaReporte";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.tabControl1.ResumeLayout(false);
            this.TabInformación.ResumeLayout(false);
            this.TabGráfica.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabInformación;
        private System.Windows.Forms.TabPage TabGráfica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TreeView TreeReports;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
namespace ControlInventario.Vistas.Aplicacion
{
    partial class VistaRegistros
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Entradas");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Salidas");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Movimientos", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Modificaciones");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Historial", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Todos");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Activos");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Inactivos");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Empleados", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnNewEstado = new System.Windows.Forms.Button();
            this.BtnNewArea = new System.Windows.Forms.Button();
            this.BtnNewCargo = new System.Windows.Forms.Button();
            this.CbCargo = new System.Windows.Forms.ComboBox();
            this.CbArea = new System.Windows.Forms.ComboBox();
            this.CbEstadoEmpleados = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnBuscarEmpleado = new System.Windows.Forms.Button();
            this.BtnAgregarEmpleado = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.TxtNombres = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CbCategoria = new System.Windows.Forms.ComboBox();
            this.DtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.BtnAplicar = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.DgHistorial = new System.Windows.Forms.DataGridView();
            this.IdReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservacionArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabEmpleados = new System.Windows.Forms.TabPage();
            this.DgEmpleados = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.GrpEmpleados = new System.Windows.Forms.GroupBox();
            this.LstEmpleados = new System.Windows.Forms.ListView();
            this.EmpleadoNombres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpleadoApellidos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpleadoDNI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpleadoCargo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpleadoArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpleadoEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DniEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgHistorial)).BeginInit();
            this.TabEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.GrpEmpleados.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnNewEstado);
            this.groupBox2.Controls.Add(this.BtnNewArea);
            this.groupBox2.Controls.Add(this.BtnNewCargo);
            this.groupBox2.Controls.Add(this.CbCargo);
            this.groupBox2.Controls.Add(this.CbArea);
            this.groupBox2.Controls.Add(this.CbEstadoEmpleados);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BtnBuscarEmpleado);
            this.groupBox2.Controls.Add(this.BtnAgregarEmpleado);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TxtApellidos);
            this.groupBox2.Controls.Add(this.TxtDNI);
            this.groupBox2.Controls.Add(this.TxtNombres);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 226);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Empleado";
            // 
            // BtnNewEstado
            // 
            this.BtnNewEstado.Location = new System.Drawing.Point(272, 144);
            this.BtnNewEstado.Name = "BtnNewEstado";
            this.BtnNewEstado.Size = new System.Drawing.Size(31, 21);
            this.BtnNewEstado.TabIndex = 11;
            this.BtnNewEstado.Text = "...";
            this.BtnNewEstado.UseVisualStyleBackColor = true;
            this.BtnNewEstado.Click += new System.EventHandler(this.BtnNewEstado_Click);
            // 
            // BtnNewArea
            // 
            this.BtnNewArea.Location = new System.Drawing.Point(272, 93);
            this.BtnNewArea.Name = "BtnNewArea";
            this.BtnNewArea.Size = new System.Drawing.Size(31, 21);
            this.BtnNewArea.TabIndex = 11;
            this.BtnNewArea.Text = "...";
            this.BtnNewArea.UseVisualStyleBackColor = true;
            this.BtnNewArea.Click += new System.EventHandler(this.BtnNewArea_Click);
            // 
            // BtnNewCargo
            // 
            this.BtnNewCargo.Location = new System.Drawing.Point(272, 41);
            this.BtnNewCargo.Name = "BtnNewCargo";
            this.BtnNewCargo.Size = new System.Drawing.Size(31, 21);
            this.BtnNewCargo.TabIndex = 11;
            this.BtnNewCargo.Text = "...";
            this.BtnNewCargo.UseVisualStyleBackColor = true;
            this.BtnNewCargo.Click += new System.EventHandler(this.BtnNewCargo_Click);
            // 
            // CbCargo
            // 
            this.CbCargo.FormattingEnabled = true;
            this.CbCargo.Location = new System.Drawing.Point(162, 41);
            this.CbCargo.Name = "CbCargo";
            this.CbCargo.Size = new System.Drawing.Size(103, 21);
            this.CbCargo.TabIndex = 3;
            this.CbCargo.Text = "SELECCIONE";
            // 
            // CbArea
            // 
            this.CbArea.FormattingEnabled = true;
            this.CbArea.Location = new System.Drawing.Point(162, 93);
            this.CbArea.Name = "CbArea";
            this.CbArea.Size = new System.Drawing.Size(103, 21);
            this.CbArea.TabIndex = 3;
            this.CbArea.Text = "SELECCIONE";
            // 
            // CbEstadoEmpleados
            // 
            this.CbEstadoEmpleados.FormattingEnabled = true;
            this.CbEstadoEmpleados.Location = new System.Drawing.Point(162, 144);
            this.CbEstadoEmpleados.Name = "CbEstadoEmpleados";
            this.CbEstadoEmpleados.Size = new System.Drawing.Size(103, 21);
            this.CbEstadoEmpleados.TabIndex = 3;
            this.CbEstadoEmpleados.Text = "SELECCIONE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "DNI:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cargo:";
            // 
            // BtnBuscarEmpleado
            // 
            this.BtnBuscarEmpleado.Location = new System.Drawing.Point(162, 183);
            this.BtnBuscarEmpleado.Name = "BtnBuscarEmpleado";
            this.BtnBuscarEmpleado.Size = new System.Drawing.Size(85, 23);
            this.BtnBuscarEmpleado.TabIndex = 10;
            this.BtnBuscarEmpleado.Text = "Buscar";
            this.BtnBuscarEmpleado.UseVisualStyleBackColor = true;
            // 
            // BtnAgregarEmpleado
            // 
            this.BtnAgregarEmpleado.Location = new System.Drawing.Point(55, 183);
            this.BtnAgregarEmpleado.Name = "BtnAgregarEmpleado";
            this.BtnAgregarEmpleado.Size = new System.Drawing.Size(85, 23);
            this.BtnAgregarEmpleado.TabIndex = 10;
            this.BtnAgregarEmpleado.Text = "Agregar";
            this.BtnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.BtnAgregarEmpleado.Click += new System.EventHandler(this.BtnAgregarEmpleado_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Área:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellidos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombres:";
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.Location = new System.Drawing.Point(19, 93);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(103, 20);
            this.TxtApellidos.TabIndex = 1;
            // 
            // TxtDNI
            // 
            this.TxtDNI.Location = new System.Drawing.Point(19, 145);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(103, 20);
            this.TxtDNI.TabIndex = 1;
            // 
            // TxtNombres
            // 
            this.TxtNombres.Location = new System.Drawing.Point(19, 42);
            this.TxtNombres.Name = "TxtNombres";
            this.TxtNombres.Size = new System.Drawing.Size(103, 20);
            this.TxtNombres.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.CbCategoria);
            this.groupBox4.Controls.Add(this.DtFechaFin);
            this.groupBox4.Controls.Add(this.DtFechaInicio);
            this.groupBox4.Controls.Add(this.BtnAplicar);
            this.groupBox4.Controls.Add(this.treeView1);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(309, 194);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtros";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(189, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Categoría:";
            // 
            // CbCategoria
            // 
            this.CbCategoria.DisplayMember = "Id";
            this.CbCategoria.FormattingEnabled = true;
            this.CbCategoria.Location = new System.Drawing.Point(192, 121);
            this.CbCategoria.Name = "CbCategoria";
            this.CbCategoria.Size = new System.Drawing.Size(99, 21);
            this.CbCategoria.TabIndex = 13;
            this.CbCategoria.Text = "SELECCIONE";
            this.CbCategoria.ValueMember = "Id";
            // 
            // DtFechaFin
            // 
            this.DtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaFin.Location = new System.Drawing.Point(192, 75);
            this.DtFechaFin.Name = "DtFechaFin";
            this.DtFechaFin.Size = new System.Drawing.Size(99, 20);
            this.DtFechaFin.TabIndex = 11;
            // 
            // DtFechaInicio
            // 
            this.DtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaInicio.Location = new System.Drawing.Point(192, 31);
            this.DtFechaInicio.Name = "DtFechaInicio";
            this.DtFechaInicio.Size = new System.Drawing.Size(99, 20);
            this.DtFechaInicio.TabIndex = 12;
            // 
            // BtnAplicar
            // 
            this.BtnAplicar.Location = new System.Drawing.Point(192, 155);
            this.BtnAplicar.Name = "BtnAplicar";
            this.BtnAplicar.Size = new System.Drawing.Size(99, 23);
            this.BtnAplicar.TabIndex = 10;
            this.BtnAplicar.Text = "Aplicar";
            this.BtnAplicar.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 19);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nodo8";
            treeNode1.Text = "Entradas";
            treeNode2.Name = "Nodo9";
            treeNode2.Text = "Salidas";
            treeNode3.Name = "Nodo7";
            treeNode3.Text = "Movimientos";
            treeNode4.Name = "Nodo10";
            treeNode4.Text = "Modificaciones";
            treeNode5.Name = "Nodo6";
            treeNode5.Text = "Historial";
            treeNode6.Name = "Nodo3";
            treeNode6.Text = "Todos";
            treeNode7.Name = "Nodo1";
            treeNode7.Text = "Activos";
            treeNode8.Name = "Nodo2";
            treeNode8.Text = "Inactivos";
            treeNode9.Name = "Nodo0";
            treeNode9.Text = "Empleados";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(169, 159);
            this.treeView1.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(189, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Fecha fin:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(189, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Fecha inicio:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(327, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 426);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Location = new System.Drawing.Point(6, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 155);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.label20);
            this.splitContainer1.Panel1.Controls.Add(this.label19);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label24);
            this.splitContainer1.Panel2.Controls.Add(this.label23);
            this.splitContainer1.Panel2.Controls.Add(this.label22);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Size = new System.Drawing.Size(443, 136);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(89, 108);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "label18";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(89, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "label18";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(89, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "label18";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(89, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "label18";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Articulo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Fecha:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Usuario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Acción:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(106, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "label18";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(106, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "label18";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(106, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "label18";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Observaciones:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Categoría:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabGeneral);
            this.tabControl1.Controls.Add(this.TabEmpleados);
            this.tabControl1.Location = new System.Drawing.Point(6, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 216);
            this.tabControl1.TabIndex = 18;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.DgHistorial);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(441, 190);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // DgHistorial
            // 
            this.DgHistorial.AllowUserToAddRows = false;
            this.DgHistorial.AllowUserToDeleteRows = false;
            this.DgHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdReport,
            this.NombreArticulo,
            this.CategoriaArticulo,
            this.Accion,
            this.Usuario,
            this.FechaAccion,
            this.ObservacionArticulo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgHistorial.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgHistorial.Location = new System.Drawing.Point(3, 3);
            this.DgHistorial.Name = "DgHistorial";
            this.DgHistorial.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.DgHistorial.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DgHistorial.Size = new System.Drawing.Size(435, 184);
            this.DgHistorial.TabIndex = 15;
            // 
            // IdReport
            // 
            this.IdReport.Frozen = true;
            this.IdReport.HeaderText = "Id";
            this.IdReport.Name = "IdReport";
            this.IdReport.ReadOnly = true;
            this.IdReport.Width = 41;
            // 
            // NombreArticulo
            // 
            this.NombreArticulo.Frozen = true;
            this.NombreArticulo.HeaderText = "Articulo";
            this.NombreArticulo.Name = "NombreArticulo";
            this.NombreArticulo.ReadOnly = true;
            this.NombreArticulo.Width = 67;
            // 
            // CategoriaArticulo
            // 
            this.CategoriaArticulo.Frozen = true;
            this.CategoriaArticulo.HeaderText = "Categoría";
            this.CategoriaArticulo.Name = "CategoriaArticulo";
            this.CategoriaArticulo.ReadOnly = true;
            this.CategoriaArticulo.Width = 79;
            // 
            // Accion
            // 
            this.Accion.Frozen = true;
            this.Accion.HeaderText = "Acción";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 65;
            // 
            // Usuario
            // 
            this.Usuario.Frozen = true;
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 68;
            // 
            // FechaAccion
            // 
            this.FechaAccion.Frozen = true;
            this.FechaAccion.HeaderText = "Fecha";
            this.FechaAccion.Name = "FechaAccion";
            this.FechaAccion.ReadOnly = true;
            this.FechaAccion.Width = 62;
            // 
            // ObservacionArticulo
            // 
            this.ObservacionArticulo.Frozen = true;
            this.ObservacionArticulo.HeaderText = "Observaciones";
            this.ObservacionArticulo.Name = "ObservacionArticulo";
            this.ObservacionArticulo.ReadOnly = true;
            this.ObservacionArticulo.Width = 103;
            // 
            // TabEmpleados
            // 
            this.TabEmpleados.Controls.Add(this.DgEmpleados);
            this.TabEmpleados.Location = new System.Drawing.Point(4, 22);
            this.TabEmpleados.Name = "TabEmpleados";
            this.TabEmpleados.Padding = new System.Windows.Forms.Padding(3);
            this.TabEmpleados.Size = new System.Drawing.Size(441, 190);
            this.TabEmpleados.TabIndex = 1;
            this.TabEmpleados.Text = "Empleados";
            this.TabEmpleados.UseVisualStyleBackColor = true;
            // 
            // DgEmpleados
            // 
            this.DgEmpleados.AllowUserToAddRows = false;
            this.DgEmpleados.AllowUserToDeleteRows = false;
            this.DgEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEmpleado,
            this.NombreEmpleado,
            this.ApellidoEmpleado,
            this.DniEmpleado,
            this.CargoEmpleado,
            this.AreaEmpleado,
            this.EstadoEmpleado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgEmpleados.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgEmpleados.Location = new System.Drawing.Point(3, 3);
            this.DgEmpleados.Name = "DgEmpleados";
            this.DgEmpleados.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.DgEmpleados.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgEmpleados.Size = new System.Drawing.Size(435, 184);
            this.DgEmpleados.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(217, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "label17";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(160, 238);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 16;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(366, 237);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(275, 237);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Exportar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // GrpEmpleados
            // 
            this.GrpEmpleados.Controls.Add(this.LstEmpleados);
            this.GrpEmpleados.Location = new System.Drawing.Point(327, 12);
            this.GrpEmpleados.Name = "GrpEmpleados";
            this.GrpEmpleados.Size = new System.Drawing.Size(461, 426);
            this.GrpEmpleados.TabIndex = 9;
            this.GrpEmpleados.TabStop = false;
            this.GrpEmpleados.Text = "Empleados";
            // 
            // LstEmpleados
            // 
            this.LstEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstEmpleados.CheckBoxes = true;
            this.LstEmpleados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EmpleadoNombres,
            this.EmpleadoApellidos,
            this.EmpleadoDNI,
            this.EmpleadoCargo,
            this.EmpleadoArea,
            this.EmpleadoEstado});
            this.LstEmpleados.HideSelection = false;
            this.LstEmpleados.Location = new System.Drawing.Point(6, 19);
            this.LstEmpleados.Name = "LstEmpleados";
            this.LstEmpleados.Size = new System.Drawing.Size(449, 401);
            this.LstEmpleados.TabIndex = 0;
            this.LstEmpleados.UseCompatibleStateImageBehavior = false;
            this.LstEmpleados.View = System.Windows.Forms.View.Details;
            // 
            // EmpleadoNombres
            // 
            this.EmpleadoNombres.Text = "Nombres";
            // 
            // EmpleadoApellidos
            // 
            this.EmpleadoApellidos.Text = "Apellidos";
            // 
            // EmpleadoDNI
            // 
            this.EmpleadoDNI.Text = "DNI";
            // 
            // EmpleadoCargo
            // 
            this.EmpleadoCargo.Text = "Cargo";
            // 
            // EmpleadoArea
            // 
            this.EmpleadoArea.Text = "Área";
            // 
            // EmpleadoEstado
            // 
            this.EmpleadoEstado.Text = "Estado";
            // 
            // IdEmpleado
            // 
            this.IdEmpleado.Frozen = true;
            this.IdEmpleado.HeaderText = "Id";
            this.IdEmpleado.Name = "IdEmpleado";
            this.IdEmpleado.ReadOnly = true;
            this.IdEmpleado.Width = 41;
            // 
            // NombreEmpleado
            // 
            this.NombreEmpleado.Frozen = true;
            this.NombreEmpleado.HeaderText = "Nombres";
            this.NombreEmpleado.Name = "NombreEmpleado";
            this.NombreEmpleado.ReadOnly = true;
            this.NombreEmpleado.Width = 74;
            // 
            // ApellidoEmpleado
            // 
            this.ApellidoEmpleado.Frozen = true;
            this.ApellidoEmpleado.HeaderText = "Apellidos";
            this.ApellidoEmpleado.Name = "ApellidoEmpleado";
            this.ApellidoEmpleado.ReadOnly = true;
            this.ApellidoEmpleado.Width = 74;
            // 
            // DniEmpleado
            // 
            this.DniEmpleado.Frozen = true;
            this.DniEmpleado.HeaderText = "DNI";
            this.DniEmpleado.Name = "DniEmpleado";
            this.DniEmpleado.ReadOnly = true;
            this.DniEmpleado.Width = 51;
            // 
            // CargoEmpleado
            // 
            this.CargoEmpleado.Frozen = true;
            this.CargoEmpleado.HeaderText = "Cargo";
            this.CargoEmpleado.Name = "CargoEmpleado";
            this.CargoEmpleado.ReadOnly = true;
            this.CargoEmpleado.Width = 60;
            // 
            // AreaEmpleado
            // 
            this.AreaEmpleado.Frozen = true;
            this.AreaEmpleado.HeaderText = "Área";
            this.AreaEmpleado.Name = "AreaEmpleado";
            this.AreaEmpleado.ReadOnly = true;
            this.AreaEmpleado.Width = 54;
            // 
            // EstadoEmpleado
            // 
            this.EstadoEmpleado.Frozen = true;
            this.EstadoEmpleado.HeaderText = "Estado";
            this.EstadoEmpleado.Name = "EstadoEmpleado";
            this.EstadoEmpleado.ReadOnly = true;
            this.EstadoEmpleado.Width = 65;
            // 
            // VistaRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GrpEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaRegistros";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros";
            this.Load += new System.EventHandler(this.VistaRegistros_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TabGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgHistorial)).EndInit();
            this.TabEmpleados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.GrpEmpleados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.TextBox TxtNombres;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker DtFechaFin;
        private System.Windows.Forms.DateTimePicker DtFechaInicio;
        private System.Windows.Forms.Button BtnAplicar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CbCategoria;
        private System.Windows.Forms.Button BtnBuscarEmpleado;
        private System.Windows.Forms.Button BtnAgregarEmpleado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabGeneral;
        public System.Windows.Forms.DataGridView DgHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservacionArticulo;
        private System.Windows.Forms.TabPage TabEmpleados;
        public System.Windows.Forms.DataGridView DgEmpleados;
        private System.Windows.Forms.GroupBox GrpEmpleados;
        private System.Windows.Forms.ListView LstEmpleados;
        private System.Windows.Forms.ColumnHeader EmpleadoNombres;
        private System.Windows.Forms.ColumnHeader EmpleadoApellidos;
        private System.Windows.Forms.ColumnHeader EmpleadoDNI;
        private System.Windows.Forms.ColumnHeader EmpleadoCargo;
        private System.Windows.Forms.ColumnHeader EmpleadoArea;
        private System.Windows.Forms.ColumnHeader EmpleadoEstado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnNewEstado;
        private System.Windows.Forms.Button BtnNewArea;
        private System.Windows.Forms.Button BtnNewCargo;
        public System.Windows.Forms.ComboBox CbEstadoEmpleados;
        public System.Windows.Forms.ComboBox CbArea;
        public System.Windows.Forms.ComboBox CbCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DniEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CargoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoEmpleado;
    }
}
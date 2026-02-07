namespace ControlInventario.Vistas
{
    partial class VistaArticulos
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
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.CbDesktop = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtFechaFinGarantía = new System.Windows.Forms.DateTimePicker();
            this.DtFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.DtFechaAdquisición = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbMonitores = new System.Windows.Forms.ComboBox();
            this.CbCelulares = new System.Windows.Forms.ComboBox();
            this.TxtSerie = new System.Windows.Forms.TextBox();
            this.TxtModelo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtDniUsuarioActual = new System.Windows.Forms.TextBox();
            this.TxtAreaUsuarioActual = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtCargoUsuarioActual = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtNombreUsuarioActual = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GpUsos = new System.Windows.Forms.GroupBox();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.TxtActivoFijo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.CbCondicion = new System.Windows.Forms.ComboBox();
            this.CbEstado = new System.Windows.Forms.ComboBox();
            this.TxtRuc = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnVerRUCs = new System.Windows.Forms.Button();
            this.BtnAgregarRUC = new System.Windows.Forms.Button();
            this.TxtRazonSocial = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BtnAgregarComprobante = new System.Windows.Forms.Button();
            this.BtnAgregarImagen = new System.Windows.Forms.Button();
            this.TxtRutaComprobante = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TxtDireccionImagen = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.PbComprobanteCompra = new System.Windows.Forms.PictureBox();
            this.PbFotoArticulo = new System.Windows.Forms.PictureBox();
            this.TxtUbicacion = new System.Windows.Forms.TextBox();
            this.TxtNombreUsuarioAnterior = new System.Windows.Forms.TextBox();
            this.TxtCargoUsuarioAnterior = new System.Windows.Forms.TextBox();
            this.TxtAreaUsuarioAnterior = new System.Windows.Forms.TextBox();
            this.TxtDniUsuarioAnterior = new System.Windows.Forms.TextBox();
            this.FlCaracteristicas = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GpUsos.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbComprobanteCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(9, 48);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigo.TabIndex = 1;
            // 
            // CbDesktop
            // 
            this.CbDesktop.FormattingEnabled = true;
            this.CbDesktop.Items.AddRange(new object[] {
            "Apple",
            "Hp",
            "Asus",
            "ThinkPad",
            "Lenovo",
            "Dell",
            "Acer",
            "Toshiba",
            "Samsung",
            "Sony",
            "LG",
            "AlienWare",
            "LANIX"});
            this.CbDesktop.Location = new System.Drawing.Point(361, 48);
            this.CbDesktop.Name = "CbDesktop";
            this.CbDesktop.Size = new System.Drawing.Size(100, 21);
            this.CbDesktop.TabIndex = 4;
            this.CbDesktop.Text = "SELECCIONAR";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtFechaFinGarantía);
            this.groupBox1.Controls.Add(this.DtFechaBaja);
            this.groupBox1.Controls.Add(this.DtFechaAdquisición);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CbMonitores);
            this.groupBox1.Controls.Add(this.CbCelulares);
            this.groupBox1.Controls.Add(this.CbDesktop);
            this.groupBox1.Controls.Add(this.TxtSerie);
            this.groupBox1.Controls.Add(this.TxtModelo);
            this.groupBox1.Controls.Add(this.TxtCodigo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información";
            // 
            // DtFechaFinGarantía
            // 
            this.DtFechaFinGarantía.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaFinGarantía.Location = new System.Drawing.Point(244, 102);
            this.DtFechaFinGarantía.Name = "DtFechaFinGarantía";
            this.DtFechaFinGarantía.Size = new System.Drawing.Size(100, 20);
            this.DtFechaFinGarantía.TabIndex = 7;
            // 
            // DtFechaBaja
            // 
            this.DtFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaBaja.Location = new System.Drawing.Point(127, 102);
            this.DtFechaBaja.Name = "DtFechaBaja";
            this.DtFechaBaja.Size = new System.Drawing.Size(100, 20);
            this.DtFechaBaja.TabIndex = 6;
            // 
            // DtFechaAdquisición
            // 
            this.DtFechaAdquisición.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaAdquisición.Location = new System.Drawing.Point(9, 102);
            this.DtFechaAdquisición.Name = "DtFechaAdquisición";
            this.DtFechaAdquisición.Size = new System.Drawing.Size(100, 20);
            this.DtFechaAdquisición.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Marca Articulo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serie Articulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo Articulo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Fin de garantía:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fecha Baja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha Adquisicion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo Articulo:";
            // 
            // CbMonitores
            // 
            this.CbMonitores.FormattingEnabled = true;
            this.CbMonitores.Items.AddRange(new object[] {
            "Dell",
            "Noc",
            "Asus",
            "ViewSonic",
            "MSI",
            "Benq",
            "Samsung",
            "Hp",
            "LG"});
            this.CbMonitores.Location = new System.Drawing.Point(361, 48);
            this.CbMonitores.Name = "CbMonitores";
            this.CbMonitores.Size = new System.Drawing.Size(100, 21);
            this.CbMonitores.TabIndex = 4;
            this.CbMonitores.Text = "SELECCIONAR";
            this.CbMonitores.Visible = false;
            // 
            // CbCelulares
            // 
            this.CbCelulares.FormattingEnabled = true;
            this.CbCelulares.Items.AddRange(new object[] {
            "Xiaomi",
            "Poco",
            "Samsung",
            "Apple",
            "Huawei",
            "LG",
            "SONY",
            "Motorola",
            "Lenovo",
            "Nokia",
            "ZTE"});
            this.CbCelulares.Location = new System.Drawing.Point(361, 48);
            this.CbCelulares.Name = "CbCelulares";
            this.CbCelulares.Size = new System.Drawing.Size(100, 21);
            this.CbCelulares.TabIndex = 4;
            this.CbCelulares.Text = "SELECCIONAR";
            this.CbCelulares.Visible = false;
            // 
            // TxtSerie
            // 
            this.TxtSerie.Location = new System.Drawing.Point(244, 48);
            this.TxtSerie.Name = "TxtSerie";
            this.TxtSerie.Size = new System.Drawing.Size(100, 20);
            this.TxtSerie.TabIndex = 3;
            // 
            // TxtModelo
            // 
            this.TxtModelo.Location = new System.Drawing.Point(127, 48);
            this.TxtModelo.Name = "TxtModelo";
            this.TxtModelo.Size = new System.Drawing.Size(100, 20);
            this.TxtModelo.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDniUsuarioAnterior);
            this.groupBox2.Controls.Add(this.TxtAreaUsuarioAnterior);
            this.groupBox2.Controls.Add(this.TxtDniUsuarioActual);
            this.groupBox2.Controls.Add(this.TxtAreaUsuarioActual);
            this.groupBox2.Controls.Add(this.TxtCargoUsuarioAnterior);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.TxtCargoUsuarioActual);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TxtNombreUsuarioAnterior);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TxtNombreUsuarioActual);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 135);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // TxtDniUsuarioActual
            // 
            this.TxtDniUsuarioActual.Location = new System.Drawing.Point(9, 43);
            this.TxtDniUsuarioActual.Name = "TxtDniUsuarioActual";
            this.TxtDniUsuarioActual.Size = new System.Drawing.Size(100, 20);
            this.TxtDniUsuarioActual.TabIndex = 8;
            // 
            // TxtAreaUsuarioActual
            // 
            this.TxtAreaUsuarioActual.Enabled = false;
            this.TxtAreaUsuarioActual.Location = new System.Drawing.Point(244, 43);
            this.TxtAreaUsuarioActual.Name = "TxtAreaUsuarioActual";
            this.TxtAreaUsuarioActual.Size = new System.Drawing.Size(100, 20);
            this.TxtAreaUsuarioActual.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(240, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Área usuario anterior:";
            // 
            // TxtCargoUsuarioActual
            // 
            this.TxtCargoUsuarioActual.Enabled = false;
            this.TxtCargoUsuarioActual.Location = new System.Drawing.Point(361, 43);
            this.TxtCargoUsuarioActual.Name = "TxtCargoUsuarioActual";
            this.TxtCargoUsuarioActual.Size = new System.Drawing.Size(100, 20);
            this.TxtCargoUsuarioActual.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Área usuario actual:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(357, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Cargo usuario anterior:";
            // 
            // TxtNombreUsuarioActual
            // 
            this.TxtNombreUsuarioActual.Enabled = false;
            this.TxtNombreUsuarioActual.Location = new System.Drawing.Point(127, 43);
            this.TxtNombreUsuarioActual.Name = "TxtNombreUsuarioActual";
            this.TxtNombreUsuarioActual.Size = new System.Drawing.Size(100, 20);
            this.TxtNombreUsuarioActual.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(357, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Cargo usuario actual:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Dni usuario anterior";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Usuario anterior:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Dni usuario actual";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Usuario actual:";
            // 
            // GpUsos
            // 
            this.GpUsos.Controls.Add(this.TxtObservaciones);
            this.GpUsos.Controls.Add(this.TxtUbicacion);
            this.GpUsos.Controls.Add(this.TxtActivoFijo);
            this.GpUsos.Controls.Add(this.label16);
            this.GpUsos.Controls.Add(this.label17);
            this.GpUsos.Controls.Add(this.label20);
            this.GpUsos.Controls.Add(this.label18);
            this.GpUsos.Controls.Add(this.label22);
            this.GpUsos.Controls.Add(this.CbCondicion);
            this.GpUsos.Controls.Add(this.CbEstado);
            this.GpUsos.Location = new System.Drawing.Point(12, 294);
            this.GpUsos.Name = "GpUsos";
            this.GpUsos.Size = new System.Drawing.Size(476, 135);
            this.GpUsos.TabIndex = 2;
            this.GpUsos.TabStop = false;
            this.GpUsos.Text = "Usos";
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.Enabled = false;
            this.TxtObservaciones.Location = new System.Drawing.Point(244, 41);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(217, 78);
            this.TxtObservaciones.TabIndex = 20;
            // 
            // TxtActivoFijo
            // 
            this.TxtActivoFijo.Enabled = false;
            this.TxtActivoFijo.Location = new System.Drawing.Point(10, 99);
            this.TxtActivoFijo.Name = "TxtActivoFijo";
            this.TxtActivoFijo.Size = new System.Drawing.Size(100, 20);
            this.TxtActivoFijo.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Activo Fijo:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(123, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Ubicación articulo:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(241, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Observaciones:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(123, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Condición articulo:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Estado Articulo:";
            // 
            // CbCondicion
            // 
            this.CbCondicion.FormattingEnabled = true;
            this.CbCondicion.Items.AddRange(new object[] {
            "Operativo",
            "Inoperativo",
            "Baja",
            "Vendido"});
            this.CbCondicion.Location = new System.Drawing.Point(127, 99);
            this.CbCondicion.Name = "CbCondicion";
            this.CbCondicion.Size = new System.Drawing.Size(100, 21);
            this.CbCondicion.TabIndex = 19;
            this.CbCondicion.Text = "SELECCIONAR";
            // 
            // CbEstado
            // 
            this.CbEstado.FormattingEnabled = true;
            this.CbEstado.Items.AddRange(new object[] {
            "Operativo",
            "Inoperativo",
            "Baja",
            "Vendido"});
            this.CbEstado.Location = new System.Drawing.Point(10, 41);
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.Size = new System.Drawing.Size(100, 21);
            this.CbEstado.TabIndex = 16;
            this.CbEstado.Text = "SELECCIONAR";
            // 
            // TxtRuc
            // 
            this.TxtRuc.Location = new System.Drawing.Point(6, 48);
            this.TxtRuc.Name = "TxtRuc";
            this.TxtRuc.Size = new System.Drawing.Size(128, 20);
            this.TxtRuc.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "RUC Proveedor:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnVerRUCs);
            this.groupBox4.Controls.Add(this.BtnAgregarRUC);
            this.groupBox4.Controls.Add(this.TxtRazonSocial);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.TxtPrecio);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.TxtRuc);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(494, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 135);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Adquisición";
            // 
            // BtnVerRUCs
            // 
            this.BtnVerRUCs.Location = new System.Drawing.Point(219, 47);
            this.BtnVerRUCs.Name = "BtnVerRUCs";
            this.BtnVerRUCs.Size = new System.Drawing.Size(73, 23);
            this.BtnVerRUCs.TabIndex = 25;
            this.BtnVerRUCs.Text = "Ver Lista";
            this.BtnVerRUCs.UseVisualStyleBackColor = true;
            // 
            // BtnAgregarRUC
            // 
            this.BtnAgregarRUC.Location = new System.Drawing.Point(140, 47);
            this.BtnAgregarRUC.Name = "BtnAgregarRUC";
            this.BtnAgregarRUC.Size = new System.Drawing.Size(73, 23);
            this.BtnAgregarRUC.TabIndex = 24;
            this.BtnAgregarRUC.Text = "Nuevo RUC";
            this.BtnAgregarRUC.UseVisualStyleBackColor = true;
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Enabled = false;
            this.TxtRazonSocial.Location = new System.Drawing.Point(6, 102);
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(191, 20);
            this.TxtRazonSocial.TabIndex = 22;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(386, 141);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "Razón Social:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(202, 86);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Precio Adquirido:";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(205, 102);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(95, 20);
            this.TxtPrecio.TabIndex = 23;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 83);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(73, 13);
            this.label24.TabIndex = 9;
            this.label24.Text = "Razón Social:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PbComprobanteCompra);
            this.groupBox5.Controls.Add(this.PbFotoArticulo);
            this.groupBox5.Controls.Add(this.BtnAgregarComprobante);
            this.groupBox5.Controls.Add(this.BtnAgregarImagen);
            this.groupBox5.Controls.Add(this.TxtRutaComprobante);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.TxtDireccionImagen);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Location = new System.Drawing.Point(494, 153);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(306, 276);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Infirmación adicional";
            // 
            // BtnAgregarComprobante
            // 
            this.BtnAgregarComprobante.Location = new System.Drawing.Point(271, 42);
            this.BtnAgregarComprobante.Name = "BtnAgregarComprobante";
            this.BtnAgregarComprobante.Size = new System.Drawing.Size(29, 23);
            this.BtnAgregarComprobante.TabIndex = 27;
            this.BtnAgregarComprobante.Text = "...";
            this.BtnAgregarComprobante.UseVisualStyleBackColor = true;
            // 
            // BtnAgregarImagen
            // 
            this.BtnAgregarImagen.Location = new System.Drawing.Point(271, 90);
            this.BtnAgregarImagen.Name = "BtnAgregarImagen";
            this.BtnAgregarImagen.Size = new System.Drawing.Size(29, 23);
            this.BtnAgregarImagen.TabIndex = 29;
            this.BtnAgregarImagen.Text = "...";
            this.BtnAgregarImagen.UseVisualStyleBackColor = true;
            // 
            // TxtRutaComprobante
            // 
            this.TxtRutaComprobante.Enabled = false;
            this.TxtRutaComprobante.Location = new System.Drawing.Point(6, 43);
            this.TxtRutaComprobante.Name = "TxtRutaComprobante";
            this.TxtRutaComprobante.Size = new System.Drawing.Size(259, 20);
            this.TxtRutaComprobante.TabIndex = 26;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(126, 13);
            this.label26.TabIndex = 9;
            this.label26.Text = "Comprobante de compra:";
            // 
            // TxtDireccionImagen
            // 
            this.TxtDireccionImagen.Enabled = false;
            this.TxtDireccionImagen.Location = new System.Drawing.Point(6, 92);
            this.TxtDireccionImagen.Name = "TxtDireccionImagen";
            this.TxtDireccionImagen.Size = new System.Drawing.Size(259, 20);
            this.TxtDireccionImagen.TabIndex = 28;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(107, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Dirección de imagen:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.FlCaracteristicas);
            this.groupBox6.Controls.Add(this.BtnEliminar);
            this.groupBox6.Controls.Add(this.btnAgregar);
            this.groupBox6.Location = new System.Drawing.Point(12, 435);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(788, 84);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Caracteristicas";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(707, 48);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 31;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(707, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // PbComprobanteCompra
            // 
            this.PbComprobanteCompra.Location = new System.Drawing.Point(155, 118);
            this.PbComprobanteCompra.Name = "PbComprobanteCompra";
            this.PbComprobanteCompra.Size = new System.Drawing.Size(145, 143);
            this.PbComprobanteCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbComprobanteCompra.TabIndex = 21;
            this.PbComprobanteCompra.TabStop = false;
            this.PbComprobanteCompra.Tag = "Comprobante";
            // 
            // PbFotoArticulo
            // 
            this.PbFotoArticulo.Location = new System.Drawing.Point(7, 118);
            this.PbFotoArticulo.Name = "PbFotoArticulo";
            this.PbFotoArticulo.Size = new System.Drawing.Size(142, 143);
            this.PbFotoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbFotoArticulo.TabIndex = 21;
            this.PbFotoArticulo.TabStop = false;
            this.PbFotoArticulo.Tag = "ImagenArticulo";
            // 
            // TxtUbicacion
            // 
            this.TxtUbicacion.Enabled = false;
            this.TxtUbicacion.Location = new System.Drawing.Point(127, 41);
            this.TxtUbicacion.Name = "TxtUbicacion";
            this.TxtUbicacion.Size = new System.Drawing.Size(100, 20);
            this.TxtUbicacion.TabIndex = 17;
            // 
            // TxtNombreUsuarioAnterior
            // 
            this.TxtNombreUsuarioAnterior.Enabled = false;
            this.TxtNombreUsuarioAnterior.Location = new System.Drawing.Point(127, 92);
            this.TxtNombreUsuarioAnterior.Name = "TxtNombreUsuarioAnterior";
            this.TxtNombreUsuarioAnterior.Size = new System.Drawing.Size(100, 20);
            this.TxtNombreUsuarioAnterior.TabIndex = 13;
            // 
            // TxtCargoUsuarioAnterior
            // 
            this.TxtCargoUsuarioAnterior.Enabled = false;
            this.TxtCargoUsuarioAnterior.Location = new System.Drawing.Point(361, 92);
            this.TxtCargoUsuarioAnterior.Name = "TxtCargoUsuarioAnterior";
            this.TxtCargoUsuarioAnterior.Size = new System.Drawing.Size(100, 20);
            this.TxtCargoUsuarioAnterior.TabIndex = 15;
            // 
            // TxtAreaUsuarioAnterior
            // 
            this.TxtAreaUsuarioAnterior.Enabled = false;
            this.TxtAreaUsuarioAnterior.Location = new System.Drawing.Point(244, 92);
            this.TxtAreaUsuarioAnterior.Name = "TxtAreaUsuarioAnterior";
            this.TxtAreaUsuarioAnterior.Size = new System.Drawing.Size(100, 20);
            this.TxtAreaUsuarioAnterior.TabIndex = 14;
            // 
            // TxtDniUsuarioAnterior
            // 
            this.TxtDniUsuarioAnterior.Location = new System.Drawing.Point(9, 92);
            this.TxtDniUsuarioAnterior.Name = "TxtDniUsuarioAnterior";
            this.TxtDniUsuarioAnterior.Size = new System.Drawing.Size(100, 20);
            this.TxtDniUsuarioAnterior.TabIndex = 12;
            // 
            // FlCaracteristicas
            // 
            this.FlCaracteristicas.Location = new System.Drawing.Point(0, 13);
            this.FlCaracteristicas.Name = "FlCaracteristicas";
            this.FlCaracteristicas.Size = new System.Drawing.Size(701, 71);
            this.FlCaracteristicas.TabIndex = 32;
            // 
            // VistaArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 531);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.GpUsos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VistaArticulos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Articulos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GpUsos.ResumeLayout(false);
            this.GpUsos.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbComprobanteCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.ComboBox CbDesktop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbCelulares;
        private System.Windows.Forms.TextBox TxtSerie;
        private System.Windows.Forms.TextBox TxtModelo;
        private System.Windows.Forms.ComboBox CbMonitores;
        private System.Windows.Forms.DateTimePicker DtFechaAdquisición;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtFechaFinGarantía;
        private System.Windows.Forms.DateTimePicker DtFechaBaja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtDniUsuarioActual;
        private System.Windows.Forms.TextBox TxtAreaUsuarioActual;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtCargoUsuarioActual;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtNombreUsuarioActual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox GpUsos;
        private System.Windows.Forms.TextBox TxtRuc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox CbEstado;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtRazonSocial;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.TextBox TxtActivoFijo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CbCondicion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox PbFotoArticulo;
        private System.Windows.Forms.Button BtnAgregarImagen;
        private System.Windows.Forms.TextBox TxtDireccionImagen;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button BtnVerRUCs;
        private System.Windows.Forms.Button BtnAgregarRUC;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Button BtnAgregarComprobante;
        private System.Windows.Forms.TextBox TxtRutaComprobante;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.PictureBox PbComprobanteCompra;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.TextBox TxtUbicacion;
        private System.Windows.Forms.TextBox TxtDniUsuarioAnterior;
        private System.Windows.Forms.TextBox TxtAreaUsuarioAnterior;
        private System.Windows.Forms.TextBox TxtCargoUsuarioAnterior;
        private System.Windows.Forms.TextBox TxtNombreUsuarioAnterior;
        public System.Windows.Forms.FlowLayoutPanel FlCaracteristicas;
    }
}
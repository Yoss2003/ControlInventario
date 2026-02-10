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
            this.GrpDesktop = new System.Windows.Forms.GroupBox();
            this.ChkCargadorDesktop = new System.Windows.Forms.CheckBox();
            this.TxtGeneracionDesktop = new System.Windows.Forms.TextBox();
            this.CbProcesadorDesktop = new System.Windows.Forms.ComboBox();
            this.CbRamDesktop = new System.Windows.Forms.ComboBox();
            this.CbAlmacenamientoDesktop = new System.Windows.Forms.ComboBox();
            this.LblGeneracionDesktop = new System.Windows.Forms.Label();
            this.LblProcesadorDesktop = new System.Windows.Forms.Label();
            this.LblRamDesktop = new System.Windows.Forms.Label();
            this.LblAlmacenamientoDesktop = new System.Windows.Forms.Label();
            this.ChkCaracteristicaDesktop = new System.Windows.Forms.CheckBox();
            this.GrpCelular = new System.Windows.Forms.GroupBox();
            this.TxtImeiCelular = new System.Windows.Forms.TextBox();
            this.CbProcesadorCelular = new System.Windows.Forms.ComboBox();
            this.LblAlmacenamientoCelular = new System.Windows.Forms.Label();
            this.CbRamCelular = new System.Windows.Forms.ComboBox();
            this.LblRamCelular = new System.Windows.Forms.Label();
            this.CbAlmacenamientoCelular = new System.Windows.Forms.ComboBox();
            this.LblProcesadorCelular = new System.Windows.Forms.Label();
            this.LblImeiCelular = new System.Windows.Forms.Label();
            this.ChkCaracteristicaCelular = new System.Windows.Forms.CheckBox();
            this.GrpMonitor = new System.Windows.Forms.GroupBox();
            this.TxtTamañoMonitor = new System.Windows.Forms.TextBox();
            this.CbResoluciónMonitor = new System.Windows.Forms.ComboBox();
            this.CbEntradaMonitor = new System.Windows.Forms.ComboBox();
            this.LblTamañoMonitor = new System.Windows.Forms.Label();
            this.LblResoluciónMonitor = new System.Windows.Forms.Label();
            this.LblEntradaMonitor = new System.Windows.Forms.Label();
            this.CbHzMonitor = new System.Windows.Forms.ComboBox();
            this.LblHzMonitor = new System.Windows.Forms.Label();
            this.ChkCaracteristicasMonitor = new System.Windows.Forms.CheckBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregarCaracteristica = new System.Windows.Forms.Button();
            this.GrpDesktop.SuspendLayout();
            this.GrpCelular.SuspendLayout();
            this.GrpMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpDesktop
            // 
            this.GrpDesktop.Controls.Add(this.ChkCargadorDesktop);
            this.GrpDesktop.Controls.Add(this.TxtGeneracionDesktop);
            this.GrpDesktop.Controls.Add(this.CbProcesadorDesktop);
            this.GrpDesktop.Controls.Add(this.CbRamDesktop);
            this.GrpDesktop.Controls.Add(this.CbAlmacenamientoDesktop);
            this.GrpDesktop.Controls.Add(this.LblGeneracionDesktop);
            this.GrpDesktop.Controls.Add(this.LblProcesadorDesktop);
            this.GrpDesktop.Controls.Add(this.LblRamDesktop);
            this.GrpDesktop.Controls.Add(this.LblAlmacenamientoDesktop);
            this.GrpDesktop.Location = new System.Drawing.Point(13, 13);
            this.GrpDesktop.Name = "GrpDesktop";
            this.GrpDesktop.Size = new System.Drawing.Size(200, 275);
            this.GrpDesktop.TabIndex = 0;
            this.GrpDesktop.TabStop = false;
            this.GrpDesktop.Text = "Laptop o PC";
            // 
            // ChkCargadorDesktop
            // 
            this.ChkCargadorDesktop.AutoSize = true;
            this.ChkCargadorDesktop.Location = new System.Drawing.Point(6, 252);
            this.ChkCargadorDesktop.Name = "ChkCargadorDesktop";
            this.ChkCargadorDesktop.Size = new System.Drawing.Size(104, 17);
            this.ChkCargadorDesktop.TabIndex = 4;
            this.ChkCargadorDesktop.Text = "Tiene cargador?";
            this.ChkCargadorDesktop.UseVisualStyleBackColor = true;
            // 
            // TxtGeneracionDesktop
            // 
            this.TxtGeneracionDesktop.Location = new System.Drawing.Point(6, 208);
            this.TxtGeneracionDesktop.Name = "TxtGeneracionDesktop";
            this.TxtGeneracionDesktop.Size = new System.Drawing.Size(121, 20);
            this.TxtGeneracionDesktop.TabIndex = 2;
            // 
            // CbProcesadorDesktop
            // 
            this.CbProcesadorDesktop.FormattingEnabled = true;
            this.CbProcesadorDesktop.Items.AddRange(new object[] {
            "Intel",
            "AMD"});
            this.CbProcesadorDesktop.Location = new System.Drawing.Point(6, 151);
            this.CbProcesadorDesktop.Name = "CbProcesadorDesktop";
            this.CbProcesadorDesktop.Size = new System.Drawing.Size(121, 21);
            this.CbProcesadorDesktop.TabIndex = 1;
            this.CbProcesadorDesktop.Text = "SELECCIONE";
            // 
            // CbRamDesktop
            // 
            this.CbRamDesktop.FormattingEnabled = true;
            this.CbRamDesktop.Items.AddRange(new object[] {
            "1 GB",
            "2 GB",
            "4 GB",
            "8 GB",
            "12 GB",
            "16 GB",
            "24 GB",
            "32 GB",
            "64 GB"});
            this.CbRamDesktop.Location = new System.Drawing.Point(6, 95);
            this.CbRamDesktop.Name = "CbRamDesktop";
            this.CbRamDesktop.Size = new System.Drawing.Size(121, 21);
            this.CbRamDesktop.TabIndex = 1;
            this.CbRamDesktop.Text = "SELECCIONE";
            // 
            // CbAlmacenamientoDesktop
            // 
            this.CbAlmacenamientoDesktop.FormattingEnabled = true;
            this.CbAlmacenamientoDesktop.Items.AddRange(new object[] {
            "240 GB",
            "480 GB",
            "1 TB",
            "2 TB"});
            this.CbAlmacenamientoDesktop.Location = new System.Drawing.Point(6, 39);
            this.CbAlmacenamientoDesktop.Name = "CbAlmacenamientoDesktop";
            this.CbAlmacenamientoDesktop.Size = new System.Drawing.Size(121, 21);
            this.CbAlmacenamientoDesktop.TabIndex = 1;
            this.CbAlmacenamientoDesktop.Text = "SELECCIONE";
            // 
            // LblGeneracionDesktop
            // 
            this.LblGeneracionDesktop.AutoSize = true;
            this.LblGeneracionDesktop.Location = new System.Drawing.Point(3, 191);
            this.LblGeneracionDesktop.Name = "LblGeneracionDesktop";
            this.LblGeneracionDesktop.Size = new System.Drawing.Size(65, 13);
            this.LblGeneracionDesktop.TabIndex = 0;
            this.LblGeneracionDesktop.Text = "Generación:";
            // 
            // LblProcesadorDesktop
            // 
            this.LblProcesadorDesktop.AutoSize = true;
            this.LblProcesadorDesktop.Location = new System.Drawing.Point(6, 135);
            this.LblProcesadorDesktop.Name = "LblProcesadorDesktop";
            this.LblProcesadorDesktop.Size = new System.Drawing.Size(64, 13);
            this.LblProcesadorDesktop.TabIndex = 0;
            this.LblProcesadorDesktop.Text = "Procesador:";
            // 
            // LblRamDesktop
            // 
            this.LblRamDesktop.AutoSize = true;
            this.LblRamDesktop.Location = new System.Drawing.Point(6, 79);
            this.LblRamDesktop.Name = "LblRamDesktop";
            this.LblRamDesktop.Size = new System.Drawing.Size(34, 13);
            this.LblRamDesktop.TabIndex = 0;
            this.LblRamDesktop.Text = "RAM:";
            // 
            // LblAlmacenamientoDesktop
            // 
            this.LblAlmacenamientoDesktop.AutoSize = true;
            this.LblAlmacenamientoDesktop.Location = new System.Drawing.Point(6, 23);
            this.LblAlmacenamientoDesktop.Name = "LblAlmacenamientoDesktop";
            this.LblAlmacenamientoDesktop.Size = new System.Drawing.Size(88, 13);
            this.LblAlmacenamientoDesktop.TabIndex = 0;
            this.LblAlmacenamientoDesktop.Text = "Almacenamiento:";
            // 
            // ChkCaracteristicaDesktop
            // 
            this.ChkCaracteristicaDesktop.AutoSize = true;
            this.ChkCaracteristicaDesktop.Location = new System.Drawing.Point(199, 7);
            this.ChkCaracteristicaDesktop.Name = "ChkCaracteristicaDesktop";
            this.ChkCaracteristicaDesktop.Size = new System.Drawing.Size(15, 14);
            this.ChkCaracteristicaDesktop.TabIndex = 3;
            this.ChkCaracteristicaDesktop.UseVisualStyleBackColor = true;
            this.ChkCaracteristicaDesktop.CheckedChanged += new System.EventHandler(this.ChkCaracteristicaDesktop_CheckedChanged);
            // 
            // GrpCelular
            // 
            this.GrpCelular.Controls.Add(this.TxtImeiCelular);
            this.GrpCelular.Controls.Add(this.CbProcesadorCelular);
            this.GrpCelular.Controls.Add(this.LblAlmacenamientoCelular);
            this.GrpCelular.Controls.Add(this.CbRamCelular);
            this.GrpCelular.Controls.Add(this.LblRamCelular);
            this.GrpCelular.Controls.Add(this.CbAlmacenamientoCelular);
            this.GrpCelular.Controls.Add(this.LblProcesadorCelular);
            this.GrpCelular.Controls.Add(this.LblImeiCelular);
            this.GrpCelular.Location = new System.Drawing.Point(219, 13);
            this.GrpCelular.Name = "GrpCelular";
            this.GrpCelular.Size = new System.Drawing.Size(200, 243);
            this.GrpCelular.TabIndex = 0;
            this.GrpCelular.TabStop = false;
            this.GrpCelular.Text = "Celular";
            // 
            // TxtImeiCelular
            // 
            this.TxtImeiCelular.Location = new System.Drawing.Point(6, 208);
            this.TxtImeiCelular.Name = "TxtImeiCelular";
            this.TxtImeiCelular.Size = new System.Drawing.Size(121, 20);
            this.TxtImeiCelular.TabIndex = 2;
            // 
            // CbProcesadorCelular
            // 
            this.CbProcesadorCelular.FormattingEnabled = true;
            this.CbProcesadorCelular.Items.AddRange(new object[] {
            "Mediatek",
            "Samsung",
            "Apple",
            "Qualcomm",
            "Hisilicon",
            "Unisoc"});
            this.CbProcesadorCelular.Location = new System.Drawing.Point(6, 151);
            this.CbProcesadorCelular.Name = "CbProcesadorCelular";
            this.CbProcesadorCelular.Size = new System.Drawing.Size(121, 21);
            this.CbProcesadorCelular.TabIndex = 1;
            this.CbProcesadorCelular.Text = "SELECCIONE";
            // 
            // LblAlmacenamientoCelular
            // 
            this.LblAlmacenamientoCelular.AutoSize = true;
            this.LblAlmacenamientoCelular.Location = new System.Drawing.Point(6, 23);
            this.LblAlmacenamientoCelular.Name = "LblAlmacenamientoCelular";
            this.LblAlmacenamientoCelular.Size = new System.Drawing.Size(88, 13);
            this.LblAlmacenamientoCelular.TabIndex = 0;
            this.LblAlmacenamientoCelular.Text = "Almacenamiento:";
            // 
            // CbRamCelular
            // 
            this.CbRamCelular.FormattingEnabled = true;
            this.CbRamCelular.Items.AddRange(new object[] {
            "2 GB",
            "4 GB",
            "8 GB",
            "16 GB",
            "32 GB"});
            this.CbRamCelular.Location = new System.Drawing.Point(6, 95);
            this.CbRamCelular.Name = "CbRamCelular";
            this.CbRamCelular.Size = new System.Drawing.Size(121, 21);
            this.CbRamCelular.TabIndex = 1;
            this.CbRamCelular.Text = "SELECCIONE";
            // 
            // LblRamCelular
            // 
            this.LblRamCelular.AutoSize = true;
            this.LblRamCelular.Location = new System.Drawing.Point(6, 79);
            this.LblRamCelular.Name = "LblRamCelular";
            this.LblRamCelular.Size = new System.Drawing.Size(34, 13);
            this.LblRamCelular.TabIndex = 0;
            this.LblRamCelular.Text = "RAM:";
            // 
            // CbAlmacenamientoCelular
            // 
            this.CbAlmacenamientoCelular.FormattingEnabled = true;
            this.CbAlmacenamientoCelular.Items.AddRange(new object[] {
            "64 GB",
            "120 GB",
            "500 GB ",
            "1 TB"});
            this.CbAlmacenamientoCelular.Location = new System.Drawing.Point(6, 39);
            this.CbAlmacenamientoCelular.Name = "CbAlmacenamientoCelular";
            this.CbAlmacenamientoCelular.Size = new System.Drawing.Size(121, 21);
            this.CbAlmacenamientoCelular.TabIndex = 1;
            this.CbAlmacenamientoCelular.Text = "SELECCIONE";
            // 
            // LblProcesadorCelular
            // 
            this.LblProcesadorCelular.AutoSize = true;
            this.LblProcesadorCelular.Location = new System.Drawing.Point(6, 135);
            this.LblProcesadorCelular.Name = "LblProcesadorCelular";
            this.LblProcesadorCelular.Size = new System.Drawing.Size(64, 13);
            this.LblProcesadorCelular.TabIndex = 0;
            this.LblProcesadorCelular.Text = "Procesador:";
            // 
            // LblImeiCelular
            // 
            this.LblImeiCelular.AutoSize = true;
            this.LblImeiCelular.Location = new System.Drawing.Point(6, 191);
            this.LblImeiCelular.Name = "LblImeiCelular";
            this.LblImeiCelular.Size = new System.Drawing.Size(32, 13);
            this.LblImeiCelular.TabIndex = 0;
            this.LblImeiCelular.Text = "IMEI:";
            // 
            // ChkCaracteristicaCelular
            // 
            this.ChkCaracteristicaCelular.AutoSize = true;
            this.ChkCaracteristicaCelular.Location = new System.Drawing.Point(404, 7);
            this.ChkCaracteristicaCelular.Name = "ChkCaracteristicaCelular";
            this.ChkCaracteristicaCelular.Size = new System.Drawing.Size(15, 14);
            this.ChkCaracteristicaCelular.TabIndex = 3;
            this.ChkCaracteristicaCelular.UseVisualStyleBackColor = true;
            this.ChkCaracteristicaCelular.CheckedChanged += new System.EventHandler(this.ChkCaracteristicaCelular_CheckedChanged);
            // 
            // GrpMonitor
            // 
            this.GrpMonitor.Controls.Add(this.TxtTamañoMonitor);
            this.GrpMonitor.Controls.Add(this.CbResoluciónMonitor);
            this.GrpMonitor.Controls.Add(this.CbEntradaMonitor);
            this.GrpMonitor.Controls.Add(this.LblTamañoMonitor);
            this.GrpMonitor.Controls.Add(this.LblResoluciónMonitor);
            this.GrpMonitor.Controls.Add(this.LblEntradaMonitor);
            this.GrpMonitor.Controls.Add(this.CbHzMonitor);
            this.GrpMonitor.Controls.Add(this.LblHzMonitor);
            this.GrpMonitor.Location = new System.Drawing.Point(425, 13);
            this.GrpMonitor.Name = "GrpMonitor";
            this.GrpMonitor.Size = new System.Drawing.Size(200, 243);
            this.GrpMonitor.TabIndex = 0;
            this.GrpMonitor.TabStop = false;
            this.GrpMonitor.Text = "Monitor";
            // 
            // TxtTamañoMonitor
            // 
            this.TxtTamañoMonitor.Location = new System.Drawing.Point(6, 208);
            this.TxtTamañoMonitor.Name = "TxtTamañoMonitor";
            this.TxtTamañoMonitor.Size = new System.Drawing.Size(121, 20);
            this.TxtTamañoMonitor.TabIndex = 2;
            // 
            // CbResoluciónMonitor
            // 
            this.CbResoluciónMonitor.FormattingEnabled = true;
            this.CbResoluciónMonitor.Items.AddRange(new object[] {
            "640 × 480",
            "800 × 600",
            "1024 × 768",
            "1280 × 720",
            "1280 × 800",
            "1366 × 768",
            "1600 × 900",
            "1920 × 1080",
            "1920 × 1200",
            "2560 × 1440",
            "2560 × 1600",
            "3440 × 1440",
            "3840 × 2160",
            "5120 × 2880",
            "7680 × 4320"});
            this.CbResoluciónMonitor.Location = new System.Drawing.Point(6, 39);
            this.CbResoluciónMonitor.Name = "CbResoluciónMonitor";
            this.CbResoluciónMonitor.Size = new System.Drawing.Size(121, 21);
            this.CbResoluciónMonitor.TabIndex = 1;
            this.CbResoluciónMonitor.Text = "SELECCIONE";
            // 
            // CbEntradaMonitor
            // 
            this.CbEntradaMonitor.FormattingEnabled = true;
            this.CbEntradaMonitor.Items.AddRange(new object[] {
            "HDMI",
            "DisplayPort",
            "DVI",
            "VGA",
            "USB-C"});
            this.CbEntradaMonitor.Location = new System.Drawing.Point(6, 151);
            this.CbEntradaMonitor.Name = "CbEntradaMonitor";
            this.CbEntradaMonitor.Size = new System.Drawing.Size(121, 21);
            this.CbEntradaMonitor.TabIndex = 1;
            this.CbEntradaMonitor.Text = "SELECCIONE";
            // 
            // LblTamañoMonitor
            // 
            this.LblTamañoMonitor.AutoSize = true;
            this.LblTamañoMonitor.Location = new System.Drawing.Point(6, 191);
            this.LblTamañoMonitor.Name = "LblTamañoMonitor";
            this.LblTamañoMonitor.Size = new System.Drawing.Size(89, 13);
            this.LblTamañoMonitor.TabIndex = 0;
            this.LblTamañoMonitor.Text = "Tamaño pantalla:";
            // 
            // LblResoluciónMonitor
            // 
            this.LblResoluciónMonitor.AutoSize = true;
            this.LblResoluciónMonitor.Location = new System.Drawing.Point(6, 23);
            this.LblResoluciónMonitor.Name = "LblResoluciónMonitor";
            this.LblResoluciónMonitor.Size = new System.Drawing.Size(63, 13);
            this.LblResoluciónMonitor.TabIndex = 0;
            this.LblResoluciónMonitor.Text = "Resolución:";
            // 
            // LblEntradaMonitor
            // 
            this.LblEntradaMonitor.AutoSize = true;
            this.LblEntradaMonitor.Location = new System.Drawing.Point(6, 135);
            this.LblEntradaMonitor.Name = "LblEntradaMonitor";
            this.LblEntradaMonitor.Size = new System.Drawing.Size(47, 13);
            this.LblEntradaMonitor.TabIndex = 0;
            this.LblEntradaMonitor.Text = "Entrada:";
            // 
            // CbHzMonitor
            // 
            this.CbHzMonitor.FormattingEnabled = true;
            this.CbHzMonitor.Items.AddRange(new object[] {
            "60HZ",
            "120Hz",
            "144Hz",
            "240Hz"});
            this.CbHzMonitor.Location = new System.Drawing.Point(6, 95);
            this.CbHzMonitor.Name = "CbHzMonitor";
            this.CbHzMonitor.Size = new System.Drawing.Size(121, 21);
            this.CbHzMonitor.TabIndex = 1;
            this.CbHzMonitor.Text = "SELECCIONE";
            // 
            // LblHzMonitor
            // 
            this.LblHzMonitor.AutoSize = true;
            this.LblHzMonitor.Location = new System.Drawing.Point(6, 79);
            this.LblHzMonitor.Name = "LblHzMonitor";
            this.LblHzMonitor.Size = new System.Drawing.Size(23, 13);
            this.LblHzMonitor.TabIndex = 0;
            this.LblHzMonitor.Text = "Hz:";
            // 
            // ChkCaracteristicasMonitor
            // 
            this.ChkCaracteristicasMonitor.AutoSize = true;
            this.ChkCaracteristicasMonitor.Location = new System.Drawing.Point(610, 7);
            this.ChkCaracteristicasMonitor.Name = "ChkCaracteristicasMonitor";
            this.ChkCaracteristicasMonitor.Size = new System.Drawing.Size(15, 14);
            this.ChkCaracteristicasMonitor.TabIndex = 3;
            this.ChkCaracteristicasMonitor.UseVisualStyleBackColor = true;
            this.ChkCaracteristicasMonitor.CheckedChanged += new System.EventHandler(this.ChkCaracteristicasMonitor_CheckedChanged);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(219, 265);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(75, 23);
            this.BtnAgregar.TabIndex = 1;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(361, 265);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregarCaracteristica
            // 
            this.BtnAgregarCaracteristica.Enabled = false;
            this.BtnAgregarCaracteristica.Location = new System.Drawing.Point(503, 265);
            this.BtnAgregarCaracteristica.Name = "BtnAgregarCaracteristica";
            this.BtnAgregarCaracteristica.Size = new System.Drawing.Size(121, 23);
            this.BtnAgregarCaracteristica.TabIndex = 1;
            this.BtnAgregarCaracteristica.Text = "Agregar Caracteristica";
            this.BtnAgregarCaracteristica.UseVisualStyleBackColor = true;
            // 
            // VistaCaracteristicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 300);
            this.Controls.Add(this.ChkCaracteristicasMonitor);
            this.Controls.Add(this.ChkCaracteristicaCelular);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.ChkCaracteristicaDesktop);
            this.Controls.Add(this.BtnAgregarCaracteristica);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.GrpMonitor);
            this.Controls.Add(this.GrpCelular);
            this.Controls.Add(this.GrpDesktop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaCaracteristicas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caracteristicas articulos";
            this.GrpDesktop.ResumeLayout(false);
            this.GrpDesktop.PerformLayout();
            this.GrpCelular.ResumeLayout(false);
            this.GrpCelular.PerformLayout();
            this.GrpMonitor.ResumeLayout(false);
            this.GrpMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpDesktop;
        private System.Windows.Forms.GroupBox GrpCelular;
        private System.Windows.Forms.GroupBox GrpMonitor;
        private System.Windows.Forms.ComboBox CbAlmacenamientoDesktop;
        private System.Windows.Forms.Label LblRamDesktop;
        private System.Windows.Forms.Label LblAlmacenamientoDesktop;
        private System.Windows.Forms.ComboBox CbRamDesktop;
        private System.Windows.Forms.Label LblProcesadorDesktop;
        private System.Windows.Forms.TextBox TxtGeneracionDesktop;
        private System.Windows.Forms.ComboBox CbProcesadorDesktop;
        private System.Windows.Forms.Label LblGeneracionDesktop;
        private System.Windows.Forms.TextBox TxtImeiCelular;
        private System.Windows.Forms.ComboBox CbProcesadorCelular;
        private System.Windows.Forms.Label LblAlmacenamientoCelular;
        private System.Windows.Forms.ComboBox CbRamCelular;
        private System.Windows.Forms.Label LblRamCelular;
        private System.Windows.Forms.ComboBox CbAlmacenamientoCelular;
        private System.Windows.Forms.Label LblProcesadorCelular;
        private System.Windows.Forms.Label LblImeiCelular;
        private System.Windows.Forms.ComboBox CbResoluciónMonitor;
        private System.Windows.Forms.ComboBox CbEntradaMonitor;
        private System.Windows.Forms.Label LblResoluciónMonitor;
        private System.Windows.Forms.Label LblEntradaMonitor;
        private System.Windows.Forms.ComboBox CbHzMonitor;
        private System.Windows.Forms.Label LblHzMonitor;
        private System.Windows.Forms.TextBox TxtTamañoMonitor;
        private System.Windows.Forms.Label LblTamañoMonitor;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.CheckBox ChkCaracteristicasMonitor;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.CheckBox ChkCargadorDesktop;
        private System.Windows.Forms.Button BtnAgregarCaracteristica;
        public System.Windows.Forms.CheckBox ChkCaracteristicaDesktop;
        public System.Windows.Forms.CheckBox ChkCaracteristicaCelular;
    }
}
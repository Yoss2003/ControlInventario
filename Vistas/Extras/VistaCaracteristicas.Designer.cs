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
            this.GrpCelular = new System.Windows.Forms.GroupBox();
            this.GrpMonitor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbAlmacenamientoDesktop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CbRamDesktop = new System.Windows.Forms.ComboBox();
            this.CbProcesadorDesktop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtGeneracionDesktop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CbAlmacenamientoCelular = new System.Windows.Forms.ComboBox();
            this.CbRamCelular = new System.Windows.Forms.ComboBox();
            this.CbProcesadorCelular = new System.Windows.Forms.ComboBox();
            this.TxtImeiCelular = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CbResoluciónMonitor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CbHzMonitor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CbEntradaMonitor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtTamañoMonitor = new System.Windows.Forms.TextBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.ChkCaracteristicaDesktop = new System.Windows.Forms.CheckBox();
            this.ChkCaracteristicaCelular = new System.Windows.Forms.CheckBox();
            this.ChkCaracteristicasMonitor = new System.Windows.Forms.CheckBox();
            this.ChkCargadorDesktop = new System.Windows.Forms.CheckBox();
            this.BtnAgregarCaracteristica = new System.Windows.Forms.Button();
            this.GrpDesktop.SuspendLayout();
            this.GrpCelular.SuspendLayout();
            this.GrpMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpDesktop
            // 
            this.GrpDesktop.Controls.Add(this.ChkCargadorDesktop);
            this.GrpDesktop.Controls.Add(this.ChkCaracteristicaDesktop);
            this.GrpDesktop.Controls.Add(this.TxtGeneracionDesktop);
            this.GrpDesktop.Controls.Add(this.CbProcesadorDesktop);
            this.GrpDesktop.Controls.Add(this.CbRamDesktop);
            this.GrpDesktop.Controls.Add(this.CbAlmacenamientoDesktop);
            this.GrpDesktop.Controls.Add(this.label4);
            this.GrpDesktop.Controls.Add(this.label3);
            this.GrpDesktop.Controls.Add(this.label2);
            this.GrpDesktop.Controls.Add(this.label1);
            this.GrpDesktop.Location = new System.Drawing.Point(13, 13);
            this.GrpDesktop.Name = "GrpDesktop";
            this.GrpDesktop.Size = new System.Drawing.Size(200, 275);
            this.GrpDesktop.TabIndex = 0;
            this.GrpDesktop.TabStop = false;
            this.GrpDesktop.Text = "Laptop o PC";
            // 
            // GrpCelular
            // 
            this.GrpCelular.Controls.Add(this.ChkCaracteristicaCelular);
            this.GrpCelular.Controls.Add(this.TxtImeiCelular);
            this.GrpCelular.Controls.Add(this.CbProcesadorCelular);
            this.GrpCelular.Controls.Add(this.label5);
            this.GrpCelular.Controls.Add(this.CbRamCelular);
            this.GrpCelular.Controls.Add(this.label6);
            this.GrpCelular.Controls.Add(this.CbAlmacenamientoCelular);
            this.GrpCelular.Controls.Add(this.label7);
            this.GrpCelular.Controls.Add(this.label8);
            this.GrpCelular.Location = new System.Drawing.Point(219, 13);
            this.GrpCelular.Name = "GrpCelular";
            this.GrpCelular.Size = new System.Drawing.Size(200, 243);
            this.GrpCelular.TabIndex = 0;
            this.GrpCelular.TabStop = false;
            this.GrpCelular.Text = "Celular";
            // 
            // GrpMonitor
            // 
            this.GrpMonitor.Controls.Add(this.ChkCaracteristicasMonitor);
            this.GrpMonitor.Controls.Add(this.TxtTamañoMonitor);
            this.GrpMonitor.Controls.Add(this.CbResoluciónMonitor);
            this.GrpMonitor.Controls.Add(this.CbEntradaMonitor);
            this.GrpMonitor.Controls.Add(this.label9);
            this.GrpMonitor.Controls.Add(this.label12);
            this.GrpMonitor.Controls.Add(this.label10);
            this.GrpMonitor.Controls.Add(this.CbHzMonitor);
            this.GrpMonitor.Controls.Add(this.label11);
            this.GrpMonitor.Location = new System.Drawing.Point(425, 13);
            this.GrpMonitor.Name = "GrpMonitor";
            this.GrpMonitor.Size = new System.Drawing.Size(200, 243);
            this.GrpMonitor.TabIndex = 0;
            this.GrpMonitor.TabStop = false;
            this.GrpMonitor.Text = "Monitor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almacenamiento:";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "RAM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Procesador:";
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
            this.CbRamDesktop.Location = new System.Drawing.Point(6, 92);
            this.CbRamDesktop.Name = "CbRamDesktop";
            this.CbRamDesktop.Size = new System.Drawing.Size(121, 21);
            this.CbRamDesktop.TabIndex = 1;
            this.CbRamDesktop.Text = "SELECCIONE";
            // 
            // CbProcesadorDesktop
            // 
            this.CbProcesadorDesktop.FormattingEnabled = true;
            this.CbProcesadorDesktop.Items.AddRange(new object[] {
            "Intel",
            "AMD"});
            this.CbProcesadorDesktop.Location = new System.Drawing.Point(6, 145);
            this.CbProcesadorDesktop.Name = "CbProcesadorDesktop";
            this.CbProcesadorDesktop.Size = new System.Drawing.Size(121, 21);
            this.CbProcesadorDesktop.TabIndex = 1;
            this.CbProcesadorDesktop.Text = "SELECCIONE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Generación:";
            // 
            // TxtGeneracionDesktop
            // 
            this.TxtGeneracionDesktop.Location = new System.Drawing.Point(6, 198);
            this.TxtGeneracionDesktop.Name = "TxtGeneracionDesktop";
            this.TxtGeneracionDesktop.Size = new System.Drawing.Size(121, 20);
            this.TxtGeneracionDesktop.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Almacenamiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "RAM:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Procesador:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "IMEI:";
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
            // TxtImeiCelular
            // 
            this.TxtImeiCelular.Location = new System.Drawing.Point(6, 208);
            this.TxtImeiCelular.Name = "TxtImeiCelular";
            this.TxtImeiCelular.Size = new System.Drawing.Size(121, 20);
            this.TxtImeiCelular.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Entrada:";
            // 
            // CbResoluciónMonitor
            // 
            this.CbResoluciónMonitor.FormattingEnabled = true;
            this.CbResoluciónMonitor.Items.AddRange(new object[] {
            "640 × 480",
            "",
            "",
            "800 × 600",
            "",
            "",
            "1024 × 768",
            "",
            "",
            "1280 × 720",
            "",
            "",
            "1280 × 800",
            "",
            "",
            "1366 × 768",
            "",
            "",
            "1600 × 900",
            "",
            "",
            "1920 × 1080",
            "",
            "",
            "1920 × 1200",
            "",
            "",
            "2560 × 1440",
            "",
            "",
            "2560 × 1600",
            "",
            "",
            "3440 × 1440",
            "",
            "",
            "3840 × 2160",
            "",
            "",
            "5120 × 2880",
            "",
            "",
            "7680 × 4320"});
            this.CbResoluciónMonitor.Location = new System.Drawing.Point(6, 39);
            this.CbResoluciónMonitor.Name = "CbResoluciónMonitor";
            this.CbResoluciónMonitor.Size = new System.Drawing.Size(121, 21);
            this.CbResoluciónMonitor.TabIndex = 1;
            this.CbResoluciónMonitor.Text = "SELECCIONE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Hz:";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Resolución:";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tamaño pantalla:";
            // 
            // TxtTamañoMonitor
            // 
            this.TxtTamañoMonitor.Location = new System.Drawing.Point(6, 208);
            this.TxtTamañoMonitor.Name = "TxtTamañoMonitor";
            this.TxtTamañoMonitor.Size = new System.Drawing.Size(121, 20);
            this.TxtTamañoMonitor.TabIndex = 2;
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
            // ChkCaracteristicaDesktop
            // 
            this.ChkCaracteristicaDesktop.AutoSize = true;
            this.ChkCaracteristicaDesktop.Location = new System.Drawing.Point(185, 0);
            this.ChkCaracteristicaDesktop.Name = "ChkCaracteristicaDesktop";
            this.ChkCaracteristicaDesktop.Size = new System.Drawing.Size(15, 14);
            this.ChkCaracteristicaDesktop.TabIndex = 3;
            this.ChkCaracteristicaDesktop.UseVisualStyleBackColor = true;
            this.ChkCaracteristicaDesktop.CheckedChanged += new System.EventHandler(this.ChkCaracteristicaDesktop_CheckedChanged);
            // 
            // ChkCaracteristicaCelular
            // 
            this.ChkCaracteristicaCelular.AutoSize = true;
            this.ChkCaracteristicaCelular.Location = new System.Drawing.Point(185, 0);
            this.ChkCaracteristicaCelular.Name = "ChkCaracteristicaCelular";
            this.ChkCaracteristicaCelular.Size = new System.Drawing.Size(15, 14);
            this.ChkCaracteristicaCelular.TabIndex = 3;
            this.ChkCaracteristicaCelular.UseVisualStyleBackColor = true;
            this.ChkCaracteristicaCelular.CheckedChanged += new System.EventHandler(this.ChkCaracteristicaCelular_CheckedChanged);
            // 
            // ChkCaracteristicasMonitor
            // 
            this.ChkCaracteristicasMonitor.AutoSize = true;
            this.ChkCaracteristicasMonitor.Location = new System.Drawing.Point(185, 0);
            this.ChkCaracteristicasMonitor.Name = "ChkCaracteristicasMonitor";
            this.ChkCaracteristicasMonitor.Size = new System.Drawing.Size(15, 14);
            this.ChkCaracteristicasMonitor.TabIndex = 3;
            this.ChkCaracteristicasMonitor.UseVisualStyleBackColor = true;
            this.ChkCaracteristicasMonitor.CheckedChanged += new System.EventHandler(this.ChkCaracteristicasMonitor_CheckedChanged);
            // 
            // ChkCargadorDesktop
            // 
            this.ChkCargadorDesktop.AutoSize = true;
            this.ChkCargadorDesktop.Location = new System.Drawing.Point(6, 240);
            this.ChkCargadorDesktop.Name = "ChkCargadorDesktop";
            this.ChkCargadorDesktop.Size = new System.Drawing.Size(104, 17);
            this.ChkCargadorDesktop.TabIndex = 4;
            this.ChkCargadorDesktop.Text = "Tiene cargador?";
            this.ChkCargadorDesktop.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.BtnCancelar);
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

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpDesktop;
        private System.Windows.Forms.GroupBox GrpCelular;
        private System.Windows.Forms.GroupBox GrpMonitor;
        private System.Windows.Forms.ComboBox CbAlmacenamientoDesktop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbRamDesktop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtGeneracionDesktop;
        private System.Windows.Forms.ComboBox CbProcesadorDesktop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtImeiCelular;
        private System.Windows.Forms.ComboBox CbProcesadorCelular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbRamCelular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbAlmacenamientoCelular;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CbResoluciónMonitor;
        private System.Windows.Forms.ComboBox CbEntradaMonitor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CbHzMonitor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtTamañoMonitor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.CheckBox ChkCaracteristicasMonitor;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.CheckBox ChkCargadorDesktop;
        private System.Windows.Forms.Button BtnAgregarCaracteristica;
        public System.Windows.Forms.CheckBox ChkCaracteristicaDesktop;
        public System.Windows.Forms.CheckBox ChkCaracteristicaCelular;
    }
}
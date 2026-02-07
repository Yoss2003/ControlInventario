namespace ControlInventario.Vistas
{
    partial class VistaConfiguracion
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sistema", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Inventario");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Seguridad");
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpGeneral = new System.Windows.Forms.GroupBox();
            this.CbFormatoFecha = new System.Windows.Forms.ComboBox();
            this.CbZonaHoraria = new System.Windows.Forms.ComboBox();
            this.CbNotificaciones = new System.Windows.Forms.ComboBox();
            this.CbMoneda = new System.Windows.Forms.ComboBox();
            this.CbUniMedida = new System.Windows.Forms.ComboBox();
            this.CbIdioma = new System.Windows.Forms.ComboBox();
            this.CbTema = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GrpSeguridad = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ChkCompartirActividad = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ChkAutenticacion2FA = new System.Windows.Forms.CheckBox();
            this.GrpInventario = new System.Windows.Forms.GroupBox();
            this.ChkGeneracionCodigo = new System.Windows.Forms.CheckBox();
            this.ChkCalcularDevaluacion = new System.Windows.Forms.CheckBox();
            this.ChkCategoriaPersonalizada = new System.Windows.Forms.CheckBox();
            this.ChkCodigoBarras = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.GrpPreview = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TreeMenu = new System.Windows.Forms.TreeView();
            this.GrpGeneral.SuspendLayout();
            this.GrpSeguridad.SuspendLayout();
            this.GrpInventario.SuspendLayout();
            this.GrpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Formato fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Idioma:";
            // 
            // GrpGeneral
            // 
            this.GrpGeneral.Controls.Add(this.CbFormatoFecha);
            this.GrpGeneral.Controls.Add(this.CbZonaHoraria);
            this.GrpGeneral.Controls.Add(this.CbNotificaciones);
            this.GrpGeneral.Controls.Add(this.CbMoneda);
            this.GrpGeneral.Controls.Add(this.CbUniMedida);
            this.GrpGeneral.Controls.Add(this.CbIdioma);
            this.GrpGeneral.Controls.Add(this.CbTema);
            this.GrpGeneral.Controls.Add(this.label4);
            this.GrpGeneral.Controls.Add(this.label5);
            this.GrpGeneral.Controls.Add(this.label7);
            this.GrpGeneral.Controls.Add(this.label3);
            this.GrpGeneral.Controls.Add(this.label6);
            this.GrpGeneral.Controls.Add(this.label1);
            this.GrpGeneral.Controls.Add(this.label2);
            this.GrpGeneral.Location = new System.Drawing.Point(203, 11);
            this.GrpGeneral.Name = "GrpGeneral";
            this.GrpGeneral.Size = new System.Drawing.Size(288, 356);
            this.GrpGeneral.TabIndex = 5;
            this.GrpGeneral.TabStop = false;
            this.GrpGeneral.Visible = false;
            // 
            // CbFormatoFecha
            // 
            this.CbFormatoFecha.FormattingEnabled = true;
            this.CbFormatoFecha.Items.AddRange(new object[] {
            "YYYY/MM/DD",
            "DD/MM/YYYY",
            "MM/DD/YYYY"});
            this.CbFormatoFecha.Location = new System.Drawing.Point(113, 127);
            this.CbFormatoFecha.Name = "CbFormatoFecha";
            this.CbFormatoFecha.Size = new System.Drawing.Size(152, 21);
            this.CbFormatoFecha.TabIndex = 4;
            this.CbFormatoFecha.Text = "SELECCIONE";
            this.CbFormatoFecha.TextChanged += new System.EventHandler(this.CbFormatoFecha_TextChanged);
            // 
            // CbZonaHoraria
            // 
            this.CbZonaHoraria.Enabled = false;
            this.CbZonaHoraria.FormattingEnabled = true;
            this.CbZonaHoraria.Items.AddRange(new object[] {
            "Si",
            "No",
            "Prioritarios",
            "Personalizado"});
            this.CbZonaHoraria.Location = new System.Drawing.Point(113, 235);
            this.CbZonaHoraria.Name = "CbZonaHoraria";
            this.CbZonaHoraria.Size = new System.Drawing.Size(152, 21);
            this.CbZonaHoraria.TabIndex = 7;
            this.CbZonaHoraria.Text = "SELECCIONE";
            this.CbZonaHoraria.TextChanged += new System.EventHandler(this.CbZonaHoraria_TextChanged);
            // 
            // CbNotificaciones
            // 
            this.CbNotificaciones.FormattingEnabled = true;
            this.CbNotificaciones.Items.AddRange(new object[] {
            "Si",
            "No",
            "Prioritarios",
            "Personalizado"});
            this.CbNotificaciones.Location = new System.Drawing.Point(113, 91);
            this.CbNotificaciones.Name = "CbNotificaciones";
            this.CbNotificaciones.Size = new System.Drawing.Size(152, 21);
            this.CbNotificaciones.TabIndex = 3;
            this.CbNotificaciones.Text = "SELECCIONE";
            this.CbNotificaciones.TextChanged += new System.EventHandler(this.CbNotificaciones_TextChanged);
            // 
            // CbMoneda
            // 
            this.CbMoneda.FormattingEnabled = true;
            this.CbMoneda.Items.AddRange(new object[] {
            "PEN",
            "USD"});
            this.CbMoneda.Location = new System.Drawing.Point(113, 163);
            this.CbMoneda.Name = "CbMoneda";
            this.CbMoneda.Size = new System.Drawing.Size(152, 21);
            this.CbMoneda.TabIndex = 5;
            this.CbMoneda.Text = "SELECCIONE";
            this.CbMoneda.TextChanged += new System.EventHandler(this.CbMoneda_TextChanged);
            // 
            // CbUniMedida
            // 
            this.CbUniMedida.FormattingEnabled = true;
            this.CbUniMedida.Items.AddRange(new object[] {
            "Unidades",
            "Cajas",
            "Litros",
            "Kilos"});
            this.CbUniMedida.Location = new System.Drawing.Point(113, 199);
            this.CbUniMedida.Name = "CbUniMedida";
            this.CbUniMedida.Size = new System.Drawing.Size(152, 21);
            this.CbUniMedida.TabIndex = 6;
            this.CbUniMedida.Text = "SELECCIONE";
            this.CbUniMedida.TextChanged += new System.EventHandler(this.CbUniMedida_TextChanged);
            // 
            // CbIdioma
            // 
            this.CbIdioma.FormattingEnabled = true;
            this.CbIdioma.Items.AddRange(new object[] {
            "Español",
            "Inglés"});
            this.CbIdioma.Location = new System.Drawing.Point(113, 19);
            this.CbIdioma.Name = "CbIdioma";
            this.CbIdioma.Size = new System.Drawing.Size(152, 21);
            this.CbIdioma.TabIndex = 1;
            this.CbIdioma.Text = "SELECCIONE";
            this.CbIdioma.TextChanged += new System.EventHandler(this.CbIdioma_TextChanged);
            // 
            // CbTema
            // 
            this.CbTema.FormattingEnabled = true;
            this.CbTema.Items.AddRange(new object[] {
            "Claro",
            "Osucro",
            "Negativo"});
            this.CbTema.Location = new System.Drawing.Point(113, 55);
            this.CbTema.Name = "CbTema";
            this.CbTema.Size = new System.Drawing.Size(152, 21);
            this.CbTema.TabIndex = 2;
            this.CbTema.Text = "SELECCIONE";
            this.CbTema.TextChanged += new System.EventHandler(this.CbTema_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Notificaciones:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tema:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Zona horaria:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unidad de medida:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Modena:";
            // 
            // GrpSeguridad
            // 
            this.GrpSeguridad.Controls.Add(this.label13);
            this.GrpSeguridad.Controls.Add(this.ChkCompartirActividad);
            this.GrpSeguridad.Controls.Add(this.label12);
            this.GrpSeguridad.Controls.Add(this.ChkAutenticacion2FA);
            this.GrpSeguridad.Location = new System.Drawing.Point(203, 12);
            this.GrpSeguridad.Name = "GrpSeguridad";
            this.GrpSeguridad.Size = new System.Drawing.Size(288, 356);
            this.GrpSeguridad.TabIndex = 5;
            this.GrpSeguridad.TabStop = false;
            this.GrpSeguridad.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(71, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Compartir actividad";
            // 
            // ChkCompartirActividad
            // 
            this.ChkCompartirActividad.AutoSize = true;
            this.ChkCompartirActividad.Location = new System.Drawing.Point(198, 111);
            this.ChkCompartirActividad.Name = "ChkCompartirActividad";
            this.ChkCompartirActividad.Size = new System.Drawing.Size(15, 14);
            this.ChkCompartirActividad.TabIndex = 9;
            this.ChkCompartirActividad.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Habilitar autenticación 2FA";
            // 
            // ChkAutenticacion2FA
            // 
            this.ChkAutenticacion2FA.AutoSize = true;
            this.ChkAutenticacion2FA.Location = new System.Drawing.Point(198, 55);
            this.ChkAutenticacion2FA.Name = "ChkAutenticacion2FA";
            this.ChkAutenticacion2FA.Size = new System.Drawing.Size(15, 14);
            this.ChkAutenticacion2FA.TabIndex = 8;
            this.ChkAutenticacion2FA.UseVisualStyleBackColor = true;
            // 
            // GrpInventario
            // 
            this.GrpInventario.Controls.Add(this.ChkGeneracionCodigo);
            this.GrpInventario.Controls.Add(this.ChkCalcularDevaluacion);
            this.GrpInventario.Controls.Add(this.ChkCategoriaPersonalizada);
            this.GrpInventario.Controls.Add(this.ChkCodigoBarras);
            this.GrpInventario.Controls.Add(this.label11);
            this.GrpInventario.Controls.Add(this.label10);
            this.GrpInventario.Controls.Add(this.label9);
            this.GrpInventario.Controls.Add(this.label8);
            this.GrpInventario.Location = new System.Drawing.Point(203, 11);
            this.GrpInventario.Name = "GrpInventario";
            this.GrpInventario.Size = new System.Drawing.Size(288, 356);
            this.GrpInventario.TabIndex = 5;
            this.GrpInventario.TabStop = false;
            this.GrpInventario.Visible = false;
            // 
            // ChkGeneracionCodigo
            // 
            this.ChkGeneracionCodigo.AutoSize = true;
            this.ChkGeneracionCodigo.Location = new System.Drawing.Point(212, 128);
            this.ChkGeneracionCodigo.Name = "ChkGeneracionCodigo";
            this.ChkGeneracionCodigo.Size = new System.Drawing.Size(15, 14);
            this.ChkGeneracionCodigo.TabIndex = 13;
            this.ChkGeneracionCodigo.UseVisualStyleBackColor = true;
            // 
            // ChkCalcularDevaluacion
            // 
            this.ChkCalcularDevaluacion.AutoSize = true;
            this.ChkCalcularDevaluacion.Location = new System.Drawing.Point(212, 100);
            this.ChkCalcularDevaluacion.Name = "ChkCalcularDevaluacion";
            this.ChkCalcularDevaluacion.Size = new System.Drawing.Size(15, 14);
            this.ChkCalcularDevaluacion.TabIndex = 12;
            this.ChkCalcularDevaluacion.UseVisualStyleBackColor = true;
            // 
            // ChkCategoriaPersonalizada
            // 
            this.ChkCategoriaPersonalizada.AutoSize = true;
            this.ChkCategoriaPersonalizada.Location = new System.Drawing.Point(212, 72);
            this.ChkCategoriaPersonalizada.Name = "ChkCategoriaPersonalizada";
            this.ChkCategoriaPersonalizada.Size = new System.Drawing.Size(15, 14);
            this.ChkCategoriaPersonalizada.TabIndex = 11;
            this.ChkCategoriaPersonalizada.UseVisualStyleBackColor = true;
            // 
            // ChkCodigoBarras
            // 
            this.ChkCodigoBarras.AutoSize = true;
            this.ChkCodigoBarras.Location = new System.Drawing.Point(212, 45);
            this.ChkCodigoBarras.Name = "ChkCodigoBarras";
            this.ChkCodigoBarras.Size = new System.Drawing.Size(15, 14);
            this.ChkCodigoBarras.TabIndex = 10;
            this.ChkCodigoBarras.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Generación de código";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Calcular devaluación";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Categorías personalizadas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Habilitar código de barras";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(367, 374);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 14;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // GrpPreview
            // 
            this.GrpPreview.Controls.Add(this.pictureBox1);
            this.GrpPreview.Location = new System.Drawing.Point(497, 12);
            this.GrpPreview.Name = "GrpPreview";
            this.GrpPreview.Size = new System.Drawing.Size(314, 356);
            this.GrpPreview.TabIndex = 16;
            this.GrpPreview.TabStop = false;
            this.GrpPreview.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 331);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TreeMenu
            // 
            this.TreeMenu.Location = new System.Drawing.Point(12, 12);
            this.TreeMenu.Name = "TreeMenu";
            treeNode1.Name = "General";
            treeNode1.Text = "General";
            treeNode2.Name = "Sistema";
            treeNode2.Text = "Sistema";
            treeNode3.Name = "Inventario";
            treeNode3.Text = "Inventario";
            treeNode4.Name = "Seguridad";
            treeNode4.Text = "Seguridad";
            this.TreeMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            this.TreeMenu.Size = new System.Drawing.Size(185, 356);
            this.TreeMenu.TabIndex = 17;
            this.TreeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeMenu_AfterSelect);
            // 
            // VistaConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 411);
            this.Controls.Add(this.GrpGeneral);
            this.Controls.Add(this.TreeMenu);
            this.Controls.Add(this.GrpPreview);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.GrpInventario);
            this.Controls.Add(this.GrpSeguridad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "VistaConfiguracion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.VistaConfiguracion_Load);
            this.GrpGeneral.ResumeLayout(false);
            this.GrpGeneral.PerformLayout();
            this.GrpSeguridad.ResumeLayout(false);
            this.GrpSeguridad.PerformLayout();
            this.GrpInventario.ResumeLayout(false);
            this.GrpInventario.PerformLayout();
            this.GrpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrpGeneral;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbTema;
        private System.Windows.Forms.ComboBox CbFormatoFecha;
        private System.Windows.Forms.ComboBox CbNotificaciones;
        private System.Windows.Forms.ComboBox CbIdioma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GrpSeguridad;
        private System.Windows.Forms.GroupBox GrpInventario;
        private System.Windows.Forms.ComboBox CbZonaHoraria;
        private System.Windows.Forms.ComboBox CbMoneda;
        private System.Windows.Forms.ComboBox CbUniMedida;
        private System.Windows.Forms.CheckBox ChkCalcularDevaluacion;
        private System.Windows.Forms.CheckBox ChkCategoriaPersonalizada;
        private System.Windows.Forms.CheckBox ChkCodigoBarras;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ChkCompartirActividad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ChkAutenticacion2FA;
        private System.Windows.Forms.CheckBox ChkGeneracionCodigo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox GrpPreview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView TreeMenu;
    }
}
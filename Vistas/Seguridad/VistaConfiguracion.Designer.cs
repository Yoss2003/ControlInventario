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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaConfiguracion));
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
            this.ChkCodigoBarras = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.GrpPreview = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TreeMenu = new System.Windows.Forms.TreeView();
            this.GrpDefault = new System.Windows.Forms.GroupBox();
            this.GrpGeneral.SuspendLayout();
            this.GrpSeguridad.SuspendLayout();
            this.GrpInventario.SuspendLayout();
            this.GrpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // GrpGeneral
            // 
            resources.ApplyResources(this.GrpGeneral, "GrpGeneral");
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
            this.GrpGeneral.Name = "GrpGeneral";
            this.GrpGeneral.TabStop = false;
            // 
            // CbFormatoFecha
            // 
            resources.ApplyResources(this.CbFormatoFecha, "CbFormatoFecha");
            this.CbFormatoFecha.FormattingEnabled = true;
            this.CbFormatoFecha.Name = "CbFormatoFecha";
            this.CbFormatoFecha.TextChanged += new System.EventHandler(this.CbFormatoFecha_TextChanged);
            // 
            // CbZonaHoraria
            // 
            resources.ApplyResources(this.CbZonaHoraria, "CbZonaHoraria");
            this.CbZonaHoraria.FormattingEnabled = true;
            this.CbZonaHoraria.Name = "CbZonaHoraria";
            this.CbZonaHoraria.TextChanged += new System.EventHandler(this.CbZonaHoraria_TextChanged);
            // 
            // CbNotificaciones
            // 
            resources.ApplyResources(this.CbNotificaciones, "CbNotificaciones");
            this.CbNotificaciones.FormattingEnabled = true;
            this.CbNotificaciones.Name = "CbNotificaciones";
            this.CbNotificaciones.TextChanged += new System.EventHandler(this.CbNotificaciones_TextChanged);
            // 
            // CbMoneda
            // 
            resources.ApplyResources(this.CbMoneda, "CbMoneda");
            this.CbMoneda.FormattingEnabled = true;
            this.CbMoneda.Name = "CbMoneda";
            this.CbMoneda.TextChanged += new System.EventHandler(this.CbMoneda_TextChanged);
            // 
            // CbUniMedida
            // 
            resources.ApplyResources(this.CbUniMedida, "CbUniMedida");
            this.CbUniMedida.FormattingEnabled = true;
            this.CbUniMedida.Name = "CbUniMedida";
            this.CbUniMedida.TextChanged += new System.EventHandler(this.CbUniMedida_TextChanged);
            // 
            // CbIdioma
            // 
            resources.ApplyResources(this.CbIdioma, "CbIdioma");
            this.CbIdioma.FormattingEnabled = true;
            this.CbIdioma.Name = "CbIdioma";
            this.CbIdioma.TextChanged += new System.EventHandler(this.CbIdioma_TextChanged);
            // 
            // CbTema
            // 
            resources.ApplyResources(this.CbTema, "CbTema");
            this.CbTema.FormattingEnabled = true;
            this.CbTema.Name = "CbTema";
            this.CbTema.SelectedIndexChanged += new System.EventHandler(this.CbTema_SelectedIndexChanged);
            this.CbTema.TextChanged += new System.EventHandler(this.CbTema_TextChanged);
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
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // GrpSeguridad
            // 
            resources.ApplyResources(this.GrpSeguridad, "GrpSeguridad");
            this.GrpSeguridad.Controls.Add(this.label13);
            this.GrpSeguridad.Controls.Add(this.ChkCompartirActividad);
            this.GrpSeguridad.Controls.Add(this.label12);
            this.GrpSeguridad.Controls.Add(this.ChkAutenticacion2FA);
            this.GrpSeguridad.Name = "GrpSeguridad";
            this.GrpSeguridad.TabStop = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // ChkCompartirActividad
            // 
            resources.ApplyResources(this.ChkCompartirActividad, "ChkCompartirActividad");
            this.ChkCompartirActividad.Name = "ChkCompartirActividad";
            this.ChkCompartirActividad.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // ChkAutenticacion2FA
            // 
            resources.ApplyResources(this.ChkAutenticacion2FA, "ChkAutenticacion2FA");
            this.ChkAutenticacion2FA.Name = "ChkAutenticacion2FA";
            this.ChkAutenticacion2FA.UseVisualStyleBackColor = true;
            // 
            // GrpInventario
            // 
            resources.ApplyResources(this.GrpInventario, "GrpInventario");
            this.GrpInventario.Controls.Add(this.ChkGeneracionCodigo);
            this.GrpInventario.Controls.Add(this.ChkCalcularDevaluacion);
            this.GrpInventario.Controls.Add(this.ChkCodigoBarras);
            this.GrpInventario.Controls.Add(this.label11);
            this.GrpInventario.Controls.Add(this.label10);
            this.GrpInventario.Controls.Add(this.label8);
            this.GrpInventario.Name = "GrpInventario";
            this.GrpInventario.TabStop = false;
            // 
            // ChkGeneracionCodigo
            // 
            resources.ApplyResources(this.ChkGeneracionCodigo, "ChkGeneracionCodigo");
            this.ChkGeneracionCodigo.Name = "ChkGeneracionCodigo";
            this.ChkGeneracionCodigo.UseVisualStyleBackColor = true;
            // 
            // ChkCalcularDevaluacion
            // 
            resources.ApplyResources(this.ChkCalcularDevaluacion, "ChkCalcularDevaluacion");
            this.ChkCalcularDevaluacion.Name = "ChkCalcularDevaluacion";
            this.ChkCalcularDevaluacion.UseVisualStyleBackColor = true;
            // 
            // ChkCodigoBarras
            // 
            resources.ApplyResources(this.ChkCodigoBarras, "ChkCodigoBarras");
            this.ChkCodigoBarras.Name = "ChkCodigoBarras";
            this.ChkCodigoBarras.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // BtnGuardar
            // 
            resources.ApplyResources(this.BtnGuardar, "BtnGuardar");
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // GrpPreview
            // 
            resources.ApplyResources(this.GrpPreview, "GrpPreview");
            this.GrpPreview.Controls.Add(this.pictureBox1);
            this.GrpPreview.Name = "GrpPreview";
            this.GrpPreview.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // TreeMenu
            // 
            resources.ApplyResources(this.TreeMenu, "TreeMenu");
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("TreeMenu.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("TreeMenu.Nodes1"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("TreeMenu.Nodes2")))});
            this.TreeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeMenu_AfterSelect);
            // 
            // GrpDefault
            // 
            resources.ApplyResources(this.GrpDefault, "GrpDefault");
            this.GrpDefault.Name = "GrpDefault";
            this.GrpDefault.TabStop = false;
            // 
            // VistaConfiguracion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpGeneral);
            this.Controls.Add(this.GrpSeguridad);
            this.Controls.Add(this.GrpInventario);
            this.Controls.Add(this.TreeMenu);
            this.Controls.Add(this.GrpPreview);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.GrpDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "VistaConfiguracion";
            this.ShowIcon = false;
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
        private System.Windows.Forms.CheckBox ChkCodigoBarras;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.GroupBox GrpDefault;
    }
}
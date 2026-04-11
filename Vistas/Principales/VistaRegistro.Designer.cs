namespace ControlInventario.Vistas
{
    partial class VistaRegistro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEdad = new System.Windows.Forms.NumericUpDown();
            this.dtFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAgregarTipoContrato = new System.Windows.Forms.Button();
            this.BtnAgregarArea = new System.Windows.Forms.Button();
            this.BtnAgregarCargo = new System.Windows.Forms.Button();
            this.CbArea = new System.Windows.Forms.ComboBox();
            this.CbCargo = new System.Windows.Forms.ComboBox();
            this.CbTipoContrato = new System.Windows.Forms.ComboBox();
            this.dtFechaIngre = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_VerContraseña2 = new System.Windows.Forms.Button();
            this.Btn_VerContraseña1 = new System.Windows.Forms.Button();
            this.txtConfirmContraseña = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkedListRol = new System.Windows.Forms.CheckedListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.TxtNumbCelular = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEdad);
            this.groupBox1.Controls.Add(this.dtFechaNac);
            this.groupBox1.Controls.Add(this.TxtNumbCelular);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtEdad
            // 
            resources.ApplyResources(this.txtEdad, "txtEdad");
            this.txtEdad.Maximum = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.txtEdad.Name = "txtEdad";
            // 
            // dtFechaNac
            // 
            this.dtFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtFechaNac, "dtFechaNac");
            this.dtFechaNac.Name = "dtFechaNac";
            // 
            // txtCorreo
            // 
            resources.ApplyResources(this.txtCorreo, "txtCorreo");
            this.txtCorreo.Name = "txtCorreo";
            // 
            // txtApellido
            // 
            resources.ApplyResources(this.txtApellido, "txtApellido");
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAgregarTipoContrato);
            this.groupBox2.Controls.Add(this.BtnAgregarArea);
            this.groupBox2.Controls.Add(this.BtnAgregarCargo);
            this.groupBox2.Controls.Add(this.CbArea);
            this.groupBox2.Controls.Add(this.CbCargo);
            this.groupBox2.Controls.Add(this.CbTipoContrato);
            this.groupBox2.Controls.Add(this.dtFechaIngre);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // BtnAgregarTipoContrato
            // 
            resources.ApplyResources(this.BtnAgregarTipoContrato, "BtnAgregarTipoContrato");
            this.BtnAgregarTipoContrato.Name = "BtnAgregarTipoContrato";
            this.BtnAgregarTipoContrato.UseVisualStyleBackColor = true;
            this.BtnAgregarTipoContrato.Click += new System.EventHandler(this.BtnAgregarTipoContrato_Click);
            // 
            // BtnAgregarArea
            // 
            resources.ApplyResources(this.BtnAgregarArea, "BtnAgregarArea");
            this.BtnAgregarArea.Name = "BtnAgregarArea";
            this.BtnAgregarArea.UseVisualStyleBackColor = true;
            this.BtnAgregarArea.Click += new System.EventHandler(this.BtnAgregarArea_Click);
            // 
            // BtnAgregarCargo
            // 
            resources.ApplyResources(this.BtnAgregarCargo, "BtnAgregarCargo");
            this.BtnAgregarCargo.Name = "BtnAgregarCargo";
            this.BtnAgregarCargo.UseVisualStyleBackColor = true;
            this.BtnAgregarCargo.Click += new System.EventHandler(this.BtnAgregarCargo_Click);
            // 
            // CbArea
            // 
            this.CbArea.FormattingEnabled = true;
            resources.ApplyResources(this.CbArea, "CbArea");
            this.CbArea.Name = "CbArea";
            // 
            // CbCargo
            // 
            this.CbCargo.FormattingEnabled = true;
            resources.ApplyResources(this.CbCargo, "CbCargo");
            this.CbCargo.Name = "CbCargo";
            // 
            // CbTipoContrato
            // 
            this.CbTipoContrato.FormattingEnabled = true;
            resources.ApplyResources(this.CbTipoContrato, "CbTipoContrato");
            this.CbTipoContrato.Name = "CbTipoContrato";
            // 
            // dtFechaIngre
            // 
            this.dtFechaIngre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtFechaIngre, "dtFechaIngre");
            this.dtFechaIngre.Name = "dtFechaIngre";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Btn_VerContraseña2);
            this.groupBox3.Controls.Add(this.Btn_VerContraseña1);
            this.groupBox3.Controls.Add(this.txtConfirmContraseña);
            this.groupBox3.Controls.Add(this.txtContraseña);
            this.groupBox3.Controls.Add(this.txtUsuario);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // Btn_VerContraseña2
            // 
            resources.ApplyResources(this.Btn_VerContraseña2, "Btn_VerContraseña2");
            this.Btn_VerContraseña2.Name = "Btn_VerContraseña2";
            this.Btn_VerContraseña2.UseVisualStyleBackColor = true;
            this.Btn_VerContraseña2.Click += new System.EventHandler(this.Btn_VerContraseña2_Click);
            // 
            // Btn_VerContraseña1
            // 
            resources.ApplyResources(this.Btn_VerContraseña1, "Btn_VerContraseña1");
            this.Btn_VerContraseña1.Name = "Btn_VerContraseña1";
            this.Btn_VerContraseña1.UseVisualStyleBackColor = true;
            this.Btn_VerContraseña1.Click += new System.EventHandler(this.Btn_VerContraseña1_Click);
            // 
            // txtConfirmContraseña
            // 
            resources.ApplyResources(this.txtConfirmContraseña, "txtConfirmContraseña");
            this.txtConfirmContraseña.Name = "txtConfirmContraseña";
            this.txtConfirmContraseña.UseSystemPasswordChar = true;
            // 
            // txtContraseña
            // 
            resources.ApplyResources(this.txtContraseña, "txtContraseña");
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            resources.ApplyResources(this.txtUsuario, "txtUsuario");
            this.txtUsuario.Name = "txtUsuario";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkedListRol);
            this.groupBox4.Controls.Add(this.label13);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // checkedListRol
            // 
            resources.ApplyResources(this.checkedListRol, "checkedListRol");
            this.checkedListRol.FormattingEnabled = true;
            this.checkedListRol.Items.AddRange(new object[] {
            resources.GetString("checkedListRol.Items"),
            resources.GetString("checkedListRol.Items1"),
            resources.GetString("checkedListRol.Items2"),
            resources.GetString("checkedListRol.Items3"),
            resources.GetString("checkedListRol.Items4")});
            this.checkedListRol.Name = "checkedListRol";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // btnGuardar
            // 
            resources.ApplyResources(this.btnGuardar, "btnGuardar");
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // TxtNumbCelular
            // 
            resources.ApplyResources(this.TxtNumbCelular, "TxtNumbCelular");
            this.TxtNumbCelular.Name = "TxtNumbCelular";
            // 
            // VistaRegistro
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "VistaRegistro";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.VistaRegistro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txtEdad;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtFechaIngre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CbTipoContrato;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtConfirmContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtFechaNac;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckedListBox checkedListRol;
        private System.Windows.Forms.Button Btn_VerContraseña2;
        private System.Windows.Forms.Button Btn_VerContraseña1;
        private System.Windows.Forms.ComboBox CbArea;
        private System.Windows.Forms.ComboBox CbCargo;
        private System.Windows.Forms.Button BtnAgregarTipoContrato;
        private System.Windows.Forms.Button BtnAgregarArea;
        private System.Windows.Forms.Button BtnAgregarCargo;
        private System.Windows.Forms.TextBox TxtNumbCelular;
        private System.Windows.Forms.Label label14;
    }
}
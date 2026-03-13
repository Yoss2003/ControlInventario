namespace ControlInventario
{
    partial class VistaInicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInicioSesion));
            this.groupBienvenida = new System.Windows.Forms.GroupBox();
            this.lnkRegistro = new System.Windows.Forms.LinkLabel();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.groupLogin = new System.Windows.Forms.GroupBox();
            this.lblErrorContraseña = new System.Windows.Forms.Label();
            this.lblErrorUsuario = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lnkContraseña = new System.Windows.Forms.LinkLabel();
            this.chkRecuerdame = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupInformation = new System.Windows.Forms.GroupBox();
            this.lblConexion = new System.Windows.Forms.Label();
            this.lnkDerechos = new System.Windows.Forms.LinkLabel();
            this.groupBienvenida.SuspendLayout();
            this.groupLogin.SuspendLayout();
            this.groupInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBienvenida
            // 
            resources.ApplyResources(this.groupBienvenida, "groupBienvenida");
            this.groupBienvenida.Controls.Add(this.lnkRegistro);
            this.groupBienvenida.Controls.Add(this.lblRegistro);
            this.groupBienvenida.Controls.Add(this.lblBienvenida);
            this.groupBienvenida.Name = "groupBienvenida";
            this.groupBienvenida.TabStop = false;
            // 
            // lnkRegistro
            // 
            resources.ApplyResources(this.lnkRegistro, "lnkRegistro");
            this.lnkRegistro.Name = "lnkRegistro";
            this.lnkRegistro.TabStop = true;
            this.lnkRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegistro_LinkClicked);
            // 
            // lblRegistro
            // 
            resources.ApplyResources(this.lblRegistro, "lblRegistro");
            this.lblRegistro.Name = "lblRegistro";
            // 
            // lblBienvenida
            // 
            resources.ApplyResources(this.lblBienvenida, "lblBienvenida");
            this.lblBienvenida.Name = "lblBienvenida";
            // 
            // groupLogin
            // 
            resources.ApplyResources(this.groupLogin, "groupLogin");
            this.groupLogin.Controls.Add(this.lblErrorContraseña);
            this.groupLogin.Controls.Add(this.lblErrorUsuario);
            this.groupLogin.Controls.Add(this.btnIngresar);
            this.groupLogin.Controls.Add(this.lnkContraseña);
            this.groupLogin.Controls.Add(this.chkRecuerdame);
            this.groupLogin.Controls.Add(this.label2);
            this.groupLogin.Controls.Add(this.label1);
            this.groupLogin.Controls.Add(this.txtContraseña);
            this.groupLogin.Controls.Add(this.txtUsuario);
            this.groupLogin.Name = "groupLogin";
            this.groupLogin.TabStop = false;
            // 
            // lblErrorContraseña
            // 
            resources.ApplyResources(this.lblErrorContraseña, "lblErrorContraseña");
            this.lblErrorContraseña.ForeColor = System.Drawing.Color.Red;
            this.lblErrorContraseña.Name = "lblErrorContraseña";
            // 
            // lblErrorUsuario
            // 
            resources.ApplyResources(this.lblErrorUsuario, "lblErrorUsuario");
            this.lblErrorUsuario.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUsuario.Name = "lblErrorUsuario";
            // 
            // btnIngresar
            // 
            resources.ApplyResources(this.btnIngresar, "btnIngresar");
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lnkContraseña
            // 
            resources.ApplyResources(this.lnkContraseña, "lnkContraseña");
            this.lnkContraseña.Name = "lnkContraseña";
            this.lnkContraseña.TabStop = true;
            this.lnkContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContraseña_LinkClicked);
            // 
            // chkRecuerdame
            // 
            resources.ApplyResources(this.chkRecuerdame, "chkRecuerdame");
            this.chkRecuerdame.Name = "chkRecuerdame";
            this.chkRecuerdame.UseVisualStyleBackColor = true;
            this.chkRecuerdame.Click += new System.EventHandler(this.chkRecuerdame_Click);
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
            // txtContraseña
            // 
            resources.ApplyResources(this.txtContraseña, "txtContraseña");
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Tag = "";
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            resources.ApplyResources(this.txtUsuario, "txtUsuario");
            this.txtUsuario.Name = "txtUsuario";
            // 
            // groupInformation
            // 
            resources.ApplyResources(this.groupInformation, "groupInformation");
            this.groupInformation.Controls.Add(this.lblConexion);
            this.groupInformation.Controls.Add(this.lnkDerechos);
            this.groupInformation.Name = "groupInformation";
            this.groupInformation.TabStop = false;
            // 
            // lblConexion
            // 
            resources.ApplyResources(this.lblConexion, "lblConexion");
            this.lblConexion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConexion.Name = "lblConexion";
            // 
            // lnkDerechos
            // 
            resources.ApplyResources(this.lnkDerechos, "lnkDerechos");
            this.lnkDerechos.Name = "lnkDerechos";
            this.lnkDerechos.TabStop = true;
            // 
            // VistaInicioSesion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupInformation);
            this.Controls.Add(this.groupLogin);
            this.Controls.Add(this.groupBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaInicioSesion";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.VistaSesion_Load);
            this.groupBienvenida.ResumeLayout(false);
            this.groupBienvenida.PerformLayout();
            this.groupLogin.ResumeLayout(false);
            this.groupLogin.PerformLayout();
            this.groupInformation.ResumeLayout(false);
            this.groupInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBienvenida;
        private System.Windows.Forms.LinkLabel lnkRegistro;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.GroupBox groupLogin;
        private System.Windows.Forms.Label lblErrorContraseña;
        private System.Windows.Forms.Label lblErrorUsuario;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.LinkLabel lnkContraseña;
        private System.Windows.Forms.CheckBox chkRecuerdame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.GroupBox groupInformation;
        public System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.LinkLabel lnkDerechos;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}


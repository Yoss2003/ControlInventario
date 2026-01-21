namespace ControlInventario
{
    partial class VistaSesion
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
            this.groupBienvenida.Controls.Add(this.lnkRegistro);
            this.groupBienvenida.Controls.Add(this.lblRegistro);
            this.groupBienvenida.Controls.Add(this.lblBienvenida);
            this.groupBienvenida.Location = new System.Drawing.Point(12, 12);
            this.groupBienvenida.Name = "groupBienvenida";
            this.groupBienvenida.Size = new System.Drawing.Size(412, 137);
            this.groupBienvenida.TabIndex = 10;
            this.groupBienvenida.TabStop = false;
            // 
            // lnkRegistro
            // 
            this.lnkRegistro.AutoSize = true;
            this.lnkRegistro.Location = new System.Drawing.Point(229, 110);
            this.lnkRegistro.Name = "lnkRegistro";
            this.lnkRegistro.Size = new System.Drawing.Size(54, 13);
            this.lnkRegistro.TabIndex = 9;
            this.lnkRegistro.TabStop = true;
            this.lnkRegistro.Text = "click aquí";
            this.lnkRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegistro_LinkClicked);
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Location = new System.Drawing.Point(79, 98);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(248, 26);
            this.lblRegistro.TabIndex = 10;
            this.lblRegistro.Text = "Si es la primera vez que ingresas es necesario que \r\nte registres haciendo click " +
    "aqui.\r\n";
            this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(51, 16);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(310, 66);
            this.lblBienvenida.TabIndex = 8;
            this.lblBienvenida.Text = "Bienvenido!\r\nQuién desea ingresar?";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupLogin
            // 
            this.groupLogin.Controls.Add(this.lblErrorContraseña);
            this.groupLogin.Controls.Add(this.lblErrorUsuario);
            this.groupLogin.Controls.Add(this.btnIngresar);
            this.groupLogin.Controls.Add(this.lnkContraseña);
            this.groupLogin.Controls.Add(this.chkRecuerdame);
            this.groupLogin.Controls.Add(this.label2);
            this.groupLogin.Controls.Add(this.label1);
            this.groupLogin.Controls.Add(this.txtContraseña);
            this.groupLogin.Controls.Add(this.txtUsuario);
            this.groupLogin.Location = new System.Drawing.Point(12, 155);
            this.groupLogin.Name = "groupLogin";
            this.groupLogin.Size = new System.Drawing.Size(412, 235);
            this.groupLogin.TabIndex = 11;
            this.groupLogin.TabStop = false;
            // 
            // lblErrorContraseña
            // 
            this.lblErrorContraseña.AutoSize = true;
            this.lblErrorContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorContraseña.ForeColor = System.Drawing.Color.Red;
            this.lblErrorContraseña.Location = new System.Drawing.Point(235, 87);
            this.lblErrorContraseña.Name = "lblErrorContraseña";
            this.lblErrorContraseña.Size = new System.Drawing.Size(132, 13);
            this.lblErrorContraseña.TabIndex = 17;
            this.lblErrorContraseña.Text = "Contraseña incorrecta";
            this.lblErrorContraseña.Visible = false;
            // 
            // lblErrorUsuario
            // 
            this.lblErrorUsuario.AutoSize = true;
            this.lblErrorUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsuario.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUsuario.Location = new System.Drawing.Point(231, 20);
            this.lblErrorUsuario.Name = "lblErrorUsuario";
            this.lblErrorUsuario.Size = new System.Drawing.Size(136, 13);
            this.lblErrorUsuario.TabIndex = 18;
            this.lblErrorUsuario.Text = "Usuario no encontrado";
            this.lblErrorUsuario.Visible = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(49, 178);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(318, 38);
            this.btnIngresar.TabIndex = 16;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lnkContraseña
            // 
            this.lnkContraseña.AutoSize = true;
            this.lnkContraseña.Location = new System.Drawing.Point(237, 149);
            this.lnkContraseña.Name = "lnkContraseña";
            this.lnkContraseña.Size = new System.Drawing.Size(130, 13);
            this.lnkContraseña.TabIndex = 15;
            this.lnkContraseña.TabStop = true;
            this.lnkContraseña.Text = "Olvidaste tu constraseña?";
            this.lnkContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContraseña_LinkClicked);
            // 
            // chkRecuerdame
            // 
            this.chkRecuerdame.AutoSize = true;
            this.chkRecuerdame.Location = new System.Drawing.Point(49, 148);
            this.chkRecuerdame.Name = "chkRecuerdame";
            this.chkRecuerdame.Size = new System.Drawing.Size(90, 17);
            this.chkRecuerdame.TabIndex = 14;
            this.chkRecuerdame.Text = "Recuerdarme";
            this.chkRecuerdame.UseVisualStyleBackColor = true;
            this.chkRecuerdame.Click += new System.EventHandler(this.chkRecuerdame_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Usuario:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtContraseña.Location = new System.Drawing.Point(49, 104);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(318, 26);
            this.txtContraseña.TabIndex = 13;
            this.txtContraseña.Tag = "";
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(49, 39);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(318, 26);
            this.txtUsuario.TabIndex = 10;
            // 
            // groupInformation
            // 
            this.groupInformation.Controls.Add(this.lblConexion);
            this.groupInformation.Controls.Add(this.lnkDerechos);
            this.groupInformation.Location = new System.Drawing.Point(12, 396);
            this.groupInformation.Name = "groupInformation";
            this.groupInformation.Size = new System.Drawing.Size(412, 77);
            this.groupInformation.TabIndex = 12;
            this.groupInformation.TabStop = false;
            // 
            // lblConexion
            // 
            this.lblConexion.AutoSize = true;
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConexion.Location = new System.Drawing.Point(153, 25);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(104, 13);
            this.lblConexion.TabIndex = 11;
            this.lblConexion.Text = "Conexión Exitosa";
            this.lblConexion.Visible = false;
            // 
            // lnkDerechos
            // 
            this.lnkDerechos.AutoSize = true;
            this.lnkDerechos.Location = new System.Drawing.Point(81, 48);
            this.lnkDerechos.Name = "lnkDerechos";
            this.lnkDerechos.Size = new System.Drawing.Size(250, 13);
            this.lnkDerechos.TabIndex = 10;
            this.lnkDerechos.TabStop = true;
            this.lnkDerechos.Text = "© 2026 Alexandro. Todos los derechos reservados.";
            // 
            // VistaSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 485);
            this.Controls.Add(this.groupInformation);
            this.Controls.Add(this.groupLogin);
            this.Controls.Add(this.groupBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VistaSesion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesión";
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


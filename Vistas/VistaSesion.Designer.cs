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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRecuerdame = new System.Windows.Forms.CheckBox();
            this.lnkContraseña = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkRegistro = new System.Windows.Forms.LinkLabel();
            this.lnkDerechos = new System.Windows.Forms.LinkLabel();
            this.lblErrorUsuario = new System.Windows.Forms.Label();
            this.lblErrorContraseña = new System.Windows.Forms.Label();
            this.lblConexion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(55, 171);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(318, 26);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtContraseña.Location = new System.Drawing.Point(55, 236);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(318, 26);
            this.txtContraseña.TabIndex = 0;
            this.txtContraseña.Tag = "";
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 66);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bienvenido!\r\nQuién desea ingresar?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkRecuerdame
            // 
            this.chkRecuerdame.AutoSize = true;
            this.chkRecuerdame.Location = new System.Drawing.Point(55, 280);
            this.chkRecuerdame.Name = "chkRecuerdame";
            this.chkRecuerdame.Size = new System.Drawing.Size(90, 17);
            this.chkRecuerdame.TabIndex = 4;
            this.chkRecuerdame.Text = "Recuerdarme";
            this.chkRecuerdame.UseVisualStyleBackColor = true;
            // 
            // lnkContraseña
            // 
            this.lnkContraseña.AutoSize = true;
            this.lnkContraseña.Location = new System.Drawing.Point(243, 281);
            this.lnkContraseña.Name = "lnkContraseña";
            this.lnkContraseña.Size = new System.Drawing.Size(130, 13);
            this.lnkContraseña.TabIndex = 5;
            this.lnkContraseña.TabStop = true;
            this.lnkContraseña.Text = "Olvidaste tu constraseña?";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(55, 310);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(318, 38);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Si es la primera vez que ingresas es necesario que \r\nte registres haciendo click " +
    "aqui.\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkRegistro
            // 
            this.lnkRegistro.AutoSize = true;
            this.lnkRegistro.Location = new System.Drawing.Point(231, 115);
            this.lnkRegistro.Name = "lnkRegistro";
            this.lnkRegistro.Size = new System.Drawing.Size(54, 13);
            this.lnkRegistro.TabIndex = 8;
            this.lnkRegistro.TabStop = true;
            this.lnkRegistro.Text = "click aquí";
            this.lnkRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegistro_LinkClicked);
            // 
            // lnkDerechos
            // 
            this.lnkDerechos.AutoSize = true;
            this.lnkDerechos.Location = new System.Drawing.Point(87, 381);
            this.lnkDerechos.Name = "lnkDerechos";
            this.lnkDerechos.Size = new System.Drawing.Size(250, 13);
            this.lnkDerechos.TabIndex = 8;
            this.lnkDerechos.TabStop = true;
            this.lnkDerechos.Text = "© 2026 Alexandro. Todos los derechos reservados.";
            // 
            // lblErrorUsuario
            // 
            this.lblErrorUsuario.AutoSize = true;
            this.lblErrorUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsuario.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUsuario.Location = new System.Drawing.Point(237, 152);
            this.lblErrorUsuario.Name = "lblErrorUsuario";
            this.lblErrorUsuario.Size = new System.Drawing.Size(136, 13);
            this.lblErrorUsuario.TabIndex = 9;
            this.lblErrorUsuario.Text = "Usuario no encontrado";
            this.lblErrorUsuario.Visible = false;
            // 
            // lblErrorContraseña
            // 
            this.lblErrorContraseña.AutoSize = true;
            this.lblErrorContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorContraseña.ForeColor = System.Drawing.Color.Red;
            this.lblErrorContraseña.Location = new System.Drawing.Point(241, 219);
            this.lblErrorContraseña.Name = "lblErrorContraseña";
            this.lblErrorContraseña.Size = new System.Drawing.Size(132, 13);
            this.lblErrorContraseña.TabIndex = 9;
            this.lblErrorContraseña.Text = "Contraseña incorrecta";
            this.lblErrorContraseña.Visible = false;
            // 
            // lblConexion
            // 
            this.lblConexion.AutoSize = true;
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConexion.Location = new System.Drawing.Point(159, 358);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(104, 13);
            this.lblConexion.TabIndex = 9;
            this.lblConexion.Text = "Conexión Exitosa";
            this.lblConexion.Visible = false;
            // 
            // VistaSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 408);
            this.Controls.Add(this.lblErrorContraseña);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.lblErrorUsuario);
            this.Controls.Add(this.lnkDerechos);
            this.Controls.Add(this.lnkRegistro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lnkContraseña);
            this.Controls.Add(this.chkRecuerdame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VistaSesion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesión";
            this.Load += new System.EventHandler(this.VistaSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRecuerdame;
        private System.Windows.Forms.LinkLabel lnkContraseña;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lnkRegistro;
        private System.Windows.Forms.LinkLabel lnkDerechos;
        private System.Windows.Forms.Label lblErrorUsuario;
        private System.Windows.Forms.Label lblErrorContraseña;
        public System.Windows.Forms.Label lblConexion;
    }
}


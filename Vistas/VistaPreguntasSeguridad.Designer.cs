namespace ControlInventario.Vistas
{
    partial class VistaPreguntasSeguridad
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
            this.CmbPregunta1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRespuesta1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRespuesta2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbPregunta2 = new System.Windows.Forms.ComboBox();
            this.CmbPregunta3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtRespuesta3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblIdusuario = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbPregunta1
            // 
            this.CmbPregunta1.FormattingEnabled = true;
            this.CmbPregunta1.Items.AddRange(new object[] {
            "¿Cuál es el nombre de tu primera mascota?",
            "¿De que provincia son tus raíces?",
            "Acontecimiento memorable de la escuela",
            "Momento importante de la infancia",
            "Reconocimiento académico más importante"});
            this.CmbPregunta1.Location = new System.Drawing.Point(12, 63);
            this.CmbPregunta1.Name = "CmbPregunta1";
            this.CmbPregunta1.Size = new System.Drawing.Size(295, 21);
            this.CmbPregunta1.TabIndex = 1;
            this.CmbPregunta1.Text = "SELECCIONE";
            this.CmbPregunta1.SelectedIndexChanged += new System.EventHandler(this.CmbPregunta1_SelectedIndexChanged);
            this.CmbPregunta1.TabIndexChanged += new System.EventHandler(this.CmbPregunta1_SelectedIndexChanged);
            this.CmbPregunta1.TextChanged += new System.EventHandler(this.CmbPregunta1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pregunta 1:";
            // 
            // TxtRespuesta1
            // 
            this.TxtRespuesta1.Enabled = false;
            this.TxtRespuesta1.Location = new System.Drawing.Point(12, 115);
            this.TxtRespuesta1.Name = "TxtRespuesta1";
            this.TxtRespuesta1.Size = new System.Drawing.Size(295, 20);
            this.TxtRespuesta1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Respuesta 1:";
            // 
            // TxtRespuesta2
            // 
            this.TxtRespuesta2.Enabled = false;
            this.TxtRespuesta2.Location = new System.Drawing.Point(12, 223);
            this.TxtRespuesta2.Name = "TxtRespuesta2";
            this.TxtRespuesta2.Size = new System.Drawing.Size(295, 20);
            this.TxtRespuesta2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Respuesta 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pregunta 2:";
            // 
            // CmbPregunta2
            // 
            this.CmbPregunta2.FormattingEnabled = true;
            this.CmbPregunta2.Items.AddRange(new object[] {
            "¿Cuál es el nombre de tu primera mascota?",
            "¿De que provincia son tus raíces?",
            "Acontecimiento memorable de la escuela",
            "Momento importante de la infancia",
            "Reconocimiento académico más importante"});
            this.CmbPregunta2.Location = new System.Drawing.Point(12, 171);
            this.CmbPregunta2.Name = "CmbPregunta2";
            this.CmbPregunta2.Size = new System.Drawing.Size(295, 21);
            this.CmbPregunta2.TabIndex = 3;
            this.CmbPregunta2.Text = "SELECCIONE";
            this.CmbPregunta2.SelectedIndexChanged += new System.EventHandler(this.CmbPregunta2_SelectedIndexChanged);
            this.CmbPregunta2.TabIndexChanged += new System.EventHandler(this.CmbPregunta2_SelectedIndexChanged);
            this.CmbPregunta2.TextChanged += new System.EventHandler(this.CmbPregunta1_TextChanged);
            // 
            // CmbPregunta3
            // 
            this.CmbPregunta3.FormattingEnabled = true;
            this.CmbPregunta3.Items.AddRange(new object[] {
            "¿Cuál es el nombre de tu primera mascota?",
            "¿De que provincia son tus raíces?",
            "Acontecimiento memorable de la escuela",
            "Momento importante de la infancia",
            "Reconocimiento académico más importante"});
            this.CmbPregunta3.Location = new System.Drawing.Point(12, 283);
            this.CmbPregunta3.Name = "CmbPregunta3";
            this.CmbPregunta3.Size = new System.Drawing.Size(295, 21);
            this.CmbPregunta3.TabIndex = 5;
            this.CmbPregunta3.Text = "SELECCIONE";
            this.CmbPregunta3.SelectedIndexChanged += new System.EventHandler(this.CmbPregunta3_SelectedIndexChanged);
            this.CmbPregunta3.TabIndexChanged += new System.EventHandler(this.CmbPregunta3_SelectedIndexChanged);
            this.CmbPregunta3.TextChanged += new System.EventHandler(this.CmbPregunta1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pregunta 3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Respuesta 3:";
            // 
            // TxtRespuesta3
            // 
            this.TxtRespuesta3.Enabled = false;
            this.TxtRespuesta3.Location = new System.Drawing.Point(12, 335);
            this.TxtRespuesta3.Name = "TxtRespuesta3";
            this.TxtRespuesta3.Size = new System.Drawing.Size(295, 20);
            this.TxtRespuesta3.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(283, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Preguntas de recuperación de contraseña";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(122, 361);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblIdusuario
            // 
            this.lblIdusuario.AutoSize = true;
            this.lblIdusuario.Location = new System.Drawing.Point(17, 366);
            this.lblIdusuario.Name = "lblIdusuario";
            this.lblIdusuario.Size = new System.Drawing.Size(52, 13);
            this.lblIdusuario.TabIndex = 9;
            this.lblIdusuario.Text = "IdUsuario";
            this.lblIdusuario.Visible = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(249, 366);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // VistaPreguntasSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 392);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblIdusuario);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtRespuesta3);
            this.Controls.Add(this.TxtRespuesta2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbPregunta3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbPregunta2);
            this.Controls.Add(this.TxtRespuesta1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbPregunta1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaPreguntasSeguridad";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VistaPreguntasSeguridad_FormClosing);
            this.Load += new System.EventHandler(this.VistaPreguntasSeguridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbPregunta1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRespuesta1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRespuesta2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbPregunta2;
        private System.Windows.Forms.ComboBox CmbPregunta3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtRespuesta3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblIdusuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
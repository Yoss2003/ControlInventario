namespace ControlInventario.Vistas.Extras
{
    partial class VistaRutaExportacion
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
            this.GpRutas = new System.Windows.Forms.GroupBox();
            this.BtnBuscarRutaPerso = new System.Windows.Forms.Button();
            this.BtnBuscarRutaPred = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.ChkRutaPredeterminada = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRutaPersonalizada = new System.Windows.Forms.TextBox();
            this.TxtRutaPredeterminada = new System.Windows.Forms.TextBox();
            this.LblRutaArchivo = new System.Windows.Forms.Label();
            this.GpRutas.SuspendLayout();
            this.SuspendLayout();
            // 
            // GpRutas
            // 
            this.GpRutas.Controls.Add(this.BtnBuscarRutaPerso);
            this.GpRutas.Controls.Add(this.BtnBuscarRutaPred);
            this.GpRutas.Controls.Add(this.BtnExportar);
            this.GpRutas.Controls.Add(this.ChkRutaPredeterminada);
            this.GpRutas.Controls.Add(this.label3);
            this.GpRutas.Controls.Add(this.label2);
            this.GpRutas.Controls.Add(this.TxtRutaPersonalizada);
            this.GpRutas.Controls.Add(this.TxtRutaPredeterminada);
            this.GpRutas.Controls.Add(this.LblRutaArchivo);
            this.GpRutas.Location = new System.Drawing.Point(12, 12);
            this.GpRutas.Name = "GpRutas";
            this.GpRutas.Size = new System.Drawing.Size(425, 166);
            this.GpRutas.TabIndex = 0;
            this.GpRutas.TabStop = false;
            // 
            // BtnBuscarRutaPerso
            // 
            this.BtnBuscarRutaPerso.Location = new System.Drawing.Point(391, 106);
            this.BtnBuscarRutaPerso.Name = "BtnBuscarRutaPerso";
            this.BtnBuscarRutaPerso.Size = new System.Drawing.Size(28, 23);
            this.BtnBuscarRutaPerso.TabIndex = 13;
            this.BtnBuscarRutaPerso.Text = "...";
            this.BtnBuscarRutaPerso.UseVisualStyleBackColor = true;
            this.BtnBuscarRutaPerso.Click += new System.EventHandler(this.BtnBuscarRutaPerso_Click);
            // 
            // BtnBuscarRutaPred
            // 
            this.BtnBuscarRutaPred.Enabled = false;
            this.BtnBuscarRutaPred.Location = new System.Drawing.Point(391, 51);
            this.BtnBuscarRutaPred.Name = "BtnBuscarRutaPred";
            this.BtnBuscarRutaPred.Size = new System.Drawing.Size(28, 23);
            this.BtnBuscarRutaPred.TabIndex = 14;
            this.BtnBuscarRutaPred.Text = "...";
            this.BtnBuscarRutaPred.UseVisualStyleBackColor = true;
            this.BtnBuscarRutaPred.Click += new System.EventHandler(this.BtnBuscarRutaPred_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Location = new System.Drawing.Point(169, 134);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(75, 23);
            this.BtnExportar.TabIndex = 15;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // ChkRutaPredeterminada
            // 
            this.ChkRutaPredeterminada.AutoSize = true;
            this.ChkRutaPredeterminada.Location = new System.Drawing.Point(404, 15);
            this.ChkRutaPredeterminada.Name = "ChkRutaPredeterminada";
            this.ChkRutaPredeterminada.Size = new System.Drawing.Size(15, 14);
            this.ChkRutaPredeterminada.TabIndex = 12;
            this.ChkRutaPredeterminada.UseVisualStyleBackColor = true;
            this.ChkRutaPredeterminada.CheckedChanged += new System.EventHandler(this.ChkRutaPredeterminada_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ruta personalizada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ruta predeterminada";
            // 
            // TxtRutaPersonalizada
            // 
            this.TxtRutaPersonalizada.Location = new System.Drawing.Point(6, 106);
            this.TxtRutaPersonalizada.Name = "TxtRutaPersonalizada";
            this.TxtRutaPersonalizada.Size = new System.Drawing.Size(379, 20);
            this.TxtRutaPersonalizada.TabIndex = 9;
            // 
            // TxtRutaPredeterminada
            // 
            this.TxtRutaPredeterminada.Enabled = false;
            this.TxtRutaPredeterminada.Location = new System.Drawing.Point(6, 53);
            this.TxtRutaPredeterminada.Name = "TxtRutaPredeterminada";
            this.TxtRutaPredeterminada.Size = new System.Drawing.Size(379, 20);
            this.TxtRutaPredeterminada.TabIndex = 8;
            // 
            // LblRutaArchivo
            // 
            this.LblRutaArchivo.AutoSize = true;
            this.LblRutaArchivo.Location = new System.Drawing.Point(189, 16);
            this.LblRutaArchivo.Name = "LblRutaArchivo";
            this.LblRutaArchivo.Size = new System.Drawing.Size(35, 13);
            this.LblRutaArchivo.TabIndex = 7;
            this.LblRutaArchivo.Text = "label1";
            // 
            // VistaRutaExportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 190);
            this.Controls.Add(this.GpRutas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaRutaExportacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.Load += new System.EventHandler(this.VistaRutaExportacion_Load);
            this.GpRutas.ResumeLayout(false);
            this.GpRutas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GpRutas;
        private System.Windows.Forms.Button BtnBuscarRutaPerso;
        private System.Windows.Forms.Button BtnBuscarRutaPred;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.CheckBox ChkRutaPredeterminada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRutaPersonalizada;
        private System.Windows.Forms.TextBox TxtRutaPredeterminada;
        public System.Windows.Forms.Label LblRutaArchivo;
    }
}
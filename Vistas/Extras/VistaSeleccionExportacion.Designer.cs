namespace ControlInventario.Vistas.Extras
{
    partial class VistaSeleccionExportacion
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.rbCuentas = new System.Windows.Forms.RadioButton();
            this.rbSalidas = new System.Windows.Forms.RadioButton();
            this.rbTodoInventario = new System.Windows.Forms.RadioButton();
            this.cbTipoSalida = new System.Windows.Forms.ComboBox();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.rbCategoria = new System.Windows.Forms.RadioButton();
            this.grpOpciones = new System.Windows.Forms.GroupBox();
            this.grpOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(204, 276);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 35);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(98, 276);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(100, 35);
            this.BtnAceptar.TabIndex = 1;
            this.BtnAceptar.Text = "Continuar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // rbCuentas
            // 
            this.rbCuentas.AutoSize = true;
            this.rbCuentas.Location = new System.Drawing.Point(18, 240);
            this.rbCuentas.Name = "rbCuentas";
            this.rbCuentas.Size = new System.Drawing.Size(392, 24);
            this.rbCuentas.TabIndex = 2;
            this.rbCuentas.TabStop = true;
            this.rbCuentas.Text = "Cuentas por cobrar (cuotas pendientes y vencidas)";
            this.rbCuentas.UseVisualStyleBackColor = true;
            this.rbCuentas.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // rbSalidas
            // 
            this.rbSalidas.AutoSize = true;
            this.rbSalidas.Location = new System.Drawing.Point(18, 168);
            this.rbSalidas.Name = "rbSalidas";
            this.rbSalidas.Size = new System.Drawing.Size(90, 24);
            this.rbSalidas.TabIndex = 2;
            this.rbSalidas.TabStop = true;
            this.rbSalidas.Text = "Salidas:";
            this.rbSalidas.UseVisualStyleBackColor = true;
            this.rbSalidas.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // rbTodoInventario
            // 
            this.rbTodoInventario.AutoSize = true;
            this.rbTodoInventario.Location = new System.Drawing.Point(18, 112);
            this.rbTodoInventario.Name = "rbTodoInventario";
            this.rbTodoInventario.Size = new System.Drawing.Size(314, 24);
            this.rbTodoInventario.TabIndex = 2;
            this.rbTodoInventario.TabStop = true;
            this.rbTodoInventario.Text = "Todo el inventario (artículos disponibles)";
            this.rbTodoInventario.UseVisualStyleBackColor = true;
            this.rbTodoInventario.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // cbTipoSalida
            // 
            this.cbTipoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoSalida.Enabled = false;
            this.cbTipoSalida.FormattingEnabled = true;
            this.cbTipoSalida.Location = new System.Drawing.Point(18, 198);
            this.cbTipoSalida.Name = "cbTipoSalida";
            this.cbTipoSalida.Size = new System.Drawing.Size(340, 28);
            this.cbTipoSalida.TabIndex = 1;
            // 
            // cbCategorias
            // 
            this.cbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(18, 70);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(340, 28);
            this.cbCategorias.TabIndex = 1;
            // 
            // rbCategoria
            // 
            this.rbCategoria.AutoSize = true;
            this.rbCategoria.Checked = true;
            this.rbCategoria.Location = new System.Drawing.Point(18, 40);
            this.rbCategoria.Name = "rbCategoria";
            this.rbCategoria.Size = new System.Drawing.Size(205, 24);
            this.rbCategoria.TabIndex = 0;
            this.rbCategoria.TabStop = true;
            this.rbCategoria.Text = "Inventario por categoría:";
            this.rbCategoria.UseVisualStyleBackColor = true;
            this.rbCategoria.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // grpOpciones
            // 
            this.grpOpciones.Controls.Add(this.BtnCancelar);
            this.grpOpciones.Controls.Add(this.BtnAceptar);
            this.grpOpciones.Controls.Add(this.rbCuentas);
            this.grpOpciones.Controls.Add(this.rbSalidas);
            this.grpOpciones.Controls.Add(this.rbTodoInventario);
            this.grpOpciones.Controls.Add(this.cbTipoSalida);
            this.grpOpciones.Controls.Add(this.cbCategorias);
            this.grpOpciones.Controls.Add(this.rbCategoria);
            this.grpOpciones.Location = new System.Drawing.Point(12, 12);
            this.grpOpciones.Name = "grpOpciones";
            this.grpOpciones.Size = new System.Drawing.Size(411, 327);
            this.grpOpciones.TabIndex = 1;
            this.grpOpciones.TabStop = false;
            this.grpOpciones.Text = "Seleccione los datos a exportar";
            // 
            // VistaSeleccionExportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 349);
            this.Controls.Add(this.grpOpciones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaSeleccionExportacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¿Qué desea exportar?";
            this.Load += new System.EventHandler(this.VistaSeleccionExportacion_Load);
            this.grpOpciones.ResumeLayout(false);
            this.grpOpciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.RadioButton rbCuentas;
        private System.Windows.Forms.RadioButton rbSalidas;
        private System.Windows.Forms.RadioButton rbTodoInventario;
        private System.Windows.Forms.ComboBox cbTipoSalida;
        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.RadioButton rbCategoria;
        private System.Windows.Forms.GroupBox grpOpciones;
    }
}
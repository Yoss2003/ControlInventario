namespace ControlInventario.Vistas
{
    partial class VistaMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaMenuPrincipal));
            this.groupInicio = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.groupAcciones = new System.Windows.Forms.GroupBox();
            this.lblTextoRandom = new System.Windows.Forms.Label();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnRegistros = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.NotificacionesWindows = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupInicio.SuspendLayout();
            this.groupAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInicio
            // 
            this.groupInicio.Controls.Add(this.lblUsuario);
            this.groupInicio.Controls.Add(this.lblFecha);
            this.groupInicio.Controls.Add(this.lblRol);
            this.groupInicio.Controls.Add(this.lblBienvenida);
            resources.ApplyResources(this.groupInicio, "groupInicio");
            this.groupInicio.Name = "groupInicio";
            this.groupInicio.TabStop = false;
            // 
            // lblUsuario
            // 
            resources.ApplyResources(this.lblUsuario, "lblUsuario");
            this.lblUsuario.Name = "lblUsuario";
            // 
            // lblFecha
            // 
            resources.ApplyResources(this.lblFecha, "lblFecha");
            this.lblFecha.Name = "lblFecha";
            // 
            // lblRol
            // 
            resources.ApplyResources(this.lblRol, "lblRol");
            this.lblRol.Name = "lblRol";
            // 
            // lblBienvenida
            // 
            resources.ApplyResources(this.lblBienvenida, "lblBienvenida");
            this.lblBienvenida.Name = "lblBienvenida";
            // 
            // groupAcciones
            // 
            this.groupAcciones.Controls.Add(this.lblTextoRandom);
            this.groupAcciones.Controls.Add(this.btnConfiguracion);
            this.groupAcciones.Controls.Add(this.btnRegistros);
            this.groupAcciones.Controls.Add(this.btnCerrarSesion);
            this.groupAcciones.Controls.Add(this.btnReportes);
            this.groupAcciones.Controls.Add(this.btnInventario);
            resources.ApplyResources(this.groupAcciones, "groupAcciones");
            this.groupAcciones.Name = "groupAcciones";
            this.groupAcciones.TabStop = false;
            // 
            // lblTextoRandom
            // 
            resources.ApplyResources(this.lblTextoRandom, "lblTextoRandom");
            this.lblTextoRandom.Name = "lblTextoRandom";
            // 
            // btnConfiguracion
            // 
            resources.ApplyResources(this.btnConfiguracion, "btnConfiguracion");
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnRegistros
            // 
            resources.ApplyResources(this.btnRegistros, "btnRegistros");
            this.btnRegistros.Name = "btnRegistros";
            this.btnRegistros.UseVisualStyleBackColor = true;
            this.btnRegistros.Click += new System.EventHandler(this.btnRegistros_Click);
            // 
            // btnCerrarSesion
            // 
            resources.ApplyResources(this.btnCerrarSesion, "btnCerrarSesion");
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnReportes
            // 
            resources.ApplyResources(this.btnReportes, "btnReportes");
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnInventario
            // 
            resources.ApplyResources(this.btnInventario, "btnInventario");
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // NotificacionesWindows
            // 
            resources.ApplyResources(this.NotificacionesWindows, "NotificacionesWindows");
            // 
            // VistaMenuPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupAcciones);
            this.Controls.Add(this.groupInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaMenuPrincipal";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.VistaInicio_Load);
            this.groupInicio.ResumeLayout(false);
            this.groupInicio.PerformLayout();
            this.groupAcciones.ResumeLayout(false);
            this.groupAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInicio;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.GroupBox groupAcciones;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnRegistros;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblTextoRandom;
        private System.Windows.Forms.NotifyIcon NotificacionesWindows;
    }
}
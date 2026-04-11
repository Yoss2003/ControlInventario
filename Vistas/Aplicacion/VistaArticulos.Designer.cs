namespace ControlInventario.Vistas
{
    partial class VistaArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaArticulos));
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.CbMarcas = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkAutoModelo = new System.Windows.Forms.CheckBox();
            this.ChkAutoSerie = new System.Windows.Forms.CheckBox();
            this.ChkAutoCodigo = new System.Windows.Forms.CheckBox();
            this.ChkFechaGarantia = new System.Windows.Forms.CheckBox();
            this.BtnAgregarMarca = new System.Windows.Forms.Button();
            this.DtpFechaFinGarantia = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaAdquisicion = new System.Windows.Forms.DateTimePicker();
            this.LblMarca = new System.Windows.Forms.Label();
            this.LblSerie = new System.Windows.Forms.Label();
            this.LblModelo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.TxtSerie = new System.Windows.Forms.TextBox();
            this.TxtModelo = new System.Windows.Forms.TextBox();
            this.GpUsos = new System.Windows.Forms.GroupBox();
            this.CbUbicacion = new System.Windows.Forms.ComboBox();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.BtnAgregarEstado = new System.Windows.Forms.Button();
            this.BtnAgregarCondicion = new System.Windows.Forms.Button();
            this.BtnAgregarUbicacion = new System.Windows.Forms.Button();
            this.LblUbicacion = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LblCondicion = new System.Windows.Forms.Label();
            this.LblEstado = new System.Windows.Forms.Label();
            this.CbCondicion = new System.Windows.Forms.ComboBox();
            this.CbEstadoArticulo = new System.Windows.Forms.ComboBox();
            this.GpInformación = new System.Windows.Forms.GroupBox();
            this.TabMultipedia = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PbFotoArticulo = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelComprobante = new System.Windows.Forms.Panel();
            this.BtnAgregarComprobante = new System.Windows.Forms.Button();
            this.BtnAgregarImagen = new System.Windows.Forms.Button();
            this.TxtRutaComprobante = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TxtDireccionImagen = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.ErrorArticulos = new System.Windows.Forms.ErrorProvider(this.components);
            this.GpAcciones = new System.Windows.Forms.GroupBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardarPlus = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEmpleados = new System.Windows.Forms.Button();
            this.GpAdquisicion = new System.Windows.Forms.GroupBox();
            this.TxtRazonSocial = new System.Windows.Forms.TextBox();
            this.LblRazonSocial = new System.Windows.Forms.Label();
            this.BtnDepreciacion = new System.Windows.Forms.Button();
            this.BtnAgregarRUC = new System.Windows.Forms.Button();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.TxtRuc = new System.Windows.Forms.TextBox();
            this.LblRuc = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GrpRegistroMasivo = new System.Windows.Forms.GroupBox();
            this.ChkActivarDatosMasivos = new System.Windows.Forms.CheckBox();
            this.CbGrupoRegistro = new System.Windows.Forms.ComboBox();
            this.BtnAgregarGrupo = new System.Windows.Forms.Button();
            this.CbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.NumCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.GpUsos.SuspendLayout();
            this.GpInformación.SuspendLayout();
            this.TabMultipedia.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoArticulo)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorArticulos)).BeginInit();
            this.GpAcciones.SuspendLayout();
            this.GpAdquisicion.SuspendLayout();
            this.GrpRegistroMasivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorArticulos.SetIconPadding(this.TxtCodigo, ((int)(resources.GetObject("TxtCodigo.IconPadding"))));
            resources.ApplyResources(this.TxtCodigo, "TxtCodigo");
            this.TxtCodigo.Name = "TxtCodigo";
            // 
            // CbMarcas
            // 
            this.CbMarcas.FormattingEnabled = true;
            this.ErrorArticulos.SetIconAlignment(this.CbMarcas, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("CbMarcas.IconAlignment"))));
            resources.ApplyResources(this.CbMarcas, "CbMarcas");
            this.CbMarcas.Name = "CbMarcas";
            this.CbMarcas.TextUpdate += new System.EventHandler(this.CbMarcas_TextUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkAutoModelo);
            this.groupBox1.Controls.Add(this.ChkAutoSerie);
            this.groupBox1.Controls.Add(this.ChkAutoCodigo);
            this.groupBox1.Controls.Add(this.ChkFechaGarantia);
            this.groupBox1.Controls.Add(this.BtnAgregarMarca);
            this.groupBox1.Controls.Add(this.DtpFechaFinGarantia);
            this.groupBox1.Controls.Add(this.DtpFechaAdquisicion);
            this.groupBox1.Controls.Add(this.LblMarca);
            this.groupBox1.Controls.Add(this.LblSerie);
            this.groupBox1.Controls.Add(this.LblModelo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LblCodigo);
            this.groupBox1.Controls.Add(this.CbMarcas);
            this.groupBox1.Controls.Add(this.TxtSerie);
            this.groupBox1.Controls.Add(this.TxtModelo);
            this.groupBox1.Controls.Add(this.TxtCodigo);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ChkAutoModelo
            // 
            resources.ApplyResources(this.ChkAutoModelo, "ChkAutoModelo");
            this.ChkAutoModelo.Name = "ChkAutoModelo";
            this.ChkAutoModelo.UseVisualStyleBackColor = true;
            this.ChkAutoModelo.CheckedChanged += new System.EventHandler(this.ChkAutoModelo_CheckedChanged);
            // 
            // ChkAutoSerie
            // 
            resources.ApplyResources(this.ChkAutoSerie, "ChkAutoSerie");
            this.ChkAutoSerie.Name = "ChkAutoSerie";
            this.ChkAutoSerie.UseVisualStyleBackColor = true;
            this.ChkAutoSerie.CheckedChanged += new System.EventHandler(this.ChkAutoSerie_CheckedChanged);
            // 
            // ChkAutoCodigo
            // 
            resources.ApplyResources(this.ChkAutoCodigo, "ChkAutoCodigo");
            this.ChkAutoCodigo.Name = "ChkAutoCodigo";
            this.ChkAutoCodigo.UseVisualStyleBackColor = true;
            this.ChkAutoCodigo.CheckedChanged += new System.EventHandler(this.ChkAuto_CheckedChanged);
            // 
            // ChkFechaGarantia
            // 
            resources.ApplyResources(this.ChkFechaGarantia, "ChkFechaGarantia");
            this.ChkFechaGarantia.Name = "ChkFechaGarantia";
            this.ChkFechaGarantia.UseVisualStyleBackColor = true;
            this.ChkFechaGarantia.CheckedChanged += new System.EventHandler(this.ChkFechaGarantia_CheckedChanged);
            // 
            // BtnAgregarMarca
            // 
            this.ErrorArticulos.SetIconAlignment(this.BtnAgregarMarca, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("BtnAgregarMarca.IconAlignment"))));
            resources.ApplyResources(this.BtnAgregarMarca, "BtnAgregarMarca");
            this.BtnAgregarMarca.Name = "BtnAgregarMarca";
            this.BtnAgregarMarca.UseVisualStyleBackColor = true;
            this.BtnAgregarMarca.Click += new System.EventHandler(this.BtnAgregarMarca_Click);
            // 
            // DtpFechaFinGarantia
            // 
            resources.ApplyResources(this.DtpFechaFinGarantia, "DtpFechaFinGarantia");
            this.DtpFechaFinGarantia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFinGarantia.Name = "DtpFechaFinGarantia";
            // 
            // DtpFechaAdquisicion
            // 
            this.DtpFechaAdquisicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ErrorArticulos.SetIconPadding(this.DtpFechaAdquisicion, ((int)(resources.GetObject("DtpFechaAdquisicion.IconPadding"))));
            resources.ApplyResources(this.DtpFechaAdquisicion, "DtpFechaAdquisicion");
            this.DtpFechaAdquisicion.Name = "DtpFechaAdquisicion";
            // 
            // LblMarca
            // 
            resources.ApplyResources(this.LblMarca, "LblMarca");
            this.LblMarca.Name = "LblMarca";
            // 
            // LblSerie
            // 
            resources.ApplyResources(this.LblSerie, "LblSerie");
            this.LblSerie.Name = "LblSerie";
            // 
            // LblModelo
            // 
            resources.ApplyResources(this.LblModelo, "LblModelo");
            this.LblModelo.Name = "LblModelo";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // LblCodigo
            // 
            resources.ApplyResources(this.LblCodigo, "LblCodigo");
            this.LblCodigo.Name = "LblCodigo";
            // 
            // TxtSerie
            // 
            this.TxtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorArticulos.SetIconPadding(this.TxtSerie, ((int)(resources.GetObject("TxtSerie.IconPadding"))));
            resources.ApplyResources(this.TxtSerie, "TxtSerie");
            this.TxtSerie.Name = "TxtSerie";
            // 
            // TxtModelo
            // 
            this.TxtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorArticulos.SetIconPadding(this.TxtModelo, ((int)(resources.GetObject("TxtModelo.IconPadding"))));
            resources.ApplyResources(this.TxtModelo, "TxtModelo");
            this.TxtModelo.Name = "TxtModelo";
            this.TxtModelo.Leave += new System.EventHandler(this.TxtModelo_Leave);
            // 
            // GpUsos
            // 
            this.GpUsos.Controls.Add(this.CbUbicacion);
            this.GpUsos.Controls.Add(this.TxtObservaciones);
            this.GpUsos.Controls.Add(this.BtnAgregarEstado);
            this.GpUsos.Controls.Add(this.BtnAgregarCondicion);
            this.GpUsos.Controls.Add(this.BtnAgregarUbicacion);
            this.GpUsos.Controls.Add(this.LblUbicacion);
            this.GpUsos.Controls.Add(this.label20);
            this.GpUsos.Controls.Add(this.LblCondicion);
            this.GpUsos.Controls.Add(this.LblEstado);
            this.GpUsos.Controls.Add(this.CbCondicion);
            this.GpUsos.Controls.Add(this.CbEstadoArticulo);
            this.ErrorArticulos.SetIconPadding(this.GpUsos, ((int)(resources.GetObject("GpUsos.IconPadding"))));
            resources.ApplyResources(this.GpUsos, "GpUsos");
            this.GpUsos.Name = "GpUsos";
            this.GpUsos.TabStop = false;
            // 
            // CbUbicacion
            // 
            this.CbUbicacion.FormattingEnabled = true;
            this.ErrorArticulos.SetIconPadding(this.CbUbicacion, ((int)(resources.GetObject("CbUbicacion.IconPadding"))));
            resources.ApplyResources(this.CbUbicacion, "CbUbicacion");
            this.CbUbicacion.Name = "CbUbicacion";
            this.CbUbicacion.TextUpdate += new System.EventHandler(this.CbUbicacion_TextUpdate);
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TxtObservaciones, "TxtObservaciones");
            this.TxtObservaciones.Name = "TxtObservaciones";
            // 
            // BtnAgregarEstado
            // 
            resources.ApplyResources(this.BtnAgregarEstado, "BtnAgregarEstado");
            this.BtnAgregarEstado.Name = "BtnAgregarEstado";
            this.BtnAgregarEstado.UseVisualStyleBackColor = true;
            this.BtnAgregarEstado.Click += new System.EventHandler(this.BtnAgregarEstado_Click);
            // 
            // BtnAgregarCondicion
            // 
            resources.ApplyResources(this.BtnAgregarCondicion, "BtnAgregarCondicion");
            this.BtnAgregarCondicion.Name = "BtnAgregarCondicion";
            this.BtnAgregarCondicion.UseVisualStyleBackColor = true;
            this.BtnAgregarCondicion.Click += new System.EventHandler(this.BtnAgregarCondicion_Click);
            // 
            // BtnAgregarUbicacion
            // 
            resources.ApplyResources(this.BtnAgregarUbicacion, "BtnAgregarUbicacion");
            this.BtnAgregarUbicacion.Name = "BtnAgregarUbicacion";
            this.BtnAgregarUbicacion.UseVisualStyleBackColor = true;
            this.BtnAgregarUbicacion.Click += new System.EventHandler(this.BtnAgregarUbicacion_Click);
            // 
            // LblUbicacion
            // 
            resources.ApplyResources(this.LblUbicacion, "LblUbicacion");
            this.LblUbicacion.Name = "LblUbicacion";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // LblCondicion
            // 
            resources.ApplyResources(this.LblCondicion, "LblCondicion");
            this.LblCondicion.Name = "LblCondicion";
            // 
            // LblEstado
            // 
            resources.ApplyResources(this.LblEstado, "LblEstado");
            this.LblEstado.Name = "LblEstado";
            // 
            // CbCondicion
            // 
            this.CbCondicion.FormattingEnabled = true;
            this.ErrorArticulos.SetIconPadding(this.CbCondicion, ((int)(resources.GetObject("CbCondicion.IconPadding"))));
            resources.ApplyResources(this.CbCondicion, "CbCondicion");
            this.CbCondicion.Name = "CbCondicion";
            this.CbCondicion.TextUpdate += new System.EventHandler(this.CbCondicion_TextUpdate);
            // 
            // CbEstadoArticulo
            // 
            this.CbEstadoArticulo.FormattingEnabled = true;
            this.ErrorArticulos.SetIconPadding(this.CbEstadoArticulo, ((int)(resources.GetObject("CbEstadoArticulo.IconPadding"))));
            resources.ApplyResources(this.CbEstadoArticulo, "CbEstadoArticulo");
            this.CbEstadoArticulo.Name = "CbEstadoArticulo";
            this.CbEstadoArticulo.TextUpdate += new System.EventHandler(this.CbEstadoArticulo_TextUpdate);
            // 
            // GpInformación
            // 
            this.GpInformación.Controls.Add(this.TabMultipedia);
            this.GpInformación.Controls.Add(this.BtnAgregarComprobante);
            this.GpInformación.Controls.Add(this.BtnAgregarImagen);
            this.GpInformación.Controls.Add(this.TxtRutaComprobante);
            this.GpInformación.Controls.Add(this.label26);
            this.GpInformación.Controls.Add(this.TxtDireccionImagen);
            this.GpInformación.Controls.Add(this.label23);
            resources.ApplyResources(this.GpInformación, "GpInformación");
            this.GpInformación.Name = "GpInformación";
            this.GpInformación.TabStop = false;
            // 
            // TabMultipedia
            // 
            this.TabMultipedia.Controls.Add(this.tabPage1);
            this.TabMultipedia.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.TabMultipedia, "TabMultipedia");
            this.TabMultipedia.Name = "TabMultipedia";
            this.TabMultipedia.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PbFotoArticulo);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PbFotoArticulo
            // 
            resources.ApplyResources(this.PbFotoArticulo, "PbFotoArticulo");
            this.PbFotoArticulo.Name = "PbFotoArticulo";
            this.PbFotoArticulo.TabStop = false;
            this.PbFotoArticulo.Tag = "ImagenArticulo";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelComprobante);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PanelComprobante
            // 
            resources.ApplyResources(this.PanelComprobante, "PanelComprobante");
            this.PanelComprobante.Name = "PanelComprobante";
            // 
            // BtnAgregarComprobante
            // 
            this.BtnAgregarComprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnAgregarComprobante, "BtnAgregarComprobante");
            this.BtnAgregarComprobante.Name = "BtnAgregarComprobante";
            this.BtnAgregarComprobante.UseVisualStyleBackColor = true;
            this.BtnAgregarComprobante.Click += new System.EventHandler(this.BtnAgregarComprobante_Click);
            // 
            // BtnAgregarImagen
            // 
            this.BtnAgregarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnAgregarImagen, "BtnAgregarImagen");
            this.BtnAgregarImagen.Name = "BtnAgregarImagen";
            this.BtnAgregarImagen.UseVisualStyleBackColor = true;
            this.BtnAgregarImagen.Click += new System.EventHandler(this.BtnAgregarImagen_Click);
            // 
            // TxtRutaComprobante
            // 
            resources.ApplyResources(this.TxtRutaComprobante, "TxtRutaComprobante");
            this.ErrorArticulos.SetIconPadding(this.TxtRutaComprobante, ((int)(resources.GetObject("TxtRutaComprobante.IconPadding"))));
            this.TxtRutaComprobante.Name = "TxtRutaComprobante";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // TxtDireccionImagen
            // 
            resources.ApplyResources(this.TxtDireccionImagen, "TxtDireccionImagen");
            this.ErrorArticulos.SetIconPadding(this.TxtDireccionImagen, ((int)(resources.GetObject("TxtDireccionImagen.IconPadding"))));
            this.TxtDireccionImagen.Name = "TxtDireccionImagen";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // ErrorArticulos
            // 
            this.ErrorArticulos.ContainerControl = this;
            // 
            // GpAcciones
            // 
            this.GpAcciones.Controls.Add(this.btnAgregar);
            this.GpAcciones.Controls.Add(this.BtnCancelar);
            this.GpAcciones.Controls.Add(this.BtnGuardarPlus);
            this.GpAcciones.Controls.Add(this.BtnGuardar);
            this.GpAcciones.Controls.Add(this.BtnEmpleados);
            resources.ApplyResources(this.GpAcciones, "GpAcciones");
            this.GpAcciones.Name = "GpAcciones";
            this.GpAcciones.TabStop = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnCancelar, "BtnCancelar");
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardarPlus
            // 
            this.BtnGuardarPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnGuardarPlus, "BtnGuardarPlus");
            this.BtnGuardarPlus.Name = "BtnGuardarPlus";
            this.BtnGuardarPlus.UseVisualStyleBackColor = true;
            this.BtnGuardarPlus.Click += new System.EventHandler(this.BtnGuardarPlus_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnGuardar, "BtnGuardar");
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEmpleados
            // 
            this.BtnEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnEmpleados, "BtnEmpleados");
            this.BtnEmpleados.Name = "BtnEmpleados";
            this.BtnEmpleados.UseVisualStyleBackColor = true;
            this.BtnEmpleados.Click += new System.EventHandler(this.BtnEmpleados_Click);
            // 
            // GpAdquisicion
            // 
            this.GpAdquisicion.Controls.Add(this.TxtRazonSocial);
            this.GpAdquisicion.Controls.Add(this.LblRazonSocial);
            this.GpAdquisicion.Controls.Add(this.BtnDepreciacion);
            this.GpAdquisicion.Controls.Add(this.BtnAgregarRUC);
            this.GpAdquisicion.Controls.Add(this.LblPrecio);
            this.GpAdquisicion.Controls.Add(this.TxtPrecio);
            this.GpAdquisicion.Controls.Add(this.TxtRuc);
            this.GpAdquisicion.Controls.Add(this.LblRuc);
            resources.ApplyResources(this.GpAdquisicion, "GpAdquisicion");
            this.GpAdquisicion.Name = "GpAdquisicion";
            this.GpAdquisicion.TabStop = false;
            // 
            // TxtRazonSocial
            // 
            resources.ApplyResources(this.TxtRazonSocial, "TxtRazonSocial");
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            // 
            // LblRazonSocial
            // 
            resources.ApplyResources(this.LblRazonSocial, "LblRazonSocial");
            this.LblRazonSocial.Name = "LblRazonSocial";
            // 
            // BtnDepreciacion
            // 
            this.BtnDepreciacion.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDepreciacion.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnDepreciacion, "BtnDepreciacion");
            this.BtnDepreciacion.Name = "BtnDepreciacion";
            this.BtnDepreciacion.UseVisualStyleBackColor = false;
            this.BtnDepreciacion.Click += new System.EventHandler(this.BtnDepreciacion_Click);
            // 
            // BtnAgregarRUC
            // 
            this.BtnAgregarRUC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarRUC.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.BtnAgregarRUC, "BtnAgregarRUC");
            this.BtnAgregarRUC.Name = "BtnAgregarRUC";
            this.BtnAgregarRUC.UseVisualStyleBackColor = true;
            this.BtnAgregarRUC.Click += new System.EventHandler(this.BtnAgregarRUC_Click);
            // 
            // LblPrecio
            // 
            resources.ApplyResources(this.LblPrecio, "LblPrecio");
            this.LblPrecio.Name = "LblPrecio";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TxtPrecio, "TxtPrecio");
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Enter += new System.EventHandler(this.TxtPrecio_Enter);
            this.TxtPrecio.Leave += new System.EventHandler(this.TxtPrecio_Leave);
            // 
            // TxtRuc
            // 
            this.TxtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TxtRuc, "TxtRuc");
            this.TxtRuc.Name = "TxtRuc";
            this.TxtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRuc_KeyDown);
            // 
            // LblRuc
            // 
            resources.ApplyResources(this.LblRuc, "LblRuc");
            this.LblRuc.Name = "LblRuc";
            // 
            // GrpRegistroMasivo
            // 
            this.GrpRegistroMasivo.Controls.Add(this.ChkActivarDatosMasivos);
            this.GrpRegistroMasivo.Controls.Add(this.CbGrupoRegistro);
            this.GrpRegistroMasivo.Controls.Add(this.BtnAgregarGrupo);
            this.GrpRegistroMasivo.Controls.Add(this.CbUnidadMedida);
            this.GrpRegistroMasivo.Controls.Add(this.NumCantidad);
            this.GrpRegistroMasivo.Controls.Add(this.label3);
            this.GrpRegistroMasivo.Controls.Add(this.label2);
            this.GrpRegistroMasivo.Controls.Add(this.label1);
            resources.ApplyResources(this.GrpRegistroMasivo, "GrpRegistroMasivo");
            this.GrpRegistroMasivo.Name = "GrpRegistroMasivo";
            this.GrpRegistroMasivo.TabStop = false;
            // 
            // ChkActivarDatosMasivos
            // 
            resources.ApplyResources(this.ChkActivarDatosMasivos, "ChkActivarDatosMasivos");
            this.ChkActivarDatosMasivos.Name = "ChkActivarDatosMasivos";
            this.ChkActivarDatosMasivos.UseVisualStyleBackColor = true;
            this.ChkActivarDatosMasivos.CheckedChanged += new System.EventHandler(this.ChkActivarDatosMasivos_CheckedChanged);
            // 
            // CbGrupoRegistro
            // 
            resources.ApplyResources(this.CbGrupoRegistro, "CbGrupoRegistro");
            this.CbGrupoRegistro.FormattingEnabled = true;
            this.CbGrupoRegistro.Name = "CbGrupoRegistro";
            this.CbGrupoRegistro.TextUpdate += new System.EventHandler(this.CbGrupoRegistro_TextUpdate);
            // 
            // BtnAgregarGrupo
            // 
            resources.ApplyResources(this.BtnAgregarGrupo, "BtnAgregarGrupo");
            this.BtnAgregarGrupo.Name = "BtnAgregarGrupo";
            this.BtnAgregarGrupo.UseVisualStyleBackColor = true;
            this.BtnAgregarGrupo.Click += new System.EventHandler(this.BtnAgregarGrupo_Click);
            // 
            // CbUnidadMedida
            // 
            resources.ApplyResources(this.CbUnidadMedida, "CbUnidadMedida");
            this.CbUnidadMedida.FormattingEnabled = true;
            this.CbUnidadMedida.Name = "CbUnidadMedida";
            this.CbUnidadMedida.TextUpdate += new System.EventHandler(this.CbUnidadMedida_TextUpdate);
            // 
            // NumCantidad
            // 
            resources.ApplyResources(this.NumCantidad, "NumCantidad");
            this.NumCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumCantidad.Name = "NumCantidad";
            this.NumCantidad.ValueChanged += new System.EventHandler(this.NumCantidad_ValueChanged);
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
            // VistaArticulos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpRegistroMasivo);
            this.Controls.Add(this.GpInformación);
            this.Controls.Add(this.GpAcciones);
            this.Controls.Add(this.GpAdquisicion);
            this.Controls.Add(this.GpUsos);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaArticulos";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.VistaArticulos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GpUsos.ResumeLayout(false);
            this.GpUsos.PerformLayout();
            this.GpInformación.ResumeLayout(false);
            this.GpInformación.PerformLayout();
            this.TabMultipedia.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbFotoArticulo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorArticulos)).EndInit();
            this.GpAcciones.ResumeLayout(false);
            this.GpAdquisicion.ResumeLayout(false);
            this.GpAdquisicion.PerformLayout();
            this.GrpRegistroMasivo.ResumeLayout(false);
            this.GrpRegistroMasivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblMarca;
        private System.Windows.Forms.Label LblSerie;
        private System.Windows.Forms.Label LblModelo;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblUbicacion;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label LblCondicion;
        private System.Windows.Forms.Button BtnAgregarImagen;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button BtnAgregarComprobante;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.ComboBox CbMarcas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TextBox TxtCodigo;
        public System.Windows.Forms.TextBox TxtSerie;
        public System.Windows.Forms.TextBox TxtModelo;
        public System.Windows.Forms.DateTimePicker DtpFechaAdquisicion;
        public System.Windows.Forms.DateTimePicker DtpFechaFinGarantia;
        public System.Windows.Forms.ComboBox CbEstadoArticulo;
        public System.Windows.Forms.TextBox TxtObservaciones;
        public System.Windows.Forms.ComboBox CbCondicion;
        public System.Windows.Forms.TextBox TxtDireccionImagen;
        public System.Windows.Forms.TextBox TxtRutaComprobante;
        public System.Windows.Forms.ComboBox CbUbicacion;
        private System.Windows.Forms.Button BtnAgregarMarca;
        public System.Windows.Forms.CheckBox ChkFechaGarantia;
        private System.Windows.Forms.ErrorProvider ErrorArticulos;
        private System.Windows.Forms.Button BtnAgregarUbicacion;
        private System.Windows.Forms.Button BtnAgregarEstado;
        private System.Windows.Forms.Button BtnAgregarCondicion;
        public System.Windows.Forms.PictureBox PbFotoArticulo;
        public System.Windows.Forms.Panel PanelComprobante;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.GroupBox GpAcciones;
        public System.Windows.Forms.Button BtnCancelar;
        public System.Windows.Forms.Button BtnGuardarPlus;
        public System.Windows.Forms.Button BtnGuardar;
        public System.Windows.Forms.Button BtnEmpleados;
        public System.Windows.Forms.GroupBox GpUsos;
        public System.Windows.Forms.GroupBox GpInformación;
        public System.Windows.Forms.TabControl TabMultipedia;
        public System.Windows.Forms.CheckBox ChkAutoCodigo;
        public System.Windows.Forms.CheckBox ChkAutoSerie;
        public System.Windows.Forms.CheckBox ChkAutoModelo;
        public System.Windows.Forms.GroupBox GpAdquisicion;
        public System.Windows.Forms.Button BtnDepreciacion;
        public System.Windows.Forms.Button BtnAgregarRUC;
        public System.Windows.Forms.Label LblPrecio;
        public System.Windows.Forms.TextBox TxtPrecio;
        public System.Windows.Forms.TextBox TxtRuc;
        public System.Windows.Forms.Label LblRuc;
        public System.Windows.Forms.TextBox TxtRazonSocial;
        public System.Windows.Forms.Label LblRazonSocial;
        private System.Windows.Forms.GroupBox GrpRegistroMasivo;
        private System.Windows.Forms.ComboBox CbGrupoRegistro;
        private System.Windows.Forms.ComboBox CbUnidadMedida;
        private System.Windows.Forms.NumericUpDown NumCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkActivarDatosMasivos;
        private System.Windows.Forms.Button BtnAgregarGrupo;
    }
}
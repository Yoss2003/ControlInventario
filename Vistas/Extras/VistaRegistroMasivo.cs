using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaRegistroMasivo : Form
    {
        private readonly Articulos _articuloBase;
        private readonly int _cantidad;
        private readonly string _nombreCategoria;

        public List<Articulos> ArticulosPersonalizados { get; private set; }

        // Controles
        private GroupBox GpSeleccion;
        private CheckBox ChkSerie;
        private CheckBox ChkModelo;
        private CheckBox ChkEstado;
        private CheckBox ChkUbicacion;
        private CheckBox ChkCondicion;
        private CheckBox ChkObservacion;
        private Button BtnConfirmarSeleccion;
        private Label LblInstrucciones;

        private DataGridView DgvMasivo;
        private Button BtnGuardar;
        private Button BtnCancelar;

        public VistaRegistroMasivo(Articulos articuloBase, int cantidad, string nombreCategoria)
        {
            _articuloBase = articuloBase;
            _cantidad = cantidad;
            _nombreCategoria = nombreCategoria;

            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            // === Instrucciones ===
            LblInstrucciones = new Label
            {
                Text = "Seleccione los campos que desea personalizar para cada artículo:",
                Location = new Point(12, 12),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(LblInstrucciones);

            // === GroupBox con CheckBoxes horizontales ===
            GpSeleccion = new GroupBox
            {
                Text = "Campos a personalizar",
                Location = new Point(12, 35),
                Size = new Size(810, 55)
            };

            int xPos = 15;
            int yPos = 22;
            int separacion = 130;

            ChkSerie = new CheckBox { Text = "Serie", Location = new Point(xPos, yPos), AutoSize = true };
            xPos += separacion;
            ChkModelo = new CheckBox { Text = "Modelo", Location = new Point(xPos, yPos), AutoSize = true };
            xPos += separacion;
            ChkEstado = new CheckBox { Text = "Estado", Location = new Point(xPos, yPos), AutoSize = true };
            xPos += separacion;
            ChkUbicacion = new CheckBox { Text = "Ubicación", Location = new Point(xPos, yPos), AutoSize = true };
            xPos += separacion;
            ChkCondicion = new CheckBox { Text = "Condición", Location = new Point(xPos, yPos), AutoSize = true };
            xPos += separacion;
            ChkObservacion = new CheckBox { Text = "Observación", Location = new Point(xPos, yPos), AutoSize = true };

            GpSeleccion.Controls.AddRange(new Control[]
            {
                ChkSerie, ChkModelo, ChkEstado, ChkUbicacion, ChkCondicion, ChkObservacion
            });
            this.Controls.Add(GpSeleccion);

            // === Botón confirmar selección ===
            BtnConfirmarSeleccion = new Button
            {
                Text = "Confirmar selección",
                Location = new Point(12, 95),
                Size = new Size(150, 30),
                Cursor = Cursors.Hand
            };
            BtnConfirmarSeleccion.Click += BtnConfirmarSeleccion_Click;
            this.Controls.Add(BtnConfirmarSeleccion);

            // === DataGridView ===
            DgvMasivo = new DataGridView
            {
                Location = new Point(12, 135),
                Size = new Size(810, 320),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                Visible = false,
                BackgroundColor = Color.White
            };
            DgvMasivo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvMasivo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Controls.Add(DgvMasivo);

            // === Botones inferiores ===
            BtnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(640, 465),
                Size = new Size(85, 30),
                Cursor = Cursors.Hand,
                Visible = false
            };
            BtnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(BtnGuardar);

            BtnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(735, 465),
                Size = new Size(85, 30),
                Cursor = Cursors.Hand
            };
            BtnCancelar.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(BtnCancelar);
        }

        private void BtnConfirmarSeleccion_Click(object sender, EventArgs e)
        {
            // Validar que al menos un CheckBox esté seleccionado
            if (!ChkSerie.Checked && !ChkModelo.Checked && !ChkEstado.Checked &&
                !ChkUbicacion.Checked && !ChkCondicion.Checked && !ChkObservacion.Checked)
            {
                MessageBox.Show("Debe seleccionar al menos un campo para personalizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bloquear CheckBoxes
            ChkSerie.Enabled = false;
            ChkModelo.Enabled = false;
            ChkEstado.Enabled = false;
            ChkUbicacion.Enabled = false;
            ChkCondicion.Enabled = false;
            ChkObservacion.Enabled = false;
            BtnConfirmarSeleccion.Enabled = false;

            // Construir DataGrid
            ConstruirDataGrid();
        }

        private void ConstruirDataGrid()
        {
            DgvMasivo.Columns.Clear();
            DgvMasivo.Rows.Clear();

            // Suprimir errores de formato durante la carga
            DgvMasivo.DataError += (s, e) => { e.ThrowException = false; };

            // Columna # (siempre visible, no editable)
            DgvMasivo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColNumero",
                HeaderText = "#",
                ReadOnly = true,
                Width = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            if (ChkSerie.Checked)
            {
                DgvMasivo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ColSerie",
                    HeaderText = "Serie"
                });
            }

            if (ChkModelo.Checked)
            {
                DgvMasivo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ColModelo",
                    HeaderText = "Modelo"
                });
            }

            if (ChkEstado.Checked)
            {
                var colEstado = CrearColumnaCombo("ColEstado", "Estado", "EstadoArticulos");
                DgvMasivo.Columns.Add(colEstado);
            }

            if (ChkUbicacion.Checked)
            {
                var colUbicacion = CrearColumnaCombo("ColUbicacion", "Ubicación", "Ubicacion");
                DgvMasivo.Columns.Add(colUbicacion);
            }

            if (ChkCondicion.Checked)
            {
                var colCondicion = CrearColumnaCombo("ColCondicion", "Condición", "Condicion");
                DgvMasivo.Columns.Add(colCondicion);
            }

            if (ChkObservacion.Checked)
            {
                DgvMasivo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ColObservacion",
                    HeaderText = "Observación"
                });
            }

            // Llenar filas con valores base
            for (int i = 0; i < _cantidad; i++)
            {
                int rowIndex = DgvMasivo.Rows.Add();
                var row = DgvMasivo.Rows[rowIndex];

                row.Cells["ColNumero"].Value = i + 1;

                if (ChkSerie.Checked)
                    row.Cells["ColSerie"].Value = ArticuloRepository.GenerarSerieAutomatica(_nombreCategoria, UsuarioSesion.UsuarioId);

                if (ChkModelo.Checked)
                    row.Cells["ColModelo"].Value = _articuloBase.Modelo;

                if (ChkEstado.Checked)
                    ((DataGridViewComboBoxCell)row.Cells["ColEstado"]).Value = Convert.ToInt64(_articuloBase.IdEstado);

                if (ChkUbicacion.Checked)
                    ((DataGridViewComboBoxCell)row.Cells["ColUbicacion"]).Value = Convert.ToInt64(_articuloBase.IdUbicacion);

                if (ChkCondicion.Checked)
                    ((DataGridViewComboBoxCell)row.Cells["ColCondicion"]).Value = Convert.ToInt64(_articuloBase.IdCondicion);

                if (ChkObservacion.Checked)
                    row.Cells["ColObservacion"].Value = _articuloBase.Observacion;
            }

            DgvMasivo.Visible = true;
            BtnGuardar.Visible = true;
        }

        private DataGridViewComboBoxColumn CrearColumnaCombo(string nombre, string headerText, string tipoParametro)
        {
            var col = new DataGridViewComboBoxColumn
            {
                Name = nombre,
                HeaderText = headerText,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dt = ParametrosRepository.ListarParametros(con, tipoParametro, UsuarioSesion.InventarioId);
                col.DataSource = dt;
                col.DisplayMember = "Nombre";
                col.ValueMember = "Id";
            }

            return col;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que no haya celdas vacías en columnas editables
            foreach (DataGridViewRow row in DgvMasivo.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0) continue;

                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        MessageBox.Show($"La fila {row.Cells["ColNumero"].Value} tiene campos vacíos. Complete todos los datos.",
                            "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DgvMasivo.CurrentCell = cell;
                        return;
                    }
                }
            }

            var confirmar = MessageBox.Show(
                $"¿Los datos ingresados para los {_cantidad} artículos son correctos?",
                "Confirmar registro masivo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.No)
                return;

            ArticulosPersonalizados = new List<Articulos>();

            for (int i = 0; i < _cantidad; i++)
            {
                var row = DgvMasivo.Rows[i];

                // Resolver IDs y textos de combos
                int idEstado = _articuloBase.IdEstado;
                string textoEstado = _articuloBase.Estado;
                int idUbicacion = _articuloBase.IdUbicacion;
                string textoUbicacion = _articuloBase.Ubicacion;
                int idCondicion = _articuloBase.IdCondicion;
                string textoCondicion = _articuloBase.Condicion;

                if (ChkEstado.Checked)
                {
                    idEstado = Convert.ToInt32(row.Cells["ColEstado"].Value);
                    textoEstado = ObtenerTextoCombo(row.Cells["ColEstado"]);
                }

                if (ChkUbicacion.Checked)
                {
                    idUbicacion = Convert.ToInt32(row.Cells["ColUbicacion"].Value);
                    textoUbicacion = ObtenerTextoCombo(row.Cells["ColUbicacion"]);
                }

                if (ChkCondicion.Checked)
                {
                    idCondicion = Convert.ToInt32(row.Cells["ColCondicion"].Value);
                    textoCondicion = ObtenerTextoCombo(row.Cells["ColCondicion"]);
                }

                var art = new Articulos
                {
                    InventarioId = _articuloBase.InventarioId,
                    Modelo = ChkModelo.Checked ? row.Cells["ColModelo"].Value?.ToString() : _articuloBase.Modelo,
                    Serie = ChkSerie.Checked ? row.Cells["ColSerie"].Value?.ToString() : ArticuloRepository.GenerarSerieAutomatica(_nombreCategoria, UsuarioSesion.UsuarioId),
                    IdMarca = _articuloBase.IdMarca,
                    Marca = _articuloBase.Marca,
                    FechaAdquisicion = _articuloBase.FechaAdquisicion,
                    FechaFinGarantia = _articuloBase.FechaFinGarantia,

                    IdEstado = idEstado,
                    Estado = textoEstado,
                    IdUbicacion = idUbicacion,
                    Ubicacion = textoUbicacion,
                    IdCondicion = idCondicion,
                    Condicion = textoCondicion,
                    Observacion = ChkObservacion.Checked ? row.Cells["ColObservacion"].Value?.ToString() : _articuloBase.Observacion,

                    RucProveedor = _articuloBase.RucProveedor,
                    Proveedor = _articuloBase.Proveedor,
                    PrecioAdquisicion = _articuloBase.PrecioAdquisicion,
                    MonedaAdquisicion = _articuloBase.MonedaAdquisicion,
                    Caracteristicas = _articuloBase.Caracteristicas,
                    FechaRegistro = DateTime.Now,

                    CategoriaId = _articuloBase.CategoriaId,
                    Categoria = _articuloBase.Categoria,
                    FotoPrincipal = _articuloBase.FotoPrincipal,
                    FotoSecundaria = _articuloBase.FotoSecundaria,
                    ComprobantePrincipal = _articuloBase.ComprobantePrincipal,
                    ComprobanteSecundaria = _articuloBase.ComprobanteSecundaria,
                    UnidadMedida = _articuloBase.UnidadMedida,
                    GrupoRegistroId = _articuloBase.GrupoRegistroId
                };

                ArticulosPersonalizados.Add(art);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string ObtenerTextoCombo(DataGridViewCell cell)
        {
            if (cell is DataGridViewComboBoxCell comboCell && comboCell.Value != null)
            {
                var col = (DataGridViewComboBoxColumn)DgvMasivo.Columns[cell.ColumnIndex];
                var dt = (DataTable)col.DataSource;
                string displayMember = col.DisplayMember;
                string valueMember = col.ValueMember;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[valueMember].ToString() == comboCell.Value.ToString())
                        return row[displayMember].ToString();
                }
            }
            return "";
        }
    }
}

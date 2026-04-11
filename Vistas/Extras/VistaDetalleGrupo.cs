using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaDetalleGrupo : Form
    {
        private ArticuloGrupo _grupo;
        private readonly int _categoriaId;
        private readonly string _categoriaNombre;
        private DataGridView DgvDetalle;
        private Label LblTitulo;
        private Button BtnAgregar;
        private Button BtnEditar;
        private Button BtnEliminar;
        private Button BtnCerrar;

        public VistaDetalleGrupo(ArticuloGrupo grupo, int categoriaId, string categoriaNombre)
        {
            _grupo = grupo;
            _categoriaId = categoriaId;
            _categoriaNombre = categoriaNombre;
            InicializarComponentes();
            CargarDatos();
        }

        private void InicializarComponentes()
        {
            this.Text = $"Detalle del grupo: {_grupo.GrupoNombre}";
            this.Size = new Size(950, 540);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;

            LblTitulo = new Label
            {
                Text = $"Grupo: {_grupo.GrupoNombre}  —  {_grupo.Cantidad} artículos  ({_grupo.UnidadMedida ?? "unidades"})",
                Location = new Point(12, 12),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            this.Controls.Add(LblTitulo);

            DgvDetalle = new DataGridView
            {
                Location = new Point(12, 42),
                Size = new Size(910, 400),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White
            };
            DgvDetalle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DgvDetalle.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "ColId", HeaderText = "ID", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None },
                new DataGridViewTextBoxColumn { Name = "ColCodigo", HeaderText = "Código" },
                new DataGridViewTextBoxColumn { Name = "ColModelo", HeaderText = "Modelo" },
                new DataGridViewTextBoxColumn { Name = "ColSerie", HeaderText = "Serie" },
                new DataGridViewTextBoxColumn { Name = "ColMarca", HeaderText = "Marca" },
                new DataGridViewTextBoxColumn { Name = "ColEstado", HeaderText = "Estado" },
                new DataGridViewTextBoxColumn { Name = "ColUbicacion", HeaderText = "Ubicación" },
                new DataGridViewTextBoxColumn { Name = "ColCondicion", HeaderText = "Condición" },
                new DataGridViewTextBoxColumn { Name = "ColObservacion", HeaderText = "Observación" }
            });

            this.Controls.Add(DgvDetalle);

            int yBotones = 450;

            BtnAgregar = new Button
            {
                Text = "Agregar",
                Location = new Point(12, yBotones),
                Size = new Size(85, 30),
                Cursor = Cursors.Hand
            };
            BtnAgregar.Click += BtnAgregar_Click;
            this.Controls.Add(BtnAgregar);

            BtnEditar = new Button
            {
                Text = "Editar",
                Location = new Point(105, yBotones),
                Size = new Size(85, 30),
                Cursor = Cursors.Hand
            };
            BtnEditar.Click += BtnEditar_Click;
            this.Controls.Add(BtnEditar);

            BtnEliminar = new Button
            {
                Text = "Eliminar",
                Location = new Point(198, yBotones),
                Size = new Size(85, 30),
                Cursor = Cursors.Hand
            };
            BtnEliminar.Click += BtnEliminar_Click;
            this.Controls.Add(BtnEliminar);

            BtnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(837, yBotones),
                Size = new Size(85, 30),
                Cursor = Cursors.Hand
            };
            BtnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(BtnCerrar);
        }

        private void CargarDatos()
        {
            DgvDetalle.Rows.Clear();

            // Recargar desde BD
            _grupo.Articulos = ArticuloRepository.ListarArticulosPorGrupo(_grupo.GrupoRegistroId, _categoriaId);
            _grupo.Cantidad = _grupo.Articulos.Count;
            LblTitulo.Text = $"Grupo: {_grupo.GrupoNombre}  —  {_grupo.Cantidad} artículos  ({_grupo.UnidadMedida ?? "unidades"})";

            foreach (var art in _grupo.Articulos)
            {
                int rowIndex = DgvDetalle.Rows.Add(
                    art.Id,
                    art.Codigo ?? "",
                    art.Modelo ?? "",
                    art.Serie ?? "",
                    art.Marca ?? "",
                    art.Estado ?? "",
                    art.Ubicacion ?? "",
                    art.Condicion ?? "",
                    art.Observacion ?? ""
                );
                DgvDetalle.Rows[rowIndex].Tag = art;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            VistaInventario.isEdit = false;

            // Pre-cargar datos del grupo como plantilla
            Articulos plantilla = _grupo.Articulos.Count > 0 ? _grupo.Articulos[0] : null;

            using (var articulos = new VistaArticulos(_categoriaId, _categoriaNombre, 0))
            {
                articulos.Text = $"Agregar Artículo al grupo ({_grupo.GrupoNombre})";
                articulos.TxtCodigo.Enabled = true;
                articulos.ChkAutoCodigo.Enabled = true;
                articulos.TxtModelo.Enabled = true;
                articulos.ChkAutoModelo.Enabled = true;
                articulos.TxtSerie.Enabled = true;
                articulos.ChkAutoSerie.Enabled = true;
                articulos.CbMarcas.Visible = true;
                articulos.GrupoRegistroIdPreseleccionado = _grupo.GrupoRegistroId;

                // Pre-cargar datos comunes del grupo
                if (plantilla != null)
                {
                    articulos.DatosPlantillaGrupo = plantilla;
                }

                if (articulos.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VistaInventario.isEdit = true;
            var artSeleccionado = DgvDetalle.SelectedRows[0].Tag as Articulos;
            if (artSeleccionado == null) return;

            int articuloId = artSeleccionado.Id;
            var art = ArticuloRepository.ObtenerArticuloPorId(articuloId);
            if (art == null)
            {
                MessageBox.Show("Error al cargar los datos del artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var articulos = new VistaArticulos(_categoriaId, _categoriaNombre, articuloId))
            {
                var datos = new EdicionArticulo
                {
                    Id = articuloId,
                    IdMarca = art.IdMarca,
                    IdEstado = art.IdEstado,
                    IdUbicacion = art.IdUbicacion,
                    IdCondicion = art.IdCondicion,
                    IdEmpleadoActual = art.EmpleadoActualId,
                    IdEmpleadoAnterior = art.EmpleadoAnteriorId,
                    Caracteristicas = art.Caracteristicas
                };

                articulos.Text = "Editar Artículo";
                articulos.TxtCodigo.Enabled = false;
                articulos.ChkAutoCodigo.Enabled = false;
                articulos.TxtModelo.Enabled = false;
                articulos.ChkAutoModelo.Enabled = false;
                articulos.TxtSerie.Enabled = false;
                articulos.ChkAutoSerie.Enabled = false;
                articulos.DatosEdicion = datos;
                articulos.TxtCodigo.Text = art.Codigo ?? string.Empty;
                articulos.TxtModelo.Text = art.Modelo ?? string.Empty;
                articulos.TxtSerie.Text = art.Serie ?? string.Empty;
                articulos.DtpFechaAdquisicion.Value = art.FechaAdquisicion;

                if (art.FechaFinGarantia.HasValue)
                {
                    articulos.DtpFechaFinGarantia.Value = art.FechaFinGarantia.Value;
                    articulos.ChkFechaGarantia.Checked = true;
                }

                articulos.TxtRuc.Text = art.RucProveedor ?? string.Empty;
                articulos.TxtRazonSocial.Text = art.Proveedor ?? string.Empty;
                articulos.TxtPrecio.Text = ClassHelper.AgregarSimboloVisual(art.PrecioAdquisicion);
                articulos.TxtObservaciones.Text = art.Observacion ?? string.Empty;

                string rutaFoto = File.Exists(art.FotoPrincipal) ? art.FotoPrincipal : art.FotoSecundaria;
                if (!string.IsNullOrEmpty(rutaFoto) && File.Exists(rutaFoto))
                {
                    articulos.TxtDireccionImagen.Text = rutaFoto;
                    articulos.PbFotoArticulo.Image = Image.FromFile(rutaFoto);
                }

                if (articulos.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int articuloId = Convert.ToInt32(DgvDetalle.SelectedRows[0].Cells["ColId"].Value);
            string codigo = DgvDetalle.SelectedRows[0].Cells["ColCodigo"].Value?.ToString();

            var result = MessageBox.Show(
                $"¿Seguro que desea eliminar el artículo {codigo}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ArticuloRepository.EliminarArticulo(articuloId);
                    LogsRepository.InsertarLogs("Artículos", "Eliminar", $"Se eliminó el artículo: {codigo} del grupo {_grupo.GrupoNombre}");
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

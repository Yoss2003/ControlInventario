using ControlInventario.Database;
using ControlInventario.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaBusquedaAvanzada : Form
    {
        private DataTable dtArticulosAgrupados;
        public string CodigoSeleccionado { get; private set; }
        public VistaBusquedaAvanzada()
        {
            InitializeComponent();
        }
        private void SeleccionarArticulo(int rowIndex)
        {
            DataRowView filaDatos = (DataRowView)DgvArticulosBusquedaAvanzada.Rows[rowIndex].DataBoundItem;

            CodigoSeleccionado = filaDatos["Codigo"].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DgvArticulosBusquedaAvanzada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarArticulo(e.RowIndex);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dtArticulosAgrupados == null) return;

            string filtro = TxtBuscarPorNombre.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                dtArticulosAgrupados.DefaultView.RowFilter = "";
            }
            else
            {
                dtArticulosAgrupados.DefaultView.RowFilter = $"Codigo LIKE '%{filtro}%' OR Modelo LIKE '%{filtro}%'";
            }
        }

        private void VistaBusquedaAvanzada_Load(object sender, EventArgs e)
        {
            DgvArticulosBusquedaAvanzada.AutoGenerateColumns = false;

            ModeloArticulo.DataPropertyName = "Modelo";
            MarcaArticulo.DataPropertyName = "MarcaTexto";
            PrecioArticulo.DataPropertyName = "PrecioAdquisicion";
            StockArticulo.DataPropertyName = "Stock";

            AcciónArticulo.Text = "Añadir";
            AcciónArticulo.UseColumnTextForButtonValue = true;

            dtArticulosAgrupados = ArticuloRepository.ListarArticulosDisponibles(UsuarioSesion.InventarioId);

            DgvArticulosBusquedaAvanzada.DataSource = dtArticulosAgrupados;

            CargarComboBoxes();

            DgvArticulosBusquedaAvanzada.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvArticulosBusquedaAvanzada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvArticulosBusquedaAvanzada.AllowUserToAddRows = false;
            DgvArticulosBusquedaAvanzada.ReadOnly = true;

            TxtBuscarPorNombre.TextChanged += (s, ev) => AplicarFiltros();
            TxtBuscarPorDescripcion.TextChanged += (s, ev) => AplicarFiltros();
            CbBuscarPorCategoria.SelectedIndexChanged += (s, ev) => AplicarFiltros();
            CbBuscarPorMarca.SelectedIndexChanged += (s, ev) => AplicarFiltros();
        }

        private void CargarComboBoxes()
        {
            var dtCategorias = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
            RefreshService.RefrescarComboDT(CbBuscarPorCategoria, dtCategorias, "Nombre", "Id", "SELECCIONE");

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dtMarcas = MarcasRepository.BuscarMarcasPorArticulosPorCategoria(con, 0, UsuarioSesion.InventarioId, true, 0);
                RefreshService.RefrescarComboDT(CbBuscarPorMarca, dtMarcas, "Nombre", "Id", "SELECCIONE");
            }
        }

        private void AplicarFiltros()
        {
            if (dtArticulosAgrupados == null) return;

            List<string> filtros = new List<string>();

            if (!string.IsNullOrWhiteSpace(TxtBuscarPorNombre.Text))
                filtros.Add($"Codigo LIKE '%{TxtBuscarPorNombre.Text.Trim()}%'");

            if (!string.IsNullOrWhiteSpace(TxtBuscarPorDescripcion.Text))
                filtros.Add($"Modelo LIKE '%{TxtBuscarPorDescripcion.Text.Trim()}%'");

            if (CbBuscarPorCategoria.SelectedIndex > 0 && CbBuscarPorCategoria.SelectedValue != null)
            {
                if (int.TryParse(CbBuscarPorCategoria.SelectedValue.ToString(), out int idCat) && idCat > 0)
                    filtros.Add($"CategoriaId = {idCat}");
            }

            if (CbBuscarPorMarca.SelectedIndex > 0 && CbBuscarPorMarca.SelectedValue != null)
            {
                if (int.TryParse(CbBuscarPorMarca.SelectedValue.ToString(), out int idMarca) && idMarca > 0)
                    filtros.Add($"IdMarca = {idMarca}");
            }

            dtArticulosAgrupados.DefaultView.RowFilter = string.Join(" AND ", filtros);
        }

        private void DgvArticulosBusquedaAvanzada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvArticulosBusquedaAvanzada.Columns[e.ColumnIndex].Name == "AcciónArticulo")
            {
                SeleccionarArticulo(e.RowIndex);
            }
        }
    }
}

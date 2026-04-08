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
            CodigoSeleccionado = DgvArticulosBusquedaAvanzada.Rows[rowIndex].Cells["CodigoArticulo"].Value.ToString();

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

            CodigoArticulo.DataPropertyName = "Codigo";
            DescripcionArticulo.DataPropertyName = "Modelo";
            MarcaArticulo.DataPropertyName = "MarcaTexto";
            PrecioArticulo.DataPropertyName = "Precio";
            StockArticulo.DataPropertyName = "Stock";

            AcciónArticulo.Text = "Añadir";
            AcciónArticulo.UseColumnTextForButtonValue = true;
                        
            DataTable dtCrudo = ArticuloRepository.ListarArticulosDisponibles(UsuarioSesion.InventarioId);

            dtArticulosAgrupados = new DataTable();
            dtArticulosAgrupados.Columns.Add("Codigo", typeof(string));
            dtArticulosAgrupados.Columns.Add("Modelo", typeof(string));
            dtArticulosAgrupados.Columns.Add("MarcaTexto", typeof(string));
            dtArticulosAgrupados.Columns.Add("Precio", typeof(decimal));
            dtArticulosAgrupados.Columns.Add("Stock", typeof(int));

            var diccionarioAgrupado = new Dictionary<string, DataRow>();

            foreach (DataRow row in dtCrudo.Rows)
            {
                string codigo = row["Codigo"].ToString();

                if (diccionarioAgrupado.ContainsKey(codigo))
                {
                    DataRow filaExistente = diccionarioAgrupado[codigo];
                    filaExistente["Stock"] = Convert.ToInt32(filaExistente["Stock"]) + 1;
                }
                else
                {
                    DataRow nuevaFila = dtArticulosAgrupados.NewRow();
                    nuevaFila["Codigo"] = codigo;
                    nuevaFila["Modelo"] = row["Modelo"].ToString();
                    nuevaFila["MarcaTexto"] = row["MarcaTexto"].ToString();
                    nuevaFila["Precio"] = row["PrecioAdquisicion"] != DBNull.Value ? Convert.ToDecimal(row["PrecioAdquisicion"]) : 0m;
                    nuevaFila["Stock"] = row["Stock"].ToString();

                    dtArticulosAgrupados.Rows.Add(nuevaFila);
                    diccionarioAgrupado.Add(codigo, nuevaFila);
                }
            }

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

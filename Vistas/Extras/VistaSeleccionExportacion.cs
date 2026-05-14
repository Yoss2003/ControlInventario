using ControlInventario.Database;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Data;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaSeleccionExportacion : Form
    {
        public DataTable DatosExportar { get; private set; }
        public string NombreSeccion { get; private set; }
        private class ComboItem
        {
            public string Texto { get; }
            public int Valor { get; }

            public ComboItem(string texto, int valor)
            {
                Texto = texto;
                Valor = valor;
            }
            public override string ToString() => Texto;
        }
        public VistaSeleccionExportacion()
        {
            InitializeComponent();
        }

        private void VistaSeleccionExportacion_Load(object sender, EventArgs e)
        {
            cbTipoSalida.Items.AddRange(new string[] { "Todas las salidas", "Solo Ventas", "Solo Asignaciones", "Solo Bajas" });
            cbTipoSalida.SelectedIndex = 0;

            CargarCategorias();
            ClassHelper.AplicarTema(this);
        }

        private void CargarCategorias()
        {
            DataTable dtCat = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
            cbCategorias.Items.Clear();

            foreach (DataRow row in dtCat.Rows)
            {
                cbCategorias.Items.Add(new ComboItem(row["Nombre"].ToString(), Convert.ToInt32(row["Id"])));
            }

            if (cbCategorias.Items.Count > 0)
                cbCategorias.SelectedIndex = 0;
        }

        private void Opciones_CheckedChanged(object sender, EventArgs e)
        {
            cbCategorias.Enabled = rbCategoria.Checked;
            cbTipoSalida.Enabled = rbSalidas.Checked;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbCategoria.Checked)
                {
                    if (cbCategorias.SelectedItem == null)
                    {
                        MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var item = (ComboItem)cbCategorias.SelectedItem;
                    NombreSeccion = item.Texto;
                    DatosExportar = ObtenerDatosCategoria(item.Valor);
                }
                else if (rbTodoInventario.Checked)
                {
                    NombreSeccion = "Inventario_Completo";
                    DatosExportar = ArticuloRepository.ListarInventarioCompleto(UsuarioSesion.InventarioId);
                }
                else if (rbSalidas.Checked)
                {
                    int[] acciones;
                    switch (cbTipoSalida.SelectedIndex)
                    {
                        case 1: acciones = new int[] { 2 }; NombreSeccion = "Ventas"; break;
                        case 2: acciones = new int[] { 3, 5, 10 }; NombreSeccion = "Asignaciones"; break;
                        case 3: acciones = new int[] { 6, 8, 11 }; NombreSeccion = "Bajas"; break;
                        default: acciones = new int[] { 2, 3, 5, 6, 8, 10, 11 }; NombreSeccion = "Todas_Salidas"; break;
                    }
                    DatosExportar = ArticuloRepository.ListarArticulosPorAccion(UsuarioSesion.InventarioId, acciones);
                }
                else if (rbCuentas.Checked)
                {
                    NombreSeccion = "Cuentas_Por_Cobrar";
                    DatosExportar = CuentasPorCobrarRepository.ListarResumenCuentas(UsuarioSesion.InventarioId);
                }

                if (DatosExportar == null || DatosExportar.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar en la sección seleccionada.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatosCategoria(int categoriaId)
        {
            DataTable dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM vw_Articulos WHERE CategoriaId = @CatId AND IdAccion IN (1, 4, 12, 13);";
                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CatId", categoriaId);
                    using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}

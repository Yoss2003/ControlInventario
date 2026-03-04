
using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Vistas;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ControlInventario.Servicios
{

    public class ClassHelper
    {
        private VistaInventario inventario;

        public ClassHelper(VistaInventario vista)
        {
            inventario = vista;
        }
        public void EliminarBotonCategoria(int idCategoria)
        {
            foreach (Control control in inventario.LstArticulos.Controls)
            {
                if (control is Button btn && btn.Tag != null && Convert.ToInt32(btn.Tag) == idCategoria)
                {
                    inventario.LstArticulos.Controls.Remove(btn);
                    btn.Dispose();
                    break;
                }
            }

            if (inventario.LstArticulos.Controls.Count == 0)
            {
                inventario.LstArticulos.Visible = false;
            }
            else
            {
                Button primerBoton = (Button)inventario.LstArticulos.Controls[0];
                primerBoton.PerformClick();
            }
        }

        public void AgregarBotonCategoria(string nombreCategoria, int idCategoria)
        {
            // Validación: no crear botón si el texto está vacío o excede 11 caracteres
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear botón solo si pasa la validación
            Button btn = new Button();
            btn.Text = nombreCategoria;
            btn.Tag = idCategoria;
            btn.Width = 75;
            btn.Height = 23;

            btn.Click += BtnCategoria_Click;

            inventario.FlCategorias.Controls.Add(btn);
        }

        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            int idCategoria = (int)btn.Tag;
            string nombreCategoria = btn.Text;

            inventario.categoriaSeleccionadaId = idCategoria; 
            inventario.categoriaSeleccionadaNombre = nombreCategoria;

            var articulos = ArticuloRepository.ListarArticulos(idCategoria);
            RefrescarListView(inventario.LstArticulos, articulos);
        }

        public static void RefrescarListView(ListView listView, IEnumerable<Articulos> articulos)
        {
            listView.Items.Clear();
            foreach (var art in articulos)
            {
                // Columna principal: Id
                var item = new ListViewItem(art.Id.ToString());

                // SubItems en el mismo orden que usas al editar
                item.SubItems.Add(art.Codigo ?? "");
                item.SubItems.Add(art.Modelo ?? "");
                item.SubItems.Add(art.Serie ?? "");
                item.SubItems.Add(art.Marca ?? "");
                item.SubItems.Add(art.FechaAdquisicion.ToString("dd/MM/yyyy") ?? "");
                item.SubItems.Add(art.FechaBaja?.ToString("dd/MM/yyyy") ?? "");
                item.SubItems.Add(art.FechaFinGarantia?.ToString("dd/MM/yyyy") ?? "");
                item.SubItems.Add(art.DniUsuarioActual ?? "");
                item.SubItems.Add(art.NombreUsuarioActual ?? "");
                item.SubItems.Add(art.AreaUsuarioActual ?? "");
                item.SubItems.Add(art.CargoUsuarioActual ?? "");
                item.SubItems.Add(art.DniUsuarioAnterior ?? "");
                item.SubItems.Add(art.NombreUsuarioAnterior ?? "");
                item.SubItems.Add(art.AreaUsuarioAnterior ?? "");
                item.SubItems.Add(art.CargoUsuarioAnterior ?? "");
                item.SubItems.Add(art.Estado ?? "");
                item.SubItems.Add(art.Ubicacion ?? "");
                item.SubItems.Add(art.Condicion ?? "");
                item.SubItems.Add(art.RucProveedor ?? "");
                item.SubItems.Add(art.Proveedor ?? "");
                item.SubItems.Add(art.PrecioAdquisicion?.ToString() ?? "");
                item.SubItems.Add(art.ActivoFijo ?? "");
                item.SubItems.Add(art.Observacion ?? "");
                item.SubItems.Add(art.FotoPrincipal ?? "");
                item.SubItems.Add(art.ComprobantePrincipal ?? "");

                listView.Items.Add(item);
            }
        }

        public static string NormalizarCombo(ComboBox combo)
        {
            return string.IsNullOrWhiteSpace(combo.Text) || combo.Text == "SELECCIONE"
                ? null
                : combo.Text;
        }

        public static void NormalizarTexro(ComboBox combo)
        {
            if (string.IsNullOrWhiteSpace(combo.Text) || combo.Text != "SELECCIONE")
            {
                combo.Text = "SELECCIONE";
            }
        }

        // Método genérico que sirve para CUALQUIER tabla
        public static bool ExisteComponenteDuplicado(string nombreTabla, string nombreIngresado, int idActual = 0)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = $@"
                SELECT COUNT(*) 
                FROM {nombreTabla} 
                WHERE TRIM(Nombre) = TRIM(@Nombre) COLLATE NOCASE 
                AND Id != @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreIngresado);
                    cmd.Parameters.AddWithValue("@Id", idActual);

                    long cantidad = (long)cmd.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }

        public static bool ValidarComboObsoleto(ComboBox combo, string valorFila, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valorFila))
            {
                combo.SelectedIndex = 0;
                return true;
            }

            int indice = combo.FindStringExact(valorFila);

            if (indice != -1)
            {
                combo.SelectedIndex = indice;
                return true;
            }
            else
            {
                combo.SelectedIndex = 0;
                MessageBox.Show($"El valor '{valorFila}' de {nombreCampo} ya no existe.\nSe restablecerá.",
                                "Dato Obsoleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static void LimpiarCampoObsoletoBD(string tablaDestino, string columnaId, string columnaNombre, int idRegistro)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $@"UPDATE {tablaDestino} SET
                        {columnaId} = 0, 
                        {columnaNombre} = 'SELECCIONE' 
                        WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idRegistro);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

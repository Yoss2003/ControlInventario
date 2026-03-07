
using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Threading;
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
                var item = new ListViewItem(art.Id.ToString());

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
                item.SubItems.Add(art.PrecioAdquisicion?.ToString("C2") ?? "");
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

        public static void NormalizarTexto(ComboBox combo)
        {
            if (string.IsNullOrWhiteSpace(combo.Text) || combo.Text != "SELECCIONE")
            {
                combo.Text = "SELECCIONE";
            }
        }

        // Método genérico que sirve para CUALQUIER tabla
        public static bool ExisteComponenteDuplicado(string nombreTabla, string valorIngresado, int idActual = 0, string nombreColumna = "Nombre")
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Ahora inyectamos {nombreColumna} en lugar de escribirlo a mano
                string query = $@"
                SELECT COUNT(*) 
                FROM {nombreTabla} 
                WHERE TRIM({nombreColumna}) = TRIM(@ValorIngresado) COLLATE NOCASE 
                AND Id != @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    // Cambié @Nombre por @ValorIngresado para que tenga más sentido lógico
                    cmd.Parameters.AddWithValue("@ValorIngresado", valorIngresado);
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

        public static void LlenarDesdeTabla(ComboBox cb, string nombreTabla, string nombreColumnaTexto)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $"SELECT Id, {nombreColumnaTexto} FROM {nombreTabla}";

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cb.DataSource = dt;
                    cb.DisplayMember = nombreColumnaTexto;
                    cb.ValueMember = "Id";
                }
            }
        }

        public static void AplicarTema(Control controlPrincipal)
        {
            string tema = UsuarioSesion.Configuracion?.Tema ?? "Claro";

            Color colorFondo = tema == "Oscuro" ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            Color colorTexto = tema == "Oscuro" ? Color.White : Color.Black;
            Color colorCajas = tema == "Oscuro" ? Color.FromArgb(30, 30, 30) : Color.White;

            controlPrincipal.BackColor = colorFondo;
            controlPrincipal.ForeColor = colorTexto;

            foreach (Control hijo in controlPrincipal.Controls)
            {
                if (hijo is TextBox || hijo is ComboBox || hijo is ListBox)
                {
                    hijo.BackColor = colorCajas;
                    hijo.ForeColor = colorTexto;
                }
                else
                {
                    AplicarTema(hijo);
                }
            }
        }

        public static void ActualizarTemaGlobal()
        {
            foreach (Form formulario in Application.OpenForms)
            {
                AplicarTema(formulario);
            }
        }

        public static void AplicarIdiomaGlobal()
        {
            string idiomaSeleccionado = UsuarioSesion.Configuracion?.Idioma ?? "Español";

            string codigoCultura = "es-ES";

            if (idiomaSeleccionado.Contains("Inglés") || idiomaSeleccionado.Contains("English"))
            {
                codigoCultura = "en-US";
            }
            else if (idiomaSeleccionado.Contains("Portugués"))
            {
                codigoCultura = "pt-BR";
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoCultura);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(codigoCultura);
        }
    }
}

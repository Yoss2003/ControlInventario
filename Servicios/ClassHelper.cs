using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Vistas;
using System;
using System.Collections.Generic;
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
            btn.Width = 120;
            btn.Height = 40;
            btn.Margin = new Padding(5);

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
                var item = new ListViewItem(art.NombreUsuarioActual);
                item.SubItems.Add(art.Codigo);
                item.SubItems.Add(art.Modelo);
                item.SubItems.Add(art.Serie);
                item.SubItems.Add(art.Marca);

                listView.Items.Add(item);
            }
        }
    }
}

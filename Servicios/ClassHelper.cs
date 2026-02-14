using ControlInventario.Modelos;
using ControlInventario.Vistas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlInventario.Servicios
{
    
    public class ClassHelper
    {
        public static void RefrescarListView(ListView listView, List<Articulos> articulos)
        {
            listView.Items.Clear();

            foreach (var art in articulos)
            {
                bool pertenece = false;

                // Comparar por nombre de categoría en lugar de IDs fijos
                if (listView.Name == "LstLaptop" && art.Categoria.Equals("Laptops", StringComparison.OrdinalIgnoreCase)) pertenece = true;
                else if (listView.Name == "LstCelulares" && art.Categoria.Equals("Celulares", StringComparison.OrdinalIgnoreCase)) pertenece = true;
                else if (listView.Name == "LstComputadoras" && art.Categoria.Equals("Computadoras", StringComparison.OrdinalIgnoreCase)) pertenece = true;
                else if (listView.Name == "LstMonitores" && art.Categoria.Equals("Monitores", StringComparison.OrdinalIgnoreCase)) pertenece = true;
                else if (listView.Name == "LstAccesorios" && art.Categoria.Equals("Accesorios", StringComparison.OrdinalIgnoreCase)) pertenece = true;

                if (!pertenece) continue;

                ListViewItem item = new ListViewItem(art.Id.ToString());
                item.SubItems.Add(art.Codigo);
                item.SubItems.Add(art.Modelo);
                item.SubItems.Add(art.Serie);
                item.SubItems.Add(art.Marca);

                listView.Items.Add(item);
            }
        }
    }
}

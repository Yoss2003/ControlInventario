using ControlInventario.Modelos;
using ControlInventario.Vistas;
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

                if (listView.Name == "LstLaptop" && art.CategoriaId == 1) pertenece = true;
                else if (listView.Name == "LstComputadoras" && art.CategoriaId == 2) pertenece = true;
                else if (listView.Name == "LstCelulares" && art.CategoriaId == 3) pertenece = true;
                else if (listView.Name == "LstMonitores" && art.CategoriaId == 4) pertenece = true;
                else if (listView.Name == "LstAccesorios" && art.CategoriaId == 5) pertenece = true;

                if (!pertenece) continue;

                ListViewItem item = new ListViewItem(art.Id.ToString());
                item.SubItems.Add(art.Codigo);
                item.SubItems.Add(art.Modelo);
                item.SubItems.Add(art.Serie);
                item.SubItems.Add(art.Marca);
                // ... resto de subitems
                listView.Items.Add(item);
            }
        }
    }
}

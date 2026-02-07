using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlInventario.Utilidades
{
    public class CustomTabControl : TabControl
    {
        private HashSet<TabPage> ocultos = new HashSet<TabPage>();

        public void OcultarTab(TabPage tab)
        {
            if (this.TabPages.Contains(tab))
                ocultos.Add(tab);
            this.Invalidate(); // fuerza redibujado
        }

        public void MostrarTab(TabPage tab)
        {
            if (ocultos.Contains(tab))
                ocultos.Remove(tab);
            this.Invalidate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var page = this.TabPages[e.Index];
            if (ocultos.Contains(page))
            {
                // No dibujar nada para esta pestaña
                return;
            }
            base.OnDrawItem(e);
        }

        public bool EstaOculto(TabPage tab)
        {
            return ocultos.Contains(tab);
        }
    }
}

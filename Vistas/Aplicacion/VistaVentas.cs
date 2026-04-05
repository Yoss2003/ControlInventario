using ControlInventario.Vistas.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Aplicacion
{
    public partial class VistaVentas : Form
    {
        public VistaVentas()
        {
            InitializeComponent();
        }

        private void BtnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            VistaVentaAvanzado ventaAvanzada = new VistaVentaAvanzado();
            ventaAvanzada.ShowDialog();
        }
    }
}

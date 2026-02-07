using ControlInventario.Vistas.Extras;
using SQLite;
using System;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaArticulos : Form
    {
        public VistaArticulos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VistaCaracteristicas caracteristicas = new VistaCaracteristicas();
            caracteristicas.CaracteristicasGuardadas += AgregarCaracteristicas;
            caracteristicas.ShowDialog();
        }

        public void AgregarCaracteristicas(GroupBox grupo)
        {
            foreach (Control ctrl in grupo.Controls)
            {
                string nombre = ctrl.Name;
                string valor = "";

                if (ctrl is TextBox)
                    valor = ((TextBox)ctrl).Text;
                else if (ctrl is ComboBox)
                    valor = ((ComboBox)ctrl).SelectedItem?.ToString();
                else if (ctrl is CheckBox)
                    valor = ((CheckBox)ctrl).Checked ? "Sí" : "No";

                if (!string.IsNullOrEmpty(valor))
                {
                    Label lbl = new Label();
                    lbl.Text = $"{nombre}: {valor}";
                    FlCaracteristicas.Controls.Add(lbl);
                }
            }
        }
    }
}

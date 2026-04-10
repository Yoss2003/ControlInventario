using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaBaja : Form
    {
        public string MotivoBaja { get; private set; }
        public VistaBaja(string codigoArticulo)
        {
            InitializeComponent();

            // Centramos la ventanita en la pantalla
            this.StartPosition = FormStartPosition.CenterParent;

            // Reemplazamos dinámicamente el texto del Label con el código real
            LblMensaje.Text = $"Ingrese el motivo de la baja para el articulo {codigoArticulo}";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Validamos que no esté vacío
            if (string.IsNullOrWhiteSpace(TxtMotivo.Text))
            {
                MessageBox.Show("Debe especificar un motivo para continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos el texto, marcamos el resultado como OK y cerramos
            MotivoBaja = TxtMotivo.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Simplemente cancelamos y cerramos
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

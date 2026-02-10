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
    public partial class VistaCaracteristicas : Form
    {
        public VistaCaracteristicas()
        {
            InitializeComponent();
        }

        public event Action<GroupBox> CaracteristicasGuardadas;
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ChkCaracteristicaDesktop.Checked)
                CaracteristicasGuardadas?.Invoke(GrpDesktop); 
            else if (ChkCaracteristicaCelular.Checked)
                CaracteristicasGuardadas?.Invoke(GrpCelular); 
            else if (ChkCaracteristicasMonitor.Checked)
                CaracteristicasGuardadas?.Invoke(GrpMonitor);

            this.Close();
        }

        private void ChkCaracteristicaDesktop_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCaracteristicaDesktop.Checked)
            {
                ChkCaracteristicaCelular.Checked = false;
                ChkCaracteristicasMonitor.Checked = false;
            }
        }

        private void ChkCaracteristicaCelular_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCaracteristicaCelular.Checked)
            {
                ChkCaracteristicaDesktop.Checked = false;
                ChkCaracteristicasMonitor.Checked = false;
                ChkCargadorDesktop.Checked = false;
            }
        }

        private void ChkCaracteristicasMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCaracteristicasMonitor.Checked)
            {
                ChkCaracteristicaDesktop.Checked = false;
                ChkCaracteristicaCelular.Checked = false;
                ChkCargadorDesktop.Checked = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            ChkCaracteristicaDesktop.Checked = false;
            ChkCaracteristicaCelular.Checked = false;
            ChkCaracteristicasMonitor.Checked = false;
            ChkCargadorDesktop.Checked = false;
        }
    }
}

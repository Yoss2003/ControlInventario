using ControlInventario.Database;
using ControlInventario.Servicios;
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
    public partial class VistaMovimiento : Form
    {
        private DataTable dtStock;
        private DataTable dtSeleccionados;
        public VistaMovimiento()
        {
            InitializeComponent();
        }

        private void VistaMovimiento_Load(object sender, EventArgs e)
        {
            DvgArticulosDisponibles.AutoGenerateColumns = false;
            DvgArticulosSeleccionados.AutoGenerateColumns = false;

            DvgArticulosSeleccionados.DataSource = dtSeleccionados;
            CargarStockDisponible();
        }

        private void CargarStockDisponible()
        {
            DataTable tablaDisponibles = ArticuloRepository.ListarArticulosDisponibles(UsuarioSesion.InventarioId);

            foreach (DataRow row in tablaDisponibles.Rows)
            {
                int idArticulo = Convert.ToInt32(row["Id"]);
                string codigo = row["Codigo"].ToString();
                string modelo = row["Modelo"].ToString();

                string fotoPrincipal = row["RutaFotoPrincipal"].ToString();
                string fotoSecundaria = row["RutaFotoSecundaria"].ToString();

                Image fotoVisual = null;
                string rutaFoto = System.IO.File.Exists(fotoPrincipal) ? fotoPrincipal : fotoSecundaria;

                if (!string.IsNullOrEmpty(rutaFoto) && System.IO.File.Exists(rutaFoto))
                {
                    fotoVisual = Image.FromFile(rutaFoto);
                }

                dtStock.Rows.Add(idArticulo, fotoVisual, codigo, modelo);
            }
        }

        private void DvgArticulosDisponibles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView filaSeleccionada = (DataRowView)DvgArticulosSeleccionados.Rows[e.RowIndex].DataBoundItem;
                DataRow filaVirtual = filaSeleccionada.Row;

                dtSeleccionados.ImportRow(filaVirtual);

                dtStock.Rows.Remove(filaVirtual);
            }
        }

        private void btnQuitarArticulo_Click(object sender, EventArgs e)
        {
            if (DvgArticulosSeleccionados.SelectedRows.Count > 0)
            {
                DataRowView filaSeleccionada = (DataRowView)DvgArticulosSeleccionados.SelectedRows[0].DataBoundItem;
                DataRow filaVirtual = filaSeleccionada.Row;

                dtStock.ImportRow(filaVirtual);
                dtSeleccionados.Rows.Remove(filaVirtual);
            }
        }
    }
}

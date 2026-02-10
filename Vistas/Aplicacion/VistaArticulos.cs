using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Vistas.Extras;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaArticulos : Form
    {
        private readonly int _categoriaId;
        private readonly string _categoria;
        public VistaArticulos(int categoriaId, string categoria)
        {
            InitializeComponent(); 
            _categoriaId = categoriaId;
            _categoria = categoria;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VistaCaracteristicas caracteristicas = new VistaCaracteristicas();
            caracteristicas.CaracteristicasGuardadas += AgregarCaracteristicas;
            caracteristicas.ShowDialog();
        }

        private void btnEliminar_Click (object sender, EventArgs e)
        {
            FlCaracteristicas.Controls.Clear();
        }

        public void AgregarCaracteristicas(GroupBox grupo)
        {
            FlCaracteristicas.Controls.Clear();

            var controles = new List<Control>();
            RecolectarControles(grupo, controles);

            var labelsAgregados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var ctrl in controles)
            {
                string nombreBase = ObtenerNombreBase(ctrl);

                Label lbl = BuscarLabelRecursivo(grupo, nombreBase);
                if (lbl != null && !labelsAgregados.Contains(lbl.Name))
                {
                    lbl.AutoSize = false;
                    lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lbl.Margin = new Padding(5, 3, 10, 0);

                    int panelWidth = FlCaracteristicas.ClientSize.Width; 
                    int marginSum = (lbl.Margin.Left + lbl.Margin.Right) + (ctrl.Margin.Left + ctrl.Margin.Right);

                    int lblPreferred = lbl.AutoSize ? lbl.PreferredSize.Width : lbl.Width; 
                    int ctrlPreferred = ctrl.AutoSize ? ctrl.PreferredSize.Width : ctrl.Width;

                    int totalNecesario = lblPreferred + ctrlPreferred + marginSum;

                    if (totalNecesario > panelWidth)
                    {
                        int minimoControl = Math.Min(ctrlPreferred, 80);
                        int nuevoLblWidth = Math.Max(40, panelWidth - minimoControl - marginSum);

                        if(nuevoLblWidth < lblPreferred)
                        {
                            lbl.AutoSize = false;
                            lbl.Width = nuevoLblWidth;
                        }
                    }

                    FlCaracteristicas.Controls.Add(lbl);
                    labelsAgregados.Add(lbl.Name);
                }

                ctrl.Margin = new Padding(5, 0, 10, 8);
                FlCaracteristicas.Controls.Add(ctrl);
            }
        }

        // Recolecta TextBox y ComboBox recursivamente (mantiene orden visual)
        private void RecolectarControles(Control parent, List<Control> lista)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    lista.Add(c);

                if (c.HasChildren)
                    RecolectarControles(c, lista);
            }
        }

        // Normaliza el nombre del control para buscar su label asociado
        private string ObtenerNombreBase(Control ctrl)
        {
            if (string.IsNullOrEmpty(ctrl?.Name)) return string.Empty;
            string n = ctrl.Name.ToLowerInvariant();
            n = n.Replace("txt", "").Replace("cb", "");
            return n;
        }

        // Busca un Label cuyo Name contenga nombreBase en todo el árbol (recursivo)
        private Label BuscarLabelRecursivo(Control root, string nombreBase)
        {
            if (string.IsNullOrEmpty(nombreBase)) return null;

            foreach (Control c in root.Controls)
            {
                if (c is Label lbl && !string.IsNullOrEmpty(lbl.Name))
                {
                    if (lbl.Name.IndexOf(nombreBase, StringComparison.OrdinalIgnoreCase) >= 0)
                        return lbl;
                }
            }

            foreach (Control c in root.Controls)
            {
                if (c.HasChildren)
                {
                    var encontrado = BuscarLabelRecursivo(c, nombreBase);
                    if (encontrado != null) return encontrado;
                }
            }

            return null;
        }

        private void CbMonitores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CbEstado_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbEstado.Text))
            {
                CbEstado.Text = "SELECCIONE";
            }
        }

        private void CbCondicion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbCondicion.Text))
            {
                CbCondicion.Text = "SELECCIONE";
            }
        }

        private void CbMonitores_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbMonitores.Text))
            {
                CbMonitores.Text = "SELECCIONE";
            }
        }

        private void CbDesktop_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbDesktop.Text))
            {
                CbDesktop.Text = "SELECCIONE";
            }
        }

        private void CbCelulares_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbCelulares.Text))
            {
                CbCelulares.Text = "SELECCIONE";
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método auxiliar para obtener la marca según el ComboBox visible
        private string ObtenerMarca()
        {
            if (CbDesktop.Visible) return CbDesktop.SelectedItem?.ToString();
            if (CbCelulares.Visible) return CbCelulares.SelectedItem?.ToString();
            if (CbMonitores.Visible) return CbMonitores.SelectedItem?.ToString();
            // Si ninguno aplica, puedes devolver null o un texto por defecto
            return null;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    Articulos art = new Articulos
                    {
                        Codigo = TxtCodigo.Text,
                        Modelo = TxtModelo.Text,
                        Serie = TxtSerie.Text,
                        Marca = ObtenerMarca(),
                        FechaAdquisicion = DtpFechaAdquisicion.Value,
                        FechaBaja = DtpFechaBaja.Value,
                        FechaFinGarantia = DtpFechaFinGarantia.Value,

                        DniUsuarioActual = TxtDniUsuarioActual.Text,
                        NombreUsuarioActual = TxtNombreUsuarioActual.Text,
                        IdAreaUsuarioActual = Convert.ToInt32(CbAreaUsuarioActual.SelectedValue),
                        AreaUsuarioActual = CbAreaUsuarioActual.Text,
                        CargoUsuarioActual = TxtCargoUsuarioActual.Text,

                        DniUsuarioAnterior = TxtDniUsuarioAnterior.Text,
                        NombreUsuarioAnterior = TxtNombreUsuarioAnterior.Text,
                        IdAreaUsuarioAnterior = Convert.ToInt32(CbAreaUsuarioAnterior.SelectedValue),
                        AreaUsuarioAnterior = CbAreaUsuarioAnterior.Text,
                        CargoUsuarioAnterior = TxtCargoUsuarioAnterior.Text,

                        IdEstado = Convert.ToInt32(CbEstado.SelectedValue),
                        Estado = CbEstado.Text,
                        IdUbicacion = Convert.ToInt32(CbUbicacion.SelectedValue),
                        Ubicacion = CbUbicacion.Text,
                        IdCondicion = Convert.ToInt32(CbCondicion.SelectedValue),
                        Condicion = CbCondicion.Text,
                        ActivoFijo = TxtActivoFijo.Text,
                        Observacion = TxtObservaciones.Text,

                        RucProveedor = TxtRuc.Text,
                        Proveedor = TxtRazonSocial.Text,
                        PrecioAdquisicion = string.IsNullOrWhiteSpace(TxtPrecio.Text) ? (decimal?)null : Convert.ToDecimal(TxtPrecio.Text),

                        CategoriaId = _categoriaId,
                        Categoria = _categoria
                    };
                    ArticuloRepository.InsertarArticulo(art, con);

                    MessageBox.Show("Artículo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close(); 
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al guardar el artículo: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                ); 
            }
        }
    }
}

using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Aplicacion
{
    public partial class VistaMovimiento : Form
    {
        private DataTable dtStock;
        private DataTable dtSeleccionados;
        private int idEmpleadoSeleccionado = 0;

        public VistaMovimiento()
        {
            InitializeComponent();
        }

        private void VistaMovimiento_Load(object sender, EventArgs e)
        {
            DvgArticulosDisponibles.AutoGenerateColumns = false;
            DvgArticulosSeleccionados.AutoGenerateColumns = false;

            ImageArticulo.DataPropertyName = "Foto";
            CodigoArticulo.DataPropertyName = "Codigo";
            ModeloArticulo.DataPropertyName = "Modelo";

            ImagenArticuloSeleccionado.DataPropertyName = "Foto";
            ModeloArticuloSeleccionado.DataPropertyName = "Modelo";

            // --- CONFIGURACIÓN DEL BOTÓN "QUITAR" ---
            AccionArticuloSeleccionado.UseColumnTextForButtonValue = true;
            AccionArticuloSeleccionado.Text = "Quitar";

            // Aseguramos que el evento del clic en el botón esté enlazado
            DvgArticulosSeleccionados.CellContentClick += DvgArticulosSeleccionados_CellContentClick;

            dtStock = new DataTable();
            dtStock.Columns.Add("Id", typeof(int));
            dtStock.Columns.Add("Foto", typeof(Image));
            dtStock.Columns.Add("Codigo", typeof(string));
            dtStock.Columns.Add("Modelo", typeof(string));
            dtStock.Columns.Add("Precio", typeof(decimal));

            dtSeleccionados = dtStock.Clone();

            DvgArticulosDisponibles.DataSource = dtStock;
            DvgArticulosSeleccionados.DataSource = dtSeleccionados;

            ClassHelper.AplicarEstilosGrillas(DvgArticulosDisponibles);
            ClassHelper.AplicarEstilosGrillas(DvgArticulosSeleccionados);
            CargarStockDisponible();

            // --- CONFIGURACIÓN PARA PERDER EL FOCO ---
            this.Click += Fondo_Click;
            ConfigurarPerdidaDeFoco(this);

            // Quitamos la selección azul por defecto al abrir la ventana
            this.BeginInvoke(new MethodInvoker(() => {
                DvgArticulosDisponibles.ClearSelection();
                DvgArticulosSeleccionados.ClearSelection();
            }));
        }

        private void CargarStockDisponible()
        {
            // Nota: Asegúrate de que este método en ArticuloRepository exista y traiga solo los de estado "Disponible"
            DataTable tablaDisponibles = ArticuloRepository.ListarArticulosDisponibles(UsuarioSesion.InventarioId);

            foreach (DataRow row in tablaDisponibles.Rows)
            {
                int idArt = Convert.ToInt32(row["Id"]);
                string codigo = row["Codigo"].ToString();
                string modelo = row["Modelo"].ToString();

                string rutaFoto = row["RutaFotoPrincipal"].ToString();
                if (!System.IO.File.Exists(rutaFoto)) rutaFoto = row["RutaFotoSecundaria"].ToString();
                Image fotoVisual = (System.IO.File.Exists(rutaFoto)) ? Image.FromFile(rutaFoto) : null;

                decimal precio = row["PrecioAdquisicion"] != DBNull.Value ? Convert.ToDecimal(row["PrecioAdquisicion"]) : 0m;

                dtStock.Rows.Add(idArt, fotoVisual, codigo, modelo, precio);
            }
        }

        private void DvgArticulosDisponibles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView fila = (DataRowView)DvgArticulosDisponibles.Rows[e.RowIndex].DataBoundItem;
                dtSeleccionados.ImportRow(fila.Row);
                dtStock.Rows.Remove(fila.Row);

                CalcularMontoTotal();
            }
        }

        private void Fondo_Click(object sender, EventArgs e)
        {
            // Limpiamos la selección de ambas grillas
            DvgArticulosDisponibles.ClearSelection();
            DvgArticulosSeleccionados.ClearSelection();

            // Quitamos el foco de cualquier TextBox activo
            this.ActiveControl = null;
        }

        private void ConfigurarPerdidaDeFoco(Control contenedorPadre)
        {
            foreach (Control c in contenedorPadre.Controls)
            {
                // Si el control es un contenedor o texto estático, le asignamos el evento clic
                if (c is Panel || c is GroupBox || c is Label || c is PictureBox || c is FlowLayoutPanel || c is TableLayoutPanel)
                {
                    c.Click += Fondo_Click;
                    // Recursividad por si hay paneles dentro de paneles
                    ConfigurarPerdidaDeFoco(c);
                }
            }
        }

        private void DvgArticulosSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el clic haya sido exactamente en la columna del botón
            if (e.RowIndex >= 0 && DvgArticulosSeleccionados.Columns[e.ColumnIndex].Name == "AccionArticuloSeleccionado")
            {
                // Tomamos la fila seleccionada
                DataRowView filaSeleccionada = (DataRowView)DvgArticulosSeleccionados.Rows[e.RowIndex].DataBoundItem;
                DataRow filaVirtual = filaSeleccionada.Row;

                // La devolvemos al stock disponible (izquierda) y la borramos de los seleccionados (derecha)
                dtStock.ImportRow(filaVirtual);
                dtSeleccionados.Rows.Remove(filaVirtual);

                // Limpiamos selecciones para que se vea limpio
                DvgArticulosDisponibles.ClearSelection();
                DvgArticulosSeleccionados.ClearSelection();

                CalcularMontoTotal();
            }
        }

        private void TxtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string dniIngresado = TxtDNI.Text.Trim();

                if (string.IsNullOrEmpty(dniIngresado)) return;

                try
                {
                    var empleado = EmpleadoRepository.ObtenerEmpleadoPorDni(dniIngresado);

                    if (empleado != null)
                    {
                        TxtNombre.Text = empleado.Nombres + " " + empleado.Apellidos;
                        TxtCargo.Text = empleado.Cargo;
                        TxtArea.Text = empleado.Area;

                        idEmpleadoSeleccionado = empleado.Id;

                        TxtObservacion.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún empleado con ese DNI.", "Búsqueda fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TxtNombre.Clear();
                        TxtCargo.Clear();
                        TxtArea.Clear();
                        idEmpleadoSeleccionado = 0;

                        TxtDNI.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar empleado: " + ex.Message);
                }
            }
        }

        private void BtnGuardarMovimiento_Click(object sender, EventArgs e)
        {
            if (idEmpleadoSeleccionado == 0)
            {
                MessageBox.Show("Busque un empleado válido por DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un artículo para asignar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extraemos los IDs de la tabla derecha
            List<int> listaIds = new List<int>();
            foreach (DataRow row in dtSeleccionados.Rows)
            {
                listaIds.Add(Convert.ToInt32(row["Id"]));
            }


            DialogResult res = MessageBox.Show($"¿Asignar {listaIds.Count} artículo(s) al empleado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    MovimientoRepository.RegistrarAsignacionLote(
                        listaIds,
                        idEmpleadoSeleccionado,
                        TxtObservacion.Text.Trim()
                    );

                    MessageBox.Show("Asignación completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        

        private void BtnVerEmpleados_Click(object sender, EventArgs e)
        {
            VistaAgregarEmpleado vistaEmpleado = new VistaAgregarEmpleado();
            vistaEmpleado.ShowDialog();
        }

        private void CalcularMontoTotal()
        {
            decimal total = 0m;

            foreach (DataRow row in dtSeleccionados.Rows)
            {
                total += Convert.ToDecimal(row["Precio"]);
            }

            string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "PEN - Soles";

            string codigoMoneda = monedaCompleta.Split('-')[0].Trim();

            string simbolo = "";
            switch (codigoMoneda)
            {
                case "PEN": simbolo = "S/"; break;
                case "USD": simbolo = "$"; break;
                case "EUR": simbolo = "€"; break;
                case "MXN": simbolo = "$"; break;
                default: simbolo = codigoMoneda; break;
            }

            TxtMontoTotal.Text = $"{simbolo} {total.ToString("N2")}";
        }
    }
}
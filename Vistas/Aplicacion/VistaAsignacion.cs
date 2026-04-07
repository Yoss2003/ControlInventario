using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Aplicacion
{
    public partial class VistaAsignacion : Form
    {
        private int idEmpleadoSeleccionado = 0;
        private DataTable dtStockDisponible;
        public VistaAsignacion()
        {
            InitializeComponent();
        }

        private void VistaAsignacion_Load(object sender, EventArgs e)
        {
            DtpFechaEntrega.Value = DateTime.Now;
            BtnAsignar.Enabled = false;

            AccionArticulo.UseColumnTextForButtonValue = true;
            AccionArticulo.Text = "Quitar";
            AccionArticulo.FlatStyle = FlatStyle.Flat;

            dtStockDisponible = ArticuloRepository.ListarArticulosDisponibles(UsuarioSesion.InventarioId);
        }

        private void TxtBuscarEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string dni = TxtBuscarEmpleado.Text.Trim();

                var empleado = EmpleadoRepository.ObtenerEmpleadoPorDni(dni);
                if (empleado != null)
                {
                    TxtNombreCompleto.Text = $"{empleado.Nombres} {empleado.Apellidos}";
                    TxtDNI.Text = empleado.DNI;
                    TxtCargo.Text = empleado.Cargo;
                    TxtArea.Text = empleado.Area;
                    idEmpleadoSeleccionado = empleado.Id;
                    TxtBuscarArticulo.Focus();
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                }
            }
        }

        private void BtnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }

        private void BuscarEmpleado()
        {
            string busqueda = TxtBuscarEmpleado.Text.Trim();
            if (string.IsNullOrEmpty(busqueda)) return;

            Empleados empleadoEncontrado = null;

            empleadoEncontrado = EmpleadoRepository.ObtenerEmpleadoPorDni(busqueda);

            if (empleadoEncontrado == null)
            {
                var todosLosEmpleados = EmpleadoRepository.ListarEmpleado();
                foreach (var emp in todosLosEmpleados)
                {
                    if (emp.Nombres.ToLower().Contains(busqueda.ToLower()) ||
                        emp.Apellidos.ToLower().Contains(busqueda.ToLower()))
                    {
                        empleadoEncontrado = emp;
                        break;
                    }
                }
            }

            if (empleadoEncontrado != null)
            {
                TxtNombreCompleto.Text = $"{empleadoEncontrado.Nombres} {empleadoEncontrado.Apellidos}";
                TxtDNI.Text = empleadoEncontrado.DNI;
                TxtCargo.Text = empleadoEncontrado.Cargo;
                TxtArea.Text = empleadoEncontrado.Area;
                idEmpleadoSeleccionado = empleadoEncontrado.Id;

                TxtBuscarEmpleado.Clear();
                TxtBuscarArticulo.Focus();
                ValidarBotonAsignar();
            }
            else
            {
                MessageBox.Show("No se encontró ningún empleado con ese DNI o Nombre.", "Búsqueda fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTarjetaEmpleado();
                TxtBuscarEmpleado.SelectAll();
            }
        }

        private void BtnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            VistaAgregarEmpleado vistaEmpleado = new VistaAgregarEmpleado();
            vistaEmpleado.ShowDialog();
        }
        private void LimpiarTarjetaEmpleado()
        {
            TxtNombreCompleto.Clear();
            TxtDNI.Clear();
            TxtCargo.Clear();
            TxtArea.Clear();
            idEmpleadoSeleccionado = 0;
            ValidarBotonAsignar();
        }

        private void TxtBuscarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarYAgregarArticulo();
                e.SuppressKeyPress = true;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = TxtBuscarArticulo.Text.Trim();
            if (string.IsNullOrEmpty(codigo)) return;

            DataTable dtArticulo = ArticuloRepository.ListarArticulosDisponibles(UsuarioSesion.InventarioId);

            DataRow[] filas = dtArticulo.Select($"Codigo = '{codigo}'");

            if (filas.Length > 0)
            {
                DgvArticulos.Rows.Add(filas[0]["Codigo"], filas[0]["Modelo"], "Disponible", "Quitar");
                TxtBuscarArticulo.Clear();
            }
            else
            {
                MessageBox.Show("Artículo no encontrado o no disponible.");
            }
        }

        private void BuscarYAgregarArticulo()
        {
            string codigoBusqueda = TxtBuscarArticulo.Text.Trim();
            if (string.IsNullOrEmpty(codigoBusqueda)) return;

            foreach (DataGridViewRow fila in DgvArticulos.Rows)
            {
                if (fila.Cells["CodigoArticulo"].Value?.ToString() == codigoBusqueda)
                {
                    MessageBox.Show("Este equipo ya está en la lista de asignación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtBuscarArticulo.Clear();
                    return;
                }
            }

            DataRow[] resultados = dtStockDisponible.Select($"Codigo = '{codigoBusqueda}'");

            if (resultados.Length > 0)
            {
                DataRow art = resultados[0];
                int idArticulo = Convert.ToInt32(art["Id"]);
                string codigo = art["Codigo"].ToString();
                string descripcion = $"{art["Modelo"]}";
                string estado = "Disponible";

                int rowIndex = DgvArticulos.Rows.Add(codigo, descripcion, estado);

                DgvArticulos.Rows[rowIndex].Tag = idArticulo;

                TxtBuscarArticulo.Clear();
                TxtBuscarArticulo.Focus();
                ValidarBotonAsignar();
            }
            else
            {
                MessageBox.Show("El código no existe o el equipo NO está disponible para asignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBuscarArticulo.SelectAll();
            }
        }

        private void DgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvArticulos.Columns[e.ColumnIndex].Name == "AccionArticulo")
            {
                DgvArticulos.Rows.RemoveAt(e.RowIndex);
                ValidarBotonAsignar();
            }
        }

        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            using (VistaBusquedaAvanzada buscador = new VistaBusquedaAvanzada())
            {
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    TxtBuscarArticulo.Text = buscador.CodigoSeleccionado;
                    BtnBuscar.PerformClick();
                }
            }
        }

        private void ValidarBotonAsignar()
        {
            BtnAsignar.Enabled = (idEmpleadoSeleccionado > 0 && DgvArticulos.Rows.Count > 0);
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            if (idEmpleadoSeleccionado == 0 || DgvArticulos.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un empleado y al menos un artículo.");
                return;
            }

            List<int> listaIds = new List<int>();
            foreach (DataGridViewRow row in DgvArticulos.Rows)
            {
                int idArt = (int)row.Tag;
                listaIds.Add(idArt);
            }

            DialogResult confirmacion = MessageBox.Show($"¿Confirmar la entrega de {listaIds.Count} equipo(s) a {TxtNombreCompleto.Text}?", "Confirmar Asignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try                
                {
                    MovimientoRepository.RegistrarAsignacionLote(
                        listaIds,
                        idEmpleadoSeleccionado,
                        TxtObservaciones.Text.Trim()
                    );

                    MessageBox.Show("Asignación completada y registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la asignación: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

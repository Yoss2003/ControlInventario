using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using ControlInventario.Vistas.Extras;
using System;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Aplicacion
{
    public partial class VistaRegistros : Form, ICargosRefrescable, IAreasRefrescable, IEstadoEmpleadosRefrescable
    {
        readonly int invetarioId = UsuarioSesion.InventarioId;
        private bool isEdit = false;
        public ComboBox CbCargoPublic => CbCargo;
        public ComboBox CbAreaPublic => CbArea;
        public ComboBox CbEstadoEmpleadosPublic => CbEstadoEmpleados;

        public VistaRegistros()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var listaEmpleados = EmpleadoRepository.ListarEmpleado();
                DgEmpleados.AutoGenerateColumns = false;
                DgEmpleados.DataSource = listaEmpleados;

                var ListaHistorial = ArticuloRepository.ListarArticulos(invetarioId);
                DgHistorial.AutoGenerateColumns = false;
                DgHistorial.DataSource = ListaHistorial;
            }
        }

        private void VistaRegistros_Load(object sender, EventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                var dtCate = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbCategoria, dtCate, "Nombre", "Id", "SELECCIONE");

                var dtCargo = CargoRepository.ListarCargos(con);
                RefreshService.RefrescarComboDT(CbCargo, dtCargo, "Nombre", "Id", "SELECCIONE");

                var dtArea = AreaRepository.ListarAreas(con);
                RefreshService.RefrescarComboDT(CbArea, dtArea, "Nombre", "Id", "SELECCIONE");

                var dtEstado = EstadoRepository.ListarEstadosEmpleados(con);
                RefreshService.RefrescarComboDT(CbEstadoEmpleados, dtEstado, "Nombre", "Id", "SELECCIONE");

                // Cargar datos empleado
                DgEmpleados.Columns["IdEmpleado"].DataPropertyName = "Id";
                DgEmpleados.Columns["NombreEmpleado"].DataPropertyName = "Nombres";
                DgEmpleados.Columns["ApellidoEmpleado"].DataPropertyName = "Apellidos";
                DgEmpleados.Columns["DniEmpleado"].DataPropertyName = "DNI";
                DgEmpleados.Columns["CargoEmpleado"].DataPropertyName = "Cargo";
                DgEmpleados.Columns["AreaEmpleado"].DataPropertyName = "Area";
                DgEmpleados.Columns["EstadoEmpleado"].DataPropertyName = "Estado";

                DgEmpleados.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
                DgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                //DgEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DgEmpleados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cargar datos articulos
                DgHistorial.Columns["IdArticulo"].DataPropertyName = "Id";
                DgHistorial.Columns["CodigoArticulo"].DataPropertyName = "Codigo";
                DgHistorial.Columns["CategoriaArticulo"].DataPropertyName = "Categoria";
                DgHistorial.Columns["AccionArticulo"].DataPropertyName = "Accion";
                DgHistorial.Columns["UsuarioArticulo"].DataPropertyName = "UsuarioActual";
                DgHistorial.Columns["FechaArticulo"].DataPropertyName = "FechaRegistro";
                DgHistorial.Columns["ObservacionArticulo"].DataPropertyName = "Observacion";

                DgHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DgHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                //DgHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DgHistorial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                CargarDatos();
            }
        }

        private void BtnNewCargo_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Cargo", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnNewArea_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Area", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnNewEstado_Click(object sender, EventArgs e)
        {
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("EstadoEmpleados", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            LimpiarVista(TipoAccion.Agregar);
            if (isEdit == false)
            {
                BtnAgregarEmpleado.Text = "Guardar";
                try
                {
                    using (var con = ConexionGlobal.ObtenerConexion())
                    {
                        con.Open();
                        Empleados emp = new Empleados
                        {
                            Nombres = TxtNombres.Text,
                            Apellidos = TxtApellidos.Text,
                            DNI = TxtDNI.Text,
                            IdCargo = Convert.ToInt32(CbCargo.SelectedIndex),
                            Cargo = CbCargo.Text,
                            IdArea = Convert.ToInt32(CbArea.SelectedIndex),
                            Area = CbArea.Text,
                            IdEstado = Convert.ToInt32(CbEstadoEmpleados.SelectedIndex),
                            Estado = CbEstadoEmpleados.Text
                        };

                        EmpleadoRepository.AgregarEmpleados(emp, con);
                    }
                }
                catch
                {

                }
            }
            else
            {
                BtnAgregarEmpleado.Text = "Actualizar";

                try
                {
                    using (var con = ConexionGlobal.ObtenerConexion())
                    {
                        con.Open();
                        Empleados emp = new Empleados
                        {
                            Nombres = TxtNombres.Text,
                            Apellidos = TxtApellidos.Text,
                            DNI = TxtDNI.Text,
                            IdCargo = Convert.ToInt32(CbCargo.SelectedIndex),
                            Cargo = CbCargo.Text,
                            IdArea = Convert.ToInt32(CbArea.SelectedIndex),
                            Area = CbArea.Text,
                            IdEstado = Convert.ToInt32(CbEstadoEmpleados.SelectedIndex),
                            Estado = CbEstadoEmpleados.Text
                        };

                        EmpleadoRepository.ActualizarEmpleados(emp);
                    }
                }
                catch
                {

                }
            }

            CargarDatos();
        }

        private void ChkFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFiltros.Checked)
            {
                DtFechaInicio.Enabled = true;
                DtFechaFin.Enabled = true;
                CbCategoria.Enabled = true;
            }
            else
            {
                DtFechaInicio.Enabled = false;
                DtFechaFin.Enabled = false;
                CbCategoria.Enabled = false;
            }
        }

        public enum TipoAccion
        {
            Aplicar,
            Agregar,
            Limpiar
        }

        private void LimpiarVista(TipoAccion accion)
        {
            switch (accion)
            {
                case TipoAccion.Aplicar:
                    DtFechaInicio.Value = DateTime.Now;
                    DtFechaFin.Value = DateTime.Now;
                    CbCategoria.SelectedIndex = 0;
                    break;

                case TipoAccion.Agregar:
                    TxtNombres.Text = "";
                    TxtApellidos.Text = "";
                    TxtDNI.Text = "";
                    CbCargo.SelectedIndex = 0;
                    CbArea.SelectedIndex = 0;
                    CbEstadoEmpleados.SelectedIndex = 0;
                    break;

                case TipoAccion.Limpiar:
                    DtFechaInicio.Value = DateTime.Now;
                    DtFechaFin.Value = DateTime.Now;
                    CbCategoria.SelectedIndex = 0;
                    TxtNombres.Text = "";
                    TxtApellidos.Text = "";
                    TxtDNI.Text = "";
                    CbCargo.SelectedIndex = 0;
                    CbArea.SelectedIndex = 0;
                    CbEstadoEmpleados.SelectedIndex = 0;
                    break;
            }
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            LimpiarVista(TipoAccion.Aplicar);
            if (DtFechaInicio.Value > DtFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string categoria = CbCategoria.SelectedIndex > 0 ? CbCategoria.SelectedItem.ToString() : null;

            var resultados = ArticuloRepository.BuscarArticulos(DtFechaInicio.Value, DtFechaFin.Value, categoria);

            DgHistorial.AutoGenerateColumns = false;
            DgHistorial.DataSource = resultados;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarVista(TipoAccion.Limpiar);
        }
    }
}

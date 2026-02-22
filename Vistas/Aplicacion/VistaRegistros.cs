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
                var lista = EmpleadoRepository.ListarEmpleado();
                DgEmpleados.AutoGenerateColumns = false;
                DgEmpleados.DataSource = lista;

                foreach (DataGridViewColumn col in DgEmpleados.Columns)
                {
                    Console.WriteLine(col.Name);
                }
            }
        }

        private void VistaRegistros_Load(object sender, EventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                var dtCate = CategoriaRepository.ListarCategorias(con);
                RefreshService.RefrescarComboDT(CbCategoria, dtCate, "Nombre", "Id", "SELECCIONE");

                var dtCargo = CargoRepository.ListarCargos(con);
                RefreshService.RefrescarComboDT(CbCargo, dtCargo, "Nombre", "Id", "SELECCIONE");

                var dtArea = AreaRepository.ListarAreas(con);
                RefreshService.RefrescarComboDT(CbArea, dtArea, "Nombre", "Id", "SELECCIONE");

                var dtEstado = EstadoRepository.ListarEstadosEmpleados(con);
                RefreshService.RefrescarComboDT(CbEstadoEmpleados, dtEstado, "Nombre", "Id", "SELECCIONE");

                DgEmpleados.Columns["IdEmpleado"].DataPropertyName = "Id";
                DgEmpleados.Columns["NombreEmpleado"].DataPropertyName = "Nombres";
                DgEmpleados.Columns["ApellidoEmpleado"].DataPropertyName = "Apellidos";
                DgEmpleados.Columns["DniEmpleado"].DataPropertyName = "DNI";
                DgEmpleados.Columns["CargoEmpleado"].DataPropertyName = "Cargo";
                DgEmpleados.Columns["AreaEmpleado"].DataPropertyName = "Area";
                DgEmpleados.Columns["EstadoEmpleado"].DataPropertyName = "Estado";

                DgEmpleados.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
                DgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DgEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DgEmpleados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            VistaAgregarComponentes vistaAgregar = new VistaAgregarComponentes("Estado", this);
            vistaAgregar.ShowDialog();
        }

        private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if(isEdit == false)
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
    }
}

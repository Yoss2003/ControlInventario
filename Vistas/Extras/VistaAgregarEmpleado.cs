using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaAgregarEmpleado : Form, IAreasRefrescable, ICargosRefrescable, IEstadoEmpleadosRefrescable
    {
        bool isEdit = false;
        public ComboBox CbAreaPublic => CbArea;
        public ComboBox CbCargoPublic => CbCargo;
        public ComboBox CbEstadoEmpleadosPublic => CbEstadoEmpleados;
        public VistaAgregarEmpleado()
        {
            InitializeComponent();
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

        private void LimpiarVista()
        {
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            TxtDNI.Text = "";
            CbCargo.SelectedIndex = 0;
            CbArea.SelectedIndex = 0;
            CbEstadoEmpleados.SelectedIndex = 0;
        }

        private void CargarDatos()
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var listaEmpleados = EmpleadoRepository.ListarEmpleado();
                DgEmpleados.AutoGenerateColumns = false;
                DgEmpleados.DataSource = listaEmpleados;
            }
        }

        private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show(
                        "Ocurrió un error al intentar agregar al empleado.\nPor favor, verifique los datos e intente nuevamente.",
                        "Error en registro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
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

                        int IdEmpleado = Convert.ToInt32(DgEmpleados.CurrentRow.Cells["IdEmpleado"].Value);

                        Empleados emp = new Empleados
                        {
                            Id = IdEmpleado,
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
                    MessageBox.Show(
                        "Ocurrió un error al intentar actualizar al empleado.\nPor favor, verifique los datos e intente nuevamente.",
                        "Error en registro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            LimpiarVista();
            CargarDatos();
        }

        private void VistaAgregarEmpleado_Load(object sender, EventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

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
                DgEmpleados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                CargarDatos();
            }
            ClassHelper.AplicarTema(this);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            var empleadoSeleccionado = DgEmpleados.CurrentRow.Cells["IdEmpleado"].Value;
            var nombreSeleccionado = DgEmpleados.CurrentRow.Cells["NombreEmpleado"].Value;

            var result = MessageBox.Show($"¿Desea eliminar al empleado {nombreSeleccionado}?",
                "Confirmación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            
            if (result == DialogResult.OK) {
                var emp = new Empleados
                {
                    Id = Convert.ToInt32(empleadoSeleccionado)
                };
                EmpleadoRepository.EliminarEmpleado(emp);
            }

            CargarDatos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgEmpleados_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (DgEmpleados.Focus())
            {
                BtnBorrar.Enabled = true;
            }
            else
            {
                BtnBorrar.Enabled = false;
            }
        }
        
        private void DgEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DgEmpleados.Rows[e.RowIndex];
                int idEmpleadoActual = Convert.ToInt32(DgEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
                TxtNombres.Text = fila.Cells["NombreEmpleado"].Value.ToString();
                TxtApellidos.Text = fila.Cells["ApellidoEmpleado"].Value.ToString();
                TxtDNI.Text = fila.Cells["DniEmpleado"].Value.ToString();
                CbArea.Text = fila.Cells["AreaEmpleado"].Value.ToString();
                CbCargo.Text = fila.Cells["CargoEmpleado"].Value.ToString();
                CbEstadoEmpleados.Text = fila.Cells["EstadoEmpleado"].Value.ToString();

                string valorvalorFilaArea = DgEmpleados.CurrentRow.Cells["IdEmpleado"].Value.ToString();
                string valorFilaEstado = DgEmpleados.CurrentRow.Cells["IdEmpleado"].Value.ToString();

                if (!ClassHelper.ValidarComboObsoleto(CbEstadoEmpleados, valorFilaEstado, "Estado"))
                {
                    ClassHelper.LimpiarCampoObsoletoBD("Empleado", "IdEstado", "Estado", idEmpleadoActual);
                }

                ValidarDatos(CbArea, fila.Cells["AreaEmpleado"].Value?.ToString(), "Area");



                ValidarDatos(CbCargo, fila.Cells["CargoEmpleado"].Value?.ToString(), "Cargo");

                isEdit = true;
                BtnAgregarEmpleado.Text = "Actualizar";
                Text = $"Editar empleado";
            }
        }

        private void ValidarDatos(ComboBox combo, string valorFila, string nombreCampo)
        {
            if (string.IsNullOrEmpty(valorFila))
            {
                combo.SelectedIndex = 0;
                return;
            }

            int indice = combo.FindStringExact(valorFila);

            if (indice != -1)
            {
                combo.SelectedIndex = indice;
            }
            else
            {
                combo.SelectedIndex = 0;

                MessageBox.Show($"El valor '{valorFila}' de {nombreCampo} ya no existe.\nSe restablecerá.",
                                "Dato Obsoleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Creamos el objeto con el ID del empleado seleccionado
                var id = DgEmpleados.CurrentRow.Cells["IdEmpleado"].Value;

                // Solo activamos el ID que falló
                switch (nombreCampo)
                {
                    case "Area":
                        EmpleadoRepository.LimpiarCampoObsoleto(Convert.ToInt32(id), "IdArea", "Area");
                        break;

                    case "Cargo":
                        EmpleadoRepository.LimpiarCampoObsoleto(Convert.ToInt32(id), "IdCargo", "Cargo");
                        break;

                    case "Estado":
                        EmpleadoRepository.LimpiarCampoObsoleto(Convert.ToInt32(id), "IdEstado", "Estado");
                        break;
                }
            }
        }
    }
}

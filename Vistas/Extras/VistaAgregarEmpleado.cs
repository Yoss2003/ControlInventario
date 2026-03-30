using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
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
            var listaEmpleados = EmpleadoRepository.ListarEmpleado();
            DgEmpleados.AutoGenerateColumns = false;
            DgEmpleados.DataSource = listaEmpleados;
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
                            IdCargo = Convert.ToInt32(CbCargo.SelectedValue),
                            IdArea = Convert.ToInt32(CbArea.SelectedValue),
                            IdEstado = Convert.ToInt32(CbEstadoEmpleados.SelectedValue)
                        };

                        if (Convert.ToInt32(CbCargo.SelectedValue) == 0 ||
                            Convert.ToInt32(CbArea.SelectedValue) == 0 ||
                            Convert.ToInt32(CbEstadoEmpleados.SelectedValue) == 0)
                        {
                            MessageBox.Show("Por favor, seleccione el Cargo, Área y Estado correctos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

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
                            IdCargo = Convert.ToInt32(CbCargo.SelectedValue),
                            IdArea = Convert.ToInt32(CbArea.SelectedValue),
                            IdEstado = Convert.ToInt32(CbEstadoEmpleados.SelectedValue)
                        };

                        if (Convert.ToInt32(CbCargo.SelectedValue) == 0 ||
                            Convert.ToInt32(CbArea.SelectedValue) == 0 ||
                            Convert.ToInt32(CbEstadoEmpleados.SelectedValue) == 0)
                        {
                            MessageBox.Show("Por favor, seleccione el Cargo, Área y Estado correctos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

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

                var dtCargo = ParametrosRepository.ListarParametros(con, "Cargo", UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbCargo, dtCargo, "Nombre", "Id", "SELECCIONE");

                var dtArea = ParametrosRepository.ListarParametros(con, "Area", UsuarioSesion.InventarioId);
                RefreshService.RefrescarComboDT(CbArea, dtArea, "Nombre", "Id", "SELECCIONE");

                var dtEstado = ParametrosRepository.ListarParametros(con, "EstadoEmpleados", UsuarioSesion.InventarioId);
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

                // Validamos el ID para que no explote
                if (fila.Cells["IdEmpleado"].Value == null) return;
                int idEmpleadoActual = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);

                // 1. Llenamos los TextBox de forma segura
                TxtNombres.Text = fila.Cells["NombreEmpleado"].Value?.ToString() ?? "";
                TxtApellidos.Text = fila.Cells["ApellidoEmpleado"].Value?.ToString() ?? "";
                TxtDNI.Text = fila.Cells["DniEmpleado"].Value?.ToString() ?? "";

                // 2. MAGIA PURA: Llenamos los ComboBoxes usando nuestro nuevo método unificado en 3 líneas
                ClassHelper.ProcesarComboSeguro(CbEstadoEmpleados, fila.Cells["EstadoEmpleado"].Value?.ToString(), "Estado", "IdEstado", idEmpleadoActual);
                ClassHelper.ProcesarComboSeguro(CbArea, fila.Cells["AreaEmpleado"].Value?.ToString(), "Area", "IdArea", idEmpleadoActual);
                ClassHelper.ProcesarComboSeguro(CbCargo, fila.Cells["CargoEmpleado"].Value?.ToString(), "Cargo", "IdCargo", idEmpleadoActual);

                // 3. Preparamos el formulario para el modo Edición
                isEdit = true;
                BtnAgregarEmpleado.Text = "Actualizar";
                Text = "Editar empleado";
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

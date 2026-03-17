using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using SixLabors.Fonts;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaAgregarComponentes : Form
    {
        public int CategoriaId { get; set; }
        private readonly object _vistaPrincipal;
        private readonly string tipoComponente;
        private bool isEdit = false;
        private string direccionTemporal = "";
        private string estadoTemporalTexto = "";
        private int estadoTemporalId = 1;

        private bool EsParametro => tipoComponente == "Cargo" || tipoComponente == "Area" ||
                                    tipoComponente == "EstadoEmpleados" || tipoComponente == "EstadoArticulos" ||
                                    tipoComponente == "Condicion" || tipoComponente == "Ubicacion" ||
                                    tipoComponente == "Contrato";

        public VistaAgregarComponentes(string componente, object vistaPadre)
        {
            InitializeComponent();
            tipoComponente = componente; 
            _vistaPrincipal = vistaPadre;
        }

        private void CargarDatos()
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                DgComponentes.AutoGenerateColumns = false;
                var lista = new DataTable();

                BtnGuardar.Text = isEdit ? "Actualizar" : "Guardar";

                if (EsParametro)
                    lista = ParametrosRepository.ListarParametros(con, tipoComponente);
                else if (tipoComponente == "Marca")
                    lista = MarcasRepository.ListarMarcas(con, CategoriaId);
                else if (tipoComponente == "Categoria")
                    lista = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
                else if (tipoComponente == "Proveedor")
                    lista = ProveedorRepository.ListarProveedor(con);

                DgComponentes.DataSource = lista;

                if (tipoComponente == "Proveedor")
                {
                    DgComponentes.Columns[1].HeaderText = "Ruc";
                    DgComponentes.Columns["NombreComponente"].DataPropertyName = "Ruc";
                    DgComponentes.Columns[2].HeaderText = "RazonSocial";
                    DgComponentes.Columns["DescripcionComponente"].DataPropertyName = "RazonSocial";
                }
                else
                {
                    DgComponentes.Columns["IdComponente"].DataPropertyName = "Id";
                    DgComponentes.Columns["NombreComponente"].DataPropertyName = "Nombre";
                    DgComponentes.Columns["DescripcionComponente"].DataPropertyName = "Descripcion";
                }

                DgComponentes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DgComponentes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DgComponentes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DgComponentes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            TxtNombreComponente.Text = "";
            TxtDescripcionComponente.Text = "";
            isEdit = false;
            Text = $"Agregar {tipoComponente}";
        }

        private void VistaAgregarComponentes_Load(object sender, EventArgs e)
        {
            BtnConsultarRUC.Visible = tipoComponente == "Proveedor";
            DgComponentes.AutoGenerateColumns = false;
            LblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Text = $"Agregar {tipoComponente}";
            LblNuevoComponente.Text = $"Nombre del {tipoComponente} nuevo:";
            LblDescripcionComponente.Text = $"Descripción del {tipoComponente} nuevo:";

            if (tipoComponente == "Cargo")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Area")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "EstadoEmpleados")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "EstadoArticulos")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Condicion")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Ubicacion")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Categoria")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Marca")
            {
                Text = $"Agregar {tipoComponente}";
                LblNuevoComponente.Text = $"Nombre de la {tipoComponente} nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    MarcasRepository.ListarMarcas(con, CategoriaId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Proveedor")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ProveedorRepository.ListarProveedor(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Contrato")
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ParametrosRepository.ListarParametros(con, tipoComponente);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }

            CargarDatos();
            ClassHelper.AplicarTema(this);
            LblFecha.Text = ClassHelper.FormatearFecha(DateTime.Now);
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreComponente.Text))
            {
                MessageBox.Show("El campo nombre no puede quedar vacío", "Información");
                return;
            }

            string nombreIngresado = TxtNombreComponente.Text.Trim();
            int idActual = isEdit ? Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value) : 0;

            // VERIFICAR DUPLICIDAD
            if (EsParametro)
            {
                if (ClassHelper.ExisteParametroDuplicado(tipoComponente, nombreIngresado, idActual))
                {
                    MessageBox.Show($"El {tipoComponente} '{nombreIngresado}' ya está registrado.", "Duplicado detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                string nombreTablaBD = tipoComponente == "Categoria" ? "Categorias" : (tipoComponente == "Marca" ? "Marcas" : "Proveedores");
                string nombreColumnaBD = tipoComponente == "Proveedor" ? "RazonSocial" : "Nombre";

                if (tipoComponente != "Proveedor" && ClassHelper.ExisteComponenteDuplicado(nombreTablaBD, nombreIngresado, idActual, nombreColumnaBD))
                {
                    MessageBox.Show($"El {tipoComponente} '{nombreIngresado}' ya está registrado.", "Duplicado detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tipoComponente == "Proveedor")
                {
                    string razonIngresada = TxtDescripcionComponente.Text.Trim();
                    if (ClassHelper.ExisteComponenteDuplicado("Proveedores", nombreIngresado, idActual, "RUC"))
                    {
                        MessageBox.Show($"El RUC '{nombreIngresado}' ya está registrado.", "RUC Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ClassHelper.ExisteComponenteDuplicado("Proveedores", razonIngresada, idActual, "RazonSocial"))
                    {
                        MessageBox.Show($"La empresa '{razonIngresada}' ya se encuentra registrada.", "Razón Social Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                if (EsParametro)
                {
                    var param = new Parametros
                    {
                        Id = idActual,
                        InventarioId = UsuarioSesion.InventarioId,
                        TipoParametro = tipoComponente,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };

                    if (isEdit)
                    {
                        ParametrosRepository.ActualizarParametros(param);
                        LogsRepository.InsertarLogs("Parámetros", "Actualizar", $"Se actualizó el {tipoComponente}: {param.Nombre}");
                    }
                    else
                    {
                        ParametrosRepository.InsertarParametros(param);
                        LogsRepository.InsertarLogs("Parámetros", "Crear", $"Se registró un {tipoComponente}: {param.Nombre}");
                    }
                }
                else if (tipoComponente == "Categoria")
                {
                    var cat = new Categoria
                    {
                        Id = idActual,
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text,
                        FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy"),
                        UsuarioCreacion = UsuarioSesion.NombreUsuario
                    };

                    if (isEdit) CategoriaRepository.ActualizarCategoria(cat);
                    else
                    {
                        long nuevoId = CategoriaRepository.AgregarCategoría(cat);
                        if (nuevoId != -1)
                        {
                            cat.Id = Convert.ToInt32(nuevoId);
                            var helper = new ClassHelper((VistaInventario)_vistaPrincipal);
                            helper.AgregarBotonCategoria(cat.Nombre, cat.Id);
                        }
                    }
                }
                else if (tipoComponente == "Marca")
                {
                    var marca = new Marcas
                    {
                        Id = idActual,
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        CategoriasId = CategoriaId
                    };
                    if (isEdit) MarcasRepository.ActualizarMarca(marca);
                    else MarcasRepository.InsertarMarca(marca);
                }
                else if (tipoComponente == "Proveedor")
                {
                    if (!isEdit && TxtNombreComponente.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Por favor ingrese un RUC válido de 11 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!isEdit)
                    {
                        var empresa = await ApiHelper.ConsultarRucAsync(TxtNombreComponente.Text.Trim());
                        if (empresa != null)
                        {
                            var prov = new Proveedor
                            {
                                InventarioId = UsuarioSesion.InventarioId,
                                Ruc = empresa.numeroDocumento,
                                RazonSocial = empresa.nombre,
                                NombreContacto = "",
                                Telefono = "",
                                Correo = "",
                                Direccion = $"{empresa.direccion} - {empresa.distrito}, {empresa.provincia}",
                                IdEstado = ApiHelper.MapearEstadoSunat(empresa.estado)
                            };
                            ProveedorRepository.InsertarProveedor(prov);
                        }
                    }
                    else
                    {
                        var prov = new Proveedor { Id = idActual, Ruc = TxtNombreComponente.Text, RazonSocial = TxtDescripcionComponente.Text };
                        ProveedorRepository.ActualizarProveedor(prov);
                    }
                }
            }

            isEdit = false;
            CargarDatos();
        }

        private void DgComponentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DgComponentes.Rows[e.RowIndex];
                TxtNombreComponente.Text = fila.Cells["NombreComponente"].Value?.ToString();
                TxtDescripcionComponente.Text = fila.Cells["DescripcionComponente"].Value?.ToString();

                isEdit = true;
                BtnGuardar.Text = "Actualizar";
                Text = $"Editar {tipoComponente}";
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VistaAgregarComponentes_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                if (tipoComponente == "Cargo" && _vistaPrincipal is ICargosRefrescable cargosVista)
                    RefreshService.RefrescarComboDT(cargosVista.CbCargoPublic, ParametrosRepository.ListarParametros(con, "Cargo"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Area" && _vistaPrincipal is IAreasRefrescable areasVista)
                    RefreshService.RefrescarComboDT(areasVista.CbAreaPublic, ParametrosRepository.ListarParametros(con, "Area"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "EstadoEmpleados" && _vistaPrincipal is IEstadoEmpleadosRefrescable estEmpVista)
                    RefreshService.RefrescarComboDT(estEmpVista.CbEstadoEmpleadosPublic, ParametrosRepository.ListarParametros(con, "EstadoEmpleados"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "EstadoArticulos" && _vistaPrincipal is IEstadoArticulosRefrescable estArtVista)
                    RefreshService.RefrescarComboDT(estArtVista.CbEstadoArticulosPublic, ParametrosRepository.ListarParametros(con, "EstadoArticulos"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Ubicacion" && _vistaPrincipal is IUbicacionRefrescable ubiVista)
                    RefreshService.RefrescarComboDT(ubiVista.CbUbicacionPublic, ParametrosRepository.ListarParametros(con, "Ubicacion"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Condicion" && _vistaPrincipal is ICondicionRefrescable condVista)
                    RefreshService.RefrescarComboDT(condVista.CbCondicionPublic, ParametrosRepository.ListarParametros(con, "Condicion"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Contrato" && _vistaPrincipal is ITipoContratoRefrescable contVista)
                    RefreshService.RefrescarComboDT(contVista.CbTipoContratoPublic, ParametrosRepository.ListarParametros(con, "Contrato"), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Categoria" && _vistaPrincipal is ICategoriasRefrescable categoriasVista)
                    RefreshService.RefrescarComboDT(categoriasVista.CbCategoriasPublic, CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Marca" && _vistaPrincipal is IMarcasRefrescable marcasVista)
                    RefreshService.RefrescarComboDT(marcasVista.CbMarcasPublic, MarcasRepository.ListarMarcas(con, CategoriaId), "Nombre", "Id", "SELECCIONE");

                else if (tipoComponente == "Proveedor" && _vistaPrincipal is IProveedoreRefrescable provVista)
                    RefreshService.RefrescarComboDT(provVista.CbProveedorPublic, ProveedorRepository.ListarProveedor(con), "Nombre", "Id", "SELECCIONE");

                if (_vistaPrincipal is VistaInventario inventarioVista)
                {
                    inventarioVista.CargarCategorias();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"¿Desea eliminar el {tipoComponente} seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int idEliminar = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value);
                string nombreEliminar = DgComponentes.CurrentRow.Cells["NombreComponente"].Value?.ToString();

                if (EsParametro)
                {
                    ParametrosRepository.EliminarParametros(idEliminar);
                }
                else if (tipoComponente == "Categoria")
                {
                    CategoriaRepository.EliminarCategoria(new Categoria { Id = idEliminar });
                    var helper = new ClassHelper((VistaInventario)_vistaPrincipal);
                    helper.EliminarBotonCategoria(idEliminar);
                }
                else if (tipoComponente == "Marca") MarcasRepository.EliminarMarca(new Marcas { Id = idEliminar });
                else if (tipoComponente == "Proveedor") ProveedorRepository.EliminarProveedor(new Proveedor { Id = idEliminar });

                LogsRepository.InsertarLogs(tipoComponente, "Eliminar", $"Se eliminó: {nombreEliminar}");
                CargarDatos();
            }
        }

        private void DgComponentes_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            BtnEliminar.Enabled = DgComponentes.Focus();
        }

        private async void BtnConsultarRUC_Click(object sender, EventArgs e)
        {
            string ruc = TxtNombreComponente.Text.Trim();
            var empresa = await ApiHelper.ConsultarRucAsync(ruc);

            if (empresa != null)
            {
                TxtDescripcionComponente.Text = empresa.nombre;
                direccionTemporal = $"{empresa.direccion} - {empresa.distrito}, {empresa.provincia}";
                estadoTemporalTexto = empresa.estado;
                estadoTemporalId = ApiHelper.MapearEstadoSunat(empresa.estado);
            }
        }
    }
}

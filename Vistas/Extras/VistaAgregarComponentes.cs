using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using SixLabors.Fonts;
using System;
using System.Data;
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

                // Actualizar el texto del botón según el modo (editar o agregar)
                if (isEdit == true)
                    BtnGuardar.Text = "Actualizar";
                else
                    BtnGuardar.Text = "Guardar";

                // Cargar datos según el tipo de componente
                if (tipoComponente == "Cargo")
                    lista = CargoRepository.ListarCargos(con);

                else if (tipoComponente == "Area")
                    lista = AreaRepository.ListarAreas(con);

                else if (tipoComponente == "EstadoEmpleados")
                    lista = EstadoRepository.ListarEstadosEmpleados(con);

                else if (tipoComponente == "EstadoArticulos")
                    lista = EstadoRepository.ListarEstadosArticulos(con);

                else if (tipoComponente == "Condicion")
                    lista = CondicionRepository.ListarCondicion(con);

                else if (tipoComponente == "Ubicacion")
                    lista = UbicacionRepository.ListarUbicacion(con);

                else if (tipoComponente == "Marca")
                    lista = MarcasRepository.ListarMarcas(con, CategoriaId);

                else if (tipoComponente == "Categoria")
                    lista = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);

                else if (tipoComponente == "Proveedor")
                    lista = ProveedorRepository.ListarProveedor(con);

                // Asignar la lista al DataGridView
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
                
                // Mapear propiedades a columnas creadas manualmente
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

            var text = $"Agregar {tipoComponente}";

            if (tipoComponente == "Cargo")
                Text = text;
            else if (tipoComponente == "Area")
                Text = text;
            else if (tipoComponente == "EstadoEmpleados" || tipoComponente == "EstadoArticulos")
                Text = text;
            else if (tipoComponente == "Condición")
                Text = text;
            else if (tipoComponente == "Ubicación")
                Text = text;
            else if (tipoComponente == "Marca")
                Text = text;
            else if (tipoComponente == "Proveedor")
                Text = text;
        }

        private void VistaAgregarComponentes_Load(object sender, EventArgs e)
        {
            BtnConsultarRUC.Visible = false;
            DgComponentes.AutoGenerateColumns = false;
            LblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (tipoComponente == "Cargo")
            {
                Text = "Agregar Cargo";
                LblNuevoComponente.Text = "Nombre del cargo nuevo:";
                LblDescripcionComponente.Text = "Descripción del cargo nuevo:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    CargoRepository.ListarCargos(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Area")
            {
                Text = "Agregar Área";
                LblNuevoComponente.Text = "Nombre del área nueva";
                LblDescripcionComponente.Text = "Descripción del área nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    AreaRepository.ListarAreas(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "EstadoEmpleados")
            {
                Text = "Agregar Estado";
                LblNuevoComponente.Text = "Nombre del estado nuevo:";
                LblDescripcionComponente.Text = "Descripción del estado nuevo:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    EstadoRepository.ListarEstadosEmpleados(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "EstadoArticulos")
            {
                Text = "Agregar Estado";
                LblNuevoComponente.Text = "Nombre del estado nuevo:";
                LblDescripcionComponente.Text = "Descripción del estado nuevo:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    EstadoRepository.ListarEstadosArticulos(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Condicion")
            {
                Text = "Agregar condicion";
                LblNuevoComponente.Text = "Nombre de la condicion nueva:";
                LblDescripcionComponente.Text = "Descripción de la condicion nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    CondicionRepository.ListarCondicion(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Ubicacion")
            {
                Text = "Agregar Ubicacion";
                LblNuevoComponente.Text = "Nombre de la Ubicacion nueva:";
                LblDescripcionComponente.Text = "Descripción de la Ubicacion nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    UbicacionRepository.ListarUbicacion(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Categoria")
            {
                Text = "Agregar categoria";
                LblNuevoComponente.Text = "Nombre de la categoria nueva:";
                LblDescripcionComponente.Text = "Descripción de la categoria nueva:";
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
                BtnConsultarRUC.Visible = true;
                Text = $"Agregar {tipoComponente}";
                LblNuevoComponente.Text = $"Nombre del {tipoComponente} nuevo:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    ProveedorRepository.ListarProveedor(con);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
                CargarDatos();
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtNombreComponente == null)
            {
                MessageBox.Show("El campo nombre no puede quedar vacío", "Información");
                return;
            }

            string nombreIngresado = TxtNombreComponente.Text.Trim();
            int idActual = isEdit ? Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value) : 0;
            string nombreTablaBD = "";
            string nombreColumnaBD = "Nombre";

            // VERIFICAR DUPLICIDAD
            if (tipoComponente == "Cargo") nombreTablaBD = "Cargos";
            else if (tipoComponente == "Area") nombreTablaBD = "Areas";
            else if (tipoComponente == "Categoria") nombreTablaBD = "Categorias";
            else if (tipoComponente == "EstadoEmpleados") nombreTablaBD = "EstadoEmpleados";
            else if (tipoComponente == "EstadoArticulos") nombreTablaBD = "EstadoArticulos";
            else if (tipoComponente == "Ubicacion") nombreTablaBD = "Ubicaciones";
            else if (tipoComponente == "Marca") nombreTablaBD = "Marcas";
            else if (tipoComponente == "Proveedor")
            {
                nombreTablaBD = "Proveedores";
                nombreColumnaBD = "RazonSocial";
            }

            if (!string.IsNullOrEmpty(nombreTablaBD))
            {
                if (ClassHelper.ExisteComponenteDuplicado(nombreTablaBD, nombreIngresado, idActual, nombreColumnaBD))
                {
                    MessageBox.Show($"El {tipoComponente} '{nombreIngresado}' ya está registrado.",
                        "Duplicado detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tipoComponente == "Proveedor")
                {
                    string rucIngresado = TxtNombreComponente.Text.Trim();
                    string razonIngresada = TxtDescripcionComponente.Text.Trim();

                    if (ClassHelper.ExisteComponenteDuplicado(nombreTablaBD, rucIngresado, idActual, "RUC"))
                    {
                        MessageBox.Show($"El RUC '{rucIngresado}' ya está registrado en otro proveedor.",
                            "RUC Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (ClassHelper.ExisteComponenteDuplicado("Proveedores", razonIngresada, 0, "RazonSocial"))
                    {
                        MessageBox.Show($"La empresa '{razonIngresada}' ya se encuentra registrada.", "Razón Social Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            
            // MODO EDICIÓN
            if (isEdit == true)
            {
                if (tipoComponente == "Cargo")
                {
                    var car = new Cargo
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    CargoRepository.ActualizarCargo(car);
                }
                else if (tipoComponente == "Area")
                {
                    var are = new Area
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    AreaRepository.ActualizarArea(are);
                }
                else if (tipoComponente == "EstadoEmpleados")
                {
                    var est = new Estado
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    EstadoRepository.ActualizarEstadoEmpleados(est);
                }
                else if (tipoComponente == "EstadoArticulos")
                {
                    var est = new Estado
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    EstadoRepository.ActualizarEstadoArticulos(est);
                }
                else if (tipoComponente == "Condicion")
                {
                    var cond = new Condicion
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    CondicionRepository.ActualizarCondicion(cond);
                }
                else if (tipoComponente == "Ubicacion")
                {
                    var ubi = new Ubicacion
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    UbicacionRepository.ActualizarUbicacion(ubi);
                }
                else if (tipoComponente == "Categoria")
                {
                    var cat = new Categoria
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text,
                        FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy"),
                        UsuarioCreacion = UsuarioSesion.NombreUsuario
                    };

                    CategoriaRepository.ActualizarCategoria(cat);
                }
                else if (tipoComponente == "Marca")
                {
                    var marca = new Marcas
                    {
                        Nombre = TxtNombreComponente.Text,
                        CategoriasId = CategoriaId,
                        Categoria = tipoComponente
                    };
                    MarcasRepository.ActualizarMarca(marca);
                }
                else if (tipoComponente == "Proveedor")
                {
                    var prov = new Proveedor
                    {
                        Ruc = TxtNombreComponente.Text,
                        RazonSocial = TxtNombreComponente.Text
                    };
                    ProveedorRepository.ActualizarProveedor(prov);
                }
            }
            // MODO INSERCIÓN
            else
            {
                if (tipoComponente == "Cargo")
                {
                    var car = new Cargo
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    CargoRepository.InsertarCargo(car);
                }
                else if (tipoComponente == "Area")
                {
                    var are = new Area
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    AreaRepository.InsertarArea(are);
                }
                else if (tipoComponente == "EstadoEmpleados")
                {
                    var est = new Estado
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    EstadoRepository.InsertarEstadoEmpleados(est);
                }
                else if (tipoComponente == "EstadoArticulos")
                {
                    var est = new Estado
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    EstadoRepository.InsertarEstadoArticulos(est);
                }
                else if (tipoComponente == "Condicion")
                {
                    var cond = new Condicion
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    CondicionRepository.InsertarCondicion(cond);
                }
                else if (tipoComponente == "Ubicacion")
                {
                    var ubi = new Ubicacion
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    UbicacionRepository.InsertarUbicacion(ubi);
                }
                else if (tipoComponente == "Categoria")
                {
                    var cat = new Categoria
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text,
                        FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy"),
                        UsuarioCreacion = UsuarioSesion.NombreUsuario
                    };

                    long nuevoId = CategoriaRepository.AgregarCategoría(cat);

                    if (nuevoId != -1)
                    {
                        cat.Id = Convert.ToInt32(nuevoId);
                        var helper = new ClassHelper((VistaInventario)_vistaPrincipal);
                        helper.AgregarBotonCategoria(cat.Nombre, cat.Id);
                    }
                }
                else if (tipoComponente == "Marca")
                {
                    var marca = new Marcas
                    {
                        InventarioId = UsuarioSesion.InventarioId,
                        Nombre = TxtNombreComponente.Text,
                        CategoriasId = CategoriaId,
                        Categoria = tipoComponente
                    };
                    MarcasRepository.InsertarMarca(marca);
                }
                else if (tipoComponente == "Proveedor")
                {
                    string rucIngresado = TxtNombreComponente.Text.Trim();

                    if (rucIngresado.Length != 11)
                    {
                        MessageBox.Show("Por favor ingrese un RUC válido de 11 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var empresa = await ApiHelper.ConsultarRucAsync(rucIngresado);

                    if (empresa != null)
                    {
                        TxtDescripcionComponente.Text = empresa.nombre;

                        int idEstado = ApiHelper.MapearEstadoSunat(empresa.estado);

                        var prov = new Proveedor
                        {
                            InventarioId = UsuarioSesion.InventarioId,
                            Ruc = empresa.numeroDocumento,
                            RazonSocial = empresa.nombre,
                            NombreContacto = "",
                            Telefono = "",
                            Correo = "",
                            Direccion = $"{empresa.direccion} - {empresa.distrito}, {empresa.provincia}",
                            IdEstado = idEstado,
                            Estado = empresa.estado
                        };

                        ProveedorRepository.InsertarProveedor(prov);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información del RUC en SUNAT.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            isEdit = false;
            CargarDatos();
        }

        private void DgComponentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow fila = DgComponentes.Rows[e.RowIndex];
                TxtNombreComponente.Text = fila.Cells["NombreComponente"].Value.ToString();
                TxtDescripcionComponente.Text = fila.Cells["DescripcionComponente"].Value.ToString();
                
                isEdit = true;
                BtnGuardar.Text = "Actualizar";

                var text = $"Editar {tipoComponente}";

                if (tipoComponente == "Cargo")
                    Text = text;
                else if (tipoComponente == "Area")
                    Text = text;
                else if (tipoComponente == "EstadoEmpleados" || tipoComponente == "EstadoArticulos")
                    Text = text;
                else if (tipoComponente == "Condicion")
                    Text = text;
                else if (tipoComponente == "Ubicacion")
                    Text = text;
                else if (tipoComponente == "Proveedor")
                    Text = text;
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
                {
                    var dtCargo = CargoRepository.ListarCargos(con);
                    RefreshService.RefrescarComboDT(cargosVista.CbCargoPublic, dtCargo, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "Area" && _vistaPrincipal is IAreasRefrescable areasVista)
                {
                    var dtArea = AreaRepository.ListarAreas(con);
                    RefreshService.RefrescarComboDT(areasVista.CbAreaPublic, dtArea, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "EstadoEmpleados" && _vistaPrincipal is IEstadoEmpleadosRefrescable estadosEmpleadosVista)
                {
                    var dtEstado = EstadoRepository.ListarEstadosEmpleados(con);
                    RefreshService.RefrescarComboDT(estadosEmpleadosVista.CbEstadoEmpleadosPublic, dtEstado, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "EstadoArticulos" && _vistaPrincipal is IEstadoArticulosRefrescable estadosArticulosVista)
                {
                    var dtEstado = EstadoRepository.ListarEstadosArticulos(con);
                    RefreshService.RefrescarComboDT(estadosArticulosVista.CbEstadoArticulosPublic, dtEstado, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "Categoria" && _vistaPrincipal is ICategoriasRefrescable categoriasVista)
                {
                    var dtCategoria = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
                    RefreshService.RefrescarComboDT(categoriasVista.CbCategoriasPublic, dtCategoria, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "Ubicacion" && _vistaPrincipal is IUbicacionRefrescable ubicacionVista)
                {
                    var dtUbicacion = UbicacionRepository.ListarUbicacion(con);
                    RefreshService.RefrescarComboDT(ubicacionVista.CbUbicacionPublic, dtUbicacion, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "Condicion" && _vistaPrincipal is ICondicionRefrescable condicionVista)
                {
                    var dtCondicion = CondicionRepository.ListarCondicion(con);
                    RefreshService.RefrescarComboDT(condicionVista.CbCondicionPublic, dtCondicion, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "Marca" && _vistaPrincipal is IMarcasRefrescable marcasVista)
                { 
                    var dtMarca = MarcasRepository.ListarMarcas(con, CategoriaId); 
                    RefreshService.RefrescarComboDT(marcasVista.CbMarcasPublic, dtMarca, "Nombre", "Id", "SELECCIONE"); 
                }
                else if (tipoComponente == "Proveedor" && _vistaPrincipal is IProveedoreRefrescable proveedorVista)
                {
                    var dtProveedor = ProveedorRepository.ListarProveedor(con);
                    RefreshService.RefrescarComboDT(proveedorVista.CbProveedorPublic, dtProveedor, "Nombre", "Id", "SELECCIONE");
                }

                if (_vistaPrincipal is VistaInventario inventarioVista)
                {
                    inventarioVista.CargarArticulos();
                }
                CargarDatos();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"¿Desea eliminar el {tipoComponente} seleccionado?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (tipoComponente == "Cargo")
                {
                    var car = new Cargo
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    CargoRepository.EliminarCargo(car);
                }
                else if (tipoComponente == "Area")
                {
                    var are = new Area
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    AreaRepository.EliminarArea(are);
                }
                else if (tipoComponente == "Categoria")
                {
                    var cat = new Categoria
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    CategoriaRepository.EliminarCategoria(cat);

                    var helper = new ClassHelper((VistaInventario)_vistaPrincipal);
                    helper.EliminarBotonCategoria(cat.Id);
                }
                else if (tipoComponente == "Condicion")
                {
                    var cond = new Condicion
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    CondicionRepository.EliminarCondicion(cond);
                }
                else if (tipoComponente == "Ubicacion")
                {
                    var ubi = new Ubicacion
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    UbicacionRepository.EliminarUbicacion(ubi);
                }
                else if (tipoComponente == "Marca")
                {
                    var mar = new Marcas
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    MarcasRepository.EliminarMarca(mar);
                }
                else if (tipoComponente == "Proveedor")
                {
                    var prov = new Proveedor
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value)
                    };
                    ProveedorRepository.EliminarProveedor(prov);
                }
            }
            else
            {
                MessageBox.Show($"{tipoComponente} no eliminado.", "Información", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
            }

            CargarDatos();
        }

        private void DgComponentes_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if(DgComponentes.Focus())
            {
                BtnEliminar.Enabled = true;
            }
            else
            {
                BtnEliminar.Enabled = false;
            }
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

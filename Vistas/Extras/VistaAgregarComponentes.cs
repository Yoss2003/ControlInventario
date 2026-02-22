using ControlInventario.Database;
using ControlInventario.Modelo.Interface;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
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

                if(isEdit == true)
                    BtnGuardar.Text = "Actualizar";
                else
                    BtnGuardar.Text = "Guardar";

                if (tipoComponente == "Cargo")
                {
                    var lista = CargoRepository.ListarCargos(con);
                    DgComponentes.AutoGenerateColumns = false;
                    DgComponentes.DataSource = lista;
                }
                else if (tipoComponente == "Area")
                {
                    var lista = AreaRepository.ListarAreas(con);
                    DgComponentes.AutoGenerateColumns = false;
                    DgComponentes.DataSource = lista;
                }
                else if (tipoComponente == "Estado")
                {
                    var lista = EstadoRepository.ListarEstadosEmpleados(con);
                    DgComponentes.AutoGenerateColumns = false;
                    DgComponentes.DataSource = lista;
                }
                else if(tipoComponente == "Laptops" || tipoComponente == "Computadoras" || tipoComponente == "Celular" || tipoComponente == "Monitor" || tipoComponente == "Celulares")
                {
                    var lista = MarcasRepository.ListarMarcas(con, CategoriaId);
                    DgComponentes.AutoGenerateColumns = false;
                    DgComponentes.DataSource = lista;
                }

                // Mapear propiedades a columnas creadas manualmente
                DgComponentes.Columns["IdComponente"].DataPropertyName = "Id";
                DgComponentes.Columns["NombreComponente"].DataPropertyName = "Nombre";
                DgComponentes.Columns["DescripcionComponente"].DataPropertyName = "Descripcion";

                DgComponentes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DgComponentes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DgComponentes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            TxtNombreComponente.Text = "";
            TxtDescripcionComponente.Text = "";

            isEdit = false;

            if (tipoComponente == "Cargo")
                Text = "Agregar Cargo";
            else if (tipoComponente == "Area")
                Text = "Agregar Área";
            else if (tipoComponente == "Estado")
                Text = "Agregar Estado";
        }

        private void VistaAgregarComponentes_Load(object sender, EventArgs e)
        {
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
            else if (tipoComponente == "Estado")
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
            else if (tipoComponente == "Laptops")
            {
                Text = "Agregar marca de laptop";
                LblNuevoComponente.Text = "Marca de laptop nueva:";
                LblDescripcionComponente.Text = "Descripción de la marca nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    MarcasRepository.ListarMarcas(con, CategoriaId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if(tipoComponente == "Computadoras")
            {
                Text = "Agregar marca de computadora";
                LblNuevoComponente.Text = "Marca de computadora nueva:";
                LblDescripcionComponente.Text = "Descripción de la marca nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    MarcasRepository.ListarMarcas(con, CategoriaId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Celular")
            {
                Text = "Agregar marca de celular";
                LblNuevoComponente.Text = "Marca del celular nueva:";
                LblDescripcionComponente.Text = "Descripción de la marca nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    MarcasRepository.ListarMarcas(con, CategoriaId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Monitor")
            {
                Text = "Agregar marca de monitores";
                LblNuevoComponente.Text = "Marca de monitor nueva:";
                LblDescripcionComponente.Text = "Descripción de la marca nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    MarcasRepository.ListarMarcas(con, CategoriaId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            else if (tipoComponente == "Celulares")
            {
                Text = "Agregar marca de celular";
                LblNuevoComponente.Text = "Marca de celular nueva:";
                LblDescripcionComponente.Text = "Descripción de la marca nueva:";
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    MarcasRepository.ListarMarcas(con, CategoriaId);
                    DataTable dt = new DataTable();
                    DgComponentes.DataSource = dt;
                }
            }
            CargarDatos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(isEdit == true)
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
                else if (tipoComponente == "Estado")
                {
                    var est = new Estado
                    {
                        Id = Convert.ToInt32(DgComponentes.CurrentRow.Cells["IdComponente"].Value),
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    EstadoRepository.ActualizarEstadoEmpleados(est);
                }
            }
            else
            {
                if (tipoComponente == "Cargo")
                {
                    var car = new Cargo
                    {
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    CargoRepository.InsertarCargo(car);
                }
                else if (tipoComponente == "Area")
                {
                    var are = new Area
                    {
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    AreaRepository.InsertarArea(are);
                }
                else if (tipoComponente == "Estado")
                {
                    var est = new Estado
                    {
                        Nombre = TxtNombreComponente.Text,
                        Descripcion = TxtDescripcionComponente.Text
                    };
                    EstadoRepository.InsertarEstadoEmpleados(est);
                }
                else if (tipoComponente == "Laptops" || tipoComponente == "Computadoras" || tipoComponente == "Celular" || tipoComponente == "Monitor" || tipoComponente == "Celulares")
                {
                    var marca = new Marcas
                    {
                        Nombre = TxtNombreComponente.Text,
                        //Descripcion = TxtDescripcionComponente.Text,
                        CategoriasId = CategoriaId,
                        Categoria = tipoComponente
                    };
                    MarcasRepository.InsertarMarca(marca);
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

                if (tipoComponente == "Cargo")
                    Text = "Editar Cargo";
                else if (tipoComponente == "Area")
                    Text = "Editar Área";
                else if (tipoComponente == "Estado")
                    Text = "Editar Estado";
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
                else if (tipoComponente == "Estado" && _vistaPrincipal is IEstadoEmpleadosRefrescable estadosVista)
                {
                    var dtEstado = EstadoRepository.ListarEstadosEmpleados(con);
                    RefreshService.RefrescarComboDT(estadosVista.CbEstadoEmpleadosPublic, dtEstado, "Nombre", "Id", "SELECCIONE");
                }
                else if (tipoComponente == "Laptops" && _vistaPrincipal is IMarcasRefrescable estadosMarca)
                {
                    var dtMarca = MarcasRepository.ListarMarcas(con, CategoriaId);
                    RefreshService.RefrescarComboDT(estadosMarca.CbMarcasPublic, dtMarca, "Nombre", "Id", "SELECCIONE");
                }
            }
        }
    }
}

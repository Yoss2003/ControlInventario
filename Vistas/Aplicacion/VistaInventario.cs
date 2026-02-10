using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Utilidades;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas
{
    public partial class VistaInventario : Form
    {
        private readonly Empleado empleadoActual;
        private Inventario inventarioActual;

        public VistaInventario(Empleado emp, Inventario inventario)
        {
            InitializeComponent();
            empleadoActual = emp;
            inventarioActual = inventario;
            
            var customTabs = new CustomTabControl();
                        
            customTabs.Name = TbArticulos.Name;
            customTabs.Dock = TbArticulos.Dock;
            customTabs.Location = TbArticulos.Location;
            customTabs.Size = TbArticulos.Size;

            foreach (TabPage tab in TbArticulos.TabPages)
            {
                customTabs.TabPages.Add(tab);
            }

            // Guardar el contenedor padre original
            var parent = TbArticulos.Parent;

            // Quitar el TabControl original
            parent.Controls.Remove(TbArticulos);

            // Reemplazar la referencia
            TbArticulos = customTabs;

            // Agregar el nuevo control al mismo contenedor
            parent.Controls.Add(TbArticulos);

            TbArticulos.Alignment = TabAlignment.Left;
            TbArticulos.DrawMode = TabDrawMode.Normal;

            TbArticulos.DrawItem += (s, e) =>
            {
                TabPage page = TbArticulos.TabPages[e.Index];
                Rectangle rect = e.Bounds;

                // Guardar estado gráfico
                e.Graphics.TranslateTransform(rect.Left, rect.Top + rect.Height);
                e.Graphics.RotateTransform(-90); // -90 = vertical hacia la derecha

                // Dibujar texto con TextRenderer (más grueso, igual al estilo nativo)
                TextRenderer.DrawText(
                    e.Graphics,
                    page.Text,
                    TbArticulos.Font,
                    new Rectangle(0, 0, rect.Height, rect.Width),
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                // Restaurar estado gráfico
                e.Graphics.ResetTransform();
            };
        }

        private void VistaInventario_Load(object sender, EventArgs e)
        {
            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();

                    // Crear la tabla Categorias con una relación al Inventario
                    string queryCategorias = @"
                    CREATE TABLE IF NOT EXISTS Categorias (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        InventarioId INT,
                        Nombre TEXT,
                        FechaCreacion TEXT,
                        FechaModificacion TEXT,
                        FechaEliminacion TEXT,
                        UsuarioCreacion TEXT,
                        UsuarioModificacion TEXT,
                        UsuarioEliminacion TEXT,
                        FOREIGN KEY (InventarioId) REFERENCES Inventarios(Id) ON DELETE CASCADE
                    );";


                    // Crear la tabla Articulos con una relación a Categorias
                    string queryArticulos = @"
                    CREATE TABLE IF NOT EXISTS Articulos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Codigo TEXT,
                        Modelo TEXT,
                        Serie TEXT,
                        Marca TEXT,
                        FechaAdquisicion TEXT,
                        FechaBaja TEXT,
                        FechaFinGarantia TEXT,
                        
                        DniUsuarioActual TEXT,
                        NombreUsuarioActual TEXT,
                        IdAreaUsuarioActual INTEGER,
                        AreaUsuarioActual TEXT,
                        CargoUsuarioActual TEXT,

                        DniUsuarioAnterior TEXT,
                        NombreUsuarioAnterior TEXT,
                        IdAreaUsuarioAnterior INTEGER,
                        AreaUsuarioAnterior TEXT,
                        CargoUsuarioAnterior TEXT,

                        IdEstado INTEGER,
                        Estado TEXT,
                        IdUbicacion INTEGER,
                        Ubicacion TEXT,
                        IdCondicion INTEGER,
                        Condicion TEXT,
                        ActivoFijo TEXT,

                        Observacion TEXT,
                        Foto BLOB,
                        Comprobante BLOB,

                        RUCProveedor TEXT,
                        Proveedor TEXT,
                        PrecioAdquisicion REAL,
                        VidaUtilMeses INTEGER,
                        
                        CategoriaId INTEGER,
                        Categoria TEXT,
                        FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id) ON DELETE CASCADE
                    );";

                    // Crear la tabla Caracteristicas con relación a Articulos
                    string queryCaracteristicas = @"
                    CREATE TABLE IF NOT EXISTS Caracteristicas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        ArticuloId INTEGER, 
                        Nombre TEXT, 
                        Caracteristica1 TEXT, 
                        Caracteristica2 TEXT, 
                        Caracteristica3 TEXT, 
                        Caracteristica4 TEXT, 
                        FOREIGN KEY (ArticuloId) REFERENCES Articulos(Id) ON DELETE CASCADE 
                    );";

                    using (var cmd = new SQLiteCommand(queryCategorias, con)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand(queryArticulos, con)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand(queryCaracteristicas, con)) cmd.ExecuteNonQuery();

                    // Verificar si el inventario del usuario ya existe
                    string queryCheckInventario = "SELECT Id FROM Inventarios WHERE UsuarioId = @UsuarioId LIMIT 1;";
                    using (var cmdCheckInventario = new SQLiteCommand(queryCheckInventario, con))
                    {
                        // Si no existe, se crea un nuevo inventario para el usuario
                        cmdCheckInventario.Parameters.AddWithValue("@UsuarioId", empleadoActual.Id);
                        var result = cmdCheckInventario.ExecuteScalar();
                        if (result == null)
                        {
                            // Crear un nuevo inventario para el usuario
                            var inventario = new Inventario
                            {
                                NombreInventario = "Inventario de " + empleadoActual.Nombres,
                                FechaCreacion = DateTime.Now.Date,
                                UsuarioId = empleadoActual.Id,
                                Usuario = empleadoActual.Usuario
                            };
                            // Insertar el nuevo inventario en la base de datos
                            var inventarioRepo = new InventarioRepository(empleadoActual);
                            inventarioActual = inventarioRepo.ObtenerOCrearInventarioPorUsuario(con);
                        }
                    }

                    // Verificar si el inventario tiene categorías asociadas
                    string queryCheckCategorias = "SELECT Id FROM Categorias WHERE InventarioId = @InventarioId LIMIT 1;";
                    using (var cmdCheckCategorias = new SQLiteCommand(queryCheckCategorias, con))
                    {
                        // Si no existen categorías en el inventario, se crean a partir de las pestañas del TabControl
                        cmdCheckCategorias.Parameters.AddWithValue("@InventarioId", inventarioActual.Id);
                        var result = cmdCheckCategorias.ExecuteScalar();
                        if (result == null)
                        {
                            // Crear categorías a partir de las pestañas del TabControl
                            foreach (TabPage tab in TbArticulos.TabPages)
                            {
                                // Crear una nueva categoría para cada pestaña
                                var categoria = new Categoria
                                {
                                    Nombre = tab.Text,
                                    InventarioId = inventarioActual.Id
                                };
                                // Insertar la categoría en la base de datos
                                var categoriaRepo = new CategoriaRepository(inventarioActual);
                                categoriaRepo.InsertarCategoriaInventario(categoria, con);
                            }
                        }
                    }


                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            CargarArticulos();
        }

        private void BtnNuevaCategoria_Click(object sender, EventArgs e)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                //COMING SOON
            }

        }

        private int ObtenerCategoriaId()
        {
            string texto = TbArticulos.SelectedTab?.Text;

            switch (texto)
            {
                case "Laptops": return 1;
                case "Celulares": return 2;
                case "Computadoras": return 3;
                case "Monitores": return 4;
                case "Accesorios": return 5;
                default: return 0;
            }
        }

        private string ObtenerCategoriaNombre()
        {
            string texto = TbArticulos.SelectedTab?.Text;

            switch (texto)
            {
                case "Laptops": return "Laptops";
                case "Computadoras": return "Computadoras";
                case "Celulares": return "Celulares";
                case "Monitores": return "Monitores";
                case "Accesorios": return "Accesorios";
                default: return string.Empty;
            }
        }


        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            int categoriaId = ObtenerCategoriaId();
            string categoria = ObtenerCategoriaNombre();
            string texto = TbArticulos.SelectedTab?.Text;

            using (var articulos = new VistaArticulos(categoriaId, categoria))
            {
                // Configuración inicial
                articulos.CbDesktop.Visible = false;
                articulos.CbCelulares.Visible = false;
                articulos.CbMonitores.Visible = false;
                articulos.GpCaracteristicas.Visible = true;

                switch (texto)
                {
                    case "Laptops":
                    case "Computadoras":
                        articulos.CbDesktop.Visible = true;
                        break;

                    case "Celulares":
                        articulos.CbCelulares.Visible = true;
                        break;

                    case "Monitores":
                        articulos.CbMonitores.Visible = true;
                        break;

                    case "Accesorios":
                        articulos.Size = new Size(828, 510);
                        articulos.GpCaracteristicas.Visible = false;
                        break;

                    default:
                        articulos.Size = new Size(828, 607);
                        break;
                }

                // Mostrar el formulario de alta
                if (articulos.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la lista activa al volver
                    CargarArticulos();
                }
            }
        }

        public void CargarArticulos()
        {
            var articulos = ArticuloRepository.ListarArticulos();

            // Detectar el tab activo
            if (TbArticulos.SelectedTab == TabLaptops)
                ClassHelper.RefrescarListView(LstLaptop, articulos);
            else if (TbArticulos.SelectedTab == TabCelulares)
                ClassHelper.RefrescarListView(LstCelulares, articulos);
            else if (TbArticulos.SelectedTab == TabPc)
                ClassHelper.RefrescarListView(LstComputadoras, articulos);
            else if (TbArticulos.SelectedTab == TabMonitores)
                ClassHelper.RefrescarListView(LstMonitores, articulos);
            else if (TbArticulos.SelectedTab == TabAccesorios)
                ClassHelper.RefrescarListView(LstAccesorios, articulos);
        }

        private void NuAccionInventario_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}

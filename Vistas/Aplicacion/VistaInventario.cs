using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using ControlInventario.Vistas.Extras;

namespace ControlInventario.Vistas
{
    public partial class VistaInventario : Form
    {
        private Inventario inventarioActual;
        private int _articuloId;
        public static bool isEdit = false;
        int usuarioId = UsuarioSesion.UsuarioId;
        string nombreUusario = UsuarioSesion.NombreUsuario;
        string nombrePersonal = UsuarioSesion.NombrePersonal;

        public VistaInventario(Inventario inventario)
        {
            InitializeComponent();
            inventarioActual = inventario;


            var customTabs = new CustomTabControl
            {
                Name = TbArticulos.Name,
                Dock = TbArticulos.Dock,
                Location = TbArticulos.Location,
                Size = TbArticulos.Size
            };

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
                System.Drawing.Rectangle rect = e.Bounds;

                // Guardar estado gráfico
                e.Graphics.TranslateTransform(rect.Left, rect.Top + rect.Height);
                e.Graphics.RotateTransform(-90); // -90 = vertical hacia la derecha

                // Dibujar texto con TextRenderer (más grueso, igual al estilo nativo)
                TextRenderer.DrawText(
                    e.Graphics,
                    page.Text,
                    TbArticulos.Font,
                    new System.Drawing.Rectangle(0, 0, rect.Height, rect.Width),
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                // Restaurar estado gráfico
                e.Graphics.ResetTransform();
            };
        }

        private void VistaInventario_Load(object sender, EventArgs e)
        {
            LblAccionDecription.Text = "EXCEL";
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

                    var repo = new InventarioRepository();
                    var inventario = repo.ObtenerOCrearInventarioPorUsuario(con);
                    UsuarioSesion.inventarioId = inventario.Id;


                    // Verificar si el inventario del usuario ya existe
                    string queryCheckInventario = "SELECT Id FROM Inventarios WHERE UsuarioId = @UsuarioId LIMIT 1;";
                    using (var cmdCheckInventario = new SQLiteCommand(queryCheckInventario, con))
                    {
                        // Si no existe, se crea un nuevo inventario para el usuario
                        cmdCheckInventario.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        var result = cmdCheckInventario.ExecuteScalar();
                        if (result == null)
                        {
                            // Crear un nuevo inventario para el usuario
                            var inventarioNew = new Inventario
                            {
                                NombreInventario = "Inventario de " + nombrePersonal,
                                FechaCreacion = DateTime.Now.Date,
                                UsuarioId = usuarioId,
                                Usuario = nombreUusario
                            };
                            // Insertar el nuevo inventario en la base de datos
                            var inventarioRepo = new InventarioRepository();
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

        public void CargarArticulos()
        {
            var articulos = ArticuloRepository.ListarArticulos(UsuarioSesion.inventarioId);

            // Mapeo de cada TabPage con su ListView
            var tabMap = new Dictionary<TabPage, ListView>
            {
                { TabLaptops, LstLaptop },
                { TabCelulares, LstCelulares },
                { TabPc, LstComputadoras },
                { TabMonitores, LstMonitores },
                { TabAccesorios, LstAccesorios }
            };

            // Recorrer todos los tabs y refrescar su ListView
            foreach (var kvp in tabMap)
            {
                ClassHelper.RefrescarListView(kvp.Value, articulos);
            }
        }

        private void NuAccionInventario_ValueChanged(object sender, EventArgs e)
        {
            switch (NuAccionInventario.Value)
            {
                case 1: LblAccionDecription.Text = "EXCEL"; break;
                case 2: LblAccionDecription.Text = "CSV"; break;
            }
        }

        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            var ListViewActivo = ObtenerListViewActivo();
            isEdit = false;
            int categoriaId = ObtenerCategoriaId();
            string categoria = ObtenerCategoriaNombre();
            string texto = TbArticulos.SelectedTab?.Text;

            using (var articulos = new VistaArticulos(categoriaId, categoria))
            {
                // Configuración inicial
                articulos.Text = "Crear Artículo";
                articulos.TxtCodigo.Enabled = true;
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

        public ListView ObtenerListViewActivo()
        {
            if (TbArticulos.SelectedTab != null)
            {
                foreach (Control ctrl in TbArticulos.SelectedTab.Controls)
                {
                    if (ctrl is ListView lv)
                        return lv;
                }
            }
            return null;
        }

        private void BtnEditarArticulo_Click(object sender, EventArgs e)
        {
            var ListViewActivo = ObtenerListViewActivo();
            if(ListViewActivo == null || ListViewActivo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para editar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            isEdit = true;
            int categoriaId = ObtenerCategoriaId();
            string categoria = ObtenerCategoriaNombre();

            ListViewItem item = ListViewActivo.SelectedItems[0];
            _articuloId = Convert.ToInt32(item.SubItems[0].Text);

            using (var articulos = new VistaArticulos(categoriaId, categoria, Convert.ToInt32(item.SubItems[0].Text)))
            {
                // Configuración inicial
                articulos.Text = "Editar Artículo";
                articulos.TxtCodigo.Enabled = false;

                articulos.CbDesktop.Visible = false;
                articulos.CbCelulares.Visible = false;
                articulos.CbMonitores.Visible = false;
                articulos.GpCaracteristicas.Visible = true;

                switch (TbArticulos.SelectedTab.Text)
                {
                    case "Laptops":
                    case "Computadoras":
                        articulos.CbDesktop.Visible = true; 
                        articulos.CbDesktop.Text = item.SubItems[4].Text;
                        break;

                    case "Celulares":
                        articulos.CbCelulares.Visible = true; 
                        articulos.CbCelulares.Text = item.SubItems[4].Text;
                        break;

                    case "Monitores":
                        articulos.CbMonitores.Visible = true;
                        articulos.CbMonitores.Text = item.SubItems[4].Text;
                        break;

                    case "Accesorios":
                        articulos.Size = new Size(828, 510);
                        articulos.GpCaracteristicas.Visible = false;
                        break;

                    default:
                        articulos.Size = new Size(828, 607);
                        break;
                }
                MessageBox.Show("Este item tiene " + item.SubItems.Count + " columnas cargadas.");

                // Campos básicos
                if (item.SubItems.Count > 1) articulos.TxtCodigo.Text = item.SubItems[1]?.Text ?? string.Empty;
                if (item.SubItems.Count > 2) articulos.TxtModelo.Text = item.SubItems[2]?.Text ?? string.Empty;
                if (item.SubItems.Count > 3) articulos.TxtSerie.Text = item.SubItems[3]?.Text ?? string.Empty;

                // Fechas con TryParse
                if (item.SubItems.Count > 5 && DateTime.TryParse(item.SubItems[5]?.Text, out DateTime fechaAdquisicion))
                    articulos.DtpFechaAdquisicion.Value = fechaAdquisicion;

                if (item.SubItems.Count > 6 && DateTime.TryParse(item.SubItems[6]?.Text, out DateTime fechaBaja))
                    articulos.DtpFechaBaja.Value = fechaBaja;

                if (item.SubItems.Count > 7 && DateTime.TryParse(item.SubItems[7]?.Text, out DateTime fechaFinGarantia))
                    articulos.DtpFechaFinGarantia.Value = fechaFinGarantia;

                // Usuario actual
                if (item.SubItems.Count > 8) articulos.TxtDniUsuarioActual.Text = item.SubItems[8]?.Text ?? string.Empty;
                if (item.SubItems.Count > 9) articulos.TxtNombreUsuarioActual.Text = item.SubItems[9]?.Text ?? string.Empty;
                if (item.SubItems.Count > 10) articulos.CbAreaUsuarioActual.Text = item.SubItems[10]?.Text ?? string.Empty;
                if (item.SubItems.Count > 11) articulos.TxtCargoUsuarioActual.Text = item.SubItems[11]?.Text ?? string.Empty;

                // Usuario anterior
                if (item.SubItems.Count > 12) articulos.TxtDniUsuarioAnterior.Text = item.SubItems[12]?.Text ?? string.Empty;
                if (item.SubItems.Count > 13) articulos.TxtNombreUsuarioAnterior.Text = item.SubItems[13]?.Text ?? string.Empty;
                if (item.SubItems.Count > 14) articulos.CbAreaUsuarioAnterior.Text = item.SubItems[14]?.Text ?? string.Empty;
                if (item.SubItems.Count > 15) articulos.TxtCargoUsuarioAnterior.Text = item.SubItems[15]?.Text ?? string.Empty;

                // Estado, ubicación, condición
                if (item.SubItems.Count > 16) articulos.CbEstado.Text = item.SubItems[16]?.Text ?? string.Empty;
                if (item.SubItems.Count > 17) articulos.CbUbicacion.Text = item.SubItems[17]?.Text ?? string.Empty;
                if (item.SubItems.Count > 18) articulos.CbCondicion.Text = item.SubItems[18]?.Text ?? string.Empty;

                // Datos adicionales
                if (item.SubItems.Count > 19) articulos.TxtRuc.Text = item.SubItems[19]?.Text ?? string.Empty;
                if (item.SubItems.Count > 20) articulos.TxtRazonSocial.Text = item.SubItems[20]?.Text ?? string.Empty;
                if (item.SubItems.Count > 21) articulos.TxtPrecio.Text = item.SubItems[21]?.Text ?? string.Empty;
                if (item.SubItems.Count > 22) articulos.TxtActivoFijo.Text = item.SubItems[22]?.Text ?? string.Empty;
                if (item.SubItems.Count > 26) articulos.TxtObservaciones.Text = item.SubItems[26]?.Text ?? string.Empty;
                if (item.SubItems.Count > 27) articulos.TxtDireccionImagen.Text = item.SubItems[27]?.Text ?? string.Empty;

                //articulos.TxtRutaComprobante.Text = item.SubItems[31].Text;

                // Mostrar el formulario de alta
                if (articulos.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la lista activa al volver
                    CargarArticulos();
                }
            }
        }

        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            var ListViewActivo = ObtenerListViewActivo();

            isEdit = false;
            int categoriaId = ObtenerCategoriaId();
            string categoria = ObtenerCategoriaNombre();

            ListViewItem item = ListViewActivo.SelectedItems[0];
            _articuloId = Convert.ToInt32(item.SubItems[0].Text);

            if (ListViewActivo == null || ListViewActivo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "¿Seguro que quieres eliminar este artículo?",
                    "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var con = ConexionGlobal.ObtenerConexion())
                        {
                            con.Open();
                            ArticuloRepository.EliminarArticulo(_articuloId);
                            CargarArticulos();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores: loguear, mostrar mensaje, etc.
                        MessageBox.Show("Ocurrió un error al eliminar el artículo: " + ex.Message);
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var listViewActivo = ObtenerListViewActivo();
            string categoria = ObtenerCategoriaNombre();
            string usuario = nombreUusario;

            // Determinar extensión según el valor del NumericUpDown
            string extension = NuAccionInventario.Value == 1 ? "xlsx" : "csv";

            // Generar nombre automático
            string nombreArchivo = GenerarNombreArchivo(extension, usuario, categoria);

            // Mostrar vista de exportación
            VistaRutaExportacion vistaRuta = new VistaRutaExportacion(nombreArchivo, listViewActivo, categoria);
            vistaRuta.ShowDialog();
        }

        private string GenerarNombreArchivo(string formato, string usuario, string categoria)
        {
            // Normalizar valores (evitar espacios o caracteres raros)
            string usuarioLimpio = usuario.Replace(" ", "_");
            string categoriaLimpia = categoria.Replace(" ", "_");

            // Fecha y hora en formato ordenado
            string fecha = DateTime.Now.ToString("yyyyMMdd_HHmm");

            // Construcción del nombre
            string nombreArchivo = $"Invent_{usuarioLimpio}_{categoriaLimpia}_{fecha}.{formato}";

            return nombreArchivo;
        }
    }
}

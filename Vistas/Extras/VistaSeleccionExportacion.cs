using ControlInventario.Database;
using ControlInventario.Repositorio;
using ControlInventario.Servicios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaSeleccionExportacion : Form
    {
        public DataTable DatosExportar { get; private set; }
        public string NombreSeccion { get; private set; }

        private RadioButton rbCategoria;
        private RadioButton rbTodoInventario;
        private RadioButton rbSalidas;
        private RadioButton rbCuentas;
        private ComboBox cbCategorias;
        private ComboBox cbTipoSalida;
        private Button btnAceptar;
        private Button btnCancelar;

        public VistaSeleccionExportacion()
        {
            InitializeComponent();
            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            this.Text = "¿Qué desea exportar?";
            this.ClientSize = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;

            GroupBox grpOpciones = new GroupBox
            {
                Text = "Seleccione los datos a exportar",
                Location = new Point(12, 10),
                Size = new Size(396, 250)
            };

            // Opción 1: Por categoría
            rbCategoria = new RadioButton
            {
                Text = "Inventario por categoría:",
                Location = new Point(15, 30),
                AutoSize = true,
                Checked = true
            };
            rbCategoria.CheckedChanged += Opciones_CheckedChanged;

            cbCategorias = new ComboBox
            {
                Location = new Point(35, 55),
                Size = new Size(340, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Opción 2: Todo el inventario
            rbTodoInventario = new RadioButton
            {
                Text = "Todo el inventario (artículos disponibles)",
                Location = new Point(15, 95),
                AutoSize = true
            };
            rbTodoInventario.CheckedChanged += Opciones_CheckedChanged;

            // Opción 3: Salidas
            rbSalidas = new RadioButton
            {
                Text = "Salidas:",
                Location = new Point(15, 130),
                AutoSize = true
            };
            rbSalidas.CheckedChanged += Opciones_CheckedChanged;

            cbTipoSalida = new ComboBox
            {
                Location = new Point(35, 155),
                Size = new Size(340, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = false
            };
            cbTipoSalida.Items.AddRange(new string[] { "Todas las salidas", "Solo Ventas", "Solo Asignaciones", "Solo Bajas" });
            cbTipoSalida.SelectedIndex = 0;

            // Opción 4: Cuentas por cobrar
            rbCuentas = new RadioButton
            {
                Text = "Cuentas por cobrar (cuotas pendientes y vencidas)",
                Location = new Point(15, 195),
                AutoSize = true
            };
            rbCuentas.CheckedChanged += Opciones_CheckedChanged;

            grpOpciones.Controls.AddRange(new Control[] {
                rbCategoria, cbCategorias,
                rbTodoInventario,
                rbSalidas, cbTipoSalida,
                rbCuentas
            });
            this.Controls.Add(grpOpciones);

            // Botones
            btnAceptar = new Button
            {
                Text = "Continuar",
                Location = new Point(220, 270),
                Size = new Size(100, 35),
                Cursor = Cursors.Hand
            };
            btnAceptar.Click += BtnAceptar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(325, 270),
                Size = new Size(83, 35),
                Cursor = Cursors.Hand
            };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);

            this.Load += VistaSeleccionExportacion_Load;
        }

        private void VistaSeleccionExportacion_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            ClassHelper.AplicarTema(this);
        }

        private void CargarCategorias()
        {
            DataTable dtCat = CategoriaRepository.ListarCategorias(UsuarioSesion.InventarioId);
            cbCategorias.Items.Clear();

            foreach (DataRow row in dtCat.Rows)
            {
                cbCategorias.Items.Add(new ComboItem(row["Nombre"].ToString(), Convert.ToInt32(row["Id"])));
            }

            if (cbCategorias.Items.Count > 0)
                cbCategorias.SelectedIndex = 0;
        }

        private void Opciones_CheckedChanged(object sender, EventArgs e)
        {
            cbCategorias.Enabled = rbCategoria.Checked;
            cbTipoSalida.Enabled = rbSalidas.Checked;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbCategoria.Checked)
                {
                    if (cbCategorias.SelectedItem == null)
                    {
                        MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var item = (ComboItem)cbCategorias.SelectedItem;
                    NombreSeccion = item.Texto;
                    DatosExportar = ObtenerDatosCategoria(item.Valor);
                }
                else if (rbTodoInventario.Checked)
                {
                    NombreSeccion = "Inventario_Completo";
                    DatosExportar = ArticuloRepository.ListarInventarioCompleto(UsuarioSesion.InventarioId);
                }
                else if (rbSalidas.Checked)
                {
                    int[] acciones;
                    switch (cbTipoSalida.SelectedIndex)
                    {
                        case 1: acciones = new int[] { 2 }; NombreSeccion = "Ventas"; break;
                        case 2: acciones = new int[] { 3, 5, 10 }; NombreSeccion = "Asignaciones"; break;
                        case 3: acciones = new int[] { 6, 8, 11 }; NombreSeccion = "Bajas"; break;
                        default: acciones = new int[] { 2, 3, 5, 6, 8, 10, 11 }; NombreSeccion = "Todas_Salidas"; break;
                    }
                    DatosExportar = ArticuloRepository.ListarArticulosPorAccion(UsuarioSesion.InventarioId, acciones);
                }
                else if (rbCuentas.Checked)
                {
                    NombreSeccion = "Cuentas_Por_Cobrar";
                    DatosExportar = CuentasPorCobrarRepository.ListarResumenCuentas(UsuarioSesion.InventarioId);
                }

                if (DatosExportar == null || DatosExportar.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar en la sección seleccionada.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatosCategoria(int categoriaId)
        {
            DataTable dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM vw_Articulos WHERE CategoriaId = @CatId AND IdAccion IN (1, 4, 12, 13);";
                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CatId", categoriaId);
                    using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Clase auxiliar para items del ComboBox con texto y valor.
        /// </summary>
        private class ComboItem
        {
            public string Texto { get; }
            public int Valor { get; }

            public ComboItem(string texto, int valor)
            {
                Texto = texto;
                Valor = valor;
            }

            public override string ToString() => Texto;
        }
    }

    partial class VistaSeleccionExportacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
    }
}
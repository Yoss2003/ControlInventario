using ControlInventario.Database;
using ControlInventario.Modelos;
using ControlInventario.Vistas;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario.Servicios
{

    public class ClassHelper
    {
        private VistaInventario inventario;
        public static Dictionary<string, decimal> TasasDeCambioCache = new Dictionary<string, decimal>();

        public ClassHelper(VistaInventario vista)
        {
            inventario = vista;
        }
        public void EliminarBotonCategoria(int idCategoria)
        {
            foreach (Control control in inventario.DvgIngresos.Controls)
            {
                if (control is Button btn && btn.Tag != null && Convert.ToInt32(btn.Tag) == idCategoria)
                {
                    inventario.DvgIngresos.Controls.Remove(btn);
                    btn.Dispose();
                    break;
                }
            }

            if (inventario.DvgIngresos.Controls.Count == 0)
            {
                inventario.DvgIngresos.Visible = false;
            }
            else
            {
                Button primerBoton = (Button)inventario.DvgIngresos.Controls[0];
                primerBoton.PerformClick();
            }
        }

        public void AgregarBotonCategoria(string nombreCategoria, int idCategoria)
        {
            // Validación: no crear botón si el texto está vacío o excede 11 caracteres
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear botón solo si pasa la validación
            Button btn = new Button();
            btn.Text = nombreCategoria;
            btn.Tag = idCategoria;
            btn.Height = 35;
            btn.Width = inventario.FlCategorias.ClientSize.Width - 6;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;

            btn.Click += BtnCategoria_Click;
            inventario.FlCategorias.Controls.Add(btn);
        }

        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            int idCategoria = (int)btn.Tag;
            string nombreCategoria = btn.Text;

            inventario.categoriaSeleccionadaId = idCategoria; 
            inventario.categoriaSeleccionadaNombre = nombreCategoria;

            var articulos = ArticuloRepository.ListarArticulos(idCategoria);
            RefrescarDvgIngresos(inventario.DvgIngresos, articulos);
        }

        public static void RefrescarDvgIngresos(DataGridView dataGrdi, IEnumerable<Articulos> articulos)
        {
            dataGrdi.Rows.Clear();
            foreach (var art in articulos)
            {
                string json = art.Caracteristicas;
                string textoBoton = (!string.IsNullOrEmpty(json) && json != "{}") ? "Ver Detalles" : "N/A";

                int rowIndex = dataGrdi.Rows.Add(
                    art.Id,
                    art.Codigo ?? "",
                    art.Modelo ?? "",
                    art.Serie ?? "",
                    art.Marca ?? "",
                    ClassHelper.FormatearFecha(art.FechaAdquisicion),
                    ClassHelper.FormatearFecha(art.FechaFinGarantia),

                    art.Estado ?? "",
                    art.Ubicacion ?? "",
                    art.Condicion ?? "",

                    art.RucProveedor ?? "",
                    art.Proveedor ?? "",
                    ClassHelper.FormatearMoneda(art.PrecioAdquisicion),
                    art.Observacion ?? "",
                    art.FotoPrincipal ?? "",
                    art.ComprobantePrincipal ?? "",

                    textoBoton
                );

                dataGrdi.Rows[rowIndex].Tag = art;
            }
        }
        public static void RefrescarDvgSalidas(DataGridView dataGrdi, DataTable dtArticulos)
        {
            dataGrdi.Rows.Clear();

            foreach (DataRow row in dtArticulos.Rows)
            {
                string json = row["Caracteristicas"] != DBNull.Value ? row["Caracteristicas"].ToString() : "";
                string textoBoton = (!string.IsNullOrEmpty(json) && json != "{}") ? "Ver Detalles" : "N/A";

                DateTime fechaAdq = row["FechaAdquisicion"] != DBNull.Value
                                    ? Convert.ToDateTime(row["FechaAdquisicion"])
                                    : DateTime.MinValue;

                decimal? precio = row["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(row["PrecioVenta"]) : (decimal?)null;
                string precioFormateado = precio.HasValue ? ClassHelper.FormatearMoneda(precio) : "";

                int rowIndex = dataGrdi.Rows.Add(
                    row["Id"],
                    row["Codigo"]?.ToString(),
                    row["Modelo"]?.ToString(),
                    row["MarcaTexto"]?.ToString(),
                    row["Serie"]?.ToString(),

                    row["EmpleadoActualTexto"]?.ToString(),
                    row["EmpleadoActualAreaTexto"]?.ToString(),
                    row["EmpleadoActualCargoTexto"]?.ToString(),

                    row["DestinatarioTexto"]?.ToString(),
                    precioFormateado,
                    row["MotivoBajaTexto"]?.ToString(),

                    ClassHelper.FormatearFecha(fechaAdq),
                    row["RutaFotoPrincipal"]?.ToString(),
                    textoBoton
                );
                dataGrdi.Rows[rowIndex].Tag = Convert.ToInt32(row["Id"]);
            }
            dataGrdi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public static string NormalizarCombo(ComboBox combo)
        {
            return string.IsNullOrWhiteSpace(combo.Text) || combo.Text == "SELECCIONE"
                ? null
                : combo.Text;
        }

        public static void NormalizarTexto(ComboBox combo)
        {
            if(combo.SelectedIndex == -1 && combo.Text != Idiomas.OpcionSeleccione)
            {
                combo.Text = Idiomas.OpcionSeleccione;
            }
        }

        public static bool ExisteParametroDuplicado(string tipoParametro, string valorIngresado, int idActual = 0)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT COUNT(*) 
                FROM Parametros 
                WHERE TipoParametro = @TipoParametro 
                AND TRIM(Nombre) = TRIM(@ValorIngresado) COLLATE NOCASE 
                AND Id != @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TipoParametro", tipoParametro);
                    cmd.Parameters.AddWithValue("@ValorIngresado", valorIngresado);
                    cmd.Parameters.AddWithValue("@Id", idActual);

                    long cantidad = (long)cmd.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
        
        public static bool ExisteComponenteDuplicado(string nombreTabla, string valorIngresado, int idActual = 0, string nombreColumna = "Nombre")
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $@"
                SELECT COUNT(*) 
                FROM {nombreTabla} 
                WHERE TRIM({nombreColumna}) = TRIM(@ValorIngresado) COLLATE NOCASE 
                AND Id != @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ValorIngresado", valorIngresado);
                    cmd.Parameters.AddWithValue("@Id", idActual);

                    long cantidad = (long)cmd.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }

        public static bool ValidarComboObsoleto(ComboBox combo, string valorFila, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valorFila))
            {
                combo.SelectedIndex = 0;
                return true;
            }

            int indice = combo.FindStringExact(valorFila);

            if (indice != -1)
            {
                combo.SelectedIndex = indice;
                return true;
            }
            else
            {
                combo.SelectedIndex = 0;
                MessageBox.Show($"El valor '{valorFila}' de {nombreCampo} ya no existe.\nSe restablecerá.",
                                "Dato Obsoleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static void ProcesarComboSeguro(ComboBox combo, string textoCelda, string tipoValidacion, string columnaIdBD, int idEmpleadoActual)
        {
            string textoLimpio = textoCelda ?? "";

            combo.DataBindings.Clear();

            if (!ValidarComboObsoleto(combo, textoLimpio, tipoValidacion))
            {
                LimpiarCampoObsoletoBD("Empleados", columnaIdBD, tipoValidacion, idEmpleadoActual);
                combo.SelectedIndex = -1;
                combo.SelectedIndex = 0;
            }
            else 
            {
                int indiceEncontrado = combo.FindStringExact(textoLimpio);
                combo.SelectedIndex = -1;
                combo.SelectedIndex = indiceEncontrado != -1 ? indiceEncontrado : 0;
            }

            combo.Refresh();
        }

        public static void LimpiarCampoObsoletoBD(string tablaDestino, string columnaId, string columnaNombre, int idRegistro)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $@"UPDATE {tablaDestino} SET
                        {columnaId} = 0
                        WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idRegistro);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void LlenarDesdeTabla(ComboBox cb, string nombreTabla, string nombreColumnaTexto)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $"SELECT Id, {nombreColumnaTexto} FROM {nombreTabla}";

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cb.DataSource = dt;
                    cb.DisplayMember = nombreColumnaTexto;
                    cb.ValueMember = "Id";
                }
            }
        }

        public static void AplicarTema(Control controlPrincipal)
        {
            string tema = UsuarioSesion.Configuracion?.Tema ?? "Claro";

            Color colorFondo = tema == "Oscuro" ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            Color colorTexto = tema == "Oscuro" ? Color.White : Color.Black;
            Color colorCajas = tema == "Oscuro" ? Color.FromArgb(30, 30, 30) : Color.White;

            controlPrincipal.BackColor = colorFondo;
            controlPrincipal.ForeColor = colorTexto;

            foreach (Control hijo in controlPrincipal.Controls)
            {
                if (hijo is TextBox || hijo is ComboBox || hijo is ListBox)
                {
                    hijo.BackColor = colorCajas;
                    hijo.ForeColor = colorTexto;
                }
                else
                {
                    AplicarTema(hijo);
                }
            }
        }

        public static void ActualizarTemaGlobal()
        {
            foreach (Form formulario in Application.OpenForms)
            {
                AplicarTema(formulario);
            }
        }

        public static void AplicarIdiomaGlobal()
        {
            string idiomaSeleccionado = UsuarioSesion.Configuracion?.Idioma ?? "Español";

            string codigoCultura = "es-ES";

            switch (idiomaSeleccionado)
            {
                case "Inglés":
                    codigoCultura = "en-US";
                    break;
                case "Portugués":
                    codigoCultura = "pt-BR";
                    break;
            }

            CultureInfo culturaSeleccionada = new CultureInfo(codigoCultura);

            Thread.CurrentThread.CurrentCulture = culturaSeleccionada;
            Thread.CurrentThread.CurrentUICulture = culturaSeleccionada;
            CultureInfo.DefaultThreadCurrentCulture = culturaSeleccionada;
            CultureInfo.DefaultThreadCurrentUICulture = culturaSeleccionada;
        }

        public static void ActualizarIdiomaGlobal()
        {
            AplicarIdiomaGlobal();

            foreach (Form form in Application.OpenForms)
            {
                AplicarIdiomaAControles(form, form);
            }
        }

        private static void AplicarIdiomaAControles(Control controlPrincipal, Form formOriginal)
        {
            ComponentResourceManager resManager = new ComponentResourceManager(formOriginal.GetType());

            if (controlPrincipal is Form)
            {
                resManager.ApplyResources(controlPrincipal, "$this");
            }

            foreach (Control hijo in controlPrincipal.Controls)
            {
                resManager.ApplyResources(hijo, hijo.Name);

                if (hijo is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        resManager.ApplyResources(col, col.Name);
                    }
                }

                if (hijo.Controls.Count > 0)
                {
                    AplicarIdiomaAControles(hijo, formOriginal);
                }
            }
        }

        public static void AplicarFormatoFecha(DateTimePicker dtp)
        {
            string formato = UsuarioSesion.Configuracion?.FormatoFecha ?? "dd/MM/yyyy";

            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = formato;
        }

        public static string FormatearFecha(DateTime? fecha)
        {
            if (!fecha.HasValue)
                return "";

            string formato = UsuarioSesion.Configuracion?.FormatoFecha ?? "dd/MM/yyyy";
            return fecha.Value.ToString(formato);
        }

        public static string FormatearMoneda(decimal? monto)
        {
            if (!monto.HasValue) return "";

            string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "USD";
            string isoCode = (!string.IsNullOrEmpty(monedaCompleta) && monedaCompleta.Length >= 3)
                     ? monedaCompleta.Substring(0, 3)
                     : "PEN";

            decimal tasaPEN = TasasDeCambioCache.ContainsKey("PEN") ? TasasDeCambioCache["PEN"] : 3.75m;
            decimal tasaDestino = TasasDeCambioCache.ContainsKey(isoCode) ? TasasDeCambioCache[isoCode] : 1.00m;

            decimal montoEnUSD = monto.Value / tasaPEN;
            decimal montoConvertido = montoEnUSD * tasaDestino;

            string simboloVisual;
            switch (isoCode)
            {
                case "PEN": simboloVisual = "S/"; break;
                case "USD": simboloVisual = "$"; break;
                case "EUR": simboloVisual = "€"; break;
                case "MXN": simboloVisual = "$"; break;
                default: simboloVisual = isoCode; break;
            }

            return $"{simboloVisual} {montoConvertido.ToString("N2")}";
        }

        public static decimal? ConvertirTextoAMoneda(string textoMoneda)
        {
            // Usamos el extractor blindado
            decimal? montoPantalla = ExtraerNumero(textoMoneda);
            if (!montoPantalla.HasValue) return null;

            string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "PEN";
            string isoCode = (!string.IsNullOrEmpty(monedaCompleta) && monedaCompleta.Length >= 3) ? monedaCompleta.Substring(0, 3) : "PEN";

            decimal tasaPEN = TasasDeCambioCache.ContainsKey("PEN") ? TasasDeCambioCache["PEN"] : 3.75m;
            decimal tasaOrigen = TasasDeCambioCache.ContainsKey(isoCode) ? TasasDeCambioCache[isoCode] : 1.00m;

            decimal montoEnUSD = montoPantalla.Value / tasaOrigen;
            decimal montoParaBD = montoEnUSD * tasaPEN;

            // LA MAGIA ESTÁ AQUÍ: Redondeamos a 2 decimales para evitar los .999999999M
            return Math.Round(montoParaBD, 2);
        }

        public static decimal ObtenerTipoCambio(string codigoISODestino)
        {
            if (TasasDeCambioCache == null || TasasDeCambioCache.Count == 0)
                return 1.00m;

            decimal valorSolEnUSD = TasasDeCambioCache.ContainsKey("PEN") ? TasasDeCambioCache["PEN"] : 3.75m;
            decimal valorDestinoEnUSD = TasasDeCambioCache.ContainsKey(codigoISODestino) ? TasasDeCambioCache[codigoISODestino] : 1.00m;

            return valorDestinoEnUSD / valorSolEnUSD;
        }

        public static async Task CargarTasasDeCambioDesdeAPI()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://open.er-api.com/v6/latest/USD";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement rates = doc.RootElement.GetProperty("rates");
                            TasasDeCambioCache.Clear();

                            foreach (JsonProperty moneda in rates.EnumerateObject())
                            {
                                TasasDeCambioCache[moneda.Name] = moneda.Value.GetDecimal();
                            }
                        }
                    }
                }
            }
            catch
            {
                TasasDeCambioCache["USD"] = 1.00m;
                TasasDeCambioCache["PEN"] = 3.75m;
                TasasDeCambioCache["EUR"] = 0.92m;
            }
        }

        public static decimal? LimpiarTextoParaEdicion(string textoMoneda)
        {
            return ExtraerNumero(textoMoneda);
        }

        private static decimal? ExtraerNumero(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;

            // 1. Quitar símbolos conocidos (Lo pasamos a mayúsculas para atrapar el "s/." aunque lo escriban en minúscula)
            string t = texto.ToUpper().Replace("S/.", "").Replace("S/", "").Replace("$", "").Replace("€", "").Trim();

            // 2. Dejar puramente números, comas y puntos
            t = Regex.Replace(t, @"[^\d.,]", "");
            if (string.IsNullOrWhiteSpace(t)) return null;

            // 3. Inteligencia para detectar qué es el separador de miles y cuál el decimal
            int ultimaComa = t.LastIndexOf(',');
            int ultimoPunto = t.LastIndexOf('.');

            if (ultimaComa > -1 && ultimoPunto > -1)
            {
                // Si tiene ambos (ej: 1,500.50 o 1.500,50), el que está al final es el decimal real
                if (ultimaComa > ultimoPunto)
                    t = t.Replace(".", "").Replace(",", "."); // Formato europeo a invariante
                else
                    t = t.Replace(",", ""); // Formato americano a invariante
            }
            else if (ultimaComa > -1)
            {
                // Si solo hay comas, la convertimos en un punto decimal
                t = t.Replace(",", ".");
            }

            // 4. Si por algún error de tipeo (o al borrar el S/.) quedaron varios puntos (ej: .150.00), limpiamos los sobrantes
            while (t.IndexOf('.') != t.LastIndexOf('.'))
            {
                t = t.Remove(t.IndexOf('.'), 1);
            }

            // 5. Convertimos a decimal de forma 100% segura usando cultura Invariante
            if (decimal.TryParse(t, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            return null;
        }

        public static string AgregarSimboloVisual(decimal? montoEnPantalla)
        {
            if (!montoEnPantalla.HasValue) return "";

            string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "PEN";
            string isoCode = (!string.IsNullOrEmpty(monedaCompleta) && monedaCompleta.Length >= 3)
                             ? monedaCompleta.Substring(0, 3) : "PEN";

            string simboloVisual;
            switch (isoCode)
            {
                case "PEN": simboloVisual = "S/."; break;
                case "USD": simboloVisual = "$"; break;
                case "EUR": simboloVisual = "€"; break;
                default: simboloVisual = isoCode; break;
            }

            return $"{simboloVisual} {montoEnPantalla.Value.ToString("0.00")}";
        }

        public static int CalcularDistancia(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return string.IsNullOrEmpty(t) ? 0 : t.Length;
            if (string.IsNullOrEmpty(t)) return s.Length;

            int[] v0 = new int[t.Length + 1];
            int[] v1 = new int[t.Length + 1];

            for (int i = 0; i < v0.Length; i++) v0[i] = i;

            for (int i = 0; i < s.Length; i++)
            {
                v1[0] = i + 1;
                for (int j = 0; j < t.Length; j++)
                {
                    int cost = (s[i] == t[j]) ? 0 : 1;
                    v1[j + 1] = Math.Min(Math.Min(v1[j] + 1, v0[j + 1] + 1), v0[j] + cost);
                }
                for (int j = 0; j < v0.Length; j++) v0[j] = v1[j];
            }
            return v1[t.Length];
        }

        public static string FormatearNombreCorto(string nombres, string apellidos)
        {
            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos))
                return nombres ?? "" + " " + apellidos ?? "";

            // Obtener primer nombre
            string primerNombre = nombres.Trim().Split(' ')[0];

            // Procesar apellidos
            string[] listaApellidos = apellidos.Trim().Split(' ');
            string primerApellido = listaApellidos[0];
            string inicialSegundo = "";

            if (listaApellidos.Length > 1)
            {
                inicialSegundo = " " + listaApellidos[1].Substring(0, 1).ToUpper() + ".";
            }

            return $"{primerNombre} {primerApellido}{inicialSegundo}";
        }

        public static void AplicarEstilosGrillas(DataGridView grid)
        {
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null,
                grid,
                new object[] { true }
            );
            grid.BackgroundColor = Color.FromArgb(240, 244, 248);
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(215, 215, 215);
            grid.EnableHeadersVisualStyles = false;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersHeight = 40;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 238, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.Padding = new Padding(0, 2, 0, 2);

            grid.RowTemplate.Height = 50;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
        }
    }
}

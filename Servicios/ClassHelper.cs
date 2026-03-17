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
            foreach (Control control in inventario.LstArticulos.Controls)
            {
                if (control is Button btn && btn.Tag != null && Convert.ToInt32(btn.Tag) == idCategoria)
                {
                    inventario.LstArticulos.Controls.Remove(btn);
                    btn.Dispose();
                    break;
                }
            }

            if (inventario.LstArticulos.Controls.Count == 0)
            {
                inventario.LstArticulos.Visible = false;
            }
            else
            {
                Button primerBoton = (Button)inventario.LstArticulos.Controls[0];
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
            btn.Width = 75;
            btn.Height = 23;

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
            RefrescarListView(inventario.LstArticulos, articulos);
        }

        public static void RefrescarListView(ListView listView, IEnumerable<Articulos> articulos)
        {
            listView.Items.Clear();
            foreach (var art in articulos)
            {
                var item = new ListViewItem(art.Id.ToString());

                item.SubItems.Add(art.Codigo ?? "");
                item.SubItems.Add(art.Modelo ?? "");
                item.SubItems.Add(art.Serie ?? "");
                item.SubItems.Add(art.Marca ?? "");
                item.SubItems.Add(ClassHelper.FormatearFecha(art.FechaAdquisicion));
                item.SubItems.Add(ClassHelper.FormatearFecha(art.FechaBaja));
                item.SubItems.Add(ClassHelper.FormatearFecha(art.FechaFinGarantia));
                item.SubItems.Add("");
                item.SubItems.Add(art.EmpleadoActualTexto ?? "");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add(art.EmpleadoAnteriorTexto ?? "");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add(art.Estado ?? "");
                item.SubItems.Add(art.Ubicacion ?? "");
                item.SubItems.Add(art.Condicion ?? "");
                item.SubItems.Add(art.RucProveedor ?? "");
                item.SubItems.Add(art.Proveedor ?? "");
                item.SubItems.Add(ClassHelper.FormatearMoneda(art.PrecioAdquisicion));
                item.SubItems.Add(art.ActivoFijo ?? "");
                item.SubItems.Add(art.Observacion ?? "");
                item.SubItems.Add(art.FotoPrincipal ?? "");
                item.SubItems.Add(art.ComprobantePrincipal ?? "");

                listView.Items.Add(item);
            }

        }

        public static string NormalizarCombo(ComboBox combo)
        {
            return string.IsNullOrWhiteSpace(combo.Text) || combo.Text == "SELECCIONE"
                ? null
                : combo.Text;
        }

        public static void NormalizarTexto(ComboBox combo)
        {
            if (string.IsNullOrWhiteSpace(combo.Text) || combo.Text != Idiomas.OpcionSeleccione)
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

        public static void LimpiarCampoObsoletoBD(string tablaDestino, string columnaId, string columnaNombre, int idRegistro)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $@"UPDATE {tablaDestino} SET
                        {columnaId} = 0, 
                        {columnaNombre} = 'SELECCIONE' 
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
            if (string.IsNullOrWhiteSpace(textoMoneda)) return null;

            string textoLimpio = Regex.Replace(textoMoneda, @"[^\d.,-]", "").Trim();
            if (string.IsNullOrWhiteSpace(textoLimpio)) return null;

            decimal? montoPantalla = null;

            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal resultadoA))
                montoPantalla = resultadoA;
            else if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultadoB))
                montoPantalla = resultadoB;

            if (montoPantalla.HasValue)
            {
                string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "PEN";
                string isoCode = (!string.IsNullOrEmpty(monedaCompleta) && monedaCompleta.Length >= 3) ? monedaCompleta.Substring(0, 3) : "PEN";

                decimal tasaPEN = TasasDeCambioCache.ContainsKey("PEN") ? TasasDeCambioCache["PEN"] : 3.75m;
                decimal tasaOrigen = TasasDeCambioCache.ContainsKey(isoCode) ? TasasDeCambioCache[isoCode] : 1.00m;

                decimal montoEnUSD = montoPantalla.Value / tasaOrigen;

                decimal montoParaBD = montoEnUSD * tasaPEN;

                return montoParaBD;
            }

            return null;
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
            if (string.IsNullOrWhiteSpace(textoMoneda)) return null;

            string textoLimpio = Regex.Replace(textoMoneda, @"[^\d.,-]", "").Trim();
            if (string.IsNullOrWhiteSpace(textoLimpio)) return null;

            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal resultadoA))
                return resultadoA;
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultadoB))
                return resultadoB;

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

    }
}

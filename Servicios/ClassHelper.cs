using ControlInventario.Database;
using ControlInventario.Vistas;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ControlInventario.Modelo;
using ControlInventario.Modelos;

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
            foreach (Control control in inventario.DgvArticulos.Controls)
            {
                if (control is Button btn && btn.Tag != null && Convert.ToInt32(btn.Tag) == idCategoria)
                {
                    inventario.DgvArticulos.Controls.Remove(btn);
                    btn.Dispose();
                    break;
                }
            }

            Button primerBoton = null;
            foreach (Control control in inventario.DgvArticulos.Controls)
            {
                if (control is Button btn)
                {
                    primerBoton = btn;
                    break;
                }
            }

            if (primerBoton == null)
            {
                inventario.DgvArticulos.Visible = false;
            }
            else
            {
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
            RefrescarDvgIngresos(inventario.DgvArticulos, articulos);
        }

        public static void RefrescarDvgIngresos(DataGridView dataGrid, IEnumerable<Articulos> articulos)
        {
            dataGrid.Rows.Clear();

            foreach (var art in articulos)
            {
                if (art.GrupoRegistroId.HasValue && art.GrupoRegistroId.Value > 0)
                    continue;

                string json = art.Caracteristicas;
                string textoBoton = (!string.IsNullOrEmpty(json) && json != "{}") ? "Ver Detalles" : "N/A";

                int rowIndex = dataGrid.Rows.Add(
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
                    ClassHelper.FormatearMoneda(art.PrecioAdquisicion, art.MonedaAdquisicion),
                    art.Observacion ?? "",
                    art.FotoPrincipal ?? "",
                    art.ComprobantePrincipal ?? "",
                    textoBoton
                );

                dataGrid.Rows[rowIndex].Tag = art;
            }
        }

        public static void RefrescarDvgIngresosMasivos(DataGridView dataGrid, IEnumerable<Articulos> articulos)
        {
            dataGrid.Rows.Clear();

            var grupos = new Dictionary<int, ArticuloGrupo>();

            foreach (var art in articulos)
            {
                if (art.GrupoRegistroId.HasValue && art.GrupoRegistroId.Value > 0)
                {
                    int grupoId = art.GrupoRegistroId.Value;
                    if (!grupos.ContainsKey(grupoId))
                    {
                        grupos[grupoId] = new ArticuloGrupo
                        {
                            GrupoRegistroId = grupoId,
                            GrupoNombre = art.GrupoRegistroNombre ?? "Grupo",
                            Modelo = art.Modelo,
                            Marca = art.Marca,
                            Estado = art.Estado,
                            Ubicacion = art.Ubicacion,
                            Condicion = art.Condicion,
                            UnidadMedida = art.UnidadMedida,
                            Cantidad = 0,
                            FotoPrincipal = art.FotoPrincipal,
                            Articulos = new List<Articulos>()
                        };
                    }
                    grupos[grupoId].Cantidad++;
                    grupos[grupoId].Articulos.Add(art);
                }
            }

            foreach (var grupo in grupos.Values)
            {
                int rowIndex = dataGrid.Rows.Add(
                    grupo.GrupoRegistroId,
                    grupo.GrupoNombre,
                    grupo.Modelo ?? "(varios)",
                    $"{grupo.Cantidad} {grupo.UnidadMedida ?? "und."}",
                    grupo.Marca ?? "",
                    "",
                    "",
                    grupo.Estado ?? "(varios)",
                    grupo.Ubicacion ?? "(varios)",
                    grupo.Condicion ?? "(varios)",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    $"Ver ({grupo.Cantidad})"
                );

                dataGrid.Rows[rowIndex].Tag = grupo;
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

            string codigoCultura = "es-PE";

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

        public static string FormatearMoneda(decimal? monto, string monedaBaseDeDatos = "PEN")
        {
            if (!monto.HasValue) return string.Empty;
            decimal? montoConvertido = ConvertirBDAMonedaLocal(monto, monedaBaseDeDatos);
            string simbolo = ObtenerSimboloMoneda();

            return $"{simbolo} {montoConvertido.Value:N2}";
        }

        public static decimal? ConvertirTextoAMoneda(string textoMoneda)
        {
            // Usamos el extractor que diseñamos antes para que no se maree con el símbolo "€" o "S/"
            decimal? montoPantalla = LimpiarTextoParaEdicion(textoMoneda);
            if (!montoPantalla.HasValue) return null;

            string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "PEN";
            string isoCode = (!string.IsNullOrEmpty(monedaCompleta) && monedaCompleta.Length >= 3) ? monedaCompleta.Substring(0, 3) : "PEN";

            // Si ya está en soles, lo dejamos tranquilo
            if (isoCode == "PEN") return Math.Round(montoPantalla.Value, 2);

            decimal tasaPEN = TasasDeCambioCache.ContainsKey("PEN") ? TasasDeCambioCache["PEN"] : 3.75m;
            decimal tasaOrigen = TasasDeCambioCache.ContainsKey(isoCode) ? TasasDeCambioCache[isoCode] : 1.00m;

            // La magia: Pasamos de Local -> Dólar -> Soles(BD)
            decimal montoEnUSD = montoPantalla.Value / tasaOrigen;
            decimal montoParaBD = montoEnUSD * tasaPEN;

            return Math.Round(montoParaBD, 2);
        }

        public static decimal? LimpiarTextoParaEdicion(string textoMoneda)
        {
            if (string.IsNullOrWhiteSpace(textoMoneda)) return null;

            // 1. Quitamos todos los símbolos de moneda posibles, letras y espacios
            string textoLimpio = textoMoneda.Replace("S/", "")
                                      .Replace("€", "")
                                      .Replace("$", "")
                                      .Replace("PEN", "")
                                      .Replace("USD", "")
                                      .Replace("EUR", "")
                                      .Trim();

            // 2. Extraemos solo la parte numérica (Soportando comas o puntos según la región del PC)
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, null, out decimal resultado))
            {
                return resultado; // Retorna el número PURO, sin conversiones de tipo de cambio
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

        public static string ObtenerSimboloMoneda()
        {
            // Reutilizamos tu lógica exacta
            string monedaCompleta = UsuarioSesion.Configuracion?.Moneda ?? "PEN - Soles";
            string codigoMoneda = monedaCompleta.Split('-')[0].Trim();
            switch (codigoMoneda)
            {
                case "PEN": return "S/";
                case "USD": return "$";
                case "EUR": return "€";
                case "MXN": return "$";
                default: return codigoMoneda;
            }
        }

        public static decimal? ConvertirBDAMonedaLocal(decimal? montoOriginal, string monedaOriginal)
        {
            if (!montoOriginal.HasValue) return null;

            string isoOriginal = ObtenerIsoCodeSeguro(monedaOriginal);
            string monedaUsuario = UsuarioSesion.Configuracion?.Moneda ?? "PEN";
            string isoUsuario = ObtenerIsoCodeSeguro(monedaUsuario);

            if (isoOriginal == isoUsuario) return Math.Round(montoOriginal.Value, 2);

            decimal tasaOriginal = TasasDeCambioCache.ContainsKey(isoOriginal) ? TasasDeCambioCache[isoOriginal] : 1.00m;
            decimal tasaUsuario = TasasDeCambioCache.ContainsKey(isoUsuario) ? TasasDeCambioCache[isoUsuario] : 1.00m;

            decimal montoEnUSD = montoOriginal.Value / tasaOriginal;
            decimal montoFinal = montoEnUSD * tasaUsuario;

            return Math.Round(montoFinal, 2);
        }

        public static string ObtenerIsoCodeSeguro(string textoMoneda)
        {
            if (string.IsNullOrEmpty(textoMoneda)) return "PEN";

            string text = textoMoneda.ToUpper();

            if (text.Contains("PEN") || text.Contains("SOL")) return "PEN";
            if (text.Contains("USD") || text.Contains("DÓL") || text.Contains("DOL")) return "USD";
            if (text.Contains("EUR") || text.Contains("EURO")) return "EUR";

            return "PEN"; // Fallback por seguridad
        }

        public static decimal? ExtraerNumero(string textoMoneda)
        {
            if (string.IsNullOrWhiteSpace(textoMoneda)) return null;

            string textoLimpio = textoMoneda.Replace("S/", "")
                                            .Replace("€", "")
                                            .Replace("$", "")
                                            .Replace("PEN", "")
                                            .Replace("EUR", "")
                                            .Replace("USD", "")
                                            .Trim();

            if (decimal.TryParse(textoLimpio, System.Globalization.NumberStyles.Any, null, out decimal montoPuro))
            {
                return montoPuro;
            }

            return null;
        }
    }
}

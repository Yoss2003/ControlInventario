using ControlInventario.Modelos;
using ControlInventario.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace ControlInventario.Database
{
    public class ArticuloRepository
    {
        public static void CrearTablaArticulos(SQLiteConnection con)
        {
            // 1. CREAMOS LA TABLA LIMPIA (Sin textos redundantes de catálogos)
            string queryTabla = @"
            CREATE TABLE IF NOT EXISTS Articulos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                Codigo TEXT NOT NULL,
                Modelo TEXT NOT NULL,
                Serie TEXT NOT NULL,
                IdMarca INTEGER NOT NULL,
                FechaAdquisicion TEXT NOT NULL,
                FechaBaja TEXT,
                FechaFinGarantia TEXT,

                EmpleadoActualId INTEGER,
                EmpleadoAnteriorId INTEGER,

                IdEstado INTEGER NOT NULL,
                IdUbicacion INTEGER NOT NULL,
                IdCondicion INTEGER NOT NULL,
                ActivoFijo TEXT,

                Observacion TEXT,
                RutaFotoPrincipal TEXT,
                RutaFotoSecundaria TEXT,
                RutaComprobantePrincipal TEXT,
                RutaComprobanteSecundaria TEXT,

                RucProveedor TEXT,
                Proveedor TEXT,
                PrecioAdquisicion REAL,
                VidaUtilMeses INTEGER,
                Caracteristicas TEXT,

                CategoriaId INTEGER NOT NULL,

                FechaRegistro TEXT,
                FechaModificacion TEXT,
                Accion TEXT,

                FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id),
                FOREIGN KEY (EmpleadoActualId) REFERENCES Empleados(Id),
                FOREIGN KEY (EmpleadoAnteriorId) REFERENCES Empleados(Id)
            );";

            using (var cmd = new SQLiteCommand(queryTabla, con))
            {
                cmd.ExecuteNonQuery();
            }

            // 2. CREAMOS LA VISTA SQL (El traductor automático de IDs a Textos)
            string queryVista = @"
            CREATE VIEW IF NOT EXISTS vw_Articulos AS
            SELECT 
                a.*,
                c.Nombre AS CategoriaTexto,
                m.Nombre AS MarcaTexto,
                e.Nombre AS EstadoTexto,
                u.Nombre AS UbicacionTexto,
                cond.Nombre AS CondicionTexto,

                empAct.Nombres || ' ' || empAct.Apellidos AS EmpleadoActualTexto,
                empAct.DNI AS EmpleadoActualDNI,
                empAct.IdArea AS EmpleadoActualIdArea,
                areaAct.Nombre AS EmpleadoActualAreaTexto,
                empAct.IdCargo AS EmpleadoActualIdCargo,
                cargoAct.Nombre AS EmpleadoActualCargoTexto,

                empAnt.Nombres || ' ' || empAnt.Apellidos AS EmpleadoAnteriorTexto,
                empAnt.DNI AS EmpleadoAnteriorDNI,
                empAnt.IdArea AS EmpleadoAnteriorIdArea,
                areaAnt.Nombre AS EmpleadoAnteriorAreaTexto,
                empAnt.IdCargo AS EmpleadoAnteriorIdCargo,
                cargoAnt.Nombre AS EmpleadoAnteriorCargoTexto

            FROM Articulos a
            LEFT JOIN Categorias c ON a.CategoriaId = c.Id
            LEFT JOIN Marcas m ON a.IdMarca = m.Id
            LEFT JOIN Parametros e ON a.IdEstado = e.Id
            LEFT JOIN Parametros u ON a.IdUbicacion = u.Id
            LEFT JOIN Parametros cond ON a.IdCondicion = cond.Id
            LEFT JOIN Empleados empAct ON a.EmpleadoActualId = empAct.Id
            LEFT JOIN Parametros areaAct ON empAct.IdArea = areaAct.Id
            LEFT JOIN Parametros cargoAct ON empAct.IdCargo = cargoAct.Id
            LEFT JOIN Empleados empAnt ON a.EmpleadoAnteriorId = empAnt.Id
            LEFT JOIN Parametros areaAnt ON empAnt.IdArea = areaAnt.Id
            LEFT JOIN Parametros cargoAnt ON empAnt.IdCargo = cargoAnt.Id;";

            using (var cmdVista = new SQLiteCommand(queryVista, con))
            {
                cmdVista.ExecuteNonQuery();
            }
        }

        public static int ObtenerCategoriaId(string nombreCategoria, int inventarioId, SQLiteConnection con)
        {
            string query = "SELECT Id FROM Categorias WHERE Nombre = @Nombre AND InventarioId = @InventarioId LIMIT 1;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombreCategoria);
                cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public static void InsertarArticulo(Articulos art, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Articulos(
                InventarioId, Codigo, Modelo, Serie, IdMarca, FechaAdquisicion, FechaBaja, FechaFinGarantia,
                EmpleadoActualId, EmpleadoAnteriorId,
                IdEstado, IdUbicacion, IdCondicion, ActivoFijo, Observacion, RutaFotoPrincipal, RutaFotoSecundaria, 
                RutaComprobantePrincipal, RutaComprobanteSecundaria, RucProveedor, Proveedor, PrecioAdquisicion, VidaUtilMeses, Caracteristicas,
                CategoriaId, FechaRegistro, Accion
            ) VALUES (
                @InventarioId, @Codigo, @Modelo, @Serie, @IdMarca, @FechaAdquisicion, @FechaBaja, @FechaFinGarantia,
                @EmpleadoActualId, @EmpleadoAnteriorId,
                @IdEstado, @IdUbicacion, @IdCondicion, @ActivoFijo, @Observacion, @RutaFotoPrincipal, @RutaFotoSecundaria, 
                @RutaComprobantePrincipal, @RutaComprobanteSecundaria, @RucProveedor, @Proveedor, @PrecioAdquisicion, @VidaUtilMeses, @Caracteristicas,
                @CategoriaId, @FechaRegistro, @Accion
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                art.CategoriaId = ObtenerCategoriaId(art.Categoria, UsuarioSesion.InventarioId, con);

                cmd.Parameters.AddWithValue("@InventarioId", art.InventarioId);
                cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                cmd.Parameters.AddWithValue("@Serie", art.Serie);
                cmd.Parameters.AddWithValue("@IdMarca", art.IdMarca);
                cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja.HasValue ? art.FechaBaja.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFinGarantia", art.FechaFinGarantia.HasValue ? art.FechaFinGarantia.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@EmpleadoActualId", art.EmpleadoActualId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EmpleadoAnteriorId", art.EmpleadoAnteriorId ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                cmd.Parameters.AddWithValue("@IdCondicion", art.IdCondicion);
                cmd.Parameters.AddWithValue("@ActivoFijo", (object)art.ActivoFijo ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Observacion", (object)art.Observacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RutaFotoPrincipal", (object)art.FotoPrincipal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RutaFotoSecundaria", (object)art.FotoSecundaria ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RutaComprobantePrincipal", (object)art.ComprobantePrincipal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RutaComprobanteSecundaria", (object)art.ComprobanteSecundaria ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@RucProveedor", (object)art.RucProveedor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Proveedor", (object)art.Proveedor ?? DBNull.Value);
                cmd.Parameters.Add(new SQLiteParameter("@PrecioAdquisicion", DbType.Decimal) { Value = art.PrecioAdquisicion ?? (object)DBNull.Value });
                cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Caracteristicas", art.Caracteristicas ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@CategoriaId", art.CategoriaId);
                cmd.Parameters.AddWithValue("@FechaRegistro", art.FechaRegistro.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Accion", "Ingreso");
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand("SELECT last_insert_rowid();", con))
            {
                art.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static void ActualizarArticulo(Articulos art)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Articulos SET
                    Codigo = @Codigo, Modelo = @Modelo, Serie = @Serie, IdMarca = @IdMarca, 
                    FechaAdquisicion = @FechaAdquisicion, FechaBaja = @FechaBaja, FechaFinGarantia = @FechaFinGarantia,
                    EmpleadoActualId = @EmpleadoActualId, EmpleadoAnteriorId = @EmpleadoAnteriorId, 
                    IdEstado = @IdEstado, IdUbicacion = @IdUbicacion, IdCondicion = @IdCondicion, ActivoFijo = @ActivoFijo,
                    Observacion = @Observacion, RutaFotoPrincipal = @RutaFotoPrincipal, RutaFotoSecundaria = @RutaFotoSecundaria, 
                    RutaComprobantePrincipal = @RutaComprobantePrincipal, RutaComprobanteSecundaria = @RutaComprobanteSecundaria,
                    RucProveedor = @RucProveedor, Proveedor = @Proveedor, PrecioAdquisicion = @PrecioAdquisicion, 
                    VidaUtilMeses = @VidaUtilMeses, Caracteristicas = @Caracteristicas, FechaModificacion = @FechaModificacion, Accion = @Accion 
                WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                    cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", art.Serie);
                    cmd.Parameters.AddWithValue("@IdMarca", art.IdMarca);
                    cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion);
                    cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFinGarantia", art.FechaFinGarantia ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@EmpleadoActualId", art.EmpleadoActualId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpleadoAnteriorId", art.EmpleadoAnteriorId ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                    cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                    cmd.Parameters.AddWithValue("@IdCondicion", art.IdCondicion);
                    cmd.Parameters.AddWithValue("@ActivoFijo", (object)art.ActivoFijo ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Observacion", (object)art.Observacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RutaFotoPrincipal", (object)art.FotoPrincipal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RutaFotoSecundaria", (object)art.FotoSecundaria ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RutaComprobantePrincipal", (object)art.ComprobantePrincipal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RutaComprobanteSecundaria", (object)art.ComprobanteSecundaria ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RucProveedor", (object)art.RucProveedor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Proveedor", (object)art.Proveedor ?? DBNull.Value);
                    cmd.Parameters.Add(new SQLiteParameter("@PrecioAdquisicion", DbType.Decimal) { Value = art.PrecioAdquisicion ?? (object)DBNull.Value });
                    cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caracteristicas", art.Caracteristicas ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@FechaModificacion", art.FechaModificacion.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Accion", "Modificado");
                    cmd.Parameters.AddWithValue("@Id", art.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int EliminarArticulo(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"DELETE FROM Articulos WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Articulos> ListarArticulos(int categoriaId)
        {
            var lista = new List<Articulos>();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM vw_Articulos WHERE CategoriaId = @CategoriaId;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var articulo = MapearArticulos(reader);
                            lista.Add(articulo);
                        }
                    }
                }
            }
            return lista;
        }

        public static List<Articulos> BuscarArticulos(DateTime? fechaInicio, DateTime? fechaFin, string categoria)
        {
            var lista = new List<Articulos>();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                    SELECT * FROM vw_Articulos 
                    WHERE (@Categoria IS NULL OR CategoriaTexto = @Categoria)
                      AND (@FechaInicio IS NULL OR FechaRegistro >= @FechaInicio)
                      AND (@FechaFin IS NULL OR FechaRegistro <= @FechaFin);";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Categoria", string.IsNullOrEmpty(categoria) ? (object)DBNull.Value : categoria);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.HasValue ? fechaInicio.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin.HasValue ? fechaFin.Value : (object)DBNull.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Articulos
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Codigo = reader["Codigo"].ToString(),
                                Categoria = reader["CategoriaTexto"].ToString(),
                                Accion = reader["Accion"].ToString(),
                                EmpleadoActualTexto = reader["EmpleadoActualTexto"]?.ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                Observacion = reader["Observacion"].ToString(),
                            });
                        }
                        return lista;
                    }
                }
            }
        }

        public static DataTable BuscarArticulosPorCategoria(int inventarioId, int categoriaId, string codigo, int idMarca, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT * FROM vw_Articulos 
                WHERE InventarioId = @InventarioId 
                  AND CategoriaId = @CategoriaId
                  AND (@Codigo IS NULL OR Codigo LIKE @CodigoBusqueda)
                  AND (@IdMarca = 0 OR IdMarca = @IdMarca)
                  AND (@FechaInicio IS NULL OR FechaAdquisicion >= @FechaInicio)
                  AND (@FechaFin IS NULL OR FechaAdquisicion <= @FechaFin);";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    cmd.Parameters.AddWithValue("@Codigo", string.IsNullOrWhiteSpace(codigo) ? (object)DBNull.Value : codigo);
                    cmd.Parameters.AddWithValue("@CodigoBusqueda", $"%{codigo}%");
                    cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.HasValue ? fechaInicio.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin.HasValue ? fechaFin.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            // Renombrar columnas del DataTable para que hagan match con el DataGridView/ListView
            if (dt.Columns.Contains("MarcaTexto")) dt.Columns["MarcaTexto"].ColumnName = "Marca";
            if (dt.Columns.Contains("EstadoTexto")) dt.Columns["EstadoTexto"].ColumnName = "Estado";
            if (dt.Columns.Contains("UbicacionTexto")) dt.Columns["UbicacionTexto"].ColumnName = "Ubicacion";
            if (dt.Columns.Contains("CondicionTexto")) dt.Columns["CondicionTexto"].ColumnName = "Condicion";
            if (dt.Columns.Contains("CategoriaTexto")) dt.Columns["CategoriaTexto"].ColumnName = "Categoria";
            if (dt.Columns.Contains("EmpleadoActualTexto")) dt.Columns["EmpleadoActualTexto"].ColumnName = "Usuario Actual";

            return dt;
        }

        private static Articulos MapearArticulos(SQLiteDataReader reader)
        {
            return new Articulos
            {
                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                Codigo = reader["Codigo"]?.ToString(),
                Modelo = reader["Modelo"]?.ToString(),
                Serie = reader["Serie"]?.ToString(),

                IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                Marca = reader["MarcaTexto"]?.ToString(),

                FechaAdquisicion = reader["FechaAdquisicion"] != DBNull.Value ? DateTime.Parse(reader["FechaAdquisicion"].ToString()) : DateTime.MinValue,
                FechaBaja = reader["FechaBaja"] != DBNull.Value ? DateTime.Parse(reader["FechaBaja"].ToString()) : (DateTime?)null,
                FechaFinGarantia = reader["FechaFinGarantia"] != DBNull.Value ? DateTime.Parse(reader["FechaFinGarantia"].ToString()) : (DateTime?)null,

                // --- MAPEO DE EMPLEADO ACTUAL ---
                EmpleadoActualId = reader["EmpleadoActualId"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoActualId"]) : (int?)null,
                EmpleadoActualTexto = reader["EmpleadoActualTexto"]?.ToString(),
                EmpleadoActualDNI = reader["EmpleadoActualDNI"]?.ToString(),
                EmpleadoActualIdArea = reader["EmpleadoActualIdArea"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoActualIdArea"]) : (int?)null,
                EmpleadoActualAreaTexto = reader["EmpleadoActualAreaTexto"]?.ToString(),
                EmpleadoActualIdCargo = reader["EmpleadoActualIdCargo"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoActualIdCargo"]) : (int?)null,
                EmpleadoActualCargoTexto = reader["EmpleadoActualCargoTexto"]?.ToString(),

                // --- MAPEO DE EMPLEADO ANTERIOR ---
                EmpleadoAnteriorId = reader["EmpleadoAnteriorId"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoAnteriorId"]) : (int?)null,
                EmpleadoAnteriorTexto = reader["EmpleadoAnteriorTexto"]?.ToString(),
                EmpleadoAnteriorDNI = reader["EmpleadoAnteriorDNI"]?.ToString(),
                EmpleadoAnteriorIdArea = reader["EmpleadoAnteriorIdArea"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoAnteriorIdArea"]) : (int?)null,
                EmpleadoAnteriorAreaTexto = reader["EmpleadoAnteriorAreaTexto"]?.ToString(),
                EmpleadoAnteriorIdCargo = reader["EmpleadoAnteriorIdCargo"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoAnteriorIdCargo"]) : (int?)null,
                EmpleadoAnteriorCargoTexto = reader["EmpleadoAnteriorCargoTexto"]?.ToString(),

                IdEstado = reader["IdEstado"] != DBNull.Value ? Convert.ToInt32(reader["IdEstado"]) : 0,
                Estado = reader["EstadoTexto"]?.ToString(),
                IdUbicacion = reader["IdUbicacion"] != DBNull.Value ? Convert.ToInt32(reader["IdUbicacion"]) : 0,
                Ubicacion = reader["UbicacionTexto"]?.ToString(),
                IdCondicion = reader["IdCondicion"] != DBNull.Value ? Convert.ToInt32(reader["IdCondicion"]) : 0,
                Condicion = reader["CondicionTexto"]?.ToString(),
                ActivoFijo = reader["ActivoFijo"]?.ToString(),

                Observacion = reader["Observacion"]?.ToString(),
                FotoPrincipal = reader["RutaFotoPrincipal"].ToString(),
                FotoSecundaria = reader["RutaFotoSecundaria"].ToString(),
                ComprobantePrincipal = reader["RutaComprobantePrincipal"].ToString(),
                ComprobanteSecundaria = reader["RutaComprobanteSecundaria"].ToString(),

                RucProveedor = reader["RucProveedor"]?.ToString(),
                Proveedor = reader["Proveedor"]?.ToString(),
                PrecioAdquisicion = reader["PrecioAdquisicion"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioAdquisicion"]) : (decimal?)null,
                VidaUtilMeses = reader["VidaUtilMeses"] != DBNull.Value ? Convert.ToInt32(reader["VidaUtilMeses"]) : (int?)null,
                Caracteristicas = reader["Caracteristicas"] != DBNull.Value ? reader["Caracteristicas"].ToString() : null,

                CategoriaId = reader["CategoriaId"] != DBNull.Value ? Convert.ToInt32(reader["CategoriaId"]) : 0,
                Categoria = reader["CategoriaTexto"]?.ToString(),
            };
        }

        public static Articulos ObtenerArticuloPorId(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM vw_Articulos WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) return MapearArticulos(reader);
                    }
                }
            }
            return null;
        }

        public static string GenerarCodigoArticulo(string prefijoCategoria, int inventarioId)
        {
            string prefijoCompleto = $"{prefijoCategoria}-";
            int siguienteNumero = 1;

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                    SELECT MAX(Codigo) 
                    FROM Articulos 
                    WHERE InventarioId = @InventarioId 
                    AND Codigo LIKE @PrefijoBusqueda;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                    cmd.Parameters.AddWithValue("@PrefijoBusqueda", prefijoCompleto + "%");
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != DBNull.Value && resultado != null)
                    {
                        string codigoMaximo = resultado.ToString();
                        string soloNumeroStr = codigoMaximo.Replace(prefijoCompleto, "");
                        if (int.TryParse(soloNumeroStr, out int numeroActual))
                            siguienteNumero = numeroActual + 1;
                    }
                }
            }
            return $"{prefijoCompleto}{siguienteNumero.ToString("D4")}";
        }

        public static DateTime ObtenerUltimaFechaRegistro(int inventarioId, string nombreUsuarioActual, SQLiteConnection con)
        {
            DateTime fechaUltimoRegistro = DateTime.MinValue;
            string query = @"
                SELECT MAX(FechaRegistro) 
                FROM Articulos 
                WHERE InventarioId = @InventarioId 
                AND NombreUsuarioActual = @NombreUsuarioActual";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                cmd.Parameters.AddWithValue("@NombreUsuarioActual", nombreUsuarioActual);
                object resultado = cmd.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    if (DateTime.TryParse(resultado.ToString(), out DateTime fechaParseada))
                        fechaUltimoRegistro = fechaParseada;
                }
            }
            return fechaUltimoRegistro;
        }

        public static DataTable ListarArticulosDisponibles(int inventarioId)
        {
            DataTable dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"SELECT Id, Codigo, Modelo, RutaFotoPrincipal, RutaFotoSecundaria, PrecioAdquisicion 
                                 FROM vw_Articulos 
                                 WHERE InventarioId = @InvId 
                                   AND EstadoTexto = 'Operativo' 
                                   AND EmpleadoActualId IS NULL;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static string GenerarSerieAutomatica(string nombreCategoria, int idUsuario)
        {
            Random rnd = new Random();

            string nombreLimpio = string.IsNullOrWhiteSpace(nombreCategoria) ? "ART" : nombreCategoria.ToUpper();
            string consonantes = "";

            foreach (char c in nombreLimpio)
            {
                if ("BCDFGHJKLMNPQRSTVWXYZ".Contains(c))
                {
                    consonantes += c;
                }
            }

            string prefijo = consonantes.Length >= 3 ? consonantes.Substring(0, 3) : consonantes;
            string letrasRelleno = "XZQW";
            while (prefijo.Length < 3)
            {
                prefijo += letrasRelleno[rnd.Next(letrasRelleno.Length)];
            }

            DateTime hoy = DateTime.Now;

            char[] inicialesMes = { 'E', 'F', 'M', 'A', 'Y', 'J', 'L', 'G', 'S', 'O', 'N', 'D' };
            char mesLetra = inicialesMes[hoy.Month - 1];

            char diaLetra = (char)('A' + ((hoy.Day - 1) % 26));

            char letraVariable = (char)rnd.Next('A', 'Z' + 1);

            string origen = $"{mesLetra}{diaLetra}{letraVariable}{idUsuario}";

            string secuencial = rnd.Next(4096, 65536).ToString("X4");

            char sufijo = (char)rnd.Next('A', 'Z' + 1);

            return $"{prefijo}{origen}{secuencial}{sufijo}";
        }

        public static string GenerarModeloAutomatico(string nombreCategoria)
        {
            Random rnd = new Random();
            string nombreLimpio = string.IsNullOrWhiteSpace(nombreCategoria) ? "ART" : nombreCategoria.ToUpper();
            string consonantes = "";

            foreach (char c in nombreLimpio)
            {
                if ("BCDFGHJKLMNPQRSTVWXYZ".Contains(c)) consonantes += c;
            }

            string prefijo;
            if (consonantes.Length >= 3)
            {
                prefijo = consonantes.Substring(consonantes.Length - 3);
            }
            else
            {
                prefijo = consonantes;
                string letrasRelleno = "XYZQ";
                while (prefijo.Length < 3)
                {
                    prefijo += letrasRelleno[rnd.Next(letrasRelleno.Length)];
                }
            }

            DateTime ahora = DateTime.Now;
            return $"{prefijo}{ahora.ToString("MM")}-{ahora.ToString("mmss")}";
        }

        public static DataTable ListarArticulosAsignados(int inventarioId)
        {
            DataTable dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"SELECT Id, Codigo, Modelo, RutaFotoPrincipal, RutaFotoSecundaria, 
                                EmpleadoActualTexto, EmpleadoActualAreaTexto, EstadoTexto
                         FROM vw_Articulos 
                         WHERE InventarioId = @InvId 
                           AND EmpleadoActualId IS NOT NULL;";

                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);

                    using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
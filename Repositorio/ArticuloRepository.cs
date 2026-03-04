using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace ControlInventario.Database
{
    public class ArticuloRepository
    {
        public static void CrearTablaArticulos(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Articulos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                Codigo TEXT NOT NULL,
                Modelo TEXT NOT NULL,
                Serie TEXT NOT NULL,
                IdMarca INTEGER NOT NULL,
                Marca TEXT NOT NULL,                
                FechaAdquisicion TEXT NOT NULL,
                FechaBaja TEXT,
                FechaFinGarantia TEXT,

                DniUsuarioActual TEXT NOT NULL,
                NombreUsuarioActual TEXT,
                IdAreaUsuarioActual INTEGER,
                AreaUsuarioActual TEXT,                
                IdCargoUsuarioActual INTEGER,
                CargoUsuarioActual TEXT,

                DniUsuarioAnterior TEXT,
                NombreUsuarioAnterior TEXT,
                IdAreaUsuarioAnterior INTEGER,
                AreaUsuarioAnterior TEXT,                
                IdCargoUsuarioAnterior INTEGER,
                CargoUsuarioAnterior TEXT,

                IdEstado INTEGER NOT NULL,
                Estado TEXT NOT NULL,
                IdUbicacion INTEGER NOT NULL,
                Ubicacion TEXT NOT NULL,
                IdCondicion INTEGER NOT NULL,
                Condicion TEXT NOT NULL,
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

                CategoriaId INTEGER NOT NULL,
                Categoria TEXT NOT NULL,

                FechaRegistro TEXT,
                FechaModificacion TEXT,
                Accion TEXT,

                Caracteristicas BOOL,
                FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
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
                InventarioId,
                Codigo,
                Modelo,
                Serie,
                IdMarca,
                Marca,
                FechaAdquisicion,
                FechaBaja,
                FechaFinGarantia,

                DniUsuarioActual,
                NombreUsuarioActual,
                IdAreaUsuarioActual,
                AreaUsuarioActual,
                IdCargoUsuarioActual,
                CargoUsuarioActual,

                DniUsuarioAnterior,
                NombreUsuarioAnterior,
                IdAreaUsuarioAnterior,
                AreaUsuarioAnterior,
                IdCargoUsuarioAnterior,
                CargoUsuarioAnterior,

                IdEstado,
                Estado,
                IdUbicacion,
                Ubicacion,
                IdCondicion,
                Condicion,
                ActivoFijo,

                Observacion,
                RutaFotoPrincipal,
                RutaFotoSecundaria,
                RutaComprobantePrincipal,
                RutaComprobanteSecundaria,

                RucProveedor,
                Proveedor,
                PrecioAdquisicion,
                VidaUtilMeses,

                CategoriaId,
                Categoria,

                FechaRegistro,
                Accion
            ) VALUES (
                @InventarioId,
                @Codigo,
                @Modelo,
                @Serie,
                @IdMarca,
                @Marca,
                @FechaAdquisicion,
                @FechaBaja,
                @FechaFinGarantia,

                @DniUsuarioActual,
                @NombreUsuarioActual,
                @IdAreaUsuarioActual,
                @AreaUsuarioActual,
                @IdCargoUsuarioActual,
                @CargoUsuarioActual,

                @DniUsuarioAnterior,
                @NombreUsuarioAnterior,
                @IdAreaUsuarioAnterior,
                @AreaUsuarioAnterior,
                @IdCargoUsuarioAnterior,
                @CargoUsuarioAnterior,

                @IdEstado,
                @Estado,
                @IdUbicacion,
                @Ubicacion,
                @IdCondicion,
                @Condicion,
                @ActivoFijo,

                @Observacion,
                @RutaFotoPrincipal,
                @RutaFotoSecundaria,
                @RutaComprobantePrincipal,
                @RutaComprobanteSecundaria,

                @RucProveedor,
                @Proveedor,
                @PrecioAdquisicion,
                @VidaUtilMeses,

                @CategoriaId,
                @Categoria,

                @FechaRegistro,
                @Accion
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {

                art.CategoriaId = ObtenerCategoriaId(art.Categoria, UsuarioSesion.InventarioId, con);

                cmd.Parameters.AddWithValue("@InventarioId", art.InventarioId);
                cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                cmd.Parameters.AddWithValue("@Serie", art.Serie);
                cmd.Parameters.AddWithValue("@IdMarca", art.IdMarca);
                cmd.Parameters.AddWithValue("@Marca", art.Marca);
                cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja.HasValue ? art.FechaBaja.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFinGarantia", art.FechaFinGarantia.HasValue ? art.FechaFinGarantia.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@DniUsuarioActual", art.DniUsuarioActual);
                cmd.Parameters.AddWithValue("@NombreUsuarioActual", art.NombreUsuarioActual);
                cmd.Parameters.AddWithValue("@IdAreaUsuarioActual", art.IdAreaUsuarioActual);
                cmd.Parameters.AddWithValue("@AreaUsuarioActual", art.AreaUsuarioActual);
                cmd.Parameters.AddWithValue("@IdCargoUsuarioActual", art.IdCargoUsuarioActual);
                cmd.Parameters.AddWithValue("@CargoUsuarioActual", art.CargoUsuarioActual);

                cmd.Parameters.AddWithValue("@DniUsuarioAnterior", art.DniUsuarioAnterior);
                cmd.Parameters.AddWithValue("@NombreUsuarioAnterior", art.NombreUsuarioAnterior);
                cmd.Parameters.AddWithValue("@IdAreaUsuarioAnterior", art.IdAreaUsuarioAnterior);
                cmd.Parameters.AddWithValue("@AreaUsuarioAnterior", art.AreaUsuarioAnterior);
                cmd.Parameters.AddWithValue("@IdCargoUsuarioAnterior", art.IdCargoUsuarioAnterior);
                cmd.Parameters.AddWithValue("@CargoUsuarioAnterior", art.CargoUsuarioAnterior);

                cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                cmd.Parameters.AddWithValue("@Estado", art.Estado);
                cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                cmd.Parameters.AddWithValue("@Ubicacion", art.Ubicacion);
                cmd.Parameters.AddWithValue("@IdCondicion", art.IdCondicion);
                cmd.Parameters.AddWithValue("@Condicion", art.Condicion);
                cmd.Parameters.AddWithValue("@ActivoFijo", art.ActivoFijo);

                cmd.Parameters.AddWithValue("@Observacion", art.Observacion);

                cmd.Parameters.AddWithValue("@RutaFotoPrincipal", art.FotoPrincipal);
                cmd.Parameters.AddWithValue("@RutaFotoSecundaria", art.FotoSecundaria);
                cmd.Parameters.AddWithValue("@RutaComprobantePrincipal", art.ComprobantePrincipal);
                cmd.Parameters.AddWithValue("@RutaComprobanteSecundaria", art.ComprobanteSecundaria);

                cmd.Parameters.AddWithValue("@RucProveedor", art.RucProveedor);
                cmd.Parameters.AddWithValue("@Proveedor", art.Proveedor);
                cmd.Parameters.AddWithValue("@PrecioAdquisicion", art.PrecioAdquisicion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@CategoriaId", art.CategoriaId);
                cmd.Parameters.AddWithValue("@Categoria", art.Categoria);

                cmd.Parameters.AddWithValue("@FechaRegistro", art.FechaRegistro.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Accion", "Ingreso"); 
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand("SELECT last_insert_rowid();", con)) 
            { 
                art.Id = Convert.ToInt32(cmd.ExecuteScalar()); 
            }

            if (art.Caracteristicas != null && art.Caracteristicas.Count > 0)
            {
                var caracteristicasRepo = new CaracteristicaRepository();
                foreach (var car in art.Caracteristicas)
                {
                    car.ArticuloId = art.Id; 
                    CaracteristicaRepository.InsertarCaracteristica(car, con);
                }
            }
        }

        public static void ActualizarArticulo(Articulos art)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Articulos SET
                    Codigo = @Codigo,
                    Modelo = @Modelo,
                    Serie = @Serie,
                    IdMarca = @IdMarca,
                    Marca = @Marca,                    
                    FechaAdquisicion = @FechaAdquisicion,
                    FechaBaja = @FechaBaja,
                    FechaFinGarantia = @FechaFinGarantia,

                    DniUsuarioActual = @DniUsuarioActual,
                    NombreUsuarioActual = @NombreUsuarioActual,
                    IdAreaUsuarioActual = @IdAreaUsuarioActual,
                    AreaUsuarioActual = @AreaUsuarioActual,
                    IdCargoUsuarioActual = @IdCargoUsuarioActual,
                    CargoUsuarioActual = @CargoUsuarioActual,

                    DniUsuarioAnterior = @DniUsuarioAnterior,
                    NombreUsuarioAnterior = @NombreUsuarioAnterior,
                    IdAreaUsuarioAnterior = @IdAreaUsuarioAnterior,
                    AreaUsuarioAnterior = @AreaUsuarioAnterior,
                    IdCargoUsuarioAnterior = @IdCargoUsuarioAnterior,
                    CargoUsuarioAnterior = @CargoUsuarioAnterior,

                    IdEstado = @IdEstado,
                    Estado = @Estado,
                    IdUbicacion = @IdUbicacion,
                    Ubicacion = @Ubicacion,
                    IdCondicion = @IdCondicion,
                    Condicion = @Condicion,
                    ActivoFijo = @ActivoFijo,

                    Observacion = @Observacion,

                    RutaFotoPrincipal = @RutaFotoPrincipal,
                    RutaFotoSecundaria = @RutaFotoSecundaria,
                    RutaComprobantePrincipal = @RutaComprobantePrincipal,
                    RutaComprobanteSecundaria = @RutaComprobanteSecundaria,

                    RucProveedor = @RucProveedor,
                    Proveedor = @Proveedor,
                    PrecioAdquisicion = @PrecioAdquisicion,
                    VidaUtilMeses = @VidaUtilMeses,

                    FechaModificacion = @FechaModificacion,
                    Accion = @Accion
                WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                { 
                    cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                    cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", art.Serie);
                    cmd.Parameters.AddWithValue("@IdMarca", art.IdMarca);
                    cmd.Parameters.AddWithValue("@Marca", art.Marca);
                    cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion);
                    cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFinGarantia", art.FechaFinGarantia ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@DniUsuarioActual", art.DniUsuarioActual);
                    cmd.Parameters.AddWithValue("@NombreUsuarioActual", art.NombreUsuarioActual);
                    cmd.Parameters.AddWithValue("@IdAreaUsuarioActual", art.IdAreaUsuarioActual);
                    cmd.Parameters.AddWithValue("@AreaUsuarioActual", art.AreaUsuarioActual);
                    cmd.Parameters.AddWithValue("@IdCargoUsuarioActual", art.IdCargoUsuarioActual);
                    cmd.Parameters.AddWithValue("@CargoUsuarioActual", art.CargoUsuarioActual);

                    cmd.Parameters.AddWithValue("@DniUsuarioAnterior", art.DniUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@NombreUsuarioAnterior", art.NombreUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@IdAreaUsuarioAnterior", art.IdAreaUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@AreaUsuarioAnterior", art.AreaUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@IdCargoUsuarioAnterior", art.IdCargoUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@CargoUsuarioAnterior", art.CargoUsuarioAnterior);

                    cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                    cmd.Parameters.AddWithValue("@Estado", art.Estado);
                    cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                    cmd.Parameters.AddWithValue("@Ubicacion", art.Ubicacion);
                    cmd.Parameters.AddWithValue("@IdCondicion", art.IdCondicion);
                    cmd.Parameters.AddWithValue("@Condicion", art.Condicion);
                    cmd.Parameters.AddWithValue("@ActivoFijo", art.ActivoFijo);

                    cmd.Parameters.AddWithValue("@Observacion", art.Observacion);

                    cmd.Parameters.AddWithValue("@RutaFotoPrincipal", art.FotoPrincipal);
                    cmd.Parameters.AddWithValue("@RutaFotoSecundaria", art.FotoSecundaria);
                    cmd.Parameters.AddWithValue("@RutaComprobantePrincipal", art.ComprobantePrincipal);
                    cmd.Parameters.AddWithValue("@RutaComprobanteSecundaria", art.ComprobanteSecundaria);

                    cmd.Parameters.AddWithValue("@RucProveedor", art.RucProveedor);
                    cmd.Parameters.AddWithValue("@Proveedor", art.Proveedor);
                    cmd.Parameters.AddWithValue("@PrecioAdquisicion", art.PrecioAdquisicion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", art.Id);

                    cmd.Parameters.AddWithValue("@FechaModificacion", art.FechaModificacion.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Accion", "Modificado");
                    cmd.ExecuteNonQuery();

                }

            }

            if (art.Caracteristicas != null && art.Caracteristicas.Count > 0)
            {
                var caracteristicasRepo = new CaracteristicaRepository();
                foreach (var car in art.Caracteristicas)
                {
                    car.ArticuloId = art.Id;
                    CaracteristicaRepository.ActualizarCaracteristicas(car);
                }
            }
        }

        public static int EliminarArticulo(int id)  
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Primero eliminar características asociadas
                CaracteristicaRepository.EliminarCaracteristica(id);

                // Luego eliminar el artículo
                string query = @"DELETE FROM Articulos WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = cmd.ExecuteNonQuery();
                    return filas;
                }
            }
        }

        public static List<Articulos> ListarArticulos(int categoriaId)
        {
            var lista = new List<Articulos>();

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT art.*, cat.Nombre AS CategoriaNombre
                    FROM Articulos art
                    INNER JOIN Categorias cat ON art.CategoriaId = cat.Id
                    WHERE art.CategoriaId = @CategoriaId;
                ";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var articulo = MapearArticulos(reader);
                            articulo.Caracteristicas = CaracteristicaRepository.ListarCaracteristicas(articulo.Id);
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
                    SELECT art.*
                    FROM Articulos art
                    INNER JOIN Categorias cat ON art.CategoriaId = cat.Id
                    WHERE (@Categoria IS NULL OR cat.Nombre = @Categoria)
                      AND (@FechaInicio IS NULL OR art.FechaRegistro >= @FechaInicio)
                      AND (@FechaFin IS NULL OR art.FechaRegistro <= @FechaFin);
                ";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    // Parámetros seguros
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
                                Categoria = reader["Categoria"].ToString(),
                                Accion = reader["Accion"].ToString(),
                                AreaUsuarioActual = reader["AreaUsuarioActual"].ToString(),
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

                // 1. La base siempre filtra por el Inventario y la Categoría seleccionada
                string query = @"
                SELECT * FROM Articulos 
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
                Marca = reader["Marca"]?.ToString(),

                FechaAdquisicion = reader["FechaAdquisicion"] != DBNull.Value? DateTime.Parse(reader["FechaAdquisicion"].ToString()): DateTime.MinValue,
                FechaBaja = reader["FechaBaja"] != DBNull.Value? DateTime.Parse(reader["FechaBaja"].ToString()): (DateTime?)null,
                FechaFinGarantia = reader["FechaFinGarantia"] != DBNull.Value? DateTime.Parse(reader["FechaFinGarantia"].ToString()): (DateTime?)null,

                DniUsuarioActual = reader["DniUsuarioActual"]?.ToString(),
                NombreUsuarioActual = reader["NombreUsuarioActual"]?.ToString(),
                IdAreaUsuarioActual = reader["IdAreaUsuarioActual"] != DBNull.Value? Convert.ToInt32(reader["IdAreaUsuarioActual"]): 0,
                AreaUsuarioActual = reader["AreaUsuarioActual"]?.ToString(),
                IdCargoUsuarioActual = reader["IdCargoUsuarioActual"] != DBNull.Value ? Convert.ToInt32(reader["IdCargoUsuarioActual"]) : 0,
                CargoUsuarioActual = reader["CargoUsuarioActual"]?.ToString(),

                DniUsuarioAnterior = reader["DniUsuarioAnterior"]?.ToString(),
                NombreUsuarioAnterior = reader["NombreUsuarioAnterior"]?.ToString(),
                IdAreaUsuarioAnterior = reader["IdAreaUsuarioAnterior"] != DBNull.Value? Convert.ToInt32(reader["IdAreaUsuarioAnterior"]): 0,
                AreaUsuarioAnterior = reader["AreaUsuarioAnterior"]?.ToString(),
                IdCargoUsuarioAnterior = reader["IdCargoUsuarioAnterior"] != DBNull.Value ? Convert.ToInt32(reader["IdCargoUsuarioAnterior"]) : 0,
                CargoUsuarioAnterior = reader["CargoUsuarioAnterior"]?.ToString(),

                IdEstado = reader["IdEstado"] != DBNull.Value? Convert.ToInt32(reader["IdEstado"]): 0,
                Estado = reader["Estado"]?.ToString(),
                IdUbicacion = reader["IdUbicacion"] != DBNull.Value? Convert.ToInt32(reader["IdUbicacion"]): 0,
                Ubicacion = reader["Ubicacion"]?.ToString(),
                IdCondicion = reader["IdCondicion"] != DBNull.Value? Convert.ToInt32(reader["IdCondicion"]): 0,
                Condicion = reader["Condicion"]?.ToString(),
                ActivoFijo = reader["ActivoFijo"]?.ToString(),

                Observacion = reader["Observacion"]?.ToString(),
                FotoPrincipal = reader["RutaFotoPrincipal"].ToString(),
                FotoSecundaria = reader["RutaFotoSecundaria"].ToString(),
                ComprobantePrincipal = reader["RutaComprobantePrincipal"].ToString(),
                ComprobanteSecundaria = reader["RutaComprobanteSecundaria"].ToString(),

                RucProveedor = reader["RucProveedor"]?.ToString(),
                Proveedor = reader["Proveedor"]?.ToString(),
                PrecioAdquisicion = reader["PrecioAdquisicion"] != DBNull.Value? Convert.ToDecimal(reader["PrecioAdquisicion"]): (decimal?)null,
                VidaUtilMeses = reader["VidaUtilMeses"] != DBNull.Value? Convert.ToInt32(reader["VidaUtilMeses"]): (int?)null,

                CategoriaId = reader["CategoriaId"] != DBNull.Value? Convert.ToInt32(reader["CategoriaId"]): 0,
                Categoria = reader["Categoria"]?.ToString(),
            };
        }

        public static Articulos ObtenerArticuloPorId(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM Articulos WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearArticulos(reader);
                        }
                    }
                }
            }
            return null;
        }

    }
}

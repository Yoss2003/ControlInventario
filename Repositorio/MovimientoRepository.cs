using ControlInventario.Database;
using ControlInventario.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public class MovimientoRepository
    {
        public static void CrearTablaMovimientos(SQLiteConnection con)
        {
            string queryTabla = @"
            CREATE TABLE IF NOT EXISTS Movimientos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ArticuloId INTEGER NOT NULL,
                EmpleadoId INTEGER,
                IdAccion INTEGER NOT NULL,
                FechaMovimiento TEXT NOT NULL,
                Observacion TEXT,
                Monto REAL,
                Destinatario TEXT,
                PrecioVenta REAL,
                Documento TEXT,
                MetodoPago TEXT,
                TipoComprobante TEXT,
                TelefonoCliente TEXT,
                CorreoCliente TEXT,
                FOREIGN KEY (ArticuloId) REFERENCES Articulos(Id),
                FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
                FOREIGN KEY (IdAccion) REFERENCES Acciones(Id)
            );";

            using (var cmd = new SQLiteCommand(queryTabla, con))
            {
                cmd.ExecuteNonQuery();
            }

            string queryVista = @"
            CREATE VIEW IF NOT EXISTS vw_Movimientos AS
            SELECT 
                m.*,
                a.Codigo AS ArticuloCodigo,
                e.Nombres || ' ' || e.Apellidos AS EmpleadoNombre,
                acc.Nombre AS NombreAccion
            FROM Movimientos m
            LEFT JOIN Articulos a ON m.ArticuloId = a.Id
            LEFT JOIN Empleados e ON m.EmpleadoId = e.Id
            LEFT JOIN Acciones acc ON m.IdAccion = acc.Id;";

            using (var cmd = new SQLiteCommand(queryVista, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarMovimiento(Movimiento mov, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Movimientos (ArticuloId, EmpleadoId, IdAccion, FechaMovimiento, Observacion, Monto,
                                     Destinatario, PrecioVenta, Documento, MetodoPago, TipoComprobante) 
            VALUES (@ArticuloId, @EmpleadoId, @IdAccion, @FechaMovimiento, @Observacion, @Monto,
                    @Destinatario, @PrecioVenta, @Documento, @MetodoPago, @TipoComprobante);";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ArticuloId", mov.ArticuloId);
                cmd.Parameters.AddWithValue("@EmpleadoId", mov.EmpleadoId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdAccion", mov.IdAccion);
                cmd.Parameters.AddWithValue("@FechaMovimiento", mov.FechaMovimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrWhiteSpace(mov.Observacion) ? (object)DBNull.Value : mov.Observacion);
                cmd.Parameters.AddWithValue("@Monto", mov.Monto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Destinatario", string.IsNullOrWhiteSpace(mov.Destinatario) ? (object)DBNull.Value : mov.Destinatario);
                cmd.Parameters.AddWithValue("@PrecioVenta", mov.PrecioVenta ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Documento", string.IsNullOrWhiteSpace(mov.Documento) ? (object)DBNull.Value : mov.Documento);
                cmd.Parameters.AddWithValue("@MetodoPago", string.IsNullOrWhiteSpace(mov.MetodoPago) ? (object)DBNull.Value : mov.MetodoPago);
                cmd.Parameters.AddWithValue("@TipoComprobante", string.IsNullOrWhiteSpace(mov.TipoComprobante) ? (object)DBNull.Value : mov.TipoComprobante);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Movimiento> ListarMovimientosPorArticulo(int articuloId)
        {
            var lista = new List<Movimiento>();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM vw_Movimientos WHERE ArticuloId = @ArticuloId ORDER BY FechaMovimiento DESC;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArticuloId", articuloId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Movimiento
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ArticuloId = Convert.ToInt32(reader["ArticuloId"]),
                                EmpleadoId = reader["EmpleadoId"] != DBNull.Value ? Convert.ToInt32(reader["EmpleadoId"]) : (int?)null,
                                IdAccion = Convert.ToInt32(reader["IdAccion"]),
                                NombreAccion = reader["NombreAccion"]?.ToString(),
                                FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString()),
                                Observacion = reader["Observacion"]?.ToString(),
                                Monto = reader["Monto"] != DBNull.Value ? Convert.ToDecimal(reader["Monto"]) : (decimal?)null,
                                Destinatario = reader["Destinatario"]?.ToString(),
                                PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : (decimal?)null,
                                Documento = reader["Documento"]?.ToString(),
                                MetodoPago = reader["MetodoPago"]?.ToString(),
                                TipoComprobante = reader["TipoComprobante"]?.ToString(),
                                ArticuloCodigo = reader["ArticuloCodigo"]?.ToString(),
                                EmpleadoNombre = reader["EmpleadoNombre"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static void RegistrarAsignacionLote(List<int> listaArticulosIds, int empleadoId, string observacion)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        string queryMov = @"INSERT INTO Movimientos (ArticuloId, EmpleadoId, IdAccion, FechaMovimiento, Observacion) 
                                                            VALUES (@ArtId, @EmpId, 3, @Fecha, @Obs);";

                        string queryArt = @"UPDATE Articulos 
                        SET EmpleadoAnteriorId = EmpleadoActualId, 
                            EmpleadoActualId = @EmpId,
                            IdAccion = 3,
                            FechaModificacion = @Fecha
                        WHERE Id = @ArtId;";

                        using (var cmdMov = new SQLiteCommand(queryMov, con, transaction))
                        using (var cmdArt = new SQLiteCommand(queryArt, con, transaction))
                        {
                            foreach (int artId in listaArticulosIds)
                            {
                                cmdMov.Parameters.Clear();
                                cmdMov.Parameters.AddWithValue("@ArtId", artId);
                                cmdMov.Parameters.AddWithValue("@EmpId", empleadoId);
                                cmdMov.Parameters.AddWithValue("@Fecha", fechaActual);
                                cmdMov.Parameters.AddWithValue("@Obs", string.IsNullOrWhiteSpace(observacion) ? (object)DBNull.Value : observacion);
                                cmdMov.ExecuteNonQuery();

                                cmdArt.Parameters.Clear();
                                cmdArt.Parameters.AddWithValue("@ArtId", artId);
                                cmdArt.Parameters.AddWithValue("@EmpId", empleadoId);
                                cmdArt.Parameters.AddWithValue("@Fecha", fechaActual);
                                cmdArt.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al registrar la asignación en lote: " + ex.Message);
                    }
                }
            }
        }

        public static void RegistrarVenta(List<Movimiento> listaVentas)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        string queryMov = @"INSERT INTO Movimientos 
                                            (ArticuloId, EmpleadoId, IdAccion, FechaMovimiento, Observacion, Monto,
                                             Destinatario, PrecioVenta, Documento, MetodoPago, TipoComprobante) 
                                            VALUES (@ArtId, NULL, @IdAccion, @Fecha, @Obs, @Monto,
                                                    @Destinatario, @PrecioVenta, @Documento, @MetodoPago, @TipoComprobante);";

                        string queryArt = @"UPDATE Articulos 
                                            SET
                                                IdAccion = 2, 
                                                EmpleadoAnteriorId = EmpleadoActualId,
                                                EmpleadoActualId = NULL,
                                                FechaModificacion = @Fecha
                                            WHERE Id = @ArtId;";

                        using (var cmdMov = new SQLiteCommand(queryMov, con, transaction))
                        using (var cmdArt = new SQLiteCommand(queryArt, con, transaction))
                        {
                            foreach (var venta in listaVentas)
                            {
                                cmdMov.Parameters.Clear();
                                cmdMov.Parameters.AddWithValue("@ArtId", venta.ArticuloId);
                                cmdMov.Parameters.AddWithValue("@IdAccion", venta.IdAccion);
                                cmdMov.Parameters.AddWithValue("@Fecha", venta.FechaMovimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdMov.Parameters.AddWithValue("@Obs", string.IsNullOrWhiteSpace(venta.Observacion) ? (object)DBNull.Value : venta.Observacion);
                                cmdMov.Parameters.AddWithValue("@Monto", venta.Monto ?? (object)DBNull.Value);
                                cmdMov.Parameters.AddWithValue("@Destinatario", string.IsNullOrWhiteSpace(venta.Destinatario) ? (object)DBNull.Value : venta.Destinatario);
                                cmdMov.Parameters.AddWithValue("@PrecioVenta", venta.PrecioVenta ?? (object)DBNull.Value);
                                cmdMov.Parameters.AddWithValue("@Documento", string.IsNullOrWhiteSpace(venta.Documento) ? (object)DBNull.Value : venta.Documento);
                                cmdMov.Parameters.AddWithValue("@MetodoPago", string.IsNullOrWhiteSpace(venta.MetodoPago) ? (object)DBNull.Value : venta.MetodoPago);
                                cmdMov.Parameters.AddWithValue("@TipoComprobante", string.IsNullOrWhiteSpace(venta.TipoComprobante) ? (object)DBNull.Value : venta.TipoComprobante);
                                cmdMov.ExecuteNonQuery();

                                cmdArt.Parameters.Clear();
                                cmdArt.Parameters.AddWithValue("@ArtId", venta.ArticuloId);
                                cmdArt.Parameters.AddWithValue("@Fecha", venta.FechaMovimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdArt.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al registrar la venta en la base de datos: " + ex.Message);
                    }
                }
            }
        }

        public static decimal ObtenerTotalVentas(int inventarioId, bool soloDiaActual)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT COALESCE(SUM(m.PrecioVenta), 0)
                    FROM Movimientos m
                    INNER JOIN Articulos a ON m.ArticuloId = a.Id
                    WHERE a.InventarioId = @InvId
                      AND m.IdAccion = 2";

                if (soloDiaActual)
                {
                    query += " AND DATE(m.FechaMovimiento) = DATE('now', 'localtime')";
                }

                query += ";";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
                }
            }
        }

        public static void RegistrarVentaCredito(List<Movimiento> listaVentas, decimal totalVenta, decimal enganche, int numCuotas, string frecuencia, DateTime fechaPrimeraCuota)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        string queryMov = @"INSERT INTO Movimientos 
                                            (ArticuloId, EmpleadoId, IdAccion, FechaMovimiento, Observacion, Monto,
                                             Destinatario, PrecioVenta, Documento, MetodoPago, TipoComprobante) 
                                            VALUES (@ArtId, NULL, @IdAccion, @Fecha, @Obs, @Monto,
                                                    @Destinatario, @PrecioVenta, @Documento, @MetodoPago, @TipoComprobante);
                                            SELECT last_insert_rowid();";

                        string queryArt = @"UPDATE Articulos 
                                            SET IdAccion = 2, 
                                                EmpleadoAnteriorId = EmpleadoActualId,
                                                EmpleadoActualId = NULL,
                                                FechaModificacion = @Fecha
                                            WHERE Id = @ArtId;";

                        List<long> movimientoIds = new List<long>();

                        using (var cmdMov = new SQLiteCommand(queryMov, con, transaction))
                        using (var cmdArt = new SQLiteCommand(queryArt, con, transaction))
                        {
                            foreach (var venta in listaVentas)
                            {
                                cmdMov.Parameters.Clear();
                                cmdMov.Parameters.AddWithValue("@ArtId", venta.ArticuloId);
                                cmdMov.Parameters.AddWithValue("@IdAccion", venta.IdAccion);
                                cmdMov.Parameters.AddWithValue("@Fecha", venta.FechaMovimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdMov.Parameters.AddWithValue("@Obs", string.IsNullOrWhiteSpace(venta.Observacion) ? (object)DBNull.Value : venta.Observacion);
                                cmdMov.Parameters.AddWithValue("@Monto", venta.Monto ?? (object)DBNull.Value);
                                cmdMov.Parameters.AddWithValue("@Destinatario", string.IsNullOrWhiteSpace(venta.Destinatario) ? (object)DBNull.Value : venta.Destinatario);
                                cmdMov.Parameters.AddWithValue("@PrecioVenta", venta.PrecioVenta ?? (object)DBNull.Value);
                                cmdMov.Parameters.AddWithValue("@Documento", string.IsNullOrWhiteSpace(venta.Documento) ? (object)DBNull.Value : venta.Documento);
                                cmdMov.Parameters.AddWithValue("@MetodoPago", string.IsNullOrWhiteSpace(venta.MetodoPago) ? (object)DBNull.Value : venta.MetodoPago);
                                cmdMov.Parameters.AddWithValue("@TipoComprobante", string.IsNullOrWhiteSpace(venta.TipoComprobante) ? (object)DBNull.Value : venta.TipoComprobante);

                                long movId = (long)cmdMov.ExecuteScalar();
                                movimientoIds.Add(movId);

                                cmdArt.Parameters.Clear();
                                cmdArt.Parameters.AddWithValue("@ArtId", venta.ArticuloId);
                                cmdArt.Parameters.AddWithValue("@Fecha", venta.FechaMovimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdArt.ExecuteNonQuery();
                            }
                        }

                        foreach (long movId in movimientoIds)
                        {
                            decimal precioArticulo = totalVenta / listaVentas.Count;
                            decimal engancheProporcional = enganche / listaVentas.Count;

                            CuentasPorCobrarRepository.GenerarCuotas(
                                (int)movId,
                                precioArticulo,
                                engancheProporcional,
                                numCuotas,
                                frecuencia,
                                fechaPrimeraCuota,
                                con,
                                transaction
                            );
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al registrar la venta a crédito: " + ex.Message);
                    }
                }
            }
        }
    }
}

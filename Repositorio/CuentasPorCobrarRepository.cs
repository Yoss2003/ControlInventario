using ControlInventario.Database;
using ControlInventario.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public class CuentasPorCobrarRepository
    {
        public static void CrearTablaCuentasPorCobrar(SQLiteConnection con)
        {
            string queryCuotas = @"
            CREATE TABLE IF NOT EXISTS CuentasPorCobrar (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                MovimientoId INTEGER NOT NULL,
                NumeroCuota INTEGER NOT NULL,
                MontoCuota REAL NOT NULL,
                MontoPagado REAL NOT NULL DEFAULT 0,
                MontoMora REAL NOT NULL DEFAULT 0,
                FechaVencimiento TEXT NOT NULL,
                FechaPago TEXT,
                Estado TEXT NOT NULL DEFAULT 'Pendiente',
                Frecuencia TEXT NOT NULL,
                FOREIGN KEY (MovimientoId) REFERENCES Movimientos(Id)
            );";

            using (var cmd = new SQLiteCommand(queryCuotas, con))
            {
                cmd.ExecuteNonQuery();
            }

            string queryPagos = @"
            CREATE TABLE IF NOT EXISTS PagosCuotas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CuotaId INTEGER NOT NULL,
                MontoAbono REAL NOT NULL,
                FechaPago TEXT NOT NULL,
                Observacion TEXT,
                FOREIGN KEY (CuotaId) REFERENCES CuentasPorCobrar(Id)
            );";

            using (var cmd = new SQLiteCommand(queryPagos, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void GenerarCuotas(int movimientoId, decimal totalVenta, decimal enganche, int numeroCuotas, string frecuencia, DateTime fechaPrimeraCuota, SQLiteConnection con, SQLiteTransaction transaction)
        {
            decimal montoFinanciar = totalVenta - enganche;
            decimal montoPorCuota = Math.Round(montoFinanciar / numeroCuotas, 2);
            decimal diferencia = montoFinanciar - (montoPorCuota * numeroCuotas);

            for (int i = 1; i <= numeroCuotas; i++)
            {
                DateTime fechaVencimiento = CalcularFechaVencimiento(fechaPrimeraCuota, frecuencia, i - 1);

                // La última cuota absorbe la diferencia de redondeo
                decimal montoCuota = (i == numeroCuotas) ? montoPorCuota + diferencia : montoPorCuota;

                string query = @"
                INSERT INTO CuentasPorCobrar (MovimientoId, NumeroCuota, MontoCuota, MontoPagado, MontoMora, FechaVencimiento, Estado, Frecuencia)
                VALUES (@MovId, @NumCuota, @MontoCuota, 0, 0, @FechaVenc, 'Pendiente', @Frecuencia);";

                using (var cmd = new SQLiteCommand(query, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@MovId", movimientoId);
                    cmd.Parameters.AddWithValue("@NumCuota", i);
                    cmd.Parameters.AddWithValue("@MontoCuota", montoCuota);
                    cmd.Parameters.AddWithValue("@FechaVenc", fechaVencimiento.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Frecuencia", frecuencia);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static DateTime CalcularFechaVencimiento(DateTime fechaBase, string frecuencia, int numeroPeriodo)
        {
            switch (frecuencia)
            {
                case "Semanal": return fechaBase.AddDays(7 * numeroPeriodo);
                case "Quincenal": return fechaBase.AddDays(15 * numeroPeriodo);
                case "Mensual": return fechaBase.AddMonths(numeroPeriodo);
                default: return fechaBase.AddMonths(numeroPeriodo);
            }
        }

        public static void RegistrarAbono(PagoCuota pago, SQLiteConnection con, SQLiteTransaction transaction)
        {
            string queryPago = @"
            INSERT INTO PagosCuotas (CuotaId, MontoAbono, FechaPago, Observacion)
            VALUES (@CuotaId, @Monto, @Fecha, @Obs);";

            using (var cmd = new SQLiteCommand(queryPago, con, transaction))
            {
                cmd.Parameters.AddWithValue("@CuotaId", pago.CuotaId);
                cmd.Parameters.AddWithValue("@Monto", pago.MontoAbono);
                cmd.Parameters.AddWithValue("@Fecha", pago.FechaPago.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Obs", string.IsNullOrWhiteSpace(pago.Observacion) ? (object)DBNull.Value : pago.Observacion);
                cmd.ExecuteNonQuery();
            }

            string queryActualizar = @"
            UPDATE CuentasPorCobrar 
            SET MontoPagado = MontoPagado + @Monto,
                Estado = CASE 
                    WHEN (MontoPagado + @Monto) >= (MontoCuota + MontoMora) THEN 'Pagada'
                    ELSE Estado 
                END,
                FechaPago = CASE 
                    WHEN (MontoPagado + @Monto) >= (MontoCuota + MontoMora) THEN @Fecha
                    ELSE FechaPago 
                END
            WHERE Id = @CuotaId;";

            using (var cmd = new SQLiteCommand(queryActualizar, con, transaction))
            {
                cmd.Parameters.AddWithValue("@Monto", pago.MontoAbono);
                cmd.Parameters.AddWithValue("@Fecha", pago.FechaPago.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@CuotaId", pago.CuotaId);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<CuentaPorCobrar> ListarCuotasPorMovimiento(int movimientoId)
        {
            var lista = new List<CuentaPorCobrar>();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM CuentasPorCobrar WHERE MovimientoId = @MovId ORDER BY NumeroCuota;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MovId", movimientoId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearCuota(reader));
                        }
                    }
                }
            }
            return lista;
        }

        public static List<CuentaPorCobrar> ListarCuotasPendientes(int inventarioId)
        {
            var lista = new List<CuentaPorCobrar>();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT c.*, m.Destinatario, m.Documento, m.ArticuloId,
                       a.Codigo AS ArticuloCodigo
                FROM CuentasPorCobrar c
                INNER JOIN Movimientos m ON c.MovimientoId = m.Id
                INNER JOIN Articulos a ON m.ArticuloId = a.Id
                WHERE a.InventarioId = @InvId
                  AND c.Estado IN ('Pendiente', 'Vencida')
                ORDER BY c.FechaVencimiento ASC;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cuota = MapearCuota(reader);
                            cuota.Destinatario = reader["Destinatario"]?.ToString();
                            cuota.Documento = reader["Documento"]?.ToString();
                            cuota.ArticuloCodigo = reader["ArticuloCodigo"]?.ToString();
                            cuota.ArticuloId = Convert.ToInt32(reader["ArticuloId"]);
                            lista.Add(cuota);
                        }
                    }
                }
            }
            return lista;
        }

        public static void AplicarMoras(int inventarioId, decimal porcentajeMora, int diasGracia)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string fechaLimite = DateTime.Now.AddDays(-diasGracia).ToString("yyyy-MM-dd");

                // Marcar como vencidas las cuotas que pasaron la fecha + gracia
                string queryVencer = @"
                UPDATE CuentasPorCobrar 
                SET Estado = 'Vencida'
                WHERE Estado = 'Pendiente'
                  AND FechaVencimiento < @FechaLimite
                  AND MovimientoId IN (
                      SELECT m.Id FROM Movimientos m
                      INNER JOIN Articulos a ON m.ArticuloId = a.Id
                      WHERE a.InventarioId = @InvId
                  );";

                using (var cmd = new SQLiteCommand(queryVencer, con))
                {
                    cmd.Parameters.AddWithValue("@FechaLimite", fechaLimite);
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);
                    cmd.ExecuteNonQuery();
                }

                // Aplicar mora sobre cuotas vencidas que aún no tienen mora
                string queryMora = @"
                UPDATE CuentasPorCobrar 
                SET MontoMora = ROUND(MontoCuota * @Porcentaje / 100.0, 2)
                WHERE Estado = 'Vencida'
                  AND MontoMora = 0
                  AND MovimientoId IN (
                      SELECT m.Id FROM Movimientos m
                      INNER JOIN Articulos a ON m.ArticuloId = a.Id
                      WHERE a.InventarioId = @InvId
                  );";

                using (var cmd = new SQLiteCommand(queryMora, con))
                {
                    cmd.Parameters.AddWithValue("@Porcentaje", porcentajeMora);
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CancelarCuotasPendientes(int movimientoId, string motivo)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE CuentasPorCobrar 
                SET Estado = 'Cancelada'
                WHERE MovimientoId = @MovId 
                  AND Estado IN ('Pendiente', 'Vencida');";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MovId", movimientoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static CuentaPorCobrar MapearCuota(SQLiteDataReader reader)
        {
            return new CuentaPorCobrar
            {
                Id = Convert.ToInt32(reader["Id"]),
                MovimientoId = Convert.ToInt32(reader["MovimientoId"]),
                NumeroCuota = Convert.ToInt32(reader["NumeroCuota"]),
                MontoCuota = Convert.ToDecimal(reader["MontoCuota"]),
                MontoPagado = Convert.ToDecimal(reader["MontoPagado"]),
                MontoMora = Convert.ToDecimal(reader["MontoMora"]),
                FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString()),
                FechaPago = reader["FechaPago"] != DBNull.Value ? DateTime.Parse(reader["FechaPago"].ToString()) : (DateTime?)null,
                Estado = reader["Estado"].ToString(),
                Frecuencia = reader["Frecuencia"].ToString()
            };
        }

        public static DataTable ListarResumenCuentas(int inventarioId, string filtroEstado = "", string filtroCliente = "")
        {
            DataTable dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT c.Id, c.NumeroCuota, c.MontoCuota, c.MontoPagado, c.MontoMora,
                       c.FechaVencimiento, c.FechaPago, c.Estado, c.Frecuencia, c.MovimientoId,
                       ROUND(c.MontoCuota + c.MontoMora - c.MontoPagado, 2) AS Saldo,
                       m.Destinatario, m.Documento, m.ArticuloId, m.MetodoPago,
                       a.Codigo AS ArticuloCodigo, a.Modelo AS ArticuloModelo,
                       cat.EsDevolvible
                FROM CuentasPorCobrar c
                INNER JOIN Movimientos m ON c.MovimientoId = m.Id
                INNER JOIN Articulos a ON m.ArticuloId = a.Id
                INNER JOIN Categorias cat ON a.CategoriaId = cat.Id
                WHERE a.InventarioId = @InvId";

                if (!string.IsNullOrEmpty(filtroEstado) && filtroEstado != "Todos")
                {
                    query += " AND c.Estado = @Estado";
                }

                if (!string.IsNullOrEmpty(filtroCliente))
                {
                    query += " AND (m.Destinatario LIKE @Cliente OR m.Documento LIKE @Cliente)";
                }

                query += " ORDER BY c.FechaVencimiento ASC;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);
                    if (!string.IsNullOrEmpty(filtroEstado) && filtroEstado != "Todos")
                        cmd.Parameters.AddWithValue("@Estado", filtroEstado);
                    if (!string.IsNullOrEmpty(filtroCliente))
                        cmd.Parameters.AddWithValue("@Cliente", $"%{filtroCliente}%");

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static void RenegociarCuotas(int movimientoId, int nuevasCuotas, string nuevaFrecuencia, DateTime nuevaFechaPrimera)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Calcular saldo total pendiente (cuotas + mora - pagado)
                        string querySaldo = @"
                        SELECT COALESCE(SUM(MontoCuota + MontoMora - MontoPagado), 0)
                        FROM CuentasPorCobrar 
                        WHERE MovimientoId = @MovId AND Estado IN ('Pendiente', 'Vencida');";

                        decimal saldoPendiente;
                        using (var cmd = new SQLiteCommand(querySaldo, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MovId", movimientoId);
                            saldoPendiente = Convert.ToDecimal(cmd.ExecuteScalar());
                        }

                        // Marcar cuotas anteriores como renegociadas
                        string queryRenegociar = @"
                        UPDATE CuentasPorCobrar 
                        SET Estado = 'Renegociada'
                        WHERE MovimientoId = @MovId AND Estado IN ('Pendiente', 'Vencida');";

                        using (var cmd = new SQLiteCommand(queryRenegociar, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MovId", movimientoId);
                            cmd.ExecuteNonQuery();
                        }

                        // Generar nuevas cuotas con el saldo pendiente
                        GenerarCuotas(movimientoId, saldoPendiente, 0, nuevasCuotas, nuevaFrecuencia, nuevaFechaPrimera, con, transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al renegociar cuotas: " + ex.Message);
                    }
                }
            }
        }

        public static int ContarCuotasVencidas(int inventarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT COUNT(*) FROM CuentasPorCobrar c
                INNER JOIN Movimientos m ON c.MovimientoId = m.Id
                INNER JOIN Articulos a ON m.ArticuloId = a.Id
                WHERE a.InventarioId = @InvId AND c.Estado = 'Vencida';";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InvId", inventarioId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static bool TieneCuotasPendientes(int articuloId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT COUNT(*)
                FROM CuentasPorCobrar c
                INNER JOIN Movimientos m ON c.MovimientoId = m.Id
                WHERE m.ArticuloId = @ArtId
                  AND c.Estado IN ('Pendiente', 'Vencida');";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArtId", articuloId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static decimal ObtenerTotalPagadoPorArticulo(int articuloId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT COALESCE(SUM(c.MontoPagado), 0)
                FROM CuentasPorCobrar c
                INNER JOIN Movimientos m ON c.MovimientoId = m.Id
                WHERE m.ArticuloId = @ArtId;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArtId", articuloId);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public static void CancelarCuotasPorArticulo(int articuloId, string motivo)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE CuentasPorCobrar 
                SET Estado = 'Cancelada'
                WHERE Estado IN ('Pendiente', 'Vencida')
                  AND MovimientoId IN (
                      SELECT Id FROM Movimientos WHERE ArticuloId = @ArtId AND IdAccion = 2
                  );";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArtId", articuloId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ListarCuotasParaNotificar(int inventarioId)
        {
            DataTable dt = new DataTable();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT c.Id, c.NumeroCuota, c.MontoCuota, c.MontoMora, c.FechaVencimiento,
                       m.Destinatario, m.Documento,
                       cl.Telefono AS TelefonoCliente, cl.Correo AS CorreoCliente
                FROM CuentasPorCobrar c
                INNER JOIN Movimientos m ON c.MovimientoId = m.Id
                INNER JOIN Articulos a ON m.ArticuloId = a.Id
                LEFT JOIN Clientes cl ON m.Documento = cl.Documento
                WHERE a.InventarioId = @InvId
                  AND c.Estado IN ('Pendiente', 'Vencida')
                  AND (cl.Telefono IS NOT NULL OR cl.Correo IS NOT NULL)
                  AND DATE(c.FechaVencimiento) <= DATE('now', '+3 days', 'localtime')
                ORDER BY c.FechaVencimiento ASC;";

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
    }
}
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
                TipoMovimiento TEXT NOT NULL,
                FechaMovimiento TEXT NOT NULL,
                Observacion TEXT,
                Monto REAL,
                UsuarioResponsable TEXT NOT NULL,
                FOREIGN KEY (ArticuloId) REFERENCES Articulos(Id),
                FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id)
            );";

            using (var cmd = new SQLiteCommand(queryTabla, con))
            {
                cmd.ExecuteNonQuery();
            }

            // Vista para ver el código del equipo y el nombre del empleado
            string queryVista = @"
            CREATE VIEW IF NOT EXISTS vw_Movimientos AS
            SELECT 
                m.*,
                a.Codigo AS ArticuloCodigo,
                e.Nombres || ' ' || e.Apellidos AS EmpleadoNombre
            FROM Movimientos m
            LEFT JOIN Articulos a ON m.ArticuloId = a.Id
            LEFT JOIN Empleados e ON m.EmpleadoId = e.Id;";

            using (var cmd = new SQLiteCommand(queryVista, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarMovimiento(Movimiento mov, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Movimientos (ArticuloId, EmpleadoId, TipoMovimiento, FechaMovimiento, Observacion, Monto, UsuarioResponsable) 
            VALUES (@ArticuloId, @EmpleadoId, @TipoMovimiento, @FechaMovimiento, @Observacion, @Monto, @UsuarioResponsable);";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ArticuloId", mov.ArticuloId);
                cmd.Parameters.AddWithValue("@EmpleadoId", mov.EmpleadoId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoMovimiento", mov.TipoMovimiento);
                cmd.Parameters.AddWithValue("@FechaMovimiento", mov.FechaMovimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrWhiteSpace(mov.Observacion) ? (object)DBNull.Value : mov.Observacion);
                cmd.Parameters.AddWithValue("@Monto", mov.Monto);
                cmd.Parameters.AddWithValue("@UsuarioResponsable", mov.UsuarioResponsable);

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
                                TipoMovimiento = reader["TipoMovimiento"].ToString(),
                                FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString()),
                                Observacion = reader["Observacion"]?.ToString(),
                                Monto = reader["Monto"] != DBNull.Value ? Convert.ToInt32(reader["Monto"]) : (int?)null,
                                UsuarioResponsable = reader["UsuarioResponsable"].ToString(),
                                ArticuloCodigo = reader["ArticuloCodigo"]?.ToString(),
                                EmpleadoNombre = reader["EmpleadoNombre"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static void RegistrarAsignacionLote(List<int> listaArticulosIds, int empleadoId, string observacion, int idEstadoAsignado, string usuarioResponsable)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        string queryMov = @"INSERT INTO Movimientos (ArticuloId, EmpleadoId, TipoMovimiento, FechaMovimiento, Observacion, UsuarioResponsable) 
                                    VALUES (@ArtId, @EmpId, 'ASIGNACION', @Fecha, @Obs, @UsuResp);";

                        string queryArt = @"UPDATE Articulos 
                                    SET EmpleadoAnteriorId = EmpleadoActualId, 
                                        EmpleadoActualId = @EmpId, 
                                        IdEstado = @IdEst 
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
                                cmdMov.Parameters.AddWithValue("@UsuResp", usuarioResponsable);
                                cmdMov.ExecuteNonQuery();

                                cmdArt.Parameters.Clear();
                                cmdArt.Parameters.AddWithValue("@ArtId", artId);
                                cmdArt.Parameters.AddWithValue("@EmpId", empleadoId);
                                cmdArt.Parameters.AddWithValue("@IdEst", idEstadoAsignado);
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
    }
}

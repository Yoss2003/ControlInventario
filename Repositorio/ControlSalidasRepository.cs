using ControlInventario.Database;
using ControlInventario.Modelo;
using System;
using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public class ControlSalidasRepository
    {
        public static void CrearTablaSalidas(SQLiteConnection con)
        {
            string sql = @"
			CREATE TABLE Salidas (
				Id	INTEGER NOT NULL UNIQUE,
				ArticuloId INTEGER NOT NULL,
				InventarioId INTEGER NOT NULL,
				Motivo TEXT NOT NULL,
				Destinatario TEXT,
				FechaSalida	TEXT NOT NULL,
				PrecioVenta	NUMERIC,
				TipoPago TEXT,
				Cuotas INTEGER,
				FechaFinPago TEXT,
				EstaPagado INTEGER NOT NULL,
				Observaciones TEXT,
				UsuarioRegistro TEXT,
				PRIMARY KEY(Id AUTOINCREMENT),
				FOREIGN KEY(ArticuloId) REFERENCES Articulos(Id)
			);";

            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void RegistrarSalida(SalidaArticulo salida, int nuevoEstadoArticuloId, string nuevoEstadoTexto)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Iniciamos una transacción: Si falla algo, nada se guarda.
                using (var transaccion = con.BeginTransaction())
                {
                    try
                    {
                        string querySalida = @"
                            INSERT INTO Salidas (ArticuloId, InventarioId, Motivo, Destinatario, FechaSalida, PrecioVenta, TipoPago, Cuotas, FechaFinPago, EstaPagado, Observaciones, UsuarioRegistro) 
                            VALUES (@ArticuloId, @InventarioId, @Motivo, @Destinatario, @FechaSalida, @PrecioVenta, @TipoPago, @Cuotas, @FechaFinPago, @EstaPagado, @Observaciones, @UsuarioRegistro)";

                        using (var cmd = new SQLiteCommand(querySalida, con, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@ArticuloId", salida.ArticuloId);
                            cmd.Parameters.AddWithValue("@InventarioId", salida.InventarioId);
                            cmd.Parameters.AddWithValue("@Motivo", salida.Motivo);
                            cmd.Parameters.AddWithValue("@Destinatario", salida.Destinatario ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@FechaSalida", salida.FechaSalida.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@PrecioVenta", salida.PrecioVenta ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@TipoPago", salida.TipoPago ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Cuotas", salida.Cuotas ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@FechaFinPago", salida.FechaFinPago.HasValue ? salida.FechaFinPago.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@EstaPagado", salida.EstaPagado ? 1 : 0);
                            cmd.Parameters.AddWithValue("@Observaciones", salida.Observaciones ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@UsuarioRegistro", salida.UsuarioRegistro);

                            cmd.ExecuteNonQuery();
                        }

                        string queryUpdateArt = @"
                            UPDATE Articulos 
                            SET IdEstado = @NuevoEstadoId, 
                                Estado = @NuevoEstadoTexto, 
                                FechaBaja = @FechaBaja,
                                Accion = 'Salida',
                                FechaModificacion = @FechaMod
                            WHERE Id = @ArticuloId";

                        using (var cmdUpd = new SQLiteCommand(queryUpdateArt, con, transaccion))
                        {
                            cmdUpd.Parameters.AddWithValue("@NuevoEstadoId", nuevoEstadoArticuloId);
                            cmdUpd.Parameters.AddWithValue("@NuevoEstadoTexto", nuevoEstadoTexto);
                            cmdUpd.Parameters.AddWithValue("@FechaBaja", salida.FechaSalida.ToString("yyyy-MM-dd"));
                            cmdUpd.Parameters.AddWithValue("@FechaMod", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmdUpd.Parameters.AddWithValue("@ArticuloId", salida.ArticuloId);

                            cmdUpd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al registrar la salida: " + ex.Message);
                    }
                }
            }
        }
    }
}

using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class ArticuloRepository
    {
        public static void InsertarArticulo(Articulos art, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Articulos(
                Codigo,
                Modelo,
                Serie,
                Marca,
                FechaAdquisicion,
                FechaBaja,
                FechaFinGarantia,

                DniUsuarioActual,
                NombreUsuarioActual,
                IdAreaUsuarioActual,
                AreaUsuarioActual,
                CargoUsuarioActual,

                DniUsuarioAnterior,
                NombreUsuarioAnterior,
                IdAreaUsuarioAnterior,
                AreaUsuarioAnterior,
                CargoUsuarioAnterior,

                IdEstado,
                Estado,
                IdUbicacion,
                Ubicacion,
                IdCondicion,
                Condicion,
                ActivoFijo,

                Observacion,
                Foto,
                Comprobante,

                RucProveedor,
                Proveedor,
                PrecioAdquisicion,
                VidaUtilMeses,

                CategoriaId,
                Categoria
            ) VALUES (
                @Codigo,
                @Modelo,
                @Serie,
                @Marca,
                @FechaAdquisicion,
                @FechaBaja,
                @FechaFinGarantia,

                @DniUsuarioActual,
                @NombreUsuarioActual,
                @IdAreaUsuarioActual,
                @AreaUsuarioActual,
                @CargoUsuarioActual,

                @DniUsuarioAnterior,
                @NombreUsuarioAnterior,
                @IdAreaUsuarioAnterior,
                @AreaUsuarioAnterior,
                @CargoUsuarioAnterior,

                @IdEstado,
                @Estado,
                @IdUbicacion,
                @Ubicacion,
                @IdCondicion,
                @Condicion,
                @ActivoFijo,

                @Observacion,
                @Foto,
                @Comprobante,

                @RucProveedor,
                @Proveedor,
                @PrecioAdquisicion,
                @VidaUtilMeses,

                @CategoriaId,
                @Categoria
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                cmd.Parameters.AddWithValue("@Serie", art.Serie);
                cmd.Parameters.AddWithValue("@Marca", art.Marca);
                cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion);
                cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFinGarantia", art.FechaFinGarantia ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@DniUsuarioActual", art.DniUsuarioActual);
                cmd.Parameters.AddWithValue("@NombreUsuarioActual", art.NombreUsuarioActual);
                cmd.Parameters.AddWithValue("@IdAreaUsuarioActual", art.IdAreaUsuarioActual);
                cmd.Parameters.AddWithValue("@AreaUsuarioActual", art.AreaUsuarioActual);
                cmd.Parameters.AddWithValue("@CargoUsuarioActual", art.CargoUsuarioActual);

                cmd.Parameters.AddWithValue("@DniUsuarioAnterior", art.DniUsuarioAnterior);
                cmd.Parameters.AddWithValue("@NombreUsuarioAnterior", art.NombreUsuarioAnterior);
                cmd.Parameters.AddWithValue("@IdAreaUsuarioAnterior", art.IdAreaUsuarioAnterior);
                cmd.Parameters.AddWithValue("@AreaUsuarioAnterior", art.AreaUsuarioAnterior);
                cmd.Parameters.AddWithValue("@CargoUsuarioAnterior", art.CargoUsuarioAnterior);

                cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                cmd.Parameters.AddWithValue("@Estado", art.Estado);
                cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                cmd.Parameters.AddWithValue("@Ubicacion", art.Ubicacion);
                cmd.Parameters.AddWithValue("@IdCondicion", art.IdCondicion);
                cmd.Parameters.AddWithValue("@Condicion", art.Condicion);
                cmd.Parameters.AddWithValue("@ActivoFijo", art.ActivoFijo);

                cmd.Parameters.AddWithValue("@Observacion", art.Observacion);
                cmd.Parameters.AddWithValue("@Foto", art.Foto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Comprobante", art.Comprobante ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@RucProveedor", art.RucProveedor);
                cmd.Parameters.AddWithValue("@Proveedor", art.Proveedor);
                cmd.Parameters.AddWithValue("@PrecioAdquisicion", art.PrecioAdquisicion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@CategoriaId", art.CategoriaId);
                cmd.Parameters.AddWithValue("@Categoria", art.Categoria);
                cmd.ExecuteNonQuery();
            }

            // Insertar características dinámicas (EAV)
            foreach (var kv in art.Caracteristicas)
            {
                string queryCar = @"INSERT INTO Caracteristicas(ArticuloId, Nombre, Valor)
                            VALUES (@ArticuloId, @Nombre, @Valor);";
                using (var cmdCar = new SQLiteCommand(queryCar, con))
                {
                    cmdCar.Parameters.AddWithValue("@ArticuloId", art.Id); // ojo: necesitas el Id generado
                    cmdCar.Parameters.AddWithValue("@Nombre", kv.Key);
                    cmdCar.Parameters.AddWithValue("@Valor", kv.Value);
                    cmdCar.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarArticulo(Articulos art)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Articulos SET
                    Codigo = @Codigo,
                    Modelo = @Modelo,
                    Serie = @Serie,
                    Marca = @Marca,
                    FechaAdquisicion = @FechaAdquisicion,
                    FechaBaja = @FechaBaja,
                    FechaFinGarantia = @FechaFinGarantia,

                    DniUsuarioActual = @DniUsuarioActual,
                    NombreUsuarioActual = @NombreUsuarioActual,
                    IdAreaUsuarioActual = @IdAreaUsuarioActual,
                    AreaUsuarioActual = @AreaUsuarioActual,
                    CargoUsuarioActual = @CargoUsuarioActual,

                    DniUsuarioAnterior = @DniUsuarioAnterior,
                    NombreUsuarioAnterior = @NombreUsuarioAnterior,
                    IdAreaUsuarioAnterior = @IdAreaUsuarioAnterior,
                    AreaUsuarioAnterior = @AreaUsuarioAnterior,
                    CargoUsuarioAnterior = @CargoUsuarioAnterior,

                    IdEstado = @IdEstado,
                    Estado = @Estado,
                    IdUbicacion = @IdUbicacion,
                    Ubicacion = @Ubicacion,
                    IdCondicion = @IdCondicion,
                    Condicion = @Condicion,
                    ActivoFijo = @ActivoFijo,

                    Observacion = @Observacion,
                    Foto = @Foto,
                    Comprobante = @Comprobante,

                    RucProveedor = @RucProveedor,
                    Proveedor = @Proveedor,
                    PrecioAdquisicion = @PrecioAdquisicion,
                    VidaUtilMeses = @VidaUtilMeses
                WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                    cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", art.Serie);
                    cmd.Parameters.AddWithValue("@Marca", art.Marca);
                    cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion);
                    cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFinGarantia", art.FechaFinGarantia ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@DniUsuarioActual", art.DniUsuarioActual);
                    cmd.Parameters.AddWithValue("@NombreUsuarioActual", art.NombreUsuarioActual);
                    cmd.Parameters.AddWithValue("@IdAreaUsuarioActual", art.IdAreaUsuarioActual);
                    cmd.Parameters.AddWithValue("@AreaUsuarioActual", art.AreaUsuarioActual);
                    cmd.Parameters.AddWithValue("@CargoUsuarioActual", art.CargoUsuarioActual);

                    cmd.Parameters.AddWithValue("@DniUsuarioAnterior", art.DniUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@NombreUsuarioAnterior", art.NombreUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@IdAreaUsuarioAnterior", art.IdAreaUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@AreaUsuarioAnterior", art.AreaUsuarioAnterior);
                    cmd.Parameters.AddWithValue("@CargoUsuarioAnterior", art.CargoUsuarioAnterior);

                    cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                    cmd.Parameters.AddWithValue("@Estado", art.Estado);
                    cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                    cmd.Parameters.AddWithValue("@Ubicacion", art.Ubicacion);
                    cmd.Parameters.AddWithValue("@IdCondicion", art.IdCondicion);
                    cmd.Parameters.AddWithValue("@Condicion", art.Condicion);
                    cmd.Parameters.AddWithValue("@ActivoFijo", art.ActivoFijo);

                    cmd.Parameters.AddWithValue("@Observacion", art.Observacion);
                    cmd.Parameters.AddWithValue("@Foto", art.Foto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Comprobante", art.Comprobante ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@RucProveedor", art.RucProveedor);
                    cmd.Parameters.AddWithValue("@Proveedor", art.Proveedor);
                    cmd.Parameters.AddWithValue("@PrecioAdquisicion", art.PrecioAdquisicion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", art.Id);

                    cmd.ExecuteNonQuery();
                }

                // Actualizar características dinámicas (EAV)
                //string deleteCar = "DELETE FROM Caracteristicas WHERE ArticuloId = @ArticuloId;";
                //using (var cmdDel = new SQLiteCommand(deleteCar, con))
                //{
                //    cmdDel.Parameters.AddWithValue("@ArticuloId", art.Id);
                //    cmdDel.ExecuteNonQuery();
                //}

                //foreach (var kv in art.Caracteristicas)
                //{
                //    string insertCar = @"INSERT INTO Caracteristicas(ArticuloId, Nombre, Valor)
                //                 VALUES (@ArticuloId, @Nombre, @Valor);";
                //    using (var cmdCar = new SQLiteCommand(insertCar, con))
                //    {
                //        cmdCar.Parameters.AddWithValue("@ArticuloId", art.Id);
                //        cmdCar.Parameters.AddWithValue("@Nombre", kv.Key);
                //        cmdCar.Parameters.AddWithValue("@Valor", kv.Value);
                //        cmdCar.ExecuteNonQuery();
                //    }
                //}
            }
        }

        public static int EliminarArticulo(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Primero eliminar características asociadas
                string queryCar = @"DELETE FROM Caracteristicas WHERE ArticuloId = @Id;";
                using (var cmdCar = new SQLiteCommand(queryCar, con))
                {
                    cmdCar.Parameters.AddWithValue("@Id", id);
                    cmdCar.ExecuteNonQuery();
                }

                // Luego eliminar el artículo
                string query = @"DELETE FROM Articulos WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = cmd.ExecuteNonQuery(); // devuelve cuántas filas se eliminaron
                    return filas; // 1 si se eliminó, 0 si no existía
                }
            }
        }

        // Listar todos los Articulos con sus Características
        public static List<Articulos> ListarArticulos()
        {
            var lista = new List<Articulos>();

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Articulos;";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var articulo = MapearArticulos(reader);

                        // Cargar características dinámicas
                        //articulo.Caracteristicas = new Dictionary<string, string>();
                        //string queryCar = "SELECT Nombre, Valor FROM Caracteristicas WHERE ArticuloId = @Id;";
                        //using (var cmdCar = new SQLiteCommand(queryCar, con))
                        //{
                        //    cmdCar.Parameters.AddWithValue("@Id", articulo.Id);
                        //    using (var readerCar = cmdCar.ExecuteReader())
                        //    {
                        //        while (readerCar.Read())
                        //        {
                        //            articulo.Caracteristicas.Add(
                        //                readerCar["Nombre"].ToString(),
                        //                readerCar["Valor"].ToString()
                        //            );
                        //        }
                        //    }
                        //}

                        lista.Add(articulo);
                    }
                }
            }

            return lista;
        }

        // Método auxiliar para mapear un registro a objeto Articulos
        private static Articulos MapearArticulos(SQLiteDataReader reader)
        {
            return new Articulos
            {
                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                Codigo = reader["Codigo"]?.ToString(),
                Modelo = reader["Modelo"]?.ToString(),
                Serie = reader["Serie"]?.ToString(),
                Marca = reader["Marca"]?.ToString(),

                FechaAdquisicion = reader["FechaAdquisicion"] != DBNull.Value
                    ? DateTime.Parse(reader["FechaAdquisicion"].ToString())
                    : DateTime.MinValue,

                FechaBaja = reader["FechaBaja"] != DBNull.Value
                    ? DateTime.Parse(reader["FechaBaja"].ToString())
                    : (DateTime?)null,

                FechaFinGarantia = reader["FechaFinGarantia"] != DBNull.Value
                    ? DateTime.Parse(reader["FechaFinGarantia"].ToString())
                    : (DateTime?)null,

                DniUsuarioActual = reader["DniUsuarioActual"]?.ToString(),
                NombreUsuarioActual = reader["NombreUsuarioActual"]?.ToString(),
                IdAreaUsuarioActual = reader["IdAreaUsuarioActual"] != DBNull.Value
                    ? Convert.ToInt32(reader["IdAreaUsuarioActual"])
                    : 0,
                AreaUsuarioActual = reader["AreaUsuarioActual"]?.ToString(),
                CargoUsuarioActual = reader["CargoUsuarioActual"]?.ToString(),

                DniUsuarioAnterior = reader["DniUsuarioAnterior"]?.ToString(),
                NombreUsuarioAnterior = reader["NombreUsuarioAnterior"]?.ToString(),
                IdAreaUsuarioAnterior = reader["IdAreaUsuarioAnterior"] != DBNull.Value
                    ? Convert.ToInt32(reader["IdAreaUsuarioAnterior"])
                    : 0,
                AreaUsuarioAnterior = reader["AreaUsuarioAnterior"]?.ToString(),
                CargoUsuarioAnterior = reader["CargoUsuarioAnterior"]?.ToString(),

                IdEstado = reader["IdEstado"] != DBNull.Value
                    ? Convert.ToInt32(reader["IdEstado"])
                    : 0,
                Estado = reader["Estado"]?.ToString(),
                IdUbicacion = reader["IdUbicacion"] != DBNull.Value
                    ? Convert.ToInt32(reader["IdUbicacion"])
                    : 0,
                Ubicacion = reader["Ubicacion"]?.ToString(),
                IdCondicion = reader["IdCondicion"] != DBNull.Value
                    ? Convert.ToInt32(reader["IdCondicion"])
                    : 0,
                Condicion = reader["Condicion"]?.ToString(),
                ActivoFijo = reader["ActivoFijo"]?.ToString(),

                Observacion = reader["Observacion"]?.ToString(),
                Foto = reader["Foto"] != DBNull.Value ? (byte[])reader["Foto"] : null,
                Comprobante = reader["Comprobante"] != DBNull.Value ? (byte[])reader["Comprobante"] : null,

                RucProveedor = reader["RucProveedor"]?.ToString(),
                Proveedor = reader["Proveedor"]?.ToString(),
                PrecioAdquisicion = reader["PrecioAdquisicion"] != DBNull.Value
                    ? Convert.ToDecimal(reader["PrecioAdquisicion"])
                    : (decimal?)null,
                VidaUtilMeses = reader["VidaUtilMeses"] != DBNull.Value
                    ? Convert.ToInt32(reader["VidaUtilMeses"])
                    : (int?)null,

                CategoriaId = reader["CategoriaId"] != DBNull.Value
                    ? Convert.ToInt32(reader["CategoriaId"])
                    : 0,
                Categoria = reader["Categoria"]?.ToString(),

                Caracteristicas = new Dictionary<string, string>() // se llena después
            };
        }
    }
}

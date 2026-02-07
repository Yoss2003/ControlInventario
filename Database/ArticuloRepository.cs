using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class ArticuloRepository
    {
        public void InsertarArticulo(Articulos art, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Articulos(
                Codigo,
                Modelo,
                Serie,
                Marca,
                FechaAdquisicion,
                UsuarioActual,
                UsuarioAnterior,
                IdArea,
                Area,
                Cargo,
                IdEstado,
                Estado,
                IdUbicacion,
                Ubicacion,
                FechaBaja,
                Observacion,
                Foto,
                CategoriaId,
                Categoria,
                PrecioAdquisicion,
                VidaUtilMeses,
                Proveedor,
                Condicion,
                ActivoFijo
            ) VALUES (
                @Codigo,
                @Modelo,
                @Serie,
                @Marca,
                @FechaAdquisicion,
                @UsuarioActual,
                @UsuarioAnterior,
                @IdArea,
                @Area,
                @Cargo,
                @IdEstado,
                @Estado,
                @IdUbicacion,
                @Ubicacion,
                @FechaBaja,
                @Observacion,
                @Foto,
                @CategoriaId,
                @Categoria,
                @PrecioAdquisicion,
                @VidaUtilMeses,
                @Proveedor,
                @Condicion,
                @ActivoFijo
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                cmd.Parameters.AddWithValue("@Serie", art.Serie);
                cmd.Parameters.AddWithValue("@Marca", art.Marca);
                cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion);
                cmd.Parameters.AddWithValue("@UsuarioActual", art.UsuarioActual);
                cmd.Parameters.AddWithValue("@UsuarioAnterior", art.UsuarioAnterior);
                cmd.Parameters.AddWithValue("@IdArea", art.IdArea);
                cmd.Parameters.AddWithValue("@Area", art.Area);
                cmd.Parameters.AddWithValue("@Cargo", art.Cargo);
                cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                cmd.Parameters.AddWithValue("@Estado", art.Estado);
                cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                cmd.Parameters.AddWithValue("@Ubicacion", art.Ubicacion);
                cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja.HasValue ? art.FechaBaja.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Observacion", art.Observacion);
                cmd.Parameters.AddWithValue("@Foto", art.Foto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoriaId", art.CategoriaId);
                cmd.Parameters.AddWithValue("@Categoria", art.Categoria);
                cmd.Parameters.AddWithValue("@PrecioAdquisicion", art.PrecioAdquisicion.HasValue ? art.PrecioAdquisicion.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses.HasValue ? art.VidaUtilMeses.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Proveedor", art.Proveedor);
                cmd.Parameters.AddWithValue("@Condicion", art.Condicion);
                cmd.Parameters.AddWithValue("@ActivoFijo", art.ActivoFijo);
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
                UsuarioActual = @UsuarioActual,
                UsuarioAnterior = @UsuarioAnterior,
                IdArea = @IdArea,
                Area = @Area,
                Cargo = @Cargo,
                IdEstado = @IdEstado,
                Estado = @Estado,
                IdUbicacion = @IdUbicacion,
                Ubicacion = @Ubicacion,
                FechaBaja = @FechaBaja,
                Observacion = @Observacion,
                Foto = @Foto,
                CategoriaId = @CategoriaId,
                Categoria = @Categoria,
                PrecioAdquisicion = @PrecioAdquisicion,
                VidaUtilMeses = @VidaUtilMeses,
                Proveedor = @Proveedor,
                Condicion = @Condicion,
                ActivoFijo = @ActivoFijo
            WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", art.Codigo);
                    cmd.Parameters.AddWithValue("@Modelo", art.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", art.Serie);
                    cmd.Parameters.AddWithValue("@Marca", art.Marca);
                    cmd.Parameters.AddWithValue("@FechaAdquisicion", art.FechaAdquisicion);
                    cmd.Parameters.AddWithValue("@UsuarioActual", art.UsuarioActual);
                    cmd.Parameters.AddWithValue("@UsuarioAnterior", art.UsuarioAnterior);
                    cmd.Parameters.AddWithValue("@IdArea", art.IdArea);
                    cmd.Parameters.AddWithValue("@Area", art.Area);
                    cmd.Parameters.AddWithValue("@Cargo", art.Cargo);
                    cmd.Parameters.AddWithValue("@IdEstado", art.IdEstado);
                    cmd.Parameters.AddWithValue("@Estado", art.Estado);
                    cmd.Parameters.AddWithValue("@IdUbicacion", art.IdUbicacion);
                    cmd.Parameters.AddWithValue("@Ubicacion", art.Ubicacion);
                    cmd.Parameters.AddWithValue("@FechaBaja", art.FechaBaja.HasValue ? art.FechaBaja.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observacion", art.Observacion);
                    cmd.Parameters.AddWithValue("@Foto", art.Foto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoriaId", art.CategoriaId);
                    cmd.Parameters.AddWithValue("@Categoria", art.Categoria);
                    cmd.Parameters.AddWithValue("@PrecioAdquisicion", art.PrecioAdquisicion.HasValue ? art.PrecioAdquisicion.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VidaUtilMeses", art.VidaUtilMeses.HasValue ? art.VidaUtilMeses.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Proveedor", art.Proveedor);
                    cmd.Parameters.AddWithValue("@Condicion", art.Condicion);
                    cmd.Parameters.AddWithValue("@ActivoFijo", art.ActivoFijo);
                    cmd.Parameters.AddWithValue("@Id", art.Id);

                    cmd.ExecuteNonQuery();
                }

                // Actualizar características dinámicas (EAV)
                string deleteCar = "DELETE FROM Caracteristicas WHERE ArticuloId = @ArticuloId;";
                using (var cmdDel = new SQLiteCommand(deleteCar, con))
                {
                    cmdDel.Parameters.AddWithValue("@ArticuloId", art.Id);
                    cmdDel.ExecuteNonQuery();
                }

                foreach (var kv in art.Caracteristicas)
                {
                    string insertCar = @"INSERT INTO Caracteristicas(ArticuloId, Nombre, Valor)
                                 VALUES (@ArticuloId, @Nombre, @Valor);";
                    using (var cmdCar = new SQLiteCommand(insertCar, con))
                    {
                        cmdCar.Parameters.AddWithValue("@ArticuloId", art.Id);
                        cmdCar.Parameters.AddWithValue("@Nombre", kv.Key);
                        cmdCar.Parameters.AddWithValue("@Valor", kv.Value);
                        cmdCar.ExecuteNonQuery();
                    }
                }
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
                        articulo.Caracteristicas = new Dictionary<string, string>();
                        string queryCar = "SELECT Nombre, Valor FROM Caracteristicas WHERE ArticuloId = @Id;";
                        using (var cmdCar = new SQLiteCommand(queryCar, con))
                        {
                            cmdCar.Parameters.AddWithValue("@Id", articulo.Id);
                            using (var readerCar = cmdCar.ExecuteReader())
                            {
                                while (readerCar.Read())
                                {
                                    articulo.Caracteristicas.Add(
                                        readerCar["Nombre"].ToString(),
                                        readerCar["Valor"].ToString()
                                    );
                                }
                            }
                        }

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
                Id = Convert.ToInt32(reader["Id"]),
                Codigo = reader["Codigo"].ToString(),
                Modelo = reader["Modelo"].ToString(),
                Serie = reader["Serie"].ToString(),
                Marca = reader["Marca"].ToString(),
                FechaAdquisicion = DateTime.Parse(reader["FechaAdquisicion"].ToString()),
                UsuarioActual = reader["UsuarioActual"].ToString(),
                UsuarioAnterior = reader["UsuarioAnterior"].ToString(),
                IdArea = Convert.ToInt32(reader["IdArea"]),
                Area = reader["Area"].ToString(),
                Cargo = reader["Cargo"].ToString(),
                IdEstado = Convert.ToInt32(reader["IdEstado"]),
                Estado = reader["Estado"].ToString(),
                IdUbicacion = Convert.ToInt32(reader["IdUbicacion"]),
                Ubicacion = reader["Ubicacion"].ToString(),
                FechaBaja = reader["FechaBaja"] != DBNull.Value ? DateTime.Parse(reader["FechaBaja"].ToString()) : (DateTime?)null,
                Observacion = reader["Observacion"].ToString(),
                Foto = reader["Foto"] != DBNull.Value ? (byte[])reader["Foto"] : null,
                CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                Categoria = reader["Categoria"].ToString(),
                PrecioAdquisicion = reader["PrecioAdquisicion"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioAdquisicion"]) : (decimal?)null,
                VidaUtilMeses = reader["VidaUtilMeses"] != DBNull.Value ? Convert.ToInt32(reader["VidaUtilMeses"]) : (int?)null,
                Proveedor = reader["Proveedor"].ToString(),
                Condicion = reader["Condicion"].ToString(),
                ActivoFijo = reader["ActivoFijo"].ToString(),
                Caracteristicas = new Dictionary<string, string>() // se llena después
            };
        }
    }
}

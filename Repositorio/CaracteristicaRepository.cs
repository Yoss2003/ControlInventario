using ControlInventario.Modelos;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class CaracteristicaRepository
    {
        public static void CrearTablaCaracteristicas(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Caracteristicas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                ArticuloId INTEGER, 
                Nombre TEXT, 
                Caracteristica1 TEXT, 
                Caracteristica2 TEXT, 
                Caracteristica3 TEXT, 
                Caracteristica4 TEXT, 
                FOREIGN KEY (ArticuloId) REFERENCES Articulos(Id) ON DELETE CASCADE 
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarCaracteristica(Caracteristicas car, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Caracteristicas (
                ArticuloId,
                Caracteristica1,
                Caracteristica2,
                Caracteristica3,
                Caracteristica4
            )   
            VALUES(
                @ArticuloId,
                @Caracteristica1,
                @Caracteristica2,
                @Caracteristica3,
                @Caracteristica4
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ArticuloId", car.ArticuloId);
                cmd.Parameters.AddWithValue("@Caracteristica1", car.Caracteristica1);
                cmd.Parameters.AddWithValue("@Caracteristica2", car.Caracteristica2);
                cmd.Parameters.AddWithValue("@Caracteristica3", car.Caracteristica3);
                cmd.Parameters.AddWithValue("@Caracteristica4", car.Caracteristica4);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarCaracteristicas(Caracteristicas car)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Caracteristicas 
                SET 
                    Caracteristica1 = @Caracteristica1,
                    Caracteristica2 = @Caracteristica2,
                    Caracteristica3 = @Caracteristica3,
                    Caracteristica4 = @Caracteristica4
                WHERE ArticuloId = @ArticuloId;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArticuloId", car.ArticuloId);
                    cmd.Parameters.AddWithValue("@Caracteristica1", car.Caracteristica1);
                    cmd.Parameters.AddWithValue("@Caracteristica2", car.Caracteristica2);
                    cmd.Parameters.AddWithValue("@Caracteristica3", car.Caracteristica3);
                    cmd.Parameters.AddWithValue("@Caracteristica4", car.Caracteristica4);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int EliminarCaracteristica(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "DELETE FROM Caracteristicas WHERE ArticuloId = @ArticuloId;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArticuloId", id);
                    int filas = cmd.ExecuteNonQuery();
                    return filas;
                }
            }                
        }

        public static List<Caracteristicas> ListarCaracteristicas(int articuloId)
        {
            var lista = new List<Caracteristicas>();

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT car.*
                    FROM Caracteristicas car
                    INNER JOIN Articulos a ON car.ArticuloId = a.Id
                    INNER JOIN Categorias c ON a.CategoriaId = c.Id
                    WHERE car.ArticuloId = @ArticuloId;
                ";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ArticuloId", articuloId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var caracteristicas = MapearCaracteristicas(reader);
                            lista.Add(caracteristicas);
                        }
                    }
                }
            }
            return lista;
        }

        public static Caracteristicas MapearCaracteristicas(SQLiteDataReader reader)
        {
            return new Caracteristicas
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ArticuloId = reader.GetInt32(reader.GetOrdinal("ArticuloId")),
                Caracteristica1 = reader.IsDBNull(reader.GetOrdinal("Caracteristica1")) ? null : reader.GetString(reader.GetOrdinal("Caracteristica1")),
                Caracteristica2 = reader.IsDBNull(reader.GetOrdinal("Caracteristica2")) ? null : reader.GetString(reader.GetOrdinal("Caracteristica2")),
                Caracteristica3 = reader.IsDBNull(reader.GetOrdinal("Caracteristica3")) ? null : reader.GetString(reader.GetOrdinal("Caracteristica3")),
                Caracteristica4 = reader.IsDBNull(reader.GetOrdinal("Caracteristica4")) ? null : reader.GetString(reader.GetOrdinal("Caracteristica4"))

                
            };
        }
    }
}

using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Database
{
    public class RutasRepository
    {
        public static void CrearTablaRutas(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS RutasExportar (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UsuarioId INT NOT NULL,
                RutaPredeterminada1 NVARCHAR(500),
                RutaPersonalizada1 NVARCHAR(500),
                RutaPredeterminada2 NVARCHAR(500),
                RutaPersonalizada2 NVARCHAR(500),
                TipoArchivo1 VARCHAR(20),
                TipoArchivo2 VARCHAR(20),
                EsPredeterminado1 BOOLEAN,
                EsPredeterminado2 BOOLEAN,
                UNIQUE (UsuarioId)
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void GuardarRuta(RutasExportar rutExp, SQLiteConnection con)
        {
            string query = @"INSERT INTO RutasExportar 
            (usuarioId, rutaPredeterminada1, rutaPersonalizada1, rutaPredeterminada2, rutaPersonalizada2, TipoArchivo1, TipoArchivo2, EsPredeterminado1, EsPredeterminado2) 
            VALUES (@usuarioId, @rutaPredeterminada1, @rutaPersonalizada1, @rutaPredeterminada2, @rutaPersonalizada2, @TipoArchivo1, @TipoArchivo2, @EsPredeterminado1, @EsPredeterminado2)";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuarioId", rutExp.UsuarioId);

                cmd.Parameters.AddWithValue("@rutaPredeterminada1", (object)rutExp.RutaPredeterminada1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rutaPersonalizada1", (object)rutExp.RutaPersonalizada1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoArchivo1", (object)rutExp.TipoArchivo1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EsPredeterminado1", (object)rutExp.EsPredeterminado1 ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@rutaPredeterminada2", (object)rutExp.RutaPredeterminada2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rutaPersonalizada2", (object)rutExp.RutaPersonalizada2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoArchivo2", (object)rutExp.TipoArchivo2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EsPredeterminado2", (object)rutExp.EsPredeterminado2 ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarRuta(RutasExportar rutExp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"UPDATE RutasExportar 
                             SET rutaPredeterminada1 = @rutaPredeterminada1, 
                                rutaPersonalizada1 = @rutaPersonalizada1, 
                                rutaPredeterminada2 = @rutaPredeterminada2, 
                                rutaPersonalizada2 = @rutaPersonalizada2,
                                TipoArchivo1 = @tipoArchivo1,
                                TipoArchivo2 = @tipoArchivo2,
                                EsPredeterminado1 = @EsPredeterminado1,
                                EsPredeterminado2 = @EsPredeterminado2
                             WHERE usuarioId = @usuarioId";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", rutExp.UsuarioId);
                    cmd.Parameters.AddWithValue("@rutaPredeterminada1", rutExp.RutaPredeterminada1);
                    cmd.Parameters.AddWithValue("@rutaPersonalizada1", rutExp.RutaPersonalizada1);
                    cmd.Parameters.AddWithValue("@tipoArchivo1", rutExp.TipoArchivo1);
                    cmd.Parameters.AddWithValue("@EsPredeterminado1", rutExp.EsPredeterminado1);

                    cmd.Parameters.AddWithValue("@rutaPredeterminada2", rutExp.RutaPredeterminada2);
                    cmd.Parameters.AddWithValue("@rutaPersonalizada2", rutExp.RutaPersonalizada2);
                    cmd.Parameters.AddWithValue("@tipoArchivo2", rutExp.TipoArchivo2);
                    cmd.Parameters.AddWithValue("@EsPredeterminado2", rutExp.EsPredeterminado2);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public RutasExportar ObtenerRutas(int usuarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // Validar existencia de la tabla
                string checkTableQuery = @"SELECT name 
                                   FROM sqlite_master 
                                   WHERE type='table' AND name='RutasExportar'";

                using (var checkCmd = new SQLiteCommand(checkTableQuery, con))
                {
                    var tableExists = checkCmd.ExecuteScalar();
                    if (tableExists == null)
                    {
                        string queryRutas = @"
                        CREATE TABLE IF NOT EXISTS RutasExportar (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            UsuarioId INT NOT NULL,
                            RutaPredeterminada1 NVARCHAR(500),
                            RutaPersonalizada1 NVARCHAR(500),
                            RutaPredeterminada2 NVARCHAR(500),
                            RutaPersonalizada2 NVARCHAR(500),
                            TipoArchivo1 VARCHAR(20),
                            TipoArchivo2 VARCHAR(20),
                            EsPredeterminado1 BOOLEAN,
                            EsPredeterminado2 BOOLEAN,
                            UNIQUE (UsuarioId)
                        );";

                        using (var rut = new SQLiteCommand(queryRutas, con))
                            rut.ExecuteNonQuery();
                    }
                }

                // Ahora sí ejecutar el SELECT
                string query = @"SELECT rutaPredeterminada1, rutaPersonalizada1, TipoArchivo1, 
                                rutaPredeterminada2, rutaPersonalizada2, TipoArchivo2, 
                                EsPredeterminado1, EsPredeterminado2
                                FROM RutasExportar 
                                WHERE usuarioId = @usuarioId";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RutasExportar
                            {
                                UsuarioId = usuarioId,

                                RutaPredeterminada1 = reader["rutaPredeterminada1"]?.ToString(),
                                RutaPersonalizada1 = reader["rutaPersonalizada1"]?.ToString(),
                                TipoArchivo1 = reader["TipoArchivo1"]?.ToString(),
                                EsPredeterminado1 = reader["EsPredeterminado1"] != DBNull.Value && Convert.ToBoolean(reader["EsPredeterminado1"]),

                                RutaPredeterminada2 = reader["rutaPredeterminada2"]?.ToString(),
                                RutaPersonalizada2 = reader["rutaPersonalizada2"]?.ToString(),
                                TipoArchivo2 = reader["TipoArchivo2"]?.ToString(),
                                EsPredeterminado2 = reader["EsPredeterminado2"] != DBNull.Value && Convert.ToBoolean(reader["EsPredeterminado2"])

                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}

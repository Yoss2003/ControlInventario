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
        public void GuardarRuta(RutasExportar rutExp, SQLiteConnection con)
        {
            string query = @"INSERT INTO RutasExportar 
            (usuarioId, rutaPredeterminada1, rutaPersonalizada1, rutaPredeterminada2, rutaPersonalizada2, TipoArchivo1, TipoArchivo2) 
            VALUES (@usuarioId, @rutaPredeterminada1, @rutaPersonalizada1, @rutaPredeterminada2, @rutaPersonalizada2, @TipoArchivo1, @TipoArchivo2)";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuarioId", rutExp.usuarioId);

                cmd.Parameters.AddWithValue("@rutaPredeterminada1", (object)rutExp.rutaPredeterminada1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rutaPersonalizada1", (object)rutExp.rutaPersonalizada1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoArchivo1", (object)rutExp.TipoArchivo1 ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@rutaPredeterminada2", (object)rutExp.rutaPredeterminada2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rutaPersonalizada2", (object)rutExp.rutaPersonalizada2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoArchivo2", (object)rutExp.TipoArchivo2 ?? DBNull.Value);

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
                                TipoArchivo2 = @tipoArchivo2 
                             WHERE usuarioId = @usuarioId";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", rutExp.usuarioId);
                    cmd.Parameters.AddWithValue("@rutaPredeterminada1", rutExp.rutaPredeterminada1);
                    cmd.Parameters.AddWithValue("@rutaPersonalizada1", rutExp.rutaPersonalizada1);
                    cmd.Parameters.AddWithValue("@tipoArchivo1", rutExp.TipoArchivo1);

                    cmd.Parameters.AddWithValue("@rutaPredeterminada2", rutExp.rutaPredeterminada2);
                    cmd.Parameters.AddWithValue("@rutaPersonalizada2", rutExp.rutaPersonalizada2);
                    cmd.Parameters.AddWithValue("@tipoArchivo2", rutExp.TipoArchivo2);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public RutasExportar ObtenerRutas(int usuarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"SELECT rutaPredeterminada1, rutaPersonalizada1, TipoArchivo1, rutaPredeterminada2, rutaPersonalizada2, TipoArchivo2
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
                                usuarioId = usuarioId,
                                rutaPredeterminada1 = reader["rutaPredeterminada1"].ToString(),
                                rutaPersonalizada1 = reader["rutaPersonalizada1"].ToString(),
                                TipoArchivo1 = reader["TipoArchivo1"].ToString(),

                                rutaPredeterminada2 = reader["rutaPredeterminada2"].ToString(),
                                rutaPersonalizada2 = reader["rutaPersonalizada2"].ToString(),
                                TipoArchivo2 = reader["TipoArchivo2"].ToString()
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

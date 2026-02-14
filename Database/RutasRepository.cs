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
            string query = @"INSERT INTO RutasExportar (usuarioId, rutaPredeterminada, rutaPersonalizada, TipoArchivo) 
                             VALUES (@usuarioId, @rutaPredeterminada, @rutaPersonalizada, @tipoArchivo)";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuarioId", rutExp.usuarioId);
                cmd.Parameters.AddWithValue("@rutaPredeterminada", rutExp.rutaPredeterminada);
                cmd.Parameters.AddWithValue("@rutaPersonalizada", rutExp.rutaPersonalizada);
                cmd.Parameters.AddWithValue("@tipoArchivo", rutExp.TipoArchivo);

                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarRuta(RutasExportar rutExp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"UPDATE RutasExportar 
                             SET rutaPredeterminada = @rutaPredeterminada, 
                                 rutaPersonalizada = @rutaPersonalizada, 
                                 TipoArchivo = @tipoArchivo 
                             WHERE usuarioId = @usuarioId";

                using (var cmd = new SQLiteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", rutExp.usuarioId);
                    cmd.Parameters.AddWithValue("@rutaPredeterminada", rutExp.rutaPredeterminada);
                    cmd.Parameters.AddWithValue("@rutaPersonalizada", rutExp.rutaPersonalizada);
                    cmd.Parameters.AddWithValue("@tipoArchivo", rutExp.TipoArchivo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public RutasExportar ObtenerRutas(int usuarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"SELECT rutaPredeterminada, rutaPersonalizada, TipoArchivo 
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
                                rutaPredeterminada = reader["rutaPredeterminada"].ToString(),
                                rutaPersonalizada = reader["rutaPersonalizada"].ToString(),
                                TipoArchivo = reader["TipoArchivo"].ToString()
                            };
                        }
                        else
                        {
                            // Si no existe registro, puedes devolver un objeto vacío o null
                            return null;
                        }
                    }
                }
            }
        }
    }
}

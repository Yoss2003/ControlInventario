using System;
using System.Data.SQLite;
using ControlInventario.Modelos;

namespace ControlInventario.Database
{
    public static class PerfilRepository
    {
        public static void CrearTablaPerfiles(SQLiteConnection con)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Perfil (
                    IdPerfil INTEGER PRIMARY KEY AUTOINCREMENT,
                    NombreUsuario TEXT,
                    IdIdioma INT,
                    Idioma TEXT,
                    IdTema INT,
                    Tema TEXT,
                    IdNotificaciones INT,
                    Notificaciones TEXT,
                    IdFormatoFecha INT,
                    FormatoFecha TEXT,
                    IdMoneda INT,
                    Moneda TEXT,
                    IdUnidadMedida INT,
                    UnidadMedida TEXT,
                    IdZonaHoraria INT,
                    ZonaHoraria TEXT,
                    Autenticacion BOOL,
                    ActividadCompartida BOOL,
                    CodigoBarras BOOL,
                    CategoriaPersonalizada BOOL,
                    CalcularDevaluacion BOOL,
                    GeneracionCodigos BOOL
                );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void AgregarPerfilUsuario(Perfiles perf, SQLiteConnection con)
        {
            string query = @"INSERT INTO Perfil (
                NombreUsuario,
                IdIdioma,
                Idioma,
                IdTema,
                Tema,
                IdNotificaciones,
                Notificaciones,
                IdFormatoFecha,
                FormatoFecha,
                IdMoneda,
                Moneda,
                IdUnidadMedida,
                UnidadMedida,
                IdZonaHoraria,
                ZonaHoraria,
                Autenticacion,
                ActividadCompartida,
                CodigoBarras,
                CategoriaPersonalizada,
                CalcularDevaluacion,
                GeneracionCodigos
            )VALUES(
                @NombreUsuario,
                @IdIdioma,
                @Idioma,
                @IdTema,
                @Tema,
                @IdNotificaciones,
                @Notificaciones,
                @IdFormatoFecha,
                @FormatoFecha,
                @IdMoneda,
                @Moneda,
                @IdUnidadMedida,
                @UnidadMedida,
                @IdZonaHoraria,
                @ZonaHoraria,
                @Autenticacion,
                @ActividadCompartida,
                @CodigoBarras,
                @CategoriaPersonalizada,
                @CalcularDevaluacion,
                @GeneracionCodigos
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@NombreUsuario", perf.NombreUsuario);
                cmd.Parameters.AddWithValue("@IdIdioma", perf.IdIdioma);
                cmd.Parameters.AddWithValue("@Idioma", perf.Idioma);
                cmd.Parameters.AddWithValue("@IdTema", perf.IdTema);
                cmd.Parameters.AddWithValue("@Tema", perf.Tema);
                cmd.Parameters.AddWithValue("@IdNotificaciones", perf.IdNotificaciones);
                cmd.Parameters.AddWithValue("@Notificaciones", perf.Notificaciones);
                cmd.Parameters.AddWithValue("@IdFormatoFecha", perf.IdFormatoFecha);
                cmd.Parameters.AddWithValue("@FormatoFecha", perf.FormatoFecha);
                cmd.Parameters.AddWithValue("@IdMoneda", perf.IdMoneda);
                cmd.Parameters.AddWithValue("@Moneda", perf.Moneda);
                cmd.Parameters.AddWithValue("@IdUnidadMedida", perf.IdUnidadMedida);
                cmd.Parameters.AddWithValue("@UnidadMedida", perf.UnidadMedida);
                cmd.Parameters.AddWithValue("@IdZonaHoraria", perf.IdZonaHoraria);
                cmd.Parameters.AddWithValue("@ZonaHoraria", perf.ZonaHoraria);
                cmd.Parameters.AddWithValue("@Autenticacion", perf.Autenticacion);
                cmd.Parameters.AddWithValue("@ActividadCompartida", perf.ActividadCompartida);
                cmd.Parameters.AddWithValue("@CodigoBarras", perf.CodigoBarras);
                cmd.Parameters.AddWithValue("@CategoriaPersonalizada", perf.CategoriaPersonalizada);
                cmd.Parameters.AddWithValue("@CalcularDevaluacion", perf.CalcularDevaluacion);
                cmd.Parameters.AddWithValue("@GeneracionCodigos", perf.GeneracionCodigos);

                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarPerfilUsuario(Perfiles perf, SQLiteConnection con)
        {
            string query = @"UPDATE Perfil SET
                NombreUsuario = @NombreUsuario,
                IdIdioma = @IdIdioma,
                Idioma = @Idioma,
                IdTema = @IdTema,
                Tema = @Tema,
                IdNotificaciones = @IdNotificaciones,
                Notificaciones = @Notificaciones,
                IdFormatoFecha = @IdFormatoFecha,
                FormatoFecha = @FormatoFecha,
                IdMoneda = @IdMoneda,
                Moneda = @Moneda,
                IdUnidadMedida = @IdUnidadMedida,
                UnidadMedida = @UnidadMedida,
                IdZonaHoraria = @IdZonaHoraria,
                ZonaHoraria = @ZonaHoraria,
                Autenticacion = @Autenticacion,
                ActividadCompartida = @ActividadCompartida,
                CodigoBarras = @CodigoBarras,
                CategoriaPersonalizada = @CategoriaPersonalizada,
                CalcularDevaluacion = @CalcularDevaluacion,
                GeneracionCodigos = @GeneracionCodigos
            WHERE IdPerfil = @IdPerfil;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@NombreUsuario", perf.NombreUsuario);
                cmd.Parameters.AddWithValue("@IdIdioma", perf.IdIdioma);
                cmd.Parameters.AddWithValue("@Idioma", perf.Idioma);
                cmd.Parameters.AddWithValue("@IdTema", perf.IdTema);
                cmd.Parameters.AddWithValue("@Tema", perf.Tema);
                cmd.Parameters.AddWithValue("@IdNotificaciones", perf.IdNotificaciones);
                cmd.Parameters.AddWithValue("@Notificaciones", perf.Notificaciones);
                cmd.Parameters.AddWithValue("@IdFormatoFecha", perf.IdFormatoFecha);
                cmd.Parameters.AddWithValue("@FormatoFecha", perf.FormatoFecha);
                cmd.Parameters.AddWithValue("@IdMoneda", perf.IdMoneda);
                cmd.Parameters.AddWithValue("@Moneda", perf.Moneda);
                cmd.Parameters.AddWithValue("@IdUnidadMedida", perf.IdUnidadMedida);
                cmd.Parameters.AddWithValue("@UnidadMedida", perf.UnidadMedida);
                cmd.Parameters.AddWithValue("@IdZonaHoraria", perf.IdZonaHoraria);
                cmd.Parameters.AddWithValue("@ZonaHoraria", perf.ZonaHoraria);
                cmd.Parameters.AddWithValue("@Autenticacion", perf.Autenticacion);
                cmd.Parameters.AddWithValue("@ActividadCompartida", perf.ActividadCompartida);
                cmd.Parameters.AddWithValue("@CodigoBarras", perf.CodigoBarras);
                cmd.Parameters.AddWithValue("@CategoriaPersonalizada", perf.CategoriaPersonalizada);
                cmd.Parameters.AddWithValue("@CalcularDevaluacion", perf.CalcularDevaluacion);
                cmd.Parameters.AddWithValue("@GeneracionCodigos", perf.GeneracionCodigos);
                cmd.Parameters.AddWithValue("@IdPerfil", perf.IdPerfil);
                cmd.ExecuteNonQuery();
            }
        }

        public static Perfiles ObtenerPerfilUsuario(string usuario, SQLiteConnection con)
        {
            string query = "SELECT * FROM Perfil WHERE NombreUsuario = @usuario LIMIT 1;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Perfiles
                        {
                            IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            IdIdioma = Convert.ToInt32(reader["IdIdioma"]),
                            Idioma = reader["Idioma"].ToString(),
                            IdTema = Convert.ToInt32(reader["IdTema"]),
                            Tema = reader["Tema"].ToString(),
                            IdNotificaciones = Convert.ToInt32(reader["IdNotificaciones"]),
                            Notificaciones = reader["Notificaciones"].ToString(),
                            IdFormatoFecha = Convert.ToInt32(reader["IdFormatoFecha"]),
                            FormatoFecha = reader["FormatoFecha"].ToString(),
                            IdMoneda = Convert.ToInt32(reader["IdMoneda"]),
                            Moneda = reader["Moneda"].ToString(),
                            IdUnidadMedida = Convert.ToInt32(reader["IdUnidadMedida"]),
                            UnidadMedida = reader["UnidadMedida"].ToString(),
                            IdZonaHoraria = Convert.ToInt32(reader["IdZonaHoraria"]),
                            ZonaHoraria = reader["ZonaHoraria"].ToString(),
                            Autenticacion = Convert.ToBoolean(reader["Autenticacion"]),
                            ActividadCompartida = Convert.ToBoolean(reader["ActividadCompartida"]),
                            CodigoBarras = Convert.ToBoolean(reader["CodigoBarras"]),
                            CategoriaPersonalizada = Convert.ToBoolean(reader["CategoriaPersonalizada"]),
                            CalcularDevaluacion = Convert.ToBoolean(reader["CalcularDevaluacion"]),
                            GeneracionCodigos = Convert.ToBoolean(reader["GeneracionCodigos"])
                        };
                    }
                }
            }
            return null; // si no existe
        }

        public static void GuardarPerfilUsuario(Perfiles perfil, SQLiteConnection con)
        {
            var existente = ObtenerPerfilUsuario(perfil.NombreUsuario, con);
            if (existente != null)
            {
                // ASIGNAR IdPerfil para que UPDATE afecte la fila correcta
                perfil.IdPerfil = existente.IdPerfil;
                ActualizarPerfilUsuario(perfil, con);
            }
            else
                AgregarPerfilUsuario(perfil, con);
        }

        public static void EliminarPerfilUsuario(int idPerfil, SQLiteConnection con)
        {
            string query = "DELETE FROM Perfil WHERE IdPerfil = @IdPerfil;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@IdPerfil", idPerfil);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
using ControlInventario.Modelos;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;

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
                    IdIdioma INT, Idioma TEXT,
                    IdTema INT, Tema TEXT,
                    IdNotificaciones INT, Notificaciones TEXT,
                    IdFormatoFecha INT, FormatoFecha TEXT,
                    IdMoneda INT, Moneda TEXT,
                    IdUnidadMedida INT, UnidadMedida TEXT,
                    IdZonaHoraria INT, ZonaHoraria TEXT,
                    Autenticacion BOOL,
                    ActividadCompartida BOOL,
                    CodigoBarras BOOL,
                    CalcularDevaluacion BOOL,
                    GeneracionCodigos BOOL,
                    IdModoVentas INT,
                    ModoVentas TEXT,
                    AplicarMora BOOL,
                    PorcentajeMora REAL,
                    DiasGracia INT,
                    CorreoSMTP TEXT,
                    ClaveSMTP TEXT
                );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }

            // Migración: agregar columnas para BD existentes que no las tengan
            AgregarColumnaSiNoExiste(con, "Perfil", "CorreoSMTP", "TEXT");
            AgregarColumnaSiNoExiste(con, "Perfil", "ClaveSMTP", "TEXT");
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
                IdZonaHoraria,
                ZonaHoraria,
                Autenticacion,
                ActividadCompartida,
                CodigoBarras,
                CalcularDevaluacion,
                GeneracionCodigos,
                IdModoVentas,
                ModoVentas,
                AplicarMora,
                PorcentajeMora,
                DiasGracia,
                CorreoSMTP,
                ClaveSMTP
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
                @IdZonaHoraria,
                @ZonaHoraria,
                @Autenticacion,
                @ActividadCompartida,
                @CodigoBarras,
                @CalcularDevaluacion,
                @GeneracionCodigos,
                @IdModoVentas,
                @ModoVentas,
                @AplicarMora,
                @PorcentajeMora,
                @DiasGracia,
                @CorreoSMTP,
                @ClaveSMTP
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
                cmd.Parameters.AddWithValue("@IdZonaHoraria", perf.IdZonaHoraria);
                cmd.Parameters.AddWithValue("@ZonaHoraria", perf.ZonaHoraria);
                cmd.Parameters.AddWithValue("@Autenticacion", perf.Autenticacion);
                cmd.Parameters.AddWithValue("@ActividadCompartida", perf.ActividadCompartida);
                cmd.Parameters.AddWithValue("@CodigoBarras", perf.CodigoBarras);
                cmd.Parameters.AddWithValue("@CalcularDevaluacion", perf.CalcularDevaluacion);
                cmd.Parameters.AddWithValue("@GeneracionCodigos", perf.GeneracionCodigos);
                cmd.Parameters.AddWithValue("@IdModoVentas", perf.IdModoVentas);
                cmd.Parameters.AddWithValue("@ModoVentas", perf.ModoVentas);
                cmd.Parameters.AddWithValue("@AplicarMora", perf.AplicarMora);
                cmd.Parameters.AddWithValue("@PorcentajeMora", perf.PorcentajeMora);
                cmd.Parameters.AddWithValue("@DiasGracia", perf.DiasGracia);
                cmd.Parameters.AddWithValue("@CorreoSMTP", (object)perf.CorreoSMTP ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClaveSMTP", (object)perf.ClaveSMTP ?? DBNull.Value);

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
                IdZonaHoraria = @IdZonaHoraria,
                ZonaHoraria = @ZonaHoraria,
                Autenticacion = @Autenticacion,
                ActividadCompartida = @ActividadCompartida,
                CodigoBarras = @CodigoBarras,
                CalcularDevaluacion = @CalcularDevaluacion,
                GeneracionCodigos = @GeneracionCodigos,
                IdModoVentas = @IdModoVentas,
                ModoVentas = @ModoVentas,
                AplicarMora = @AplicarMora,
                PorcentajeMora = @PorcentajeMora,
                DiasGracia = @DiasGracia,
                CorreoSMTP = @CorreoSMTP,
                ClaveSMTP = @ClaveSMTP
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
                cmd.Parameters.AddWithValue("@IdZonaHoraria", perf.IdZonaHoraria);
                cmd.Parameters.AddWithValue("@ZonaHoraria", perf.ZonaHoraria);
                cmd.Parameters.AddWithValue("@Autenticacion", perf.Autenticacion);
                cmd.Parameters.AddWithValue("@ActividadCompartida", perf.ActividadCompartida);
                cmd.Parameters.AddWithValue("@CodigoBarras", perf.CodigoBarras);
                cmd.Parameters.AddWithValue("@CalcularDevaluacion", perf.CalcularDevaluacion);
                cmd.Parameters.AddWithValue("@GeneracionCodigos", perf.GeneracionCodigos);
                cmd.Parameters.AddWithValue("@IdModoVentas", perf.IdModoVentas);
                cmd.Parameters.AddWithValue("@ModoVentas", perf.ModoVentas);
                cmd.Parameters.AddWithValue("@AplicarMora", perf.AplicarMora);
                cmd.Parameters.AddWithValue("@PorcentajeMora", perf.PorcentajeMora);
                cmd.Parameters.AddWithValue("@DiasGracia", perf.DiasGracia);
                cmd.Parameters.AddWithValue("@CorreoSMTP", (object)perf.CorreoSMTP ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClaveSMTP", (object)perf.ClaveSMTP ?? DBNull.Value);
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
                            IdZonaHoraria = Convert.ToInt32(reader["IdZonaHoraria"]),
                            ZonaHoraria = reader["ZonaHoraria"].ToString(),
                            Autenticacion = Convert.ToBoolean(reader["Autenticacion"]),
                            ActividadCompartida = Convert.ToBoolean(reader["ActividadCompartida"]),
                            CodigoBarras = Convert.ToBoolean(reader["CodigoBarras"]),
                            CalcularDevaluacion = Convert.ToBoolean(reader["CalcularDevaluacion"]),
                            GeneracionCodigos = Convert.ToBoolean(reader["GeneracionCodigos"]),
                            IdModoVentas = reader["IdModoVentas"] != DBNull.Value ? Convert.ToInt32(reader["IdModoVentas"]) : 1,
                            ModoVentas = reader["ModoVentas"] != DBNull.Value ? reader["ModoVentas"].ToString() : "No mostrar",
                            AplicarMora = reader["AplicarMora"] != DBNull.Value && Convert.ToBoolean(reader["AplicarMora"]),
                            PorcentajeMora = reader["PorcentajeMora"] != DBNull.Value ? Convert.ToDecimal(reader["PorcentajeMora"]) : 0m,
                            DiasGracia = reader["DiasGracia"] != DBNull.Value ? Convert.ToInt32(reader["DiasGracia"]) : 3,
                            CorreoSMTP = reader["CorreoSMTP"].ToString(),
                            ClaveSMTP = reader["ClaveSMTP"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public static void GuardarPerfilUsuario(Perfiles perfil, SQLiteConnection con)
        {
            var existente = ObtenerPerfilUsuario(perfil.NombreUsuario, con);
            if (existente != null)
            {
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

        private static (int Id, string Texto) BuscarEnCatalogo(SQLiteConnection con, string nombreTabla, string columnaTexto, string textoBuscar)
        {
            string query = $"SELECT Id, {columnaTexto} FROM {nombreTabla} WHERE {columnaTexto} LIKE @texto LIMIT 1";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@texto", "%" + textoBuscar + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (Convert.ToInt32(reader["Id"]), reader[columnaTexto].ToString());
                    }
                }
            }

            string queryFallback = $"SELECT Id, {columnaTexto} FROM {nombreTabla} LIMIT 1";
            using (var cmdFallback = new SQLiteCommand(queryFallback, con))
            {
                using (var readerFallback = cmdFallback.ExecuteReader())
                {
                    if (readerFallback.Read())
                    {
                        return (Convert.ToInt32(readerFallback["Id"]), readerFallback[columnaTexto].ToString());
                    }
                }
            }

            return (1, textoBuscar);
        }

        public static Perfiles GenerarPerfilPorDefecto(string nombreUsuario, SQLiteConnection con)
        {
            string idiomaAbreviado = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            string textoBusquedaIdioma = "Español"; 

            if (idiomaAbreviado == "en")
            {
                textoBusquedaIdioma = "Inglés";
            }
            else if (idiomaAbreviado == "es")
            {
                textoBusquedaIdioma = "Español";
            }

            string monedaWindows = RegionInfo.CurrentRegion.ISOCurrencySymbol;
            string textoBusquedaMoneda = "Soles"; // Fallback por defecto

            if (monedaWindows == "PEN")
            {
                textoBusquedaMoneda = "Soles";
            }
            else if (monedaWindows == "USD")
            {
                textoBusquedaMoneda = "Dólar";
            }
            else if (monedaWindows == "EUR")
            {
                textoBusquedaMoneda = "Euro";
            }

            string zonaHorariaWindows = TimeZoneInfo.Local.DisplayName;
            string fechaWindows = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            var dbIdioma = BuscarEnCatalogo(con, "Idioma", "Idioma", textoBusquedaIdioma);
            var dbMoneda = BuscarEnCatalogo(con, "Moneda", "Moneda", textoBusquedaMoneda);
            var dbFecha = BuscarEnCatalogo(con, "FormatoFecha", "FormatoFecha", fechaWindows);
            var dbZona = BuscarEnCatalogo(con, "ZonaHoraria", "ZonaHoraria", zonaHorariaWindows);

            return new Perfiles
            {
                NombreUsuario = nombreUsuario,

                IdMoneda = dbMoneda.Id,
                Moneda = dbMoneda.Texto,

                IdFormatoFecha = dbFecha.Id,
                FormatoFecha = dbFecha.Texto,

                IdIdioma = dbIdioma.Id,
                Idioma = dbIdioma.Texto,

                IdZonaHoraria = dbZona.Id,
                ZonaHoraria = dbZona.Texto,

                IdTema = 1,
                Tema = "Claro",
                IdNotificaciones = 1,
                Notificaciones = "Activadas",

                Autenticacion = false,
                ActividadCompartida = false,
                CodigoBarras = false,
                CalcularDevaluacion = false,
                GeneracionCodigos = false,
                IdModoVentas = 1,
                ModoVentas = "No mostrar",
                AplicarMora = false,
                PorcentajeMora = 5m,
                DiasGracia = 3
            };
        }

        private static void AgregarColumnaSiNoExiste(SQLiteConnection con, string tabla, string columna, string tipo)
        {
            try
            {
                string query = $"SELECT {columna} FROM {tabla} LIMIT 1;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.ExecuteScalar();
                }
            }
            catch
            {
                string alter = $"ALTER TABLE {tabla} ADD COLUMN {columna} {tipo};";
                using (var cmd = new SQLiteCommand(alter, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
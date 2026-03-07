using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public class ConfiguracionRepository
    {
        public static void CrearTablaConfiguracion(SQLiteConnection con)
        {
            string scriptTablas = @"
                CREATE TABLE IF NOT EXISTS Idioma (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Idioma TEXT
                );

                CREATE TABLE IF NOT EXISTS Tema (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Tema TEXT
                );

                CREATE TABLE IF NOT EXISTS Notificaciones (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Notificaciones TEXT
                );

                CREATE TABLE IF NOT EXISTS FormatoFecha (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FormatoFecha TEXT
                );

                CREATE TABLE IF NOT EXISTS Moneda (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Moneda TEXT
                );

                CREATE TABLE IF NOT EXISTS UnidadMedida (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UnidadMedida TEXT
                );

                CREATE TABLE IF NOT EXISTS ZonaHoraria (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ZonaHoraria TEXT
                );
            ";

            using (var cmd = new SQLiteCommand(scriptTablas, con))
            {
                cmd.ExecuteNonQuery();
            }

            InsertarConfiguracion(con);
        }

        public static void InsertarConfiguracion(SQLiteConnection con)
        {
            string[] idiomas = { "Español", "Inglés", "Portugués" };
            string[] temas = { "Claro", "Oscuro" };
            string[] notificaciones = { "Activadas", "Desactivadas", "Solo errores" };
            string[] formatos = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };
            string[] monedas = { "PEN - Soles", "USD - Dólares", "EUR - Euros", "MXN - Pesos" };
            string[] medidas = { "Unidades", "Cajas", "Kg", "Litros" };
            string[] zonas = { "UTC-5 (Lima/Bogotá)", "UTC-6 (CDMX)", "UTC-3 (Buenos Aires)" };

            LlenarCatalogoSiEstaVacio(con, "Idioma", "Idioma", idiomas);
            LlenarCatalogoSiEstaVacio(con, "Tema", "Tema", temas);
            LlenarCatalogoSiEstaVacio(con, "Notificaciones", "Notificaciones", notificaciones);
            LlenarCatalogoSiEstaVacio(con, "FormatoFecha", "FormatoFecha", formatos);
            LlenarCatalogoSiEstaVacio(con, "Moneda", "Moneda", monedas);
            LlenarCatalogoSiEstaVacio(con, "UnidadMedida", "UnidadMedida", medidas);
            LlenarCatalogoSiEstaVacio(con, "ZonaHoraria", "ZonaHoraria", zonas);
        }

        private static void LlenarCatalogoSiEstaVacio(SQLiteConnection con, string nombreTabla, string nombreColumna, string[] valoresFijos)
        {
            string queryCheck = $"SELECT COUNT(*) FROM {nombreTabla}";
            using (var cmdCheck = new SQLiteCommand(queryCheck, con))
            {
                long cantidadFilas = (long)cmdCheck.ExecuteScalar();

                if (cantidadFilas > 0) return;
            }

            string queryInsert = $"INSERT INTO {nombreTabla} ({nombreColumna}) VALUES (@Valor)";
            using (var cmdInsert = new SQLiteCommand(queryInsert, con))
            {
                cmdInsert.Parameters.Add("@Valor", System.Data.DbType.String);

                foreach (string valor in valoresFijos)
                {
                    cmdInsert.Parameters["@Valor"].Value = valor;
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }
    }
}

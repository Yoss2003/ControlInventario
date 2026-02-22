using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Database
{
    public class RecuperacionRepository
    {
        public static void CrearTablaPreguntasSeguridad(SQLiteConnection con)
        {
            string query = @"
                CREATE TABLE IF NOT EXISTS PreguntasSeguridad (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Usuario INT NOT NULL,
                    Nombre_Usuario TEXT NOT NULL,
                    Id_Pregunta1 INT NOT NULL,
                    Pregunta1 TEXT NOT NULL,
                    Respuesta1 TEXT NOT NULL,
                    Id_Pregunta2 INT NOT NULL,
                    Pregunta2 TEXT NOT NULL,
                    Respuesta2 TEXT NOT NULL,
                    Id_Pregunta3 INT NOT NULL,
                    Pregunta3 TEXT NOT NULL,
                    Respuesta3 TEXT NOT NULL,
                    FOREIGN KEY (Id_Usuario) REFERENCES Empleados(Id)
                );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

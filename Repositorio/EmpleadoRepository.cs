using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;

namespace ControlInventario.Repositorio
{
    public class EmpleadoRepository
    {
        public static void CrearTablaEmpleado(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Empleados (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombres TEXT NOT NULL,
                Apellidos TEXT NOT NULL,
                DNI TEXT NOT NULL UNIQUE,
                IdCargo INTEGER NOT NULL,
                IdArea INTEGER NOT NULL,
                IdEstado INTEGER NOT NULL
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
            string queryVista = @"
            CREATE VIEW IF NOT EXISTS vw_Empleado AS
            SELECT 
                e.*,
                c.Nombre AS Cargo,
                a.Nombre AS Area,
                s.Nombre AS Estado
            FROM Empleados e
            LEFT JOIN Parametros c ON e.IdCargo = c.Id
            LEFT JOIN Parametros a ON e.IdArea = a.Id
            LEFT JOIN Parametros s ON e.IdEstado = s.Id;";
            using (var cmd = new SQLiteCommand(queryVista, con)) { cmd.ExecuteNonQuery(); }
        }

        public static void AgregarEmpleados(Empleados emp,SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Empleados(
                Nombres,
                Apellidos,
                DNI,
                IdCargo,
                IdArea,
                IdEstado,
            )VALUES(
                @Nombres,
                @Apellidos,
                @DNI,
                @IdCargo,
                @IdArea,
                @IdEstado,
            );";

            using (var cmd = new SQLiteCommand (query, con))
            {
                cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                cmd.Parameters.AddWithValue("@DNI", emp.DNI);
                cmd.Parameters.AddWithValue("@IdCargo", emp.IdCargo);
                cmd.Parameters.AddWithValue("@IdArea", emp.IdArea);
                cmd.Parameters.AddWithValue("@IdEstado", emp.IdEstado);

                cmd.ExecuteNonQuery ();
            }
        }

        public static void ActualizarEmpleados(Empleados emp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Empleados SET
                    Nombres = @Nombres,
                    Apellidos = @Apellidos,
                    DNI = @DNI,
                    IdCargo = @IdCargo,
                    IdArea = @IdArea,
                    IdEstado = @IdEstado,
                WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand (query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@DNI", emp.DNI);
                    cmd.Parameters.AddWithValue("@IdCargo", emp.IdCargo);
                    cmd.Parameters.AddWithValue("@IdArea", emp.IdArea);
                    cmd.Parameters.AddWithValue("@IdEstado", emp.IdEstado);
                    cmd.Parameters.AddWithValue("@Id", emp.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void LimpiarCampoObsoleto(int idEmpleado, string columnaId, string columnaNombre)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = $@"UPDATE Empleados SET 
                          {columnaId} = 0, 
                          {columnaNombre} = 'SELECCIONE' 
                          WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idEmpleado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarEmpleado(Empleados emp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM Empleados WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", emp.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    
        public static List<Empleados> ListarEmpleado()
        {
            var lista = new List<Empleados>();

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Empleados;";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearEmpleado(reader));
                    }
                }
            }

            return lista;
        }

        private static Empleados MapearEmpleado(SQLiteDataReader reader)
        {
            return new Empleados
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombres = reader["Nombres"].ToString(),
                Apellidos = reader["Apellidos"].ToString(),
                DNI = reader["DNI"].ToString(),
                IdCargo = Convert.ToInt32(reader["IdCargo"]),
                IdArea = Convert.ToInt32(reader["IdArea"]),
                IdEstado = Convert.ToInt32(reader["IdEstado"]),
            };
        }

        public static Empleados ObtenerEmpleadoPorDni(string dni)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM Empleados WHERE DNI = @DNI LIMIT 1;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearEmpleado(reader);
                        }
                    }
                }
            }
            return null;
        }

    }
}

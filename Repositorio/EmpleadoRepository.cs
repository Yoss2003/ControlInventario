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
            CREATE TABLE IF NOT EXISTS Empleado (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombres TEXT NOT NULL,
                Apellidos TEXT NOT NULL,
                DNI TEXT NOT NULL,
                IdCargo INTEGER NOT NULL,
                Cargo TEXT NOT NULL,
                IdArea INTEGER NOT NULL UNIQUE,
                Area TEXT NOT NULL,
                IdEstado INTEGER NOT NULL,
                Estado TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void AgregarEmpleados(Empleados emp,SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Empleado(
                Nombres,
                Apellidos,
                DNI,
                IdCargo,
                Cargo,
                IdArea,
                Area,
                IdEstado,
                Estado
            )VALUES(
                @Nombres,
                @Apellidos,
                @DNI,
                @IdCargo,
                @Cargo,
                @IdArea,
                @Area,
                @IdEstado,
                @Estado
            );";

            using (var cmd = new SQLiteCommand (query, con))
            {
                cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                cmd.Parameters.AddWithValue("@DNI", emp.DNI);
                cmd.Parameters.AddWithValue("@IdCargo", emp.IdCargo);
                cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                cmd.Parameters.AddWithValue("@IdArea", emp.IdArea);
                cmd.Parameters.AddWithValue("@Area", emp.Area);
                cmd.Parameters.AddWithValue("@IdEstado", emp.IdEstado);
                cmd.Parameters.AddWithValue("@Estado", emp.Estado);

                cmd.ExecuteNonQuery ();
            }
        }

        public static void ActualizarEmpleados(Empleados emp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE Empleado SET
                    Nombres = @Nombres,
                    Apellidos = @Apellidos,
                    DNI = @DNI,
                    IdCargo = @IdCargo,
                    Cargo = @Cargo,
                    IdArea = @IdArea,
                    Area = @Area,
                    IdEstado = @IdEstado,
                    Estado = @Estado
                WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand (query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidoss", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@DNI", emp.DNI);
                    cmd.Parameters.AddWithValue("@IdCargo", emp.IdCargo);
                    cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                    cmd.Parameters.AddWithValue("@IdArea", emp.IdArea);
                    cmd.Parameters.AddWithValue("@Area", emp.Area);
                    cmd.Parameters.AddWithValue("@IdEstado", emp.IdEstado);
                    cmd.Parameters.AddWithValue("@Estado", emp.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    
        public static List<Empleados> ListarEmpleado()
        {
            var lista = new List<Empleados>();

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Empleado;";
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
                Cargo = reader["Cargo"].ToString(),
                IdArea = Convert.ToInt32(reader["IdArea"]),
                Area = reader["Area"].ToString(),
                IdEstado = Convert.ToInt32(reader["IdEstado"]),
                Estado = reader["Estado"].ToString()
            };
        }
    }
}

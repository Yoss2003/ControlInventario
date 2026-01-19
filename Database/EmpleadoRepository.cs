using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public static class EmpleadoRepository
    {
        // Insertar nuevo empleado
        public static void InsertarEmpleado(Empleado emp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    INSERT INTO Empleados (
                        Nombres, 
                        Apellidos, 
                        Correo, 
                        Edad, 
                        FechaNacimiento,
                        Usuario, 
                        Contraseña, 
                        Cargo, 
                        Area, 
                        FechaIngreso, 
                        TipoContrato,
                        Developer, 
                        Administrador, 
                        UsuarioRol, 
                        Invitado, 
                        Bloqueado
                    ) VALUES (
                        @Nombres, 
                        @Apellidos, 
                        @Correo, 
                        @Edad, 
                        @FechaNacimiento,
                        @Usuario, 
                        @Contraseña, 
                        @Cargo, 
                        @Area, 
                        @FechaIngreso, 
                        @TipoContrato,
                        @Developer, 
                        @Administrador, 
                        @UsuarioRol, 
                        @Invitado, 
                        @Bloqueado
                    );";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@Correo", emp.Correo);
                    cmd.Parameters.AddWithValue("@Edad", emp.Edad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", emp.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Usuario", emp.Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", emp.Contraseña);
                    cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                    cmd.Parameters.AddWithValue("@Area", emp.Area);
                    cmd.Parameters.AddWithValue("@FechaIngreso", emp.FechaIngreso);
                    cmd.Parameters.AddWithValue("@TipoContrato", emp.TipoContrato);
                    cmd.Parameters.AddWithValue("@Developer", emp.Developer);
                    cmd.Parameters.AddWithValue("@Administrador", emp.Administrador);
                    cmd.Parameters.AddWithValue("@UsuarioRol", emp.User);
                    cmd.Parameters.AddWithValue("@Invitado", emp.Invitado);
                    cmd.Parameters.AddWithValue("@Bloqueado", emp.Bloqueado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Actualizar empleado existente
        public static void ActualizarEmpleado(Empleado emp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    UPDATE Empleados SET
                        Nombres=@Nombres, 
                        Apellidos=@Apellidos, 
                        Correo=@Correo, 
                        Edad=@Edad,
                        FechaNacimiento=@FechaNacimiento, 
                        Usuario=@Usuario, 
                        Contraseña=@Contraseña,
                        Cargo=@Cargo, 
                        Area=@Area,
                        FechaIngreso=@FechaIngreso, 
                        TipoContrato=@TipoContrato,
                        Developer=@Developer, 
                        Administrador=@Administrador,
                        UsuarioRol=@UsuarioRol, 
                        Invitado=@Invitado, 
                        Bloqueado=@Bloqueado
                    WHERE Id=@Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", emp.Id); // necesitas Id en la clase Empleado
                    cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@Correo", emp.Correo);
                    cmd.Parameters.AddWithValue("@Edad", emp.Edad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", emp.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Usuario", emp.Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", emp.Contraseña);
                    cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                    cmd.Parameters.AddWithValue("@Area", emp.Area);
                    cmd.Parameters.AddWithValue("@FechaIngreso", emp.FechaIngreso);
                    cmd.Parameters.AddWithValue("@TipoContrato", emp.TipoContrato);
                    cmd.Parameters.AddWithValue("@Developer", emp.Developer);
                    cmd.Parameters.AddWithValue("@Administrador", emp.Administrador);
                    cmd.Parameters.AddWithValue("@UsuarioRol", emp.User);
                    cmd.Parameters.AddWithValue("@Invitado", emp.Invitado);
                    cmd.Parameters.AddWithValue("@Bloqueado", emp.Bloqueado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar empleado por Id
        public static void EliminarEmpleado(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "DELETE FROM Empleados WHERE Id=@Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Obtener un empleado por Id
        public static Empleado ObtenerEmpleadoPorId(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Empleados WHERE Id=@Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
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

        // Listar todos los empleados
        public static List<Empleado> ListarEmpleados()
        {
            var lista = new List<Empleado>();

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

        // Método auxiliar para mapear un registro a objeto Empleado
        private static Empleado MapearEmpleado(SQLiteDataReader reader)
        {
            return new Empleado
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombres = reader["Nombres"].ToString(),
                Apellidos = reader["Apellidos"].ToString(),
                Correo = reader["Correo"].ToString(),
                Edad = Convert.ToInt32(reader["Edad"]),
                FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString()),
                Usuario = reader["Usuario"].ToString(),
                Contraseña = reader["Contraseña"].ToString(),
                Cargo = reader["Cargo"].ToString(),
                Area = reader["Area"].ToString(),
                FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString()),
                TipoContrato = reader["TipoContrato"].ToString(),
                Developer = Convert.ToBoolean(reader["Developer"]),
                Administrador = Convert.ToBoolean(reader["Administrador"]),
                User = Convert.ToBoolean(reader["UsuarioRol"]),
                Invitado = Convert.ToBoolean(reader["Invitado"]),
                Bloqueado = Convert.ToBoolean(reader["Bloqueado"])
            };
        }
    }
}
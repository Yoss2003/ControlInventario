using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public static class UsuarioRepository
    {
        public static void CrearTablaUsuario(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Usuario (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombres TEXT NOT NULL,
                Apellidos TEXT NOT NULL,
                Correo TEXT NOT NULL,
                Edad INTEGER NOT NULL,
                FechaNacimiento TEXT NOT NULL,
                Usuario TEXT NOT NULL UNIQUE,
                Contraseña TEXT NOT NULL,
                Cargo TEXT NOT NULL,
                Area TEXT NOT NULL,
                FechaIngreso TEXT,
                TipoContrato TEXT,
                IdRol INTEGER NOT NULL,
                Rol TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Insertar nuevo empleado
        public static long InsertarUsuario(Usuario emp, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Usuario (
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
                IdRol,
                Rol
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
                @IdRol,
                @Rol
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                cmd.Parameters.AddWithValue("@Correo", emp.Correo);
                cmd.Parameters.AddWithValue("@Edad", emp.Edad);
                cmd.Parameters.AddWithValue("@FechaNacimiento", emp.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Usuario", emp.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", emp.Contraseña);
                cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                cmd.Parameters.AddWithValue("@Area", emp.Area);
                cmd.Parameters.AddWithValue("@FechaIngreso", emp.FechaIngreso);
                cmd.Parameters.AddWithValue("@TipoContrato", emp.TipoContrato);
                cmd.Parameters.AddWithValue("@IdRol", emp.IdRol);
                cmd.Parameters.AddWithValue("@Rol", emp.Rol);

                cmd.ExecuteNonQuery();
            }

            using (var cmdId = new SQLiteCommand("SELECT last_insert_rowid();", con))
            {
                return (long)cmdId.ExecuteScalar();
            }
        }

        // Actualizar empleado existente
        public static void ActualizarUsuario(Usuario emp)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    UPDATE Usuario SET
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
                        IdRol=@IdRol,
                        Rol=@Rol
                    WHERE Id=@Id;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombres", emp.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@Correo", emp.Correo);
                    cmd.Parameters.AddWithValue("@Edad", emp.Edad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", emp.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Usuario", emp.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", emp.Contraseña);
                    cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                    cmd.Parameters.AddWithValue("@Area", emp.Area);
                    cmd.Parameters.AddWithValue("@FechaIngreso", emp.FechaIngreso);
                    cmd.Parameters.AddWithValue("@TipoContrato", emp.TipoContrato);
                    cmd.Parameters.AddWithValue("@IdRol", emp.IdRol);
                    cmd.Parameters.AddWithValue("@Rol", emp.Rol);
                    cmd.Parameters.AddWithValue("@Id", emp.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar empleado por Id
        public static long EliminarUsuario(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "DELETE FROM Usuario WHERE Id=@Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }

                using (var cmdId = new SQLiteCommand("SELECT last_insert_rowid();", con))
                {
                    return (long)cmdId.ExecuteScalar();
                }
            }
        }

        // Listar todos los empleados
        public static List<Usuario> ListarUsuario()
        {
            var lista = new List<Usuario>();

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Usuario;";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearUsuario(reader));
                    }
                }
            }

            return lista;
        }

        // Método auxiliar para mapear un registro a objeto Empleado
        private static Usuario MapearUsuario(SQLiteDataReader reader)
        {
            return new Usuario
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombres = reader["Nombres"].ToString(),
                Apellidos = reader["Apellidos"].ToString(),
                Correo = reader["Correo"].ToString(),
                Edad = Convert.ToInt32(reader["Edad"]),
                FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString()),
                NombreUsuario = reader["Usuario"].ToString(),
                Contraseña = reader["Contraseña"].ToString(),
                Cargo = reader["Cargo"].ToString(),
                Area = reader["Area"].ToString(),
                FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString()),
                TipoContrato = reader["TipoContrato"].ToString(),
                IdRol = Convert.ToInt32(reader["IdRol"]),
                Rol = reader["Rol"].ToString()
            };
        }

        public static Usuario BuscarPorUsuario(string usuario)
        {
            using (var conexion = ConexionGlobal.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT * FROM Usuario WHERE Usuario = @Usuario";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Reuse the mapping helper to populate all fields (including Rol and IdRol)
                            return MapearUsuario(reader);
                        }
                    }
                }
            }
            return null;
        }
    }
}
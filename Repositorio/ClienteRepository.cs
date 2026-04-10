using ControlInventario.Database;
using ControlInventario.Modelo;
using System;
using System.Data.SQLite;

namespace ControlInventario.Repositorio
{
    public static class ClienteRepository
    {
        public static void CrearTablaClientes(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Clientes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Documento TEXT UNIQUE,
                Nombre TEXT NOT NULL,
                Telefono TEXT,
                Correo TEXT,
                Direccion TEXT,
                FechaRegistro TEXT
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static Cliente ObtenerPorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento)) return null;

            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM Clientes WHERE Documento = @Doc LIMIT 1;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Doc", documento);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Documento = reader["Documento"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : "",
                                Correo = reader["Correo"] != DBNull.Value ? reader["Correo"].ToString() : "",
                                Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : "",
                                FechaRegistro = reader["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static int GuardarOActualizar(Cliente cliente)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var existente = ObtenerPorDocumentoConConexion(cliente.Documento, con);

                if (existente != null)
                {
                    string query = @"UPDATE Clientes SET 
                        Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion
                        WHERE Id = @Id;";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", string.IsNullOrWhiteSpace(cliente.Correo) ? (object)DBNull.Value : cliente.Correo);
                        cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(cliente.Direccion) ? (object)DBNull.Value : cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Id", existente.Id);
                        cmd.ExecuteNonQuery();
                    }
                    return existente.Id;
                }
                else
                {
                    string query = @"INSERT INTO Clientes (Documento, Nombre, Telefono, Correo, Direccion, FechaRegistro)
                        VALUES (@Doc, @Nombre, @Telefono, @Correo, @Direccion, @Fecha);
                        SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Doc", cliente.Documento);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", string.IsNullOrWhiteSpace(cliente.Correo) ? (object)DBNull.Value : cliente.Correo);
                        cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(cliente.Direccion) ? (object)DBNull.Value : cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }

        private static Cliente ObtenerPorDocumentoConConexion(string documento, SQLiteConnection con)
        {
            string query = "SELECT * FROM Clientes WHERE Documento = @Doc LIMIT 1;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Doc", documento);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Documento = reader["Documento"].ToString(),
                            Nombre = reader["Nombre"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public static Cliente ObtenerClientePorMovimiento(int movimientoId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT c.* FROM Clientes c
                INNER JOIN Movimientos m ON m.Documento = c.Documento
                WHERE m.Id = @MovId LIMIT 1;";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MovId", movimientoId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Documento = reader["Documento"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : "",
                                Correo = reader["Correo"] != DBNull.Value ? reader["Correo"].ToString() : ""
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class InventarioRepository
    {
        private readonly Empleado empleadoActual;

        public InventarioRepository(Empleado emp)
        {
            empleadoActual = emp;
        }

        public int InsertarInventarioUsuario(Inventario invent, SQLiteConnection con)
        {
            string query = @"
            INSERT INTO Inventarios (
                NombreInventario,
                FechaCreacion,
                UsuarioId,
                Usuario
            ) VALUES (
                @NombreInventario,
                @FechaCreacion,
                @UsuarioId,
                @Usuario
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@NombreInventario", "Invent_" + empleadoActual.Usuario);
                cmd.Parameters.AddWithValue("@FechaCreacion", invent.FechaCreacion);
                cmd.Parameters.AddWithValue("@UsuarioId", empleadoActual.Id);
                cmd.Parameters.AddWithValue("@Usuario", empleadoActual.Usuario);

                cmd.ExecuteNonQuery();
            }
            using (var cmd = new SQLiteCommand("SELECT last_insert_rowid();", con))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Inventario ObtenerOCrearInventarioPorUsuario(SQLiteConnection con)
        {
            string select = "SELECT Id, NombreInventario, FechaCreacion, FechaModificacion, UsuarioId, Usuario FROM Inventarios WHERE UsuarioId = @UsuarioId LIMIT 1;";
            using (var cmd = new SQLiteCommand(select, con))
            {
                cmd.Parameters.AddWithValue("@UsuarioId", empleadoActual.Id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var inv = new Inventario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NombreInventario = reader["NombreInventario"]?.ToString(),
                            UsuarioId = reader["UsuarioId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UsuarioId"]),
                            Usuario = reader["Usuario"]?.ToString()
                        };

                        DateTime temp;
                        if (reader["FechaCreacion"] != DBNull.Value && DateTime.TryParse(reader["FechaCreacion"].ToString(), out temp))
                            inv.FechaCreacion = temp;
                        if (reader["FechaModificacion"] != DBNull.Value && DateTime.TryParse(reader["FechaModificacion"].ToString(), out temp))
                            inv.FechaModificacion = temp;

                        return inv;
                    }
                }
            }
            // No existe: crear
            var nuevo = new Inventario
            {
                NombreInventario = "Invent_" + empleadoActual.Usuario,
                FechaCreacion = DateTime.Now.Date,
                UsuarioId = empleadoActual.Id,
                Usuario = empleadoActual.Usuario
            };

            int newId = InsertarInventarioUsuario(nuevo, con);
            nuevo.Id = newId;
            return nuevo;
        }

        public void ActualizarInventario(Inventario invent, SQLiteConnection con)
        {
            string query = @"
                UPDATE Inventarios SET
                    NombreInventario = @NombreInventario,
                    FechaModificacion = @FechaModificacion,
                    UsuarioId = @UsuarioId,
                    Usuario = @Usuario
                WHERE Id = @Id;";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@NombreInventario", invent.NombreInventario);
                cmd.Parameters.AddWithValue("@FechaModificacion", invent.FechaModificacion);
                cmd.Parameters.AddWithValue("@UsuarioId", invent.UsuarioId);
                cmd.Parameters.AddWithValue("@Usuario", invent.Usuario);
                cmd.Parameters.AddWithValue("@Id", invent.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Inventario> ListarInventarios()
        {
            var lista = new List<Inventario>();
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT * FROM Inventarios;";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearInventarioInvetario(reader));
                    }
                }
            }
            return lista;
        }

        private static Inventario MapearInventarioInvetario (SQLiteDataReader reader)
        {
            return new Inventario
            {
                Id = Convert.ToInt32(reader["Id"]),
                NombreInventario = reader["NombreInventario"].ToString(),
                FechaCreacion = DateTime.Parse(reader["FechaCreacion"].ToString()),
                FechaModificacion = DateTime.Parse(reader["FechaModificacion"].ToString()),
                UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                Usuario = reader["Usuario"].ToString()
            };
        }
    }
}

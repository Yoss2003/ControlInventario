using ControlInventario.Modelos;
using ControlInventario.Servicios;
using ControlInventario.Vistas;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Database
{
    public class InventarioRepository
    {
        private readonly int usuarioId; 
        private readonly string nombreUsuario;

        public InventarioRepository() 
        { 
            usuarioId = UsuarioSesion.UsuarioId; 
            nombreUsuario = UsuarioSesion.NombreUsuario; 
        }

        public static void CrearTablaInventarios(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Inventarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                NombreInventario TEXT NOT NULL,
                FechaCreacion TEXT NOT NULL,
                FechaModificacion TEXT,
                UsuarioId INTEGER NOT NULL,
                Usuario TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
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
                cmd.Parameters.AddWithValue("@NombreInventario", "Invent_" + nombreUsuario);
                cmd.Parameters.AddWithValue("@FechaCreacion", invent.FechaCreacion);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);

                cmd.ExecuteNonQuery();
            }
            using (var cmd = new SQLiteCommand("SELECT last_insert_rowid();", con))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Inventario ObtenerOCrearInventarioPorUsuario(string NombreUsuario)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();

                // 1. Verificar inventario
                string select = "SELECT Id, NombreInventario, FechaCreacion, FechaModificacion, UsuarioId, Usuario FROM Inventarios WHERE UsuarioId = @UsuarioId LIMIT 1;";
                Inventario inventario = null;
                using (var cmd = new SQLiteCommand(select, con))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inventario = new Inventario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreInventario = reader["NombreInventario"]?.ToString(),
                                UsuarioId = reader["UsuarioId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UsuarioId"]),
                                Usuario = reader["Usuario"]?.ToString()
                            };

                            DateTime temp;
                            if (reader["FechaCreacion"] != DBNull.Value && DateTime.TryParse(reader["FechaCreacion"].ToString(), out temp))
                                inventario.FechaCreacion = temp;
                            if (reader["FechaModificacion"] != DBNull.Value && DateTime.TryParse(reader["FechaModificacion"].ToString(), out temp))
                                inventario.FechaModificacion = temp;
                        }
                    }
                }

                // 2. Si no existe, crear inventario
                if (inventario == null)
                {
                    inventario = new Inventario
                    {
                        NombreInventario = "Invent_" + nombreUsuario,
                        FechaCreacion = DateTime.Now.Date,
                        UsuarioId = usuarioId,
                        Usuario = nombreUsuario
                    };

                    int newId = InsertarInventarioUsuario(inventario, con);
                    inventario.Id = newId;
                }

                // 3. Verificar categorías
                string queryCheckCategorias = "SELECT Id FROM Categorias WHERE InventarioId = @InventarioId LIMIT 1;";
                using (var cmdCheckCategorias = new SQLiteCommand(queryCheckCategorias, con))
                {
                    cmdCheckCategorias.Parameters.AddWithValue("@InventarioId", inventario.Id);
                    var result = cmdCheckCategorias.ExecuteScalar();
                    if (result == null)
                    {
                        // Crear categorías por defecto (ejemplo)
                        var categoriasPorDefecto = new List<string> { "General", "Otros" };
                        foreach (var nombreCat in categoriasPorDefecto)
                        {
                            var categoria = new Categoria
                            {
                                Nombre = nombreCat,
                                InventarioId = inventario.Id
                            };
                            var categoriaRepo = new CategoriaRepository(inventario);
                            categoriaRepo.InsertarCategoriaInventario(categoria, con);
                        }
                    }
                }

                con.Close();
                return inventario;
            }
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

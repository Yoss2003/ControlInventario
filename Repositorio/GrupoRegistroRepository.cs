using ControlInventario.Modelo;
using System;
using System.Data;
using System.Data.SQLite;

namespace ControlInventario.Database
{
    public class GrupoRegistroRepository
    {
        public static void CrearTablaGruposRegistro(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS GruposRegistro (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                Nombre TEXT NOT NULL,
                Descripcion TEXT,
                FechaCreacion TEXT,
                UsuarioCreacion TEXT,
                FOREIGN KEY (InventarioId) REFERENCES Inventarios(Id)
            );";
            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static long AgregarGrupo(GruposRegistros grupo)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                INSERT INTO GruposRegistro (
                    InventarioId, Nombre, Descripcion, FechaCreacion, UsuarioCreacion
                ) VALUES (
                    @InventarioId, @Nombre, @Descripcion, @FechaCreacion, @UsuarioCreacion
                );
                SELECT last_insert_rowid();";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", grupo.InventarioId);
                    cmd.Parameters.AddWithValue("@Nombre", grupo.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", grupo.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", grupo.FechaCreacion);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", grupo.UsuarioCreacion);

                    return (long)cmd.ExecuteScalar();
                }
            }
        }

        public static void ActualizarGrupo(GruposRegistros grupo)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                UPDATE GruposRegistro SET
                    Nombre = @Nombre,
                    Descripcion = @Descripcion
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", grupo.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", grupo.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", grupo.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarGrupo(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM GruposRegistro WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool TieneArticulosAsociados(int grupoId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Articulos WHERE GrupoRegistroId = @GrupoId;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@GrupoId", grupoId);
                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static bool ExisteGrupo(GruposRegistros grupo)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"
                SELECT COUNT(*) FROM GruposRegistro
                WHERE TRIM(Nombre) = TRIM(@Nombre) COLLATE NOCASE
                AND InventarioId = @InventarioId
                AND Id != @Id;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", grupo.Nombre);
                    cmd.Parameters.AddWithValue("@InventarioId", grupo.InventarioId);
                    cmd.Parameters.AddWithValue("@Id", grupo.Id);

                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static DataTable ListarGrupos(int inventarioId)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                var dt = new DataTable();
                string query = "SELECT * FROM GruposRegistro WHERE InventarioId = @InventarioId;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
        }
    }
}

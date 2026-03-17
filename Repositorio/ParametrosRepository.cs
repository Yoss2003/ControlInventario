using ControlInventario.Database;
using ControlInventario.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Repositorio
{
    public class ParametrosRepository
    {
        public static void CrearTablaParametros(SQLiteConnection con)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Parametros (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER NOT NULL,
                TipoParametro TEXT NOT NULL,
                Nombre TEXT NOT NULL,
                Descripcion TEXT
            );";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarParametros(Parametros param)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"INSERT INTO Parametros (InventarioId, TipoParametro, Nombre, Descripcion) 
                            VALUES (@InventarioId, @TipoParametro, @Nombre, @Descripcion)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", param.InventarioId);
                    cmd.Parameters.AddWithValue("@TipoParametro", param.TipoParametro);
                    cmd.Parameters.AddWithValue("@Nombre", param.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(param.Descripcion) ? (object)DBNull.Value : param.Descripcion);
                    cmd.ExecuteNonQuery();
                }
            }            
        }

        public static void ActualizarParametros(Parametros param)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = @"UPDATE Parametros 
                                SET Nombre = @Nombre, Descripcion = @Descripcion 
                                WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", param.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(param.Descripcion) ? (object)DBNull.Value : param.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", param.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarParametros(int id)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM Parametros WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ListarParametros(SQLiteConnection con, string TipoParametro)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Id, Nombre, Descripcion 
                            FROM Parametros 
                            WHERE TipoParametro = @TipoParametro";

            using (var cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TipoParametro", TipoParametro);
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}

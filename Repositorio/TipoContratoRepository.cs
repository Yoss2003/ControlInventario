using ControlInventario.Database;
using ControlInventario.Modelo;
using ControlInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Repositorio
{
    public class TipoContratoRepository
    {
        public static void CrearTablaContrato(SQLiteConnection con)
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS Contratos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Descripcion TEXT
            );";

            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarContrato(TipoContrato cont)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    INSERT INTO Contratos (Nombre, Descripcion) 
                    VALUES (@Nombre, @Descripcion);";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cont.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cont.Descripcion);
                    cmd.ExecuteNonQuery();
                }
                con.Clone();
            }
        }

        public static void ActualizarContrato(TipoContrato cont)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                UPDATE Contratos SET 
                    Nombre = @Nombre,
                    Descripcion = @Descripcion
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cont.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cont.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", cont.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void EliminarContrato(TipoContrato cont)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = "DELETE FROM Contratos WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", cont.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static DataTable ListarContrato(SQLiteConnection con)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM Contratos ORDER BY Nombre ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

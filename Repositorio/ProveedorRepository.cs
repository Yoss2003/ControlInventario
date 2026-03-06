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
    public class ProveedorRepository
    {
        public static void CrearTablaProveedor(SQLiteConnection con)
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS Proveedores(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InventarioId INTEGER,
                Ruc TEXT,
                RazonSocial TEXT,
                NombreContacto TEXT,
                Telefono TEXT,
                Correo TEXT,
                Direccion TEXT,
                IdEstado INTEGER,
                Estado TEXT
            );";
            using (var cmd = new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertarProveedor(Proveedor prov)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                INSERT INTO Proveedores (InventarioId, Ruc, RazonSocial, NombreContacto, Telefono, Direccion, Correo, IdEstado, Estado)
                VALUES (@InventarioId, @Ruc, @RazonSocial, @NombreContacto, @Telefono, @Direccion, @Correo, @IdEstado, @Estado);";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", prov.InventarioId);
                    cmd.Parameters.AddWithValue("@Ruc", prov.Ruc);
                    cmd.Parameters.AddWithValue("@RazonSocial", prov.RazonSocial);
                    cmd.Parameters.AddWithValue("@NombreContacto", prov.NombreContacto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", prov.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Correo", prov.Correo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", prov.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdEstado", prov.IdEstado);
                    cmd.Parameters.AddWithValue("@Estado", prov.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarProveedor(Proveedor prov)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                UPDATE Proveedores SET 
                    Ruc = @Ruc, 
                    RazonSocial = @RazonSocial,
                    NombreContacto = @NombreContacto,
                    Telefono = @Telefono,
                    Correo = @Correo,
                    IdEstado = @IdEstado,
                    Estado = @Estado                    
                WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@InventarioId", prov.InventarioId);
                    cmd.Parameters.AddWithValue("@Ruc", prov.Ruc);
                    cmd.Parameters.AddWithValue("@RazonSocial", prov.RazonSocial);
                    cmd.Parameters.AddWithValue("@NombreContacto", prov.NombreContacto);
                    cmd.Parameters.AddWithValue("@Telefono", prov.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", prov.Correo);
                    cmd.Parameters.AddWithValue("@IdEstado", prov.IdEstado);
                    cmd.Parameters.AddWithValue("@Estado", prov.Estado);
                    cmd.Parameters.AddWithValue("@Id", prov.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarProveedor(Proveedor prov)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string sql = "DELETE FROM Proveedores WHERE Id = @Id;";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", prov.Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        /* Enlace a ComboBox*/
        public static DataTable ListarProveedor(SQLiteConnection con)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM Proveedores ORDER BY RazonSocial ASC;";
            using (var cmd = new SQLiteCommand(query, con))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public static Proveedor MapearProveedor(SQLiteDataReader reader)
        {
            return new Proveedor
            {
                Id = Convert.ToInt32(reader["Id"]),
                RazonSocial = reader["RazonSocial"].ToString()
            };
        }
        public static Proveedor ObtenerProveedorPorRUC(string ruc)
        {
            using (var con = ConexionGlobal.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM Proveedores WHERE Ruc = @Ruc LIMIT 1;";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Ruc", ruc);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearProveedor(reader);
                        }
                    }
                }
            }
            return null;
        }
    }
}

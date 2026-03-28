using ControlInventario.Database;
using ControlInventario.Repositorio;
using System;
using System.Data.SQLite;

namespace ControlInventario.Servicios
{
    public static class DatabaseInitializer
    {
        public static void CreateTables(SQLiteConnection con)
        {
            // 1. PADRES: Tablas independientes (No dependen de otras)
            ParametrosRepository.CrearTablaParametros(con);
            CategoriaRepository.CrearTablaCategorias(con);
            EmpleadoRepository.CrearTablaEmpleado(con);
            UsuarioRepository.CrearTablaUsuario(con);
            ProveedorRepository.CrearTablaProveedor(con);

            // 2. INTERMEDIAS: Dependen de los padres
            MarcasRepository.CrearTablaMarcas(con);

            // 3. HIJOS: Dependen de muchos padres
            ArticuloRepository.CrearTablaArticulos(con);
            MovimientoRepository.CrearTablaMovimientos(con);

            // 4. SISTEMA: Tablas operativas
            InventarioRepository.CrearTablaInventarios(con);
            RutasRepository.CrearTablaRutas(con);
            PerfilRepository.CrearTablaPerfiles(con);
            RecuperacionRepository.CrearTablaPreguntasSeguridad(con);
            LogsRepository.CrearTablaLogs(con);
            ConfiguracionRepository.CrearTablaConfiguracion(con);
            ParametrosRepository.InsertarPreguntasPorDefecto(con);

            // Agregar más tablas según sea necesario
            Console.WriteLine("Tablas creadas exitosamente.");
        }
    }
}

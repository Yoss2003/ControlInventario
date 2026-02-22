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
            // Crear tabla de Artículos
            ArticuloRepository.CrearTablaArticulos(con);

            // Crear tabla de Categorías
            CategoriaRepository.CrearTablaCategorias(con);

            // Crear tabla de Características
            CaracteristicaRepository.CrearTablaCaracteristicas(con);

            // Crear tabla de  Inventarios
            InventarioRepository.CrearTablaInventarios(con);

            // Crear tabla de Rutas
            RutasRepository.CrearTablaRutas(con);

            // Crear tabla de Estados Empleados
            EstadoRepository.CrearTablaEstadoEmpleados(con);

            // Crear tabla de Estados Articulos
            EstadoRepository.CrearTablaEstadoArticulos(con);

            // Crear tabla de Ubicaciones
            UbicacionRepository.CrearTablaUbicaciones(con);

            // Crear tabla de Condiciones
            CondicionRepository.CrearTablaCondicion(con);

            // Crear tabla de Cargos
            CargoRepository.CrearTablaCargos(con);

            // Crear tabla de Áreas
            AreaRepository.CrearTablaAreas(con);

            // Crear tabla de Marcas
            MarcasRepository.CrearTablaMarcas(con);

            // Crear tabla de Perfiles
            PerfilRepository.CrearTablaPerfiles(con);

            // Crear tabla de Preguntas de Seguridad
            RecuperacionRepository.CrearTablaPreguntasSeguridad(con);

            // Crear tabla de Empleados
            EmpleadoRepository.CrearTablaEmpleado(con);

            // Agregar más tablas según sea necesario
            Console.WriteLine("Tablas creadas exitosamente.");
        }
    }
}

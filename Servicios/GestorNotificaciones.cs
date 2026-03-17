using ControlInventario.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario.Servicios
{
    public enum PrioridadNoti
    {
        Baja = 1,      // Sociales y Saludos
        Normal = 2,    // Operativas y Recordatorios
        Alta = 3       // Críticas, Garantías, Errores
    }

    public class GestorNotificaciones
    {
        private NotifyIcon _notifyIcon;

        // Constructor: Recibe la "campanita" de Windows desde tu formulario
        public GestorNotificaciones(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon;
        }

        // --- MOTOR CENTRAL QUE FILTRA ---
        public void LanzarNotificacion(string titulo, string mensaje, PrioridadNoti prioridad)
        {
            string preferencia = UsuarioSesion.Configuracion?.Notificaciones ?? "Todas";

            if (preferencia == "Ninguna") return;
            if (preferencia == "Solo importantes" && prioridad != PrioridadNoti.Alta) return;

            ToolTipIcon icono = (prioridad == PrioridadNoti.Alta) ? ToolTipIcon.Warning : ToolTipIcon.Info;

            _notifyIcon.ShowBalloonTip(5000, titulo, mensaje, icono);
        }

        // --- REGLAS DE NEGOCIO ---
        public void EvaluarHabitosYAlertas(string nombreEmpleado, DateTime fechaIngreso, DateTime ultimoRegistro)
        {
            if (fechaIngreso.Month == DateTime.Now.Month && fechaIngreso.Day == DateTime.Now.Day && fechaIngreso.Year < DateTime.Now.Year)
            {
                int anios = DateTime.Now.Year - fechaIngreso.Year;
                LanzarNotificacion("¡Feliz Aniversario laboral!", $"Felicidades por cumplir {anios} año(s), {nombreEmpleado}.", PrioridadNoti.Baja);
            }

            if ((DateTime.Now - ultimoRegistro).TotalDays >= 2)
            {
                LanzarNotificacion("Inventario desactualizado", "No descuides tu inventario, el trabajo de hoy puede ser tu martirio de mañana.", PrioridadNoti.Normal);
            }

            DateTime inicioJornada = DateTime.Today.AddHours(8);
            if (DateTime.Now >= inicioJornada.AddHours(4))
            {
                LanzarNotificacion("Te estábamos esperando", "El inventario está esperando una actualización tuya.", PrioridadNoti.Baja);
            }
        }

        public void EvaluarAlertasCriticasDeBD()
        {
            int inventarioId = UsuarioSesion.InventarioId;
            int garantiasPorVencer = 0;

            string query = @"
                SELECT COUNT(*) 
                FROM Articulos 
                WHERE InventarioId = @InvId 
                AND FechaFinGarantia IS NOT NULL 
                AND date(FechaFinGarantia) BETWEEN date('now') AND date('now', '+7 days')";

            try
            {
                using (var con = ConexionGlobal.ObtenerConexion())
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@InvId", inventarioId);
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            garantiasPorVencer = Convert.ToInt32(result);
                        }
                    }
                }

                if (garantiasPorVencer > 0)
                {
                    LanzarNotificacion("Garantías por vencer 🚨", $"Tienes {garantiasPorVencer} artículo(s) cuya garantía vence en los próximos 7 días.", PrioridadNoti.Alta);
                }
            }
            catch
            {
            }
        }
    }
}

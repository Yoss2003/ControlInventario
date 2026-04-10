using ControlInventario.Database;
using ControlInventario.Repositorio;
using System;
using System.Data.SQLite;
using System.Diagnostics;
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
            int preferenciaId = UsuarioSesion.Configuracion?.IdNotificaciones ?? 1;

            if (preferenciaId == 3)
                return;

            if (preferenciaId == 2 && prioridad != PrioridadNoti.Alta)
                return;

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

        public void EvaluarAlertasCuotasVencidas()
        {
            try
            {
                int inventarioId = UsuarioSesion.InventarioId;

                // 1. Alerta interna (campanita)
                int vencidas = CuentasPorCobrarRepository.ContarCuotasVencidas(inventarioId);
                if (vencidas > 0)
                {
                    LanzarNotificacion(
                        "Cuotas vencidas 💰",
                        $"Tienes {vencidas} cuota(s) vencida(s) pendientes de cobro.",
                        PrioridadNoti.Alta
                    );
                }

                // 2. Notificar a los clientes (WhatsApp)
                NotificarClientesCuotasPendientes(inventarioId);
            }
            catch { }
        }

        private void NotificarClientesCuotasPendientes(int inventarioId)
        {
            try
            {
                var cuotasPendientes = CuentasPorCobrarRepository.ListarCuotasParaNotificar(inventarioId);
                if (cuotasPendientes == null || cuotasPendientes.Rows.Count == 0) return;

                string simbolo = ClassHelper.ObtenerSimboloMoneda();

                foreach (System.Data.DataRow row in cuotasPendientes.Rows)
                {
                    string cliente = row["Destinatario"]?.ToString() ?? "";
                    string telefonoCliente = row["TelefonoCliente"]?.ToString() ?? "";
                    int numCuota = Convert.ToInt32(row["NumeroCuota"]);
                    decimal montoCuota = Convert.ToDecimal(row["MontoCuota"]);
                    decimal montoMora = Convert.ToDecimal(row["MontoMora"]);
                    DateTime fechaVenc = DateTime.Parse(row["FechaVencimiento"].ToString());

                    // Solo WhatsApp para cuotas vencidas
                    if (!string.IsNullOrWhiteSpace(telefonoCliente) && fechaVenc.Date < DateTime.Now.Date)
                    {
                        string mensaje = GenerarMensajeRecordatorio(cliente, numCuota, montoCuota, montoMora, fechaVenc, simbolo);
                        EnviarWhatsApp(telefonoCliente, mensaje);
                    }
                }
            }
            catch { }
        }

        // --- UTILIDADES DE NOTIFICACIÓN AL CLIENTE ---

        private string GenerarMensajeRecordatorio(string nombreCliente, int numeroCuota, decimal montoCuota, decimal montoMora, DateTime fechaVencimiento, string simboloMoneda)
        {
            decimal totalAPagar = montoCuota + montoMora;
            string fecha = fechaVencimiento.ToString("dd/MM/yyyy");

            string mensaje = $"Estimado/a {nombreCliente},\n\n" +
                $"Le recordamos que tiene una cuota pendiente de pago:\n\n" +
                $"• Cuota N°: {numeroCuota}\n" +
                $"• Monto: {simboloMoneda} {montoCuota:N2}\n";

            if (montoMora > 0)
            {
                mensaje += $"• Mora: {simboloMoneda} {montoMora:N2}\n" +
                    $"• Total a pagar: {simboloMoneda} {totalAPagar:N2}\n";
            }

            mensaje += $"• Fecha de vencimiento: {fecha}\n\n" +
                "⚠️ Esta cuota se encuentra VENCIDA. Le solicitamos regularizar su pago a la brevedad.\n\n" +
                "Gracias por su preferencia.";

            return mensaje;
        }

        private void EnviarWhatsApp(string telefono, string mensaje)
        {
            try
            {
                string numeroLimpio = System.Text.RegularExpressions.Regex.Replace(telefono, @"[^\d]", "");

                // Si no tiene código de país, asumir Perú (+51)
                if (numeroLimpio.Length == 9)
                    numeroLimpio = "51" + numeroLimpio;

                string mensajeCodificado = Uri.EscapeDataString(mensaje);
                string url = $"https://wa.me/{numeroLimpio}?text={mensajeCodificado}";

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch { }
        }
    }
}

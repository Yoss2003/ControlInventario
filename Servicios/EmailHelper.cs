using System;
using System.Net;
using System.Net.Mail;

namespace ControlInventario.Servicios
{
    public static class EmailHelper
    {
        /// <summary>
        /// Envía un correo usando las credenciales SMTP del usuario actual en sesión.
        /// </summary>
        public static bool EnviarCorreoDesdeUsuarioActual(string destinatario, string asunto, string cuerpoHtml, out string error)
        {
            error = "";
            
            string correoRemitente = UsuarioSesion.Configuracion?.CorreoSMTP;
            string claveRemitente = UsuarioSesion.Configuracion?.ClaveSMTP;

            // Validar que el usuario tenga configurado su correo SMTP
            if (string.IsNullOrWhiteSpace(correoRemitente) || string.IsNullOrWhiteSpace(claveRemitente))
            {
                error = "El usuario no tiene configurado su correo SMTP. Configure en: Configuración > Seguridad";
                return false;
            }

            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(correoRemitente, UsuarioSesion.NombrePersonal);
                    message.To.Add(destinatario);
                    message.Subject = asunto;
                    message.Body = cuerpoHtml;
                    message.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(correoRemitente, claveRemitente);
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = $"Error al enviar correo: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Envía una copia del correo al mismo vendedor/usuario que realizó la venta.
        /// </summary>
        public static bool EnviarCopiaAVendedor(string asunto, string cuerpoHtml)
        {
            string correoVendedor = UsuarioSesion.Configuracion?.CorreoSMTP;
            if (string.IsNullOrWhiteSpace(correoVendedor))
                return false;

            return EnviarCorreoDesdeUsuarioActual(correoVendedor, "[COPIA] " + asunto, cuerpoHtml, out _);
        }

        /// <summary>
        /// Genera el cuerpo HTML para el correo de confirmación de venta a crédito.
        /// </summary>
        public static string GenerarCorreoVentaCredito(string nombreCliente, decimal totalVenta, decimal enganche, int numCuotas, decimal montoCuota, DateTime primeraCuota, string frecuencia)
        {
            string simbolo = ClassHelper.ObtenerSimboloMoneda();
            decimal montoFinanciar = totalVenta - enganche;
            
            return $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: 'Segoe UI', Arial, sans-serif; color: #2c3e50; }}
                        .header {{ background-color: #3498db; color: white; padding: 20px; text-align: center; }}
                        .content {{ padding: 20px; }}
                        .detalle-tabla {{ border-collapse: collapse; width: 100%; margin: 20px 0; }}
                        .detalle-tabla td {{ padding: 10px; border-bottom: 1px solid #ecf0f1; }}
                        .detalle-tabla td:first-child {{ font-weight: bold; width: 200px; }}
                        .destacado {{ background-color: #e8f5e9; padding: 15px; border-left: 4px solid #27ae60; margin: 20px 0; }}
                        .footer {{ background-color: #ecf0f1; padding: 15px; text-align: center; font-size: 12px; color: #7f8c8d; }}
                    </style>
                </head>
                <body>
                    <div class='header'>
                        <h2>✓ Confirmación de Venta a Crédito</h2>
                    </div>
                    <div class='content'>
                        <p>Estimado/a <strong>{nombreCliente}</strong>,</p>
                        <p>Le confirmamos que su compra a crédito ha sido registrada exitosamente con los siguientes detalles:</p>
                        
                        <table class='detalle-tabla'>
                            <tr><td>Total de la venta:</td><td>{simbolo} {totalVenta:N2}</td></tr>
                            <tr><td>Enganche pagado:</td><td>{simbolo} {enganche:N2}</td></tr>
                            <tr><td>Monto a financiar:</td><td><strong>{simbolo} {montoFinanciar:N2}</strong></td></tr>
                            <tr><td>Número de cuotas:</td><td>{numCuotas} cuotas ({frecuencia})</td></tr>
                            <tr><td>Monto por cuota:</td><td><strong>{simbolo} {montoCuota:N2}</strong></td></tr>
                            <tr><td>Primera cuota vence:</td><td>{primeraCuota:dd/MM/yyyy}</td></tr>
                        </table>
                        
                        <div class='destacado'>
                            <strong>📧 Recordatorios automáticos</strong><br/>
                            Recibirá notificaciones por correo y WhatsApp antes del vencimiento de cada cuota.
                        </div>
                        
                        <p>Gracias por su preferencia.</p>
                        <p><em>Vendedor: {UsuarioSesion.NombrePersonal}</em></p>
                    </div>
                    <div class='footer'>
                        Control de Inventario - {DateTime.Now.Year}<br/>
                        Este es un correo automático, por favor no responder directamente.
                    </div>
                </body>
                </html>
            ";
        }
    }
}

using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace ControlInventario.Servicios
{
    public class GestorVoz
    {
        private SpeechSynthesizer _sintetizador;

        public GestorVoz()
        {
            _sintetizador = new SpeechSynthesizer();
            _sintetizador.SetOutputToDefaultAudioDevice();

            // Opcional: Intentar seleccionar una voz en español por defecto
            try
            {
                // Descomenta la siguiente línea si quieres forzar una voz específica (ej. Microsoft Sabina)
                // _sintetizador.SelectVoice("Microsoft Sabina Desktop"); 
            }
            catch (Exception)
            {
                // Si falla, usará la voz por defecto de Windows
            }
        }

        // Usamos Task para que la voz se ejecute en segundo plano 
        // y no congele la pantalla de tu aplicación mientras habla.
        public void HablarAsincrono(string texto)
        {
            Task.Run(() =>
            {
                _sintetizador.Speak(texto);
            });
        }
    }
}
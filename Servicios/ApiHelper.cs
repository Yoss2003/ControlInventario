using ControlInventario.Modelo.API;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControlInventario.Servicios
{
    public static class ApiHelper
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static int MapearEstadoSunat(string estadoSunat)
        {
            if (string.IsNullOrWhiteSpace(estadoSunat)) return 1;

            switch (estadoSunat.Trim().ToUpper())
            {
                case "ACTIVO": return 1;
                case "SUSPENSION TEMPORAL": return 2;
                case "BAJA PROVISIONAL": return 3;
                case "BAJA DEFINITIVA": return 4;
                case "BAJA PROVISIONAL DE OFICIO": return 5;
                case "BAJA DEFINITIVA DE OFICIO": return 6;
                default: return 1; // Por seguridad
            }
        }

        public static async Task<RespuestaSunat> ConsultarRucAsync(string ruc)
        {
            if (string.IsNullOrWhiteSpace(ruc) || ruc.Length != 11)
                return null;

            string url = $"https://api.apis.net.pe/v1/ruc?numero={ruc}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var empresa = JsonSerializer.Deserialize<RespuestaSunat>(jsonResponse, opciones);

                    return empresa;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

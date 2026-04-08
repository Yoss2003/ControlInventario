using ControlInventario.Modelo.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControlInventario.Servicios
{
    public static class ApiHelper
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public static Dictionary<string, decimal> TasasDeCambioCache = new Dictionary<string, decimal>();

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

        public static async Task<RequestReniec> ConsultarDniAsync(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni) || dni.Length != 8) return null;
            string url = $"https://api.apis.net.pe/v1/dni?numero={dni}";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<RequestReniec>(jsonResponse, opciones);
                }
                return null;
            }
            catch { return null; }
        }

        public static async Task CargarTasasDeCambioDesdeAPI()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://open.er-api.com/v6/latest/USD";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement rates = doc.RootElement.GetProperty("rates");
                            TasasDeCambioCache.Clear();

                            foreach (JsonProperty moneda in rates.EnumerateObject())
                            {
                                TasasDeCambioCache[moneda.Name] = moneda.Value.GetDecimal();
                            }
                        }
                    }
                }
            }
            catch
            {
                TasasDeCambioCache["USD"] = 1.00m;
                TasasDeCambioCache["PEN"] = 3.75m;
                TasasDeCambioCache["EUR"] = 0.92m;
            }
        }
    }
}

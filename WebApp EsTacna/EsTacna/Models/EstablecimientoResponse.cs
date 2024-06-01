using EsTacna.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EsTacna.Models
{
    public class EstablecimientoResponse
    {
        public int establecimiento_id { get; set; }
        public string clasificacionReal { get; set; }
        private readonly HttpClient httpClient;
        //
        private readonly EstablecimientoSaludRepositoryImpl objEstablecimientoRepo = new EstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        //
        public EstablecimientoResponse()
        {
            httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<List<EstablecimientoSalud>> GetEstablecimiento(int id)
        {
            // URL del endpoint de tu API
            string apiUrl = $"https://estacna-api.azurewebsites.net/api/recomendaciones";
            // Realizar la solicitud GET a la API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            List<EstablecimientoSalud> ListEstablecimiento = new List<EstablecimientoSalud>();
            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Leer la respuesta como una cadena JSON
                string json = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON en un diccionario
                Dictionary<string, List<string>> recomendaciones = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);

                if (recomendaciones.ContainsKey(id.ToString()))
                {
                    List<string> recomendacionesUsuario = recomendaciones[id.ToString()];
                    foreach (var item in recomendacionesUsuario)
                    {

                        var objEstablecimiento = objEstablecimientoRepo.BuscarId(Convert.ToInt32(item));
                        ListEstablecimiento.Add(objEstablecimiento);
                    }
                    // Pasar a la vista las recomendaciones del usuario
                    return ListEstablecimiento;
                }
                else
                {
                    // Manejar el caso en que no se encuentren recomendaciones para el ID de usuario
                    return ListEstablecimiento;
                }
            }
            else
            {
                // Manejar el caso de error en la solicitud a la API
                return ListEstablecimiento;
            }
        }
    }
}

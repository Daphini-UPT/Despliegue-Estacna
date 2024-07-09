using EsTacna.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

/**
* Clase para manejar la respuesta de la API de recomendaciones de establecimientos de salud.
*/
namespace EsTacna.Models
{
    public class ClinicaResponse
    {
        /**
        * Id del establecimiento.
        */
        public int establecimiento_id { get; set; }

        /**
        * Clasificación real del establecimiento.
        */
        public string clasificacionReal { get; set; }

        /**
        * Cliente HTTP para realizar solicitudes a la API.
        */
        private readonly HttpClient httpClient;

        /**
        * Repositorio de establecimientos de salud.
        */
        private readonly ClinicaRepositoryImpl objEstablecimientoRepo = new ClinicaRepositoryImpl(new EsTacnaContext());

        /**
        * Constructor para inicializar el cliente HTTP.
        */
        public ClinicaResponse()
        {
            httpClient = new HttpClient();
        }

        /**
        * Método para obtener los establecimientos recomendados para un usuario.
        * @param id El id del usuario.
        * @return Lista de establecimientos recomendados.
        */
        [HttpGet]
        public async Task<List<EstablecimientoSalud>> GetClinica(int id)
        {
            /**
            * URL del endpoint de tu API
            */
            string apiUrl = $"https://estacna-api.azurewebsites.net/api/recomendaciones";

            /**
            * Realizar la solicitud GET a la API
            */
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            List<EstablecimientoSalud> ListEstablecimiento = new List<EstablecimientoSalud>();

            /**
            * Verificar si la solicitud fue exitosa
            */
            if (response.IsSuccessStatusCode)
            {
                /**
                * Leer la respuesta como una cadena JSON
                */
                string json = await response.Content.ReadAsStringAsync();

                /**
                * Deserializar la respuesta JSON en un diccionario
                */
                Dictionary<string, List<string>> recomendaciones = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);

                if (recomendaciones.ContainsKey(id.ToString()))
                {
                    List<string> recomendacionesUsuario = recomendaciones[id.ToString()];
                    foreach (var item in recomendacionesUsuario)
                    {

                        var objEstablecimiento = objEstablecimientoRepo.BuscarId(Convert.ToInt32(item));
                        ListEstablecimiento.Add(objEstablecimiento);
                    }

                    /**
                    * Pasar a la vista las recomendaciones del usuario
                    */
                    return ListEstablecimiento;
                }
                else
                {
                    /**
                    * Manejar el caso en que no se encuentren recomendaciones para el ID de usuario
                    */
                    return ListEstablecimiento;
                }
            }
            else
            {
                /**
                * Manejar el caso de error en la solicitud a la API
                */
                return ListEstablecimiento;
            }
        }
    }
}

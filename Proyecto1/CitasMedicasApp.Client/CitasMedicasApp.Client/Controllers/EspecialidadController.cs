using AppCitasMedicas.DTO.Response.Especialidad;
using AppCitasMedicas.DTO.Response.Pacientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CitasMedicasApp.Client.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        //URL que se obtiene del appsettings.json para hacer las peticiones a la API
        private readonly string baseUrl;

        public EspecialidadController(IConfiguration configuration)
        {
            client = new HttpClient();
            baseUrl = configuration["ApiSettings:baseUrl"] + "especialidades";
        }

        // Metodo listar 
        public async Task<IActionResult> Index()
        {
            List<EspecialidadResponse> lista = new List<EspecialidadResponse>();

            HttpResponseMessage response =
                await client.GetAsync($"{baseUrl}/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<EspecialidadResponse>>(json);
            }

            return View(lista);
        }

    }
}

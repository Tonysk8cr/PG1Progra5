using AppCitasMedicas.DTO.Request.Pacientes;
using AppCitasMedicas.DTO.Response.Pacientes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace AppCitasMedicas.Client.Controllers
{
    public class PacientesController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        //URL que se obtiene del appsettings.json para hacer las peticiones a la API
        private readonly string baseUrl;

        public PacientesController(IConfiguration configuration)
        {
            client = new HttpClient();
            baseUrl = configuration["ApiSettings:baseUrl"] + "Pacientes";
        }

        // Metodo listar 
        public async Task<IActionResult> Index()
        {
            List<PacientesResponse> lista = new List<PacientesResponse>();

            HttpResponseMessage response =
                await client.GetAsync($"{baseUrl}/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<PacientesResponse>>(json);
            }

            return View(lista);
        }

        // Vista para crear Pacientes
        public IActionResult Crear()
        {
            return View();
        }

        // POST para crear Pacientes
        [HttpPost]
        public async Task<IActionResult> Crear(PacientesRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/Crear", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(request);
        }

        // Metodo Eliminar Pacientes
        public async Task<IActionResult> Eliminar(int id)
        {
            await client.DeleteAsync($"{baseUrl}/Eliminar?id={id}");
            return RedirectToAction("Index");
        }

        // Vista para editar los Pacientes
        public async Task<IActionResult> Editar(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/Buscar?id={id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var json = await response.Content.ReadAsStringAsync();
            var paciente = JsonConvert.DeserializeObject<PacientesResponse>(json);

            var request = new PacientesUpdateRequest
            {
              
                Nombre = paciente.Nombre,
                Edad = paciente.Edad,
                Telefono = paciente.Telefono,
                Email = paciente.Email

            };

            ViewBag.Id = id;
            return View(request);
        }

        // POST para editar los Pacientes
        [HttpPost]
        public async Task<IActionResult> Editar(int id, PacientesUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync($"{baseUrl}/Actualizar?id={id}", content);

            return RedirectToAction("Index");
        }
    }
}
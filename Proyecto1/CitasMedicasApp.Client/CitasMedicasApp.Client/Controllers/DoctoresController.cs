using AppCitasMedicas.Client.Models;
using AppCitasMedicas.DTO.Request.Doctor;
using AppCitasMedicas.DTO.Response.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CitasMedicasApp.Client.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        //URL que se obtiene del appsettings.json para hacer las peticiones a la API
        private readonly string baseUrl;

        public DoctoresController(IConfiguration configuration)
        {
            client = new HttpClient();
            baseUrl = configuration["ApiSettings:baseUrl"] + "Doctores";
        }

        // Metodo listar 
        public async Task<IActionResult> Index()
        {
            List<DoctorResponse> lista = new List<DoctorResponse>();

            HttpResponseMessage response =
                await client.GetAsync($"{baseUrl}/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<DoctorResponse>>(json);
            }

            return View(lista);
        }

        // Vista para crear Doctro
        public IActionResult Crear()
        {
            return View();
        }

        // POST para crear Doctor
        [HttpPost]
        public async Task<IActionResult> Crear(DoctorRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/Crear", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(request);
        }

        // Metodo Eliminar Doctor
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
            var doc = JsonConvert.DeserializeObject<DoctorResponse>(json);

            var request = new DoctorUpdateRequest
            {

                Nombre = doc.Nombre,
                EspecialidadId = doc.EspecialidadId,
                Telefono = doc.Telefono,
                Email = doc.Email

            };

            ViewBag.Id = id;
            return View(request);
        }

        // POST para editar los Pacientes
        [HttpPost]
        public async Task<IActionResult> Editar(int id, DoctorUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync($"{baseUrl}/Actualizar?id={id}", content);

            return RedirectToAction("Index");
        }
    }
}

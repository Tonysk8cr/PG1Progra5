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
        public IActionResult Index()
        {
            return View();
        }

    }
}

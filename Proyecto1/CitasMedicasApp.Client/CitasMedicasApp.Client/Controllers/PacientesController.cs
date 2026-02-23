using Microsoft.AspNetCore.Mvc;

namespace AppCitasMedicas.Client.Controllers
{
    public class PacientesController : Controller
    {

        //Vista paciente 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
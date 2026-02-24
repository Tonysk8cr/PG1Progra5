using Microsoft.AspNetCore.Mvc;

namespace AppCitasMedicas.Client.Controllers
{
    public class CitasController : Controller
    {
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
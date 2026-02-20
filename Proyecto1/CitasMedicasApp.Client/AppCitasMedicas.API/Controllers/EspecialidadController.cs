using AppCitasMedicas.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCitasMedicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadNegocio _negocio;

        public EspecialidadesController(IEspecialidadNegocio negocio)
        {
            _negocio = negocio;
        }

        // GET: /api/especialidades/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var rpta = await _negocio.Listar();
            return Ok(rpta);
        }
    }
}


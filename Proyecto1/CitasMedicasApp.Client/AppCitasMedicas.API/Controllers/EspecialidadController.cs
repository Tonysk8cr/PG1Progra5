using AppCitasMedicas.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCitasMedicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadNegocio _repositorio;

        public EspecialidadesController(IEspecialidadNegocio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: /api/especialidades/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var rpta = await _repositorio.Listar();
            return Ok(rpta);
        }
    }
}
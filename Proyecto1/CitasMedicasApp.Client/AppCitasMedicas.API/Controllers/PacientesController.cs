using AppCitasMedicas.DTO.Request.Pacientes;
using AppCitasMedicas.Negocio.Implementaciones;
using AppCitasMedicas.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCitasMedicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesNegocio _negocio;

        public PacientesController(IPacientesNegocio negocio)
        {
            _negocio = negocio;
        }

        // GET: /api/pacientes/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var rpta = await _negocio.Listar();
            return Ok(rpta);
        }

        // GET: /api/pacientes/Buscar?id=1
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar(int id)
        {
            var rpta = await _negocio.ObtenerPorId(id);
            if (rpta == null) return NotFound($"No existe paciente con id {id}.");
            return Ok(rpta);
        }

        // POST: /api/pacientes/Crear
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PacientesRequest request)
        {
            var ok = await _negocio.Crear(request);
            return ok ? Ok("Paciente guardado correctamente.") : BadRequest("No se pudo guardar.");
        }

        // PUT: /api/pacientes/Actualizar?id=1
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] PacientesUpdateRequest request)
        {
            var ok = await _negocio.Actualizar(id, request);
            return ok ? Ok($"Paciente {id} actualizado correctamente.") : NotFound($"No existe paciente con id {id}.");
        }

        // DELETE: /api/pacientes/Eliminar?id=1
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await _negocio.Eliminar(id);
            return ok ? Ok($"Paciente {id} eliminado correctamente.") : NotFound($"No existe paciente con id {id}.");
        }
    }
}
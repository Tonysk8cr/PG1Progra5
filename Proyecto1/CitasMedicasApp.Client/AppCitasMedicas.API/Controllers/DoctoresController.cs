using AppCitasMedicas.DTO.Request.Doctor;
using AppCitasMedicas.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCitasMedicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly IDoctorNegocio _repositorio;

        public DoctoresController(IDoctorNegocio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: /api/doctores/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var rpta = await _repositorio.Listar();
            return Ok(rpta);
        }

        // GET: /api/doctores/Buscar?id=5
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar(int id)
        {
            var rpta = await _repositorio.ObtenerPorId(id);
            if (rpta == null) return NotFound($"No existe doctor con id {id}.");
            return Ok(rpta);
        }

        // POST: /api/doctores/Crear
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] DoctorRequest request)
        {
            var ok = await _repositorio.Crear(request);
            return ok ? Ok("Doctor guardado correctamente.") : BadRequest("No se pudo guardar.");
        }

        // PUT: /api/doctores/Actualizar?id=5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] DoctorUpdateRequest request)
        {
            var ok = await _repositorio.Actualizar(id, request);
            return ok ? Ok($"Doctor {id} actualizado correctamente.") : NotFound($"No existe doctor con id {id}.");
        }

        // DELETE: /api/doctores/Eliminar?id=5
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await _repositorio.Eliminar(id);
            return ok ? Ok($"Doctor {id} eliminado correctamente.") : NotFound($"No existe doctor con id {id}.");
        }
    }
}
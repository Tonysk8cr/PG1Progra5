using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.DTO.Request.Citas;
using AppCitasMedicas.Entities;
using AppCitasMedicas.Negocio.Implementaciones;
using AppCitasMedicas.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCitasMedicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitasNegocio _negocio;
        private readonly IDoctorNegocio _doctornegocio;

        public CitasController(ICitasNegocio negocio, IDoctorNegocio doctornegocio)
        {
            _negocio = negocio;
            _doctornegocio = doctornegocio;
        }

        // GET: /api/citas/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var rpta = await _negocio.Listar();
            return Ok(rpta);
        }

        // GET: /api/citas/Buscar?id=5
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar(int id)
        {
            var rpta = await _negocio.ObtenerPorId(id);
            if (rpta == null) return NotFound($"No existe cita con id {id}.");
            return Ok(rpta);
        }

        // POST: /api/citas/Crear
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CitasRequest request)
        {
            // Validar que la fecha no sea en el pasado
            if (request.FechaCita < DateOnly.FromDateTime(DateTime.Today))
            {
                return BadRequest("La fecha de la cita no puede ser en el pasado.");
            }

            // Validar que el doctor exista
            var doctor = await _doctornegocio.ObtenerPorId(request.DoctorId);
            if (doctor == null)
            {
                return BadRequest($"No existe un doctor con id {request.DoctorId}.");
            }

            var ok = await _negocio.Crear(request);
            return ok ? Ok("Cita guardada correctamente.") : BadRequest("No se pudo guardar.");
        }

        // PUT: /api/citas/Actualizar?id=5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] CitasUpdateRequest request)
        {
            // Validar que el doctor exista
            var doctor = await _doctornegocio.ObtenerPorId(request.DoctorId);
            if (doctor == null)
            {
                return BadRequest($"No existe un doctor con id {request.DoctorId}.");
            }

            var ok = await _negocio.Actualizar(id, request);
            return ok ? Ok($"Cita {id} actualizada correctamente.") : NotFound($"No existe cita con id {id}.");
        }

        // DELETE: /api/citas/Eliminar?id=5
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await _negocio.Eliminar(id);
            return ok ? Ok($"Cita {id} eliminada correctamente.") : NotFound($"No existe cita con id {id}.");
        }
    }
}

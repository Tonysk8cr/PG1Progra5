using AppTareas.DTO.Request.Tareas;
using AppTareas.Negocio.Implementaciones;
using AppTareas.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareasNegocio _repositorio;

        public TareasController(ITareasNegocio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: /api/tareas/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var rpta = await _repositorio.Listar();
            return Ok(rpta);
        }

        // POST: /api/tareas/Crear
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] TareasRequest request)
        {
            var ok = await _repositorio.Crear(request);
            return ok ? Ok("La Tarea fue guardada correctamente.") : BadRequest("No se pudo guardar la tarea.");
        }

        // PUT: /api/tareas/Actualizar?id=5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] TareasUpdateRequest request)
        {
            var ok = await _repositorio.Actualizar(id, request);
            return ok ? Ok($"La Tarea con el {id} fue actualizada correctamente.")
                      : NotFound($"No existe ninguna tarea con el id {id}.");
        }

        // DELETE: /api/tareas/Eliminar?id=5
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await _repositorio.Eliminar(id);
            return ok ? Ok($"Tarea {id} eliminada correctamente.")
                      : NotFound($"No existe una tarea con el id {id}.");
        }
    }
}

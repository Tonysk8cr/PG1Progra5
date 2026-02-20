using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCitasMedicas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitasController : ControllerBase
    {
        // ORM
        private readonly CitasMedicasContext _context = null;

        public CitasController(CitasMedicasContext pContext)
        {
            _context = pContext;
        }

        // ==============================
        // Listar citas (filtrar por fecha opcional)
        // GET: /Citas/ListarCitas?fecha=2026-02-17
        // ==============================

        [HttpGet]
        [Route("ListarCitas")]
        public List<Citum> ListarCitas(DateOnly? fecha)
        {
            if (fecha.HasValue)
            {
                return _context.Cita
                    .Where(c => c.FechaCita == fecha.Value)
                    .ToList();
            }

            return _context.Cita.ToList();
        }

        // ==============================
        // Buscar cita por id
        // GET: /Citas/BuscarCita?id=1
        // ==============================

        [HttpGet]
        [Route("BuscarCita")]
        public Citum BuscarCita(int id)
        {
            return _context.Cita.FirstOrDefault(c => c.CitaId == id);
        }

        // ==============================
        // Crear cita
        // POST: /Citas/AgregarCita
        // ==============================

        [HttpPost]
        [Route("AgregarCita")]
        public string AgregarCita(Citum temp)
        {
            string msj = "";
            try
            {
                if (temp == null)
                {
                    msj = "No se permiten datos en blanco.";
                }
                else
                {
                    _context.Cita.Add(temp);
                    _context.SaveChanges();

                    msj = $"Cita {temp.CitaId} fue guardada correctamente.";
                }
            }
            catch (Exception ex)
            {
                msj = $"Error, {ex.InnerException?.ToString() ?? ex.Message}";
            }

            return msj;
        }

        // ==============================
        // Modificar cita
        // PUT: /Citas/ModificarCita
        // ==============================

        [HttpPut]
        [Route("ModificarCita")]
        public string ModificarCita(Citum temp)
        {
            string msj = "";
            try
            {
                if (temp == null)
                {
                    msj = "No se permiten datos en blanco.";
                }
                else
                {
                    var cita = _context.Cita.FirstOrDefault(c => c.CitaId == temp.CitaId);

                    if (cita != null)
                    {
                        cita.PacienteId = temp.PacienteId;
                        cita.DoctorId = temp.DoctorId;
                        cita.FechaCita = temp.FechaCita;
                        cita.HoraCita = temp.HoraCita;
                        cita.Motivo = temp.Motivo;
                        cita.Estado = temp.Estado;

                        _context.Cita.Update(cita);
                        _context.SaveChanges();

                        msj = $"La cita con id {temp.CitaId} fue actualizada correctamente.";
                    }
                    else
                    {
                        msj = $"No existe cita con id {temp.CitaId}.";
                    }
                }
            }
            catch (Exception ex)
            {
                msj = $"Error, {ex.InnerException?.ToString() ?? ex.Message}";
            }

            return msj;
        }

        // ==============================
        // Eliminar / Cancelar cita
        // DELETE: /Citas/EliminarCita?id=1
        // ==============================

        [HttpDelete]
        [Route("EliminarCita")]
        public string EliminarCita(int id)
        {
            string msj = "";
            try
            {
                var cita = _context.Cita.FirstOrDefault(c => c.CitaId == id);

                if (cita == null)
                {
                    msj = $"No existe cita con id {id}.";
                }
                else
                {
                    // Cancelar (soft delete)
                    cita.Estado = 0;

                    _context.Cita.Update(cita);
                    _context.SaveChanges();

                    msj = $"Cita {id} cancelada correctamente.";
                }
            }
            catch (Exception ex)
            {
                msj = $"Error, {ex.InnerException?.ToString() ?? ex.Message}";
            }

            return msj;
        }
    }
}

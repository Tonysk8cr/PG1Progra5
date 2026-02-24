using AppCitasMedicas.Entities;
using AppCitasMedicas.DTO.Response.Citas;
using AppCitasMedicas.DTO.Request.Citas;
using AppCitasMedicas.Negocio.Interfaces;
using AppCitasMedicas.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Implementaciones
{
    public class CitasNegocio : ICitasNegocio
    {
        private readonly ICitasRepositorio _repositorio;

        public CitasNegocio(ICitasRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<CitaResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(c => new CitaResponse
            {
                CitaId = c.CitaId,

                PacienteId = c.PacienteId,
                PacienteNombre = c.Paciente.Nombre,

                DoctorId = c.DoctorId,
                DoctorNombre = c.Doctor.Nombre,

                FechaCita = c.FechaCita,
                HoraCita = c.HoraCita,
                Motivo = c.Motivo,
                Estado = c.Estado

            }).ToList();
        }

        public async Task<CitaResponse?> ObtenerPorId(int id)
        {
            var cita = await _repositorio.ObtenerPorId(id);
            if (cita == null) return null;

            return new CitaResponse
            {
                CitaId = cita.CitaId,

                PacienteId = cita.PacienteId,
                PacienteNombre = cita.Paciente.Nombre,

                DoctorId = cita.DoctorId,
                DoctorNombre = cita.Doctor.Nombre,

                FechaCita = cita.FechaCita,
                HoraCita = cita.HoraCita,
                Motivo = cita.Motivo,
                Estado = cita.Estado
            };
        }

        public async Task<bool> Crear(CitasRequest request)
        {
            var entity = new Citum
            {
                PacienteId = request.PacienteId,
                DoctorId = request.DoctorId,
                FechaCita = request.FechaCita,
                HoraCita = request.HoraCita,
                Motivo = request.Motivo,
                Estado = 1,
                FechaCreacion = System.DateTime.Now
            };

            return await _repositorio.Crear(entity);
        }

        public async Task<bool> Actualizar(int id, CitasUpdateRequest request)
        {
            var cita = await _repositorio.ObtenerPorId(id);
            if (cita == null) return false;

            cita.FechaCita = request.FechaCita;
            cita.HoraCita = request.HoraCita;
            cita.Motivo = request.Motivo;
            cita.Estado = request.Estado;

            return await _repositorio.Actualizar(cita);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }
    }
}

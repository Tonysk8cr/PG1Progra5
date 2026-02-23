using AppCitasMedicas.Entities;
using AppCitasMedicas.DTO.Response.Pacientes;
using AppCitasMedicas.DTO.Request.Pacientes;
using AppCitasMedicas.Negocio.Interfaces;
using AppCitasMedicas.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Implementaciones
{
    public class PacientesNegocio : IPacientesNegocio
    {
        private readonly IPacientesRepositorio _repositorio;

        public PacientesNegocio(IPacientesRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<PacientesResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(p => new PacientesResponse
            {
                PacienteId = p.PacienteId,
                Nombre = p.Nombre,
                Edad = p.Edad,
                Telefono = p.Telefono,
                Email = p.Email,
                Activo = p.Activo
            }).ToList();
        }

        public async Task<PacientesResponse?> ObtenerPorId(int id)
        {
            var paciente = await _repositorio.ObtenerPorId(id);
            if (paciente == null) return null;

            return new PacientesResponse
            {
                PacienteId = paciente.PacienteId,
                Nombre = paciente.Nombre,
                Edad = paciente.Edad,
                Telefono = paciente.Telefono,
                Email = paciente.Email,
                Activo = paciente.Activo
            };
        }

        public async Task<bool> Crear(PacientesRequest request)
        {
            var entity = new Pacientes
            {
                Nombre = request.Nombre,
                Edad = request.Edad,
                Telefono = request.Telefono,
                Email = request.Email,
                Activo = true,
                FechaCreacion = System.DateTime.Now
            };

            return await _repositorio.Crear(entity);
        }

        public async Task<bool> Actualizar(int id, PacientesUpdateRequest request)
        {
            var paciente = await _repositorio.ObtenerPorId(id);
            if (paciente == null) return false;

            paciente.Nombre = request.Nombre;
            paciente.Edad = request.Edad;
            paciente.Telefono = request.Telefono;
            paciente.Email = request.Email;

            return await _repositorio.Actualizar(paciente);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }
    }
}
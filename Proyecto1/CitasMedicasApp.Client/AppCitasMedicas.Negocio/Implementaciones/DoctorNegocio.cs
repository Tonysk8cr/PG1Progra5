using AppCitasMedicas.Entities;
using AppCitasMedicas.DTO.Response.Doctor;
using AppCitasMedicas.DTO.Request.Doctor;
using AppCitasMedicas.Negocio.Interfaces;
using AppCitasMedicas.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Implementaciones
{
    public class DoctorNegocio : IDoctorNegocio
    {
        private readonly IDoctorRepositorio _repositorio;

        public DoctorNegocio(IDoctorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<DoctorResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(d => new DoctorResponse
            {
                DoctorId = d.DoctorId,
                Nombre = d.Nombre,
                EspecialidadId = d.EspecialidadId,
                EspecialidadNombre = d.Especialidad != null ? d.Especialidad.Nombre : null,
                Telefono = d.Telefono,
                Email = d.Email,
                Activo = d.Activo
            }).ToList();
        }

        public async Task<DoctorResponse?> ObtenerPorId(int id)
        {
            var doctor = await _repositorio.ObtenerPorId(id);
            if (doctor == null) return null;

            return new DoctorResponse
            {
                DoctorId = doctor.DoctorId,
                Nombre = doctor.Nombre,
                EspecialidadId = doctor.EspecialidadId,
                EspecialidadNombre = doctor.Especialidad != null ? doctor.Especialidad.Nombre : null,
                Telefono = doctor.Telefono,
                Email = doctor.Email,
                Activo = doctor.Activo
            };
        }

        public async Task<bool> Crear(DoctorRequest request)
        {
            var entity = new Doctor
            {
                Nombre = request.Nombre,
                EspecialidadId = request.EspecialidadId,
                Telefono = request.Telefono,
                Email = request.Email,
                Activo = true,
                FechaCreacion = System.DateTime.Now
            };

            return await _repositorio.Crear(entity);
        }

        public async Task<bool> Actualizar(int id, DoctorUpdateRequest request)
        {
            var doctor = await _repositorio.ObtenerPorId(id);
            if (doctor == null) return false;

            doctor.Nombre = request.Nombre;
            doctor.EspecialidadId = request.EspecialidadId;
            doctor.Telefono = request.Telefono;
            doctor.Email = request.Email;

            return await _repositorio.Actualizar(doctor);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }
    }
}

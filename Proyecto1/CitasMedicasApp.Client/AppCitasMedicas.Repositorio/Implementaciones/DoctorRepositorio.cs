using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.Entities;
using AppCitasMedicas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppCitasMedicas.Repositorio.Implementaciones
{
    public class DoctorRepositorio : IDoctorRepositorio
    {
        public readonly CitasMedicasContext _bd;

        public DoctorRepositorio(CitasMedicasContext bd)
        {
            _bd = bd;
        }

        public async Task<List<Doctor>> Listar()
        {
            return await _bd.Doctors
                .Include(d => d.Especialidad)
                .Where(d => d.Activo)
                .ToListAsync();
        }

        public async Task<Doctor?> ObtenerPorId(int id)
        {
            return await _bd.Doctors
                .Include(d => d.Especialidad)
                .FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<bool> Crear(Doctor entidad)
        {
            _bd.Doctors.Add(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }

        public async Task<bool> Actualizar(Doctor entidad)
        {
            _bd.Doctors.Update(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var doctor = await _bd.Doctors.FirstOrDefaultAsync(p => p.DoctorId == id);
            if (doctor == null) return false;

            // soft delete 
            doctor.Activo = false;
            _bd.Doctors.Update(doctor);

            return await _bd.SaveChangesAsync() > 0;
        }
    }
}

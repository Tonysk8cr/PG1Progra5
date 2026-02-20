using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.Entities;
using AppCitasMedicas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppCitasMedicas.Repositorio.Implementaciones
{
    public class PacientesRepositorio : IPacientesRepositorio
    {
        public readonly CitasMedicasContext _bd;

        public PacientesRepositorio(CitasMedicasContext bd)
        {
            _bd = bd;
        }

        public async Task<List<Pacientes>> Listar()
        {
            return await _bd.Pacientes.Where(p => p.Activo).ToListAsync();
        }

        public async Task<Pacientes?> ObtenerPorId(int id)
        {
            return await _bd.Pacientes.FirstOrDefaultAsync(p => p.PacienteId == id);
        }

        public async Task<bool> Crear(Pacientes entidad)
        {
            _bd.Pacientes.Add(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }

        public async Task<bool> Actualizar(Pacientes entidad)
        {
            _bd.Pacientes.Update(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var paciente = await _bd.Pacientes.FirstOrDefaultAsync(p => p.PacienteId == id);
            if (paciente == null) return false;

            // soft delete
            paciente.Activo = false;
            _bd.Pacientes.Update(paciente);

            return await _bd.SaveChangesAsync() > 0;
        }
    }
}
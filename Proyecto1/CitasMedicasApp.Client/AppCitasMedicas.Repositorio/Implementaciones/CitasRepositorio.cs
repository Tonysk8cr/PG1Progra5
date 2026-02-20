using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.Entities;
using AppCitasMedicas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppCitasMedicas.Repositorio.Implementaciones
{
    public class CitasRepositorio : ICitasRepositorio
    {
        public readonly CitasMedicasContext _bd;

        public CitasRepositorio(CitasMedicasContext bd)
        {
            _bd = bd;
        }

        public async Task<List<Citum>> Listar()
        {
            return await _bd.Cita.ToListAsync();
        }

        public async Task<Citum?> ObtenerPorId(int id)
        {
            return await _bd.Cita.FirstOrDefaultAsync(p => p.CitaId == id);
        }

        public async Task<bool> Crear(Citum entidad)
        {
            _bd.Cita.Add(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }

        public async Task<bool> Actualizar(Citum entidad)
        {
            _bd.Cita.Update(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var cita = await _bd.Cita.FirstOrDefaultAsync(p => p.CitaId == id);
            if (cita == null) return false;

            _bd.Cita.Remove(cita);
            return await _bd.SaveChangesAsync() > 0;
        }
    }
}

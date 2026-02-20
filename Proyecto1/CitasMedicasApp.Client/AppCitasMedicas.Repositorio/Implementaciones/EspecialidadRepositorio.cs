using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.Entities;
using AppCitasMedicas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppCitasMedicas.Repositorio.Implementaciones
{
    public class EspecialidadRepositorio : IEspecialidadRepositorio
    {
        public readonly CitasMedicasContext _bd;

        public EspecialidadRepositorio(CitasMedicasContext bd)
        {
            _bd = bd;
        }

        public async Task<List<Especialidad>> Listar()
        {
            return await _bd.Especialidads.Where(p => p.Activo).ToListAsync();
        }
    }
}

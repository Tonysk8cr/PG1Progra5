using AppCitasMedicas.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Repositorio.Interfaces
{
    public interface IEspecialidadRepositorio
    {
        Task<List<Especialidad>> Listar();
    }
}

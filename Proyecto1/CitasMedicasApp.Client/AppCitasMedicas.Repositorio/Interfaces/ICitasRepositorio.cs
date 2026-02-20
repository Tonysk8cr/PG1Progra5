using AppCitasMedicas.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Repositorio.Interfaces
{
    public interface ICitasRepositorio
    {
        Task<List<Citum>> Listar();
        Task<Citum?> ObtenerPorId(int id);
        Task<bool> Crear(Citum entidad);
        Task<bool> Actualizar(Citum entidad);
        Task<bool> Eliminar(int id);
    }
}

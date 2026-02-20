using AppCitasMedicas.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Repositorio.Interfaces
{
    public interface IPacientesRepositorio
    {
        Task<List<Pacientes>> Listar();
        Task<Pacientes?> ObtenerPorId(int id);
        Task<bool> Crear(Pacientes entidad);
        Task<bool> Actualizar(Pacientes entidad);
        Task<bool> Eliminar(int id);
    }
}
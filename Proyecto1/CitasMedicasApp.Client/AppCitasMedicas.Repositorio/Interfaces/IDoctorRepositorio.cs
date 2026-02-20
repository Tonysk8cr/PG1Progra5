using AppCitasMedicas.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Repositorio.Interfaces
{
    public interface IDoctorRepositorio
    {
        Task<List<Doctor>> Listar();
        Task<Doctor?> ObtenerPorId(int id);
        Task<bool> Crear(Doctor entidad);
        Task<bool> Actualizar(Doctor entidad);
        Task<bool> Eliminar(int id);
    }
}

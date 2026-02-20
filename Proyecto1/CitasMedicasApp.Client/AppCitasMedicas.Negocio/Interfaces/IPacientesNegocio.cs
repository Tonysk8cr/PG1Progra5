using AppCitasMedicas.DTO.Request.Pacientes;
using AppCitasMedicas.DTO.Response.Pacientes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Interfaces
{
    public interface IPacientesNegocio
    {
        Task<List<PacientesResponse>> Listar();

        Task<PacientesResponse?> ObtenerPorId(int id);

        Task<bool> Crear(PacientesRequest request);

        Task<bool> Actualizar(int id, PacientesUpdateRequest request);

        Task<bool> Eliminar(int id);
    }
}
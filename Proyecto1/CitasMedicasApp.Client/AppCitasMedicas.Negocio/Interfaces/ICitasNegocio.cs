using AppCitasMedicas.DTO.Request.Citas;
using AppCitasMedicas.DTO.Response.Citas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Interfaces
{
    public interface ICitasNegocio
    {
        Task<List<CitaResponse>> Listar();

        Task<CitaResponse?> ObtenerPorId(int id);

        Task<bool> Crear(CitasRequest request);

        Task<bool> Actualizar(int id, CitasUpdateRequest request);

        Task<bool> Eliminar(int id);
    }
}

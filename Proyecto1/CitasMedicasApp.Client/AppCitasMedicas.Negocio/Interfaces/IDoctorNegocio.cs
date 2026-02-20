using AppCitasMedicas.DTO.Request.Doctor;
using AppCitasMedicas.DTO.Response.Doctor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Interfaces
{
    public interface IDoctorNegocio
    {
        Task<List<DoctorResponse>> Listar();

        Task<DoctorResponse?> ObtenerPorId(int id);

        Task<bool> Crear(DoctorRequest request);

        Task<bool> Actualizar(int id, DoctorUpdateRequest request);

        Task<bool> Eliminar(int id);
    }
}


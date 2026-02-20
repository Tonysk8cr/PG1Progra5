using AppCitasMedicas.DTO.Response.Especialidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Interfaces
{
    public interface IEspecialidadNegocio
    {
        Task<List<EspecialidadResponse>> Listar();
    }
}
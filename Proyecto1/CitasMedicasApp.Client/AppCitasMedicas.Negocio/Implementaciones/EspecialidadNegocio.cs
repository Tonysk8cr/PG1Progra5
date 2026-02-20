using AppCitasMedicas.DTO.Response.Especialidad;
using AppCitasMedicas.Negocio.Interfaces;
using AppCitasMedicas.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCitasMedicas.Negocio.Implementaciones
{
    public class EspecialidadNegocio : IEspecialidadNegocio
    {
        private readonly IEspecialidadRepositorio _repositorio;

        public EspecialidadNegocio(IEspecialidadRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<EspecialidadResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(e => new EspecialidadResponse
            {
                EspecialidadId = e.EspecialidadId,
                Nombre = e.Nombre,
                Activo = e.Activo
            }).ToList();
        }
    }
}


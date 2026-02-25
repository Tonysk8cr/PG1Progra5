using AppTareas.DTO.Request.Tareas;
using AppTareas.DTO.Response.Tareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTareas.Negocio.Interfaces
{
    public interface ITareasNegocio
    {
        Task<List<TareasResponse>> Listar();

        Task<TareasResponse?> ObtenerPorId(int id);

        Task<bool> Crear(TareasRequest request);

        Task<bool> Actualizar(int id, TareasUpdateRequest request);

        Task<bool> Eliminar(int id);
    }
}

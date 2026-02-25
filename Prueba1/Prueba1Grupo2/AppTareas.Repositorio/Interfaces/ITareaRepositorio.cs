using AppTareas.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AppTareas.Repositorio.Interfaces
{
    public interface ITareaRepositorio
    {
        Task<List<Tarea>> Listar();
        Task<Tarea?> ObtenerPorId(int id);
        Task<bool> Crear(Tarea entidad);
        Task<bool> Actualizar(Tarea entidad);
        Task<bool> Eliminar(int id);
    }
}

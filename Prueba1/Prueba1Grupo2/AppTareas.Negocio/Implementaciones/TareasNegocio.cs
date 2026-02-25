using AppTareas.Negocio.Interfaces;
using AppTareas.Entities;
using AppTareas.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AppTareas.DTO.Request.Tareas;
using AppTareas.DTO.Response.Tareas;

namespace AppTareas.Negocio.Implementaciones
{
    public class TareasNegocio : ITareasNegocio
    {
        private readonly ITareaRepositorio _repositorio;

        public TareasNegocio(ITareaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<TareasResponse>> Listar()
        {
            var lista = await _repositorio.Listar();

            return lista.Select(d => new TareasResponse
            {
                Titulo = d.Titulo,
                Descripcion = d.Descripcion,
                EstaCompletada = d.EstaCompletada,
                FechaCreacion = d.FechaCreacion

            }).ToList();
        }
        public async Task<TareasResponse?> ObtenerPorId(int id)
        {
            var tarea = await _repositorio.ObtenerPorId(id);
            if (tarea == null) return null;

            return new TareasResponse
            {
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                EstaCompletada = tarea.EstaCompletada,
                FechaCreacion = tarea.FechaCreacion
            };
        }
        public async Task<bool> Crear(TareasRequest request)
        {
            var entity = new Tarea
            {
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                EstaCompletada = false,
                FechaCreacion = DateTime.Now
            };

            return await _repositorio.Crear(entity);
        }
        public async Task<bool> Actualizar(int id, TareasUpdateRequest request)
        {
            var tarea = await _repositorio.ObtenerPorId(id);
            if (tarea == null) return false;

            tarea.Titulo = request.Titulo;
            tarea.Descripcion = request.Descripcion;
            tarea.EstaCompletada = request.EstaCompletada;

            return await _repositorio.Actualizar(tarea);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }


    }
}

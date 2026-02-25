using AppTareas.AccesoDatos.Models;
using AppTareas.AccesoDatos;
using AppTareas.Entities;
using AppTareas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TareasDbContext = AppTareas.AccesoDatos.Models.TareasDbContext;

namespace AppTareas.Repositorio.Implementaciones
{
    public class TareaRepositorio : ITareaRepositorio
    {
        private readonly TareasDbContext _bd;
        public TareaRepositorio(TareasDbContext bd) 
        {
            _bd = bd;
        }
        public async Task<List<Tarea>> Listar()
        {
            return await _bd.Tareas.ToListAsync();
        }
        public async Task<Tarea?> ObtenerPorId(int id)
        {
            return await _bd.Tareas
                .Include(d => d.Titulo)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<bool> Crear(Tarea entidad)
        {
            _bd.Tareas.Add(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }
        public async Task<bool> Actualizar(Tarea entidad)
        {
            _bd.Tareas.Update(entidad);
            return await _bd.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(int id)
        {
            var tarea = await _bd.Tareas.FirstOrDefaultAsync(p => p.Id == id);
            if (tarea == null) return false;

            _bd.Tareas.Remove(tarea);
            return await _bd.SaveChangesAsync() > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudiantesAppWeb.Estudiante;

namespace EstudiantesApp.Services
{
    public class EstudianteService
    {
        // ── Lista interna de datos ────────────────────────────────────────────
        private List<EstudianteListCLS> estudiantes;
        private int _nextId = 2;

        // ── Notificación de cambios ───────────────────────────────────────────
        // Los componentes Blazor que se suscriban a este evento se actualizarán
        // automáticamente cada vez que la lista cambie (Insert, Update, Delete)
        public event Action OnChange;
        private void NotificarCambio() => OnChange?.Invoke();

        // ── Constructor con datos de prueba ───────────────────────────────────
        public EstudianteService()
        {
            estudiantes = new List<EstudianteListCLS>();

            var fechaNac = new DateTime(2000, 1, 1);

            estudiantes.Add(new EstudianteListCLS
            {
                IdEstudiante    = 1,
                Nombre          = "Dilan",
                PrimerApellido = "Durán",
                SegundoApellido = "Díaz",
                Cedula          = "999999999",
                Correo          = "test@gmail.com",
                Telefono        = "88658865",
                FechaNacimiento = fechaNac,
                Carrera         = "Ingenieria en Sistemas",
                Nivel           = "Pregrado",
                Promedio        = 6.5,
                Activo          = 1
            });
            estudiantes.Add(new EstudianteListCLS
            {
                IdEstudiante = 2,
                Nombre = "Yudi",
                PrimerApellido = "Fallas",
                SegundoApellido = "Calderón",
                Cedula = "123456789",
                Correo = "yudi@gmail.com",
                Telefono = "88881234",
                FechaNacimiento = fechaNac,
                Carrera = "Ingenieria en Sistemas",
                Nivel = "Pregrado",
                Promedio = 8.6,
                Activo = 1
            });
            estudiantes.Add(new EstudianteListCLS
            {
                IdEstudiante = 3,
                Nombre = "Santi",
                PrimerApellido = "Fonseca",
                SegundoApellido = "Chinchilla",
                Cedula = "123456789",
                Correo = "santi@gmail.com",
                Telefono = "88881234",
                FechaNacimiento = fechaNac,
                Carrera = "Ingenieria en Sistemas",
                Nivel = "Pregrado",
                Promedio = 8.7,
                Activo = 1
            });
            estudiantes.Add(new EstudianteListCLS
            {
                IdEstudiante = 4,
                Nombre = "Camila",
                PrimerApellido = "Rodríguez",
                SegundoApellido = "Coronado",
                Cedula = "123456789",
                Correo = "cam@gmail.com",
                Telefono = "88881234",
                FechaNacimiento = fechaNac,
                Carrera = "Ingenieria en Sistemas",
                Nivel = "Pregrado",
                Promedio = 8.8,
                Activo = 1
            });
            estudiantes.Add(new EstudianteListCLS
            {
                IdEstudiante = 5,
                Nombre = "Anthony",
                PrimerApellido = "Villalobos",
                SegundoApellido = "Hidalgo",
                Cedula = "123456789",
                Correo = "tony@gmail.com",
                Telefono = "88881234",
                FechaNacimiento = fechaNac,
                Carrera = "Ingenieria en Sistemas",
                Nivel = "Pregrado",
                Promedio = 8.9,
                Activo = 0
            });
        }

        // ── GetAll ────────────────────────────────────────────────────────────
        public async Task<List<EstudianteListCLS>> GetAll()
        {
            return estudiantes.ToList();
        }

        // ── GetById ───────────────────────────────────────────────────────────
        public async Task<EstudianteListCLS> GetById(int id)
        {
            return estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
        }

        // ── Insert ────────────────────────────────────────────────────────────
        public async Task Insert(EstudianteListCLS nuevo)
        {
            int nuevoId = estudiantes.Count > 0
                ? estudiantes.Max(e => e.IdEstudiante) + 1
                : 1;

            nuevo.IdEstudiante = nuevoId;

            estudiantes.Add(nuevo);
            NotificarCambio();
        }

        // ── Update ────────────────────────────────────────────────────────────
        public async Task Update(EstudianteListCLS actualizado)
        {
            int index = estudiantes.FindIndex(e => e.IdEstudiante == actualizado.IdEstudiante);
            if (index >= 0)
            {
                estudiantes[index] = actualizado;
                NotificarCambio();
            }
        }

        // ── Delete ────────────────────────────────────────────────────────────
        public async Task Delete(int id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                NotificarCambio();
            }
        }

        // ── Alias de compatibilidad con código de los compañeros ─────────────
        public async Task<List<EstudianteListCLS>> listarEstudiante()
        {
            return await GetAll();
        }
    }
}

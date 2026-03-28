using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EstudiantesAppWeb.Estudiante;

namespace EstudiantesApp.Services
{
    public class EstudianteService
    {
        private List<EstudianteListCLS> estudiantes;
        public EstudianteService()
        {

            estudiantes = new List<EstudianteListCLS>();
            //TODO: 
            //Esto lo vamos a tener que cambiar en un futuro cuando el crud y la bd exista
            var fechaNac = new DateTime(2000, 1, 1);

            estudiantes.Add(new EstudianteListCLS
            {
                IdEstudiante = 1,
                Nombre = "Juan",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Gomez",
                Cedula = "1234567890",
                Correo = "test@gmail.com",
                Telefono = "1234567890",
                FechaNacimiento = fechaNac,
                Edad = DateTime.Today.Year - fechaNac.Year -
                       (DateTime.Today.DayOfYear < fechaNac.DayOfYear ? 1 : 0),
                Carrera = "Ingenieria en Sistemas",
                Nivel = "Pregrado",
                Promedio = 3.5,
                Activo = 1
            });

        }

        public async Task<List<EstudianteListCLS>> listarEstudiante()
        { 
            return estudiantes;
        }
    }
}

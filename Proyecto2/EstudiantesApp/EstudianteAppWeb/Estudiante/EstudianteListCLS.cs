using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesAppWeb.Estudiante
{
    public class EstudianteListCLS
    {

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; } //Agregar metodo por fuera del modelo para calcular la edad a partir de la fecha de nacimiento, asi evitamos exponer logica

        public string Carrera { get; set; }

        public string Nivel { get; set; }

        public double Promedio { get; set; }

        public int Activo { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
            }
        }


    }
}

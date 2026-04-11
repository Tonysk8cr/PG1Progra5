using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstudiantesAppWeb.Estudiante
{
    public class EstudianteListCLS
    {
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es obligatorio.")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "La cédula debe tener entre 9 y 10 dígitos.")]
        public string Cedula { get; set; } //Tipo string para permitir dimex o ced extranjeras

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-18);

        // Edad calculada a partir de FechaNacimiento
        // Se mantiene fuera del modelo como propiedad calculada para no exponer lógica
        public int Edad
        {
            get
            {
                return DateTime.Today.Year - FechaNacimiento.Year -
                       (DateTime.Today.DayOfYear < FechaNacimiento.DayOfYear ? 1 : 0);
            }
        }

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El nivel es obligatorio.")]
        public string Nivel { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "El promedio debe estar entre 0 y 10.")]
        public double Promedio { get; set; }

        public int Activo { get; set; } = 1;

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {PrimerApellido} {SegundoApellido}";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;


namespace AppCitasMedicas.DTO.Response.Doctor
{
    public class DoctorResponse
    {
        public int DoctorId { get; set; }

        public string Nombre { get; set; } = null!;

        public int EspecialidadId { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public bool Activo { get; set; }
    }
}

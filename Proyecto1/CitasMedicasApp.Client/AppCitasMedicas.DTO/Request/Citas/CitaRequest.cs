using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasMedicas.DTO.Request.Citas
{
    public class CitaRequest
    {
        public int PacienteId { get; set; }

        public int DoctorId { get; set; }

        public DateOnly FechaCita { get; set; }

        public TimeOnly HoraCita { get; set; }

        public string? Motivo { get; set; }
    }
}



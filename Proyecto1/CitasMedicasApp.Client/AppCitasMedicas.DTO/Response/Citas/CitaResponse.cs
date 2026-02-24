using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasMedicas.DTO.Response.Citas
{
    public class CitaResponse
    {
        public int CitaId { get; set; }

        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }

        public int DoctorId { get; set; }
        public string DoctorNombre { get; set; }

        public DateOnly FechaCita { get; set; }
        public TimeOnly HoraCita { get; set; }

        public string Motivo { get; set; }
        public int Estado { get; set; }
    }
}


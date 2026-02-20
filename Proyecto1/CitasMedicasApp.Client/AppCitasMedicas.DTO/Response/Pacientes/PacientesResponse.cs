using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasMedicas.DTO.Response.Pacientes
{
    public class PacientesResponse
    {
        public int PacienteId { get; set; }

        public string Nombre { get; set; } = null!;

        public int Edad { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public bool Activo { get; set; }
    }
}

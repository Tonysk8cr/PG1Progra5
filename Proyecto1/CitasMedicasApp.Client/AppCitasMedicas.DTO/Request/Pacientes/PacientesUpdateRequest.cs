using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasMedicas.DTO.Request.Pacientes
{
    public class PacientesUpdateRequest
    {
        public string Nombre { get; set; } = null!;

        public int Edad { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public bool Activo { get; set; }
    }
}
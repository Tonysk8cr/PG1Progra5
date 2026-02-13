using System;
using System.Collections.Generic;
using System.Text;

namespace AppCitasMedicas.DTO.Request.Doctor
{
    public class DoctorRequest
{
    public string Nombre { get; set; } = null!;

    public int EspecialidadId { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }
}
}


using System;
using System.Collections.Generic;

namespace AppCitasMedicas.Client.Models;

public partial class Especialidad
{
    public int EspecialidadId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}

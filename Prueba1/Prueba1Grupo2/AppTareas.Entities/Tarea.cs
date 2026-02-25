using System;
using System.Collections.Generic;

namespace AppTareas.Entities;

public partial class Tarea
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool EstaCompletada { get; set; }

    public DateTime FechaCreacion { get; set; }
}

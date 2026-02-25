using System;
using System.Collections.Generic;
using System.Text;

namespace AppTareas.DTO.Request.Tareas
{
    public class TareasRequest
    {
        public string Titulo { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
        public bool EstaCompletada { get; set; }

        public DateTime FechaCreacion
        {
            get; set;
        }
       }
}
    

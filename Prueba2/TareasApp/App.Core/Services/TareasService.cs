using App.Core.Tarea;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Services
{
    public class TareasService
    {
        public List<Tarea> ObtenerTodas()
        {
            return new List<Tarea>
            {
                new Tarea { Id = 1, Descripcion = "Comprar leche" },
                new Tarea { Id = 2, Descripcion = "Estudiar MAUI" },
                new Tarea { Id = 3, Descripcion = "Pagar facturas" }
            };
        }

        public void Agregar(Tarea tarea)
        {
            // Simulado: en producción esto iría a la BD
        }
    }
}

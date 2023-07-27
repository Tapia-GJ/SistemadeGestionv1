using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Entities
{
    public class EmpleadoCapacitacion
    {
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int CapacitacionId { get; set; }
        public Capacitacion Capacitacion { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Entities
{
    public class Capacitacion
    {
        [Key]
        public int PkCapacitacion { get; set; }
        public string TipoCapacitacion { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        // Propiedad de navegación para la relación con los empleados
        //public ICollection<EmpleadoCapacitacion> EmpleadoCapacitaciones { get; set; }
        public ICollection<EmpleadoCapacitacion> EmpleadoCapacitaciones { get; set; }
    }
}

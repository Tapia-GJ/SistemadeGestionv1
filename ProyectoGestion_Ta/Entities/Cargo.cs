using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Entities
{
    public class Cargo
    {
        [Key]
        public int PkCargo { get; set; }
        public string Nombre { get; set; }
        // Propiedad de navegación para la relación con Empleado
        public ICollection<Empleado> Empleados { get; set; }
    }
}

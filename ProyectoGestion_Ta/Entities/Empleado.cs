using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Entities
{
    public class Empleado
    {
        [Key]
        public int PkEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Salario { get; set; }
        // Propiedad de navegación para la relación con Cargo
        [ForeignKey("Cargos")]
        public int CargoId { get; set; }
        public Cargo Cargos { get; set; }
        // Propiedad de navegación para la relación con las capacitaciones
        //public ICollection<EmpleadoCapacitacion> EmpleadoCapacitaciones { get; set; }
        public ICollection<EmpleadoCapacitacion> EmpleadoCapacitaciones { get; set; }
        public ICollection<Permiso> permisos { get; set; }
    }
}

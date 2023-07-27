using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Entities
{
    public class Direccion
    {
        [Key]
        [ForeignKey("Empleado")] // Establecer ForeignKey con el nombre de la propiedad de navegación en Empleado
        public int PkEmpleado { get; set; }
        public int Region { get; set; }
        public int Calle { get; set; }
        public int Lote { get; set; }

        // Propiedad de navegación para la relación con Empleado
        public Empleado Empleado { get; set; }
    }
}

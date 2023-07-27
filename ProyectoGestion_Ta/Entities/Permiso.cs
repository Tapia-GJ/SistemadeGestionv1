using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Entities
{
    public class Permiso
    {
        [Key]
        public int PkPermiso { get; set; }
        public DateTime FechaSoli { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        public Empleado Empleados { get; set; }
    }
}

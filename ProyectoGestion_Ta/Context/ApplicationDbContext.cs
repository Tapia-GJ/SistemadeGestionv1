using Microsoft.EntityFrameworkCore;
using ProyectoGestion_Ta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //AQUI va la cadena de conexion de bd
            options.UseMySQL("Server=localhost; database=bdproyecto; user=root; password=; ");
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<EmpleadoCapacitacion> empleadoCapacitaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir clave primaria para la entidad EmpleadoCapacitacion
            modelBuilder.Entity<EmpleadoCapacitacion>()
                .HasKey(ec => new { ec.EmpleadoId, ec.CapacitacionId });
        }

    }
}

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
            options.UseMySQL("Server=localhost; database=bdproyectov2; user=root; password=; ");
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<EmpleadoCapacitacion> empleadoCapacitaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir clave primaria para la entidad EmpleadoCapacitacion
            modelBuilder.Entity<EmpleadoCapacitacion>()
                .HasKey(ec => new { ec.EmpleadoId, ec.CapacitacionId });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Usuario 1",
                    UserName = "user1",
                    Password = "123",
                    FkRol = 1 // Aquí debes proporcionar el ID del rol correspondiente
                },
                new Usuario
                {
                    PkUsuario = 2,
                    Nombre = "Usuario 2",
                    UserName = "user2",
                    Password = "123",
                    FkRol = 2 // Aquí debes proporcionar el ID del rol correspondiente
                }
            // Agrega más usuarios si es necesario
            );

            modelBuilder.Entity<Rol>().HasData(
               new Rol
               {
                   PkRol = 1,
                   Nombre = "Administrador"
               },
               new Rol
               {
                   PkRol = 2,
                   Nombre = "UsuarioNormal"
               }
           // Agrega más roles si es necesario
           );
        }

    }
}

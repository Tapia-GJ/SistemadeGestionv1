using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using ProyectoGestion_Ta.Context;
using ProyectoGestion_Ta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Services
{
    public class EmpleadoServices
    {
        public List<Cargo> GetCargos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cargo> empleados = _context.Cargos.ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
        public void AddEmpleado(Empleado request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Empleado emple = new Empleado();
                        emple.Nombre = request.Nombre;
                        emple.ApellidoPaterno = request.ApellidoPaterno;
                        emple.ApellidoMaterno = request.ApellidoMaterno;
                        emple.FechaNacimiento = request.FechaNacimiento;
                        emple.Direccion = request.Direccion;
                        emple.Telefono = request.Telefono;
                        emple.Email = request.Email;
                        emple.Salario = request.Salario;
                        emple.CargoId = request.CargoId;

                        _context.Empleados.Add(emple);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public List<Empleado> ReadEmpleado()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Empleado> empleados = _context.Empleados.Include(x=>x.Cargos).ToList();
                    return empleados;
                }
            }
            catch (Exception f)
            {
                throw new Exception("Error: " + f.Message);
            }
        }

        public Empleado UpdateEmpleado(int PkEmpleado, Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(PkEmpleado);
                    if (empleado == null)
                    {
                        return empleado;
                    }
                    else
                    {
                        empleado.Nombre = request.Nombre;
                        empleado.ApellidoPaterno = request.ApellidoPaterno;
                        empleado.ApellidoMaterno = request.ApellidoMaterno;
                        empleado.FechaNacimiento = request.FechaNacimiento;
                        empleado.Direccion = request.Direccion;
                        empleado.Telefono = request.Telefono;
                        empleado.Email = request.Email;
                        empleado.Salario = request.Salario;
                        empleado.CargoId = request.CargoId;

                        _context.Empleados.Update(empleado);
                        _context.SaveChanges();

                        return empleado;
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception("Error: " + x.Message);
            }
        }

        public void DeleteEmpleado(int PKEmpleado)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var empleado = _context.Empleados.Find(PKEmpleado);
                    if (empleado != null)
                    {
                        _context.Empleados.Remove(empleado);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception d)
            {
                throw new Exception("Error: " + d.Message);
            }
        }
    }
}

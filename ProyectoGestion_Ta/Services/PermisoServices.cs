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
    public class PermisoServices
    {
        public List<Empleado> GetREmpleado()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Empleado> empleados = _context.Empleados.ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
        public void AddPermiso(Permiso request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Permiso res = new Permiso()
                        {
                            Motivo = request.Motivo,
                            FechaSoli = request.FechaSoli,
                            FechaIni = request.FechaIni,
                            FechaFin = request.FechaFin,
                            EmpleadoId = request.EmpleadoId,
                        };
                        _context.Permisos.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }

        }

        public List<Permiso> ReadPermisos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Permiso> permisos = new List<Permiso>();
                    permisos = _context.Permisos.Include(x => x.Empleados).ToList();
                    return permisos;
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }

        public Permiso Update(int id, Permiso request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Permiso permiso = _context.Permisos.Find(id);
                    if (permiso == null)
                    {
                        return permiso;
                    }
                    else
                    {
                        permiso.Motivo = request.Motivo;
                        permiso.FechaSoli = request.FechaSoli;
                        permiso.FechaIni = request.FechaIni;
                        permiso.FechaFin = request.FechaFin;
                        permiso.EmpleadoId = request.EmpleadoId;
                        _context.Permisos.Update(permiso);
                        _context.SaveChanges();
                        return permiso;
                    }
                }

            }
            catch (Exception x)
            {

                throw new Exception("error" + x.Message);
            }

        }

        public void Delete(int id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                    var permiso = _context.Permisos.Find(id);
                    _context.Permisos.Remove(permiso);
                    _context.SaveChanges();
                }
            }
            catch (Exception d)
            {

                throw new Exception("error" + d.Message);
            }
        }
    }
}

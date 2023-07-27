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

    public class EmpleadoCapacitacionServices
    {
        public List<EmpleadoCapacitacion> Read(int id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<EmpleadoCapacitacion> emplcapa = _context.empleadoCapacitaciones
                        .Include(y => y.Empleado)
                        .Where(x => x.CapacitacionId == id)
                        .ToList();
                    return emplcapa;
                }
            }
            catch (Exception f)
            {
                throw new Exception("Error: " + f.Message);
            }
        }

        //public void Delete(int id)
        //{
        //    try
        //    {
        //        using (var _context = new ApplicationDbContext())
        //        {

        //            var emplecapa = _context.empleadoCapacitaciones.Find(id);
        //            _context.empleadoCapacitaciones.Remove(emplecapa);
        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception d)
        //    {

        //        throw new Exception("error" + d.Message);
        //    }
        //}
        public void Delete(int capacitacionId, int empleadoId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var emplecapa = _context.empleadoCapacitaciones
                        .SingleOrDefault(x => x.CapacitacionId == capacitacionId && x.EmpleadoId == empleadoId);

                    if (emplecapa != null)
                    {
                        _context.empleadoCapacitaciones.Remove(emplecapa);
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

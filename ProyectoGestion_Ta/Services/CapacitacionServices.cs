using ProyectoGestion_Ta.Context;
using ProyectoGestion_Ta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Services
{
    public class CapacitacionServices
    {
        public void AddCapacitacion(Capacitacion request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Capacitacion res = new Capacitacion()
                        {
                            TipoCapacitacion = request.TipoCapacitacion,
                            FechaIni = request.FechaIni,
                            FechaFin = request.FechaFin,
                        };
                        _context.Capacitaciones.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }

        }

        public List<Capacitacion> ReadCapacitaciones()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Capacitacion> capacitacions = new List<Capacitacion>();
                    capacitacions = _context.Capacitaciones.ToList();
                    return capacitacions;
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }

        public Capacitacion Update(int id, Capacitacion request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Capacitacion capacitacion = _context.Capacitaciones.Find(id);
                    if (capacitacion == null)
                    {
                        return capacitacion;
                    }
                    else
                    {
                        capacitacion.TipoCapacitacion = request.TipoCapacitacion;
                        capacitacion.FechaIni = request.FechaIni;
                        capacitacion.FechaFin = request.FechaFin;
                        _context.Capacitaciones.Update(capacitacion);
                        _context.SaveChanges();
                        return capacitacion;
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

                    var capacitacion = _context.Capacitaciones.Find(id);
                    _context.Capacitaciones.Remove(capacitacion);
                    _context.SaveChanges();
                }
            }
            catch (Exception d)
            {

                throw new Exception("error" + d.Message);
            }
        }

        public List<Capacitacion> GetCapacitaciones()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Capacitacion> capacitacion = _context.Capacitaciones.ToList();
                    return capacitacion;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
    }
}

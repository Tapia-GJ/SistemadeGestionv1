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
    public class RolServices
    {
        public void AddRol(Rol request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Rol rols = new Rol()
                        {
                            Nombre = request.Nombre,
                        };
                        _context.Roles.Add(rols);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }
        public List<Rol> ReadRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> rols = new List<Rol>();
                    rols = _context.Roles.ToList();
                    return rols;
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }
        public Rol Update(int id, Rol request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Rol rols = _context.Roles.Find(id);
                    if (rols == null)
                    {
                        return rols;
                    }
                    else
                    {
                        rols.Nombre = request.Nombre;
                        _context.Roles.Update(rols);
                        _context.SaveChanges();
                        return rols;
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

                    var rols = _context.Roles.Find(id);
                    _context.Roles.Remove(rols);
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

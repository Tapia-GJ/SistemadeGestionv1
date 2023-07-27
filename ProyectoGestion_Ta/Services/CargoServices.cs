using ProyectoGestion_Ta.Context;
using ProyectoGestion_Ta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestion_Ta.Services
{
    public class CargoServices
    {
        public void AddCargo(Cargo request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Cargo cargo = new Cargo()
                        {
                            Nombre = request.Nombre,
                        };
                        _context.Cargos.Add(cargo);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }
        public List<Cargo> ReadCargos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cargo> cargo = new List<Cargo>();
                    cargo = _context.Cargos.ToList();
                    return cargo;
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }
        public Cargo Update(int id, Cargo request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cargo cargo = _context.Cargos.Find(id);
                    if (cargo == null)
                    {
                        return cargo;
                    }
                    else
                    {
                        cargo.Nombre = request.Nombre;
                        _context.Cargos.Update(cargo);
                        _context.SaveChanges();
                        return cargo;
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

                    var cargo = _context.Cargos.Find(id);
                    _context.Cargos.Remove(cargo);
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

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
    public class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario()
                        {
                            Nombre = request.Nombre,
                            UserName = request.UserName,
                            Password = request.Password,
                            FkRol = request.FkRol,
                        };
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }

        }

        public List<Usuario> ReadUsers()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();
                    usuarios = _context.Usuarios.Include(x => x.Roles).ToList();
                    return usuarios;
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }

        public Usuario Update(int id, Usuario request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario usuario = _context.Usuarios.Find(id);
                    if (usuario == null)
                    {
                        return usuario;
                    }
                    else
                    {
                        usuario.Nombre = request.Nombre;
                        usuario.UserName = request.UserName;
                        usuario.Password = request.Password;
                        usuario.FkRol = request.FkRol;
                        _context.Usuarios.Update(usuario);
                        _context.SaveChanges();
                        return usuario;
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

                    var usuario = _context.Usuarios.Find(id);
                    _context.Usuarios.Remove(usuario);
                    _context.SaveChanges();
                }
            }
            catch (Exception d)
            {

                throw new Exception("error" + d.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
        public Usuario Login(string username, string password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    // Buscar el usuario en la base de datos que coincida con el username y el password
                    var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x => x.UserName == username && x.Password == password);

                    // Verificar si se encontró el usuario
                    if (usuario == null || usuario.Password != password)
                    {
                        // Si no se encontró el usuario, devolver un usuario vacío o null
                        return null;
                    }

                    // Si se encontró el usuario y el password coincide, devolver el usuario
                    return usuario;
                }


            }
            catch (Exception f)
            {

                throw new Exception("error" + f.Message);
            }
        }
    }
}

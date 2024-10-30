using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarioBD : IRepositorioUsuario
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioUsuarioBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public void Add(Usuario obj)
        {
            obj.Validate();
            if (obj == null)
            {
                throw new ExcepcionesUsuario("No se encuentra el usuario");
            }
            if (FindByMail(obj.Email.Valor) != null)
            {
                throw new ExcepcionesUsuario("Este email ya está en uso");
            }
            Context.Usuarios.Add(obj);
            Context.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            if (obj != null)
            {
                obj.Validate();
                Context.Usuarios.Update(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesUsuario("Usuario no Encontrado");
            }
        }

        public Usuario FindById(int id)
        {
            return Context.Usuarios.Include(usu => usu.Rol).Where(usu => usu.Id == id).SingleOrDefault();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Context.Usuarios.Include(usu => usu.Rol).ToList();
        }

        public void Remove(int id)
        {
            Usuario user = Context.Usuarios.Find(id);
            if (user != null)
            {
                Context.Usuarios.Remove(user);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesUsuario("No se encuentra el usuario");
            }
        }

        public Usuario FindByMail(string mail)
        {
            if (mail != null)
            {
                return Context.Usuarios.Include(usu => usu.Rol).Where(usu => usu.Email.Valor == mail).SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesUsuario("Email no encontrado");
            }
        }
    }
}

using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaDatos.Repositorios
{
    public class RepositorioRolesBD : IRepositorioRoles
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioRolesBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public void Add(Rol obj)
        {
            if (obj == null)
            {
                throw new ExcepcionesRol("No se encuentra el rol");
            }
            if (FindByName(obj.Nombre) != null)
            {
                throw new ExcepcionesRol("Este nombre ya está en uso");
            }
            Context.Roles.Add(obj);
            Context.SaveChanges();
        }

        public IEnumerable<Rol> FindAll()
        {
            return Context.Roles.ToList();
        }

        public Rol FindById(int id)
        {
            if (id != null)
            {
                return Context.Roles.Find(id);
            }
            throw new ExcepcionesRol("Rol nulo");
        }

        public void Remove(int id)
        {
            Rol rol = Context.Roles.Find(id);
            if (rol != null)
            {
                Context.Roles.Remove(rol);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesRol("No se encuentra el Rol");
            }
        }

        public void Update(Rol obj)
        {
            Rol rol = FindByName(obj.Nombre);
            if (rol == null)
            {
                Context.Roles.Update(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Rol no encontrado.");
            }
        }

        public Rol FindByName(string name)
        {
            if (name != null)
            {
                return Context.Roles.Where(rol => rol.Nombre == name).SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesRol("Nombre de Rol no encontrado");
            }
        }
    }
}

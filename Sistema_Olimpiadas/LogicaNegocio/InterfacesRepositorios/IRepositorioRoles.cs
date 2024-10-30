using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioRoles : IRepositorio<Rol>
    {
        Rol FindByName(string name);
    }
}

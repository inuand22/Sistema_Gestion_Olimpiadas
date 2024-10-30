using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDelegado
    {
        IEnumerable<Delegado> FindAll();
        Delegado FindById(int id);
    }
}

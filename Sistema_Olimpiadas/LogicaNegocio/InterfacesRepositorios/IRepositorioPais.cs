using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPais
    {
        Pais FindByName(string name);
        IEnumerable<Pais> FindAll();
        Pais FindById(int id);
    }
}

using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        Evento FindByName(string nombreEvento);
        IEnumerable<Evento> GetEventosPorFecha(DateTime fecha);
    }
}

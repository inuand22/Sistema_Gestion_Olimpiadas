using DTO;
using LogicaNegocio.EntidadesDominio;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoEventos
    {
        IEnumerable<ListadoEventosDTO> GetEventosPorFecha(DateTime fecha);
    }
}

using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoEventos : IListadoEventos
    {
        public IRepositorioEvento RepositorioEvento { get; set; }
        public IRepositorioAtleta RepositorioAtleta { get; set; }
        public IRepositorioDisciplina RepositorioDisciplina { get; set; }

        public ListadoEventos(IRepositorioEvento repositorioEvento,
            IRepositorioAtleta repositorioAtleta, IRepositorioDisciplina repositorioDisciplina)
        {
            RepositorioEvento = repositorioEvento;
            RepositorioAtleta = repositorioAtleta;
            RepositorioDisciplina = repositorioDisciplina;
        }

        public IEnumerable<ListadoEventosDTO> GetEventosPorFecha(DateTime fecha)
        {
            IEnumerable<Evento> eventos = RepositorioEvento.GetEventosPorFecha(fecha);
            var eventosDTO = MappersEventos.ToDTOs(eventos.ToList());
            return eventosDTO;
        }
    }
}

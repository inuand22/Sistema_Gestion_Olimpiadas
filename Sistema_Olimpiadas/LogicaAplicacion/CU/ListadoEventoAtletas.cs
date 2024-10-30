using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class ListadoEventoAtletas : IListadoEventosAtletas
    {
        public IRepositorioEventoAtleta RepositorioEventoAtleta { get; set; }
        public ListadoEventoAtletas(IRepositorioEventoAtleta repositorioEventoAtleta)
        {
            RepositorioEventoAtleta = repositorioEventoAtleta;
        }

        public IEnumerable<ListadoEventoAtletaDTO> GetAtletasPorEvento(int idEvento)
        {
            IEnumerable<EventoAtleta> eventoAtletas = new List<EventoAtleta>();
            eventoAtletas = RepositorioEventoAtleta.ObtenerAtletasPorEvento(idEvento);
            return MappersEventoAtleta.ToDTOs(eventoAtletas);
        }

        public IEnumerable<ListadoEventoAtletaDTO> GetEventosPorAtleta(int idAtleta)
        {
            IEnumerable<EventoAtleta> EventosPorAtleta = new List<EventoAtleta>();
            EventosPorAtleta = RepositorioEventoAtleta.ObtenerEventosPorAtleta(idAtleta);
            return MappersEventoAtleta.ToDTOs(EventosPorAtleta);
        }
    }
}

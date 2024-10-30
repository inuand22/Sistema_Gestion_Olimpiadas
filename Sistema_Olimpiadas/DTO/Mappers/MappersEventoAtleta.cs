using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class MappersEventoAtleta
    {
        public static EventoAtleta FromDTO(AltaEventoAtletaPuntajeDTO dto)
        {
            if (dto != null)
            {
                EventoAtleta eventoAtleta = new EventoAtleta
                {
                    Id = dto.Id,
                    Atleta = null,
                    PuntajeAtleta = dto.Puntaje,
                    Evento = null
                };
                return eventoAtleta;
            }
            return null;
        }

        public static ListadoEventoAtletaDTO ToDTO(EventoAtleta eventoAtleta)
        {
            if (eventoAtleta != null)
            {
                ListadoEventoAtletaDTO dto = new ListadoEventoAtletaDTO
                {
                    Id = eventoAtleta.Id,
                    IdAtleta = eventoAtleta.Atleta.Id,
                    NombreAtleta = eventoAtleta.Atleta.Nombre,
                    IdEvento = eventoAtleta.Evento.Id,
                    NombreEvento = eventoAtleta.Evento.NombreEvento.Valor,
                    PuntajeAtleta = eventoAtleta.PuntajeAtleta,
                    FechaEvento = eventoAtleta.Evento.FechaFinal
                };
                return dto;
            }
            return null;
        }

        public static IEnumerable<ListadoEventoAtletaDTO> ToDTOs(IEnumerable<EventoAtleta> eventosAtletas)
        {
            List<ListadoEventoAtletaDTO> dto = new List<ListadoEventoAtletaDTO>();

            foreach (EventoAtleta item in eventosAtletas)
            {
                dto.Add(ToDTO(item));
            }
            return dto;
        }
    }
}


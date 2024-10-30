using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;

namespace DTO.Mappers
{
    public class MappersEventos
    {
        public static Evento FromDTO(AltaEventoDTO dto)
        {
            if (dto != null)
            {
                NombreEvento nombreEvento = new NombreEvento(dto.NombreEvento);
                Evento evento = new Evento(nombreEvento, dto.IdDisciplina, dto.FechaInicioEvento, dto.FechaFinalEvento, dto.IdsAtletas)
                {
                    Id = dto.IdEvento
                };
                evento.IdDisciplina = dto.IdDisciplina;
                return evento;
            }
            return null;
        }

        public static ListadoEventosDTO ToDTO(Evento evento)
        {
            if (evento == null) return null;

            ListadoEventosDTO dto = new ListadoEventosDTO
            {
                IdEvento = evento.Id,
                NombreEvento = evento.NombreEvento.Valor,
                NombreDisciplina = evento.Disciplina.Nombre.Valor,
                FechaInicio = evento.FechaInicio,
                FechaFinal = evento.FechaFinal
            };
            return dto;
        }

        public static IEnumerable<ListadoEventosDTO> ToDTOs(List<Evento> eventos)
        {
            List<ListadoEventosDTO> dto = new List<ListadoEventosDTO>();
            foreach (Evento evento in eventos)
            {
                dto.Add(ToDTO(evento));
            }
            return dto;
        }
    }
}

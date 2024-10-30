using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class AltaEvento : IAltaEvento
    {
        public IRepositorioEvento Repositorio { get; set; }
        public IRepositorioDisciplina RepositorioDisciplina { get; set; }
        public IRepositorioAtleta RepositorioAtleta { get; set; }

        public AltaEvento(IRepositorioEvento repositorio, IRepositorioDisciplina repositorioDisciplina,
            IRepositorioAtleta repositorioAtleta)
        {
            Repositorio = repositorio;
            RepositorioDisciplina = repositorioDisciplina;
            RepositorioAtleta = repositorioAtleta;
        }

        public void AltaEve(AltaEventoDTO dto)
        {
            if (Repositorio.FindByName(dto.NombreEvento) != null)
            {
                throw new ExcepcionesEvento("Ya existe un evento con el mismo nombre.");
            }

            Evento evento = MappersEventos.FromDTO(dto);
            Disciplina disciplina = RepositorioDisciplina.FindById(evento.IdDisciplina);

            if (disciplina == null)
            {
                throw new ExcepcionesEvento("La disciplina seleccionada no existe.");
            }

            evento.Disciplina = disciplina;

            if (dto.IdsAtletas.Count < 3)
            {
                throw new ExcepcionesEvento("Se requiere un mínimo de tres atletas para registrar un evento.");
            }

            List<EventoAtleta> EventoAtletas = new List<EventoAtleta>();

            foreach (int atletaId in dto.IdsAtletas)
            {
                Atleta atleta = RepositorioAtleta.FindById(atletaId);

                if (atleta == null)
                {
                    throw new ExcepcionesEvento($"El atleta con ID {atletaId} no está registrado en el sistema.");
                }

                if (!atleta.Disciplinas.Any(d => d.Id == evento.Disciplina.Id))
                {
                    throw new ExcepcionesEvento($"El atleta con ID {atletaId} no está registrado para la disciplina del evento.");
                }

                EventoAtleta eventoAtleta = new EventoAtleta
                {
                    Atleta = atleta,
                    Evento = null
                };

                EventoAtletas.Add(eventoAtleta);
            }

            evento.EventosAtletas = EventoAtletas;

            Repositorio.Add(evento);
        }
    }
}
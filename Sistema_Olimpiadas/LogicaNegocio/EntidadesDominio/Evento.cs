using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.EntidadesDominio
{
    public class Evento : IValidable
    {
        public int Id { get; set; }
        public NombreEvento NombreEvento { get; set; }
        public Disciplina Disciplina { get; set; }

        [NotMapped]
        public int IdDisciplina { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public List<EventoAtleta> EventosAtletas { get; set; }

        [NotMapped]
        public List<int> IdsEventosAtletas { get; set; }

        protected Evento() { }

        public Evento(NombreEvento nombreEvento, int idDisciplina, DateTime fechaInicio, DateTime fechaFinal, List<int> idsEventosAtletas)
        {
            NombreEvento = nombreEvento;
            IdDisciplina = idDisciplina;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            IdsEventosAtletas = idsEventosAtletas;
            Validate();
        }

        public void Validate()
        {
            if (FechaInicio > FechaFinal)
            {
                throw new ExcepcionesEvento("La fecha de inicio no puede ser mayor a la fecha final.");
            }

            if (FechaInicio.Year != 2024 || FechaFinal.Year != 2024)
            {
                throw new ExcepcionesEvento("Los años de las fechas deben ser 2024.");
            }
        }
    }
}

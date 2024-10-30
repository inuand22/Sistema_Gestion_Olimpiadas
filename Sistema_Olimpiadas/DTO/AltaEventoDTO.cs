using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class AltaEventoDTO
    {
        [Display(Name = "Id")]
        public int IdEvento { get; set; }

        [Required]
        [Display(Name = "Nombre del Evento")]
        public string NombreEvento { get; set; }

        [Required]
        [Display(Name = "Disciplina")]
        public int IdDisciplina { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicioEvento { get; set; }

        [Required]
        [Display(Name = "Fecha de Finalización")]
        public DateTime FechaFinalEvento { get; set; }

        [Required]
        [Display(Name = "Atletas Participantes")]
        public List<int> IdsAtletas { get; set; } = new List<int>();
    }
}


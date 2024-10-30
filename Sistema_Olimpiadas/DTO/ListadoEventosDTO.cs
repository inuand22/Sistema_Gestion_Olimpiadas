using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ListadoEventosDTO
    {
        [Display(Name = "Id Evento")]
        public int IdEvento { get; set; } 

        [Display(Name = "Nombre Evento")]
        public string NombreEvento { get; set; }

        [Display(Name = "Nombre Disciplina")]
        public string NombreDisciplina { get; set; }

        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Final")]
        public DateTime FechaFinal { get; set; }
    }
}

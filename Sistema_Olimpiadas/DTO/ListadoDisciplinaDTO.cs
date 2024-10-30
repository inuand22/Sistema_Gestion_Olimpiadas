using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ListadoDisciplinaDTO
    {
        [Required]
        [Display(Name = "Id")]
        public int IdDisciplina { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreDisciplina { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int AnioDisciplina { get; set; }
    }
}

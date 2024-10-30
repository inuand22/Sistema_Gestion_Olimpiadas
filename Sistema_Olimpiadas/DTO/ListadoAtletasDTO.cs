using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ListadoAtletasDTO
    {
        [Display(Name = "Id")]
        public int IdAtleta { get; set; }

        [Display(Name = "Nombre")]
        public string NombreAtleta { get; set; }

        [Display(Name = "Apellido")]
        public string ApellidoAtleta { get; set; }

        [Display(Name = "Sexo")]
        public bool SexoAtleta { get; set; }

        [Display(Name = "Nombre-Pais")]
        public string NombrePais { get; set; }

        public List<int> IdDisciplinas { get; set; }
        public int IdDisciplina { get; set; }
    }
}

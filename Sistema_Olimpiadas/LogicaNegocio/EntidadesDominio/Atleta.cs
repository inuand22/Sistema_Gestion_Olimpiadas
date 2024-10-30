using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.EntidadesDominio
{
    [Table("Atletas")]
    public class Atleta
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public bool EsMasculino { get; set; }

        [Required]
        public Pais Pais { get; set; }

        [Required]
        public List<Disciplina> Disciplinas { get; set; }

        [NotMapped]
        public List<int> IdDisciplinas { get; set; }

        [NotMapped]
        public int IdDisciplina { get; set; }

        public List<EventoAtleta>? EventosAtletas {  get; set; }

        [NotMapped]
        public List<int>? IdsEventosAtletas { get; set; }
    }
}


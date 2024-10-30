using DTO;

namespace Presentacion.Models
{
    public class AtletaDisciplinasViewModel
    {
        public ListadoAtletasDTO DTOAtleta { get; set; }
        public IEnumerable<ListadoDisciplinaDTO> DTODisciplinasDisponibles { get; set; }
        public IEnumerable<ListadoDisciplinaDTO> DTODisciplinasRegistradas { get; set; }
    }
}

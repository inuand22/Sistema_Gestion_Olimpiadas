using DTO;

namespace Presentacion.Models
{
    public class AltaEventoViewModel
    {
        public AltaEventoDTO DTOAltaEvento { get; set; }
        public IEnumerable<ListadoAtletasDTO> DTOAtleta { get; set; }
        public IEnumerable<ListadoDisciplinaDTO> DTODisciplinas { get; set; }
    }
}

using DTO;
using LogicaNegocio.EntidadesDominio;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoDisciplina
    {
        Disciplina FindById(int idDisciplina);
        IEnumerable<ListadoDisciplinaDTO> GetDisciplinas();
        IEnumerable<ListadoDisciplinaDTO> GetDisciplinasDisponibles(int idAtleta);
        IEnumerable<ListadoDisciplinaDTO> GetDisciplinasRegistradas(int idAtleta);
    }
}

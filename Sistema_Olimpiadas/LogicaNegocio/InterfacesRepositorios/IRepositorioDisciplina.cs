using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina
    {
        List<Disciplina> FindAllDisciplinasById(List<int> ids);
        Disciplina Add(Disciplina obj);
        IEnumerable<Disciplina> FindAll();
        List<Disciplina> FindAllByAtletaId(int idAtleta);
        Disciplina FindById(int idDisciplina);
    }    
}

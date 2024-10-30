using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAtleta
    {
        Atleta FindById(int id);
        IEnumerable<Atleta> FindAll();
        void Update(int atletaId, int idDisciplina);
        IEnumerable<Disciplina> FindAllDisponible(int idAtleta);
        IEnumerable<Disciplina> FindAllRegistrada(int idAtleta);
   
    }
}

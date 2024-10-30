using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.EntidadesDominio
{
    public class Disciplina
    {
        public int Id { get; set; }
        public NombreDisciplina Nombre { get; set; }
        public AnioDisciplina AnioDisciplina { get; set; }
        public List<Atleta> Atletas { get; set; }
    }
}

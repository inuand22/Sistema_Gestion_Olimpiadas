using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaDatos.Repositorios
{
    public class RepositorioDisciplinaBD : IRepositorioDisciplina
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioDisciplinaBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public Disciplina Add(Disciplina obj)
        {
            if (obj != null)
            {
                if (FindByName(obj.Nombre.Valor) == null)
                {
                    Context.Disciplinas.Add(obj);
                    Context.SaveChanges();
                    return obj;
                }
                else
                {
                    throw new ExcepcionesDisciplina("Disciplina ya existente");
                }
            }
            else
            {
                throw new ExcepcionesDisciplina("No se encuentra la disciplina");
            }
        }

        public IEnumerable<Disciplina> FindAll()
        {
            return Context.Disciplinas.
                OrderBy(d => d.Nombre.Valor).
                ToList();
        }

        public List<Disciplina> FindAllDisciplinasById(List<int> ids)
        {
            return Context.Disciplinas.Where(disci => ids.Contains(disci.Id)).ToList();
        }

        public Disciplina FindById(int id)
        {
            return Context.Disciplinas.
                Where(disci => disci.Id == id).
                SingleOrDefault();
        }

        public Disciplina FindByName(string name)
        {
            if (name != null)
            {
                return Context.Disciplinas.Where(disc => disc.Nombre.Valor == name).SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesDisciplina("Nombre de disciplina no encontrado");
            }
        }

        public List<Disciplina> FindAllByAtletaId(int atletaId)
        {
            return Context.Disciplinas
                .Where(disci => disci.Atletas.Any(atle => atle.Id == atletaId))
                .ToList();
        }
    }
}

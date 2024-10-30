using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaDatos.Repositorios
{
    public class RepositorioDelegadoBD : IRepositorioDelegado
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioDelegadoBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public IEnumerable<Delegado> FindAll()
        {
            return Context.Delegados.ToList();
        }

        public Delegado FindById(int id)
        {
            return Context.Delegados.
                Where(dele => dele.Id == id).
                SingleOrDefault();
        }

        public Delegado FindByName(string nombre)
        {
            return Context.Delegados.
                Where(dele => dele.Nombre == nombre).
                SingleOrDefault();
        }
    }
}


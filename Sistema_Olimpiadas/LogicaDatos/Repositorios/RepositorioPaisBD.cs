using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPaisBD : IRepositorioPais
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioPaisBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public IEnumerable<Pais> FindAll()
        {
            return Context.Paises.ToList();
        }

        public Pais FindById(int id)
        {
            return Context.Paises.Include(pais => pais.Delegado).
                Where(pais => pais.Id == id).
                SingleOrDefault();
        }

        public Pais FindByName(string nombre)
        {
            return Context.Paises.Include(pais => pais.Delegado).
                Where(pais => pais.Nombre == nombre).
                SingleOrDefault();
        }
    }
}

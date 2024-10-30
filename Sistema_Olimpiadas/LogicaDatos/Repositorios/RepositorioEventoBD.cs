using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Repositorios
{
    public class RepositorioEventoBD : IRepositorioEvento
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioEventoBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public void Add(Evento obj)
        {
            obj.Validate();
            if (obj != null)
            {
                Context.Eventos.Add(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No se encuentra el evento");
            }
        }

        public void Update(Evento obj)
        {
            if (obj != null)
            {
                Context.Eventos.Update(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No se encuentra el evento");
            }
        }

        public Evento FindById(int id)
        {
            var evento = Context.Eventos
                .Include(eve => eve.Disciplina)
                .SingleOrDefault(eve => eve.Id == id);

            if (evento == null)
            {
                throw new ExcepcionesEvento("Evento no encontrado.");
            }

            return evento;
        }

        public IEnumerable<Evento> FindAll()
        {
            return Context.Eventos
                .Include(eve => eve.Disciplina)
                .Include(eve => eve.EventosAtletas)
                .ToList();
        }

        public void Remove(int id)
        {
            var eve = Context.Eventos.Find(id);
            if (eve != null)
            {
                Context.Eventos.Remove(eve);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No se encuentra el evento");
            }
        }

        public IEnumerable<Evento> GetEventosPorFecha(DateTime fecha)
        {
            return Context.Eventos
                    .Where(eve => eve.FechaFinal == fecha)
                    .Include(eve => eve.Disciplina)
                    .Include(eve => eve.EventosAtletas)
                    .ToList();
        }

        public Evento FindByName(string nombreEvento)
        {
            if (nombreEvento != null)
            {
                return Context.Eventos
                    .Include(eve => eve.Disciplina)
                    .Where(eve => eve.NombreEvento.Valor == nombreEvento)
                    .SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesEvento("Nombre no encontrado");
            }
        }
    }
}


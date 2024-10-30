using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    using ExcepcionesPropias;
    using LogicaNegocio.EntidadesDominio;
    using LogicaNegocio.InterfacesRepositorios;
    using Microsoft.EntityFrameworkCore;

    namespace LogicaDatos.Repositorios
    {
        public class RepositorioEventoAtletaBD : IRepositorioEventoAtleta
        {
            public OlimpiadasContext Context { get; set; }

            public RepositorioEventoAtletaBD(OlimpiadasContext context)
            {
                Context = context;
            }

            public void Add(EventoAtleta obj)
            {
                Context.EventoAtleta.Add(obj);
                Context.SaveChanges();
            }

            public void Update(EventoAtleta obj)
            {
                var Existe = Context.EventoAtleta
                    .FirstOrDefault(eveatl => eveatl.Id == obj.Id);
                if (Existe != null)
                {
                    Context.Entry(Existe).State = EntityState.Detached;
                }
                Context.EventoAtleta.Update(obj);
                Context.SaveChanges();
            }

            public EventoAtleta FindById(int id)
            {
                return Context.EventoAtleta.Find(id);
            }

            public IEnumerable<EventoAtleta> FindAll()
            {
                return Context.EventoAtleta.ToList();
            }

            public void Remove(int id)
            {
                var eventoAtleta = FindById(id);
                if (eventoAtleta != null)
                {
                    Context.EventoAtleta.Remove(eventoAtleta);
                    Context.SaveChanges();
                }
            }

            public IEnumerable<EventoAtleta> ObtenerAtletasPorEvento(int idEvento)
            {
                return Context.EventoAtleta
                    .Where(eve => eve.Evento.Id == idEvento)
                    .Include(eve => eve.Atleta)
                    .Include(eve => eve.Evento)
                    .ToList();
            }

            public int FindIdByAtletaEvento(int idEvento, int idAtleta)
            {
                var eventoAtleta = Context.EventoAtleta
                    .FirstOrDefault(eveatl => eveatl.Evento.Id == idEvento && eveatl.Atleta.Id == idAtleta);

                if (eventoAtleta != null)
                {
                    return eventoAtleta.Id;
                }

                throw new ExcepcionesEvento("No se encontró la relación entre el atleta y el evento.");
            }

            public IEnumerable<EventoAtleta> ObtenerEventosPorAtleta(int idAtleta)
            {
                return Context.EventoAtleta
                    .Where(eveatl => eveatl.Atleta.Id == idAtleta)
                    .Include(eveatl => eveatl.Evento)
                    .Include(eveatl => eveatl.Evento.Disciplina)
                    .Include(eveatl => eveatl.Atleta)
                    .OrderBy(eveatl => eveatl.Evento.Disciplina.Nombre.Valor)
                    .ToList();
            }
        }
    }
}




using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Repositorios
{
    public class OlimpiadasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Delegado> Delegados { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<EventoAtleta> EventoAtleta { get; set; }

        public OlimpiadasContext(DbContextOptions options) : base(options)
        {
        }
    }
}
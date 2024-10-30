using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaDatos.Repositorios.LogicaDatos.Repositorios;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();


            //USUARIO
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
            builder.Services.AddScoped<IListadoRoles, ListadoRoles>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioBD>();
            builder.Services.AddScoped<IRepositorioRoles, RepositorioRolesBD>();
            builder.Services.AddScoped<IBajaUsuario, BajaUsuario>();
            builder.Services.AddScoped<IUpdateUsuario, UpdateUsuario>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
            builder.Services.AddScoped<IBuscarUsuarioPorID, BuscarUsuarioPorId>();


            //ATLETA
            builder.Services.AddScoped<IAltaAtleta, AltaAtleta>();
            builder.Services.AddScoped<IListadoAtletas, ListadoAtletas>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtletaBD>();


            //EVENTO
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEventoBD>();
            builder.Services.AddScoped<IAltaEvento, AltaEvento>();
            builder.Services.AddScoped<IListadoEventos, ListadoEventos>();

            //EVENTO ATLETA
            builder.Services.AddScoped<IRepositorioEventoAtleta, RepositorioEventoAtletaBD>();
            builder.Services.AddScoped<IListadoEventosAtletas, ListadoEventoAtletas>();
            builder.Services.AddScoped<IAltaEventoAtletaPuntaje, AltaEventoPuntaje>();

            //DISCIPLINA
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaBD>();
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IListadoDisciplina, ListadoDisciplina>();


            // CONF DE LA BASE DE DATOS
            string strCon = builder.Configuration.GetConnectionString("MiConexion");
            builder.Services.AddDbContext<OlimpiadasContext>(options => options.UseSqlServer(strCon));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
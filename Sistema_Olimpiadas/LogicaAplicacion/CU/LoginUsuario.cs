using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public LoginUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public Usuario FindByMail(string email)
        {
            if (email != null)
            {
                Usuario user = RepositorioUsuario.FindByMail(email);
                return user;
            }
            else
            {
                throw new ExcepcionesUsuario("Email y/o Contraseña no pueden ser vacíos");
            }
        }
    }
}

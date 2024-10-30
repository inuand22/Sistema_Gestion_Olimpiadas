using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class BajaUsuario : IBajaUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public BajaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void BajaUser(string email)
        {
            if (email != null)
            {
                Usuario user = RepositorioUsuario.FindByMail(email);
                if (user != null)
                {
                    RepositorioUsuario.Remove(user.Id);
                }
                else
                {
                    throw new ExcepcionesUsuario("Usuario no encontrado");
                }
            }
            else
            {
                throw new ExcepcionesUsuario("Email no puede ser nulo");
            }
        }
    }
}

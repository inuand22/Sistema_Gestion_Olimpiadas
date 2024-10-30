using LogicaNegocio.EntidadesDominio;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ILoginUsuario
    {
        Usuario FindByMail(string email);
    }
}

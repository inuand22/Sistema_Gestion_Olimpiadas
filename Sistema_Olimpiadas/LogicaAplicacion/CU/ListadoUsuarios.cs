using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuario Repositorio { get; set; }

        public ListadoUsuarios(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }

        public IEnumerable<ListadoUsuariosDTO> ObtenerListado()
        {
            IEnumerable<Usuario> usuarios = Repositorio.FindAll();
            return MappersUsuario.FromUsuarios(usuarios);
        }
    }
}

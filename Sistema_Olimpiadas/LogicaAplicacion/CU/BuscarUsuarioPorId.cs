using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class BuscarUsuarioPorId : IBuscarUsuarioPorID
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public BuscarUsuarioPorId(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }
        public AltaUsuarioDTO BuscarUsuarioId(int id)
        {
            return MappersUsuario.ToDTO(RepositorioUsuario.FindById(id));
        }
    }
}

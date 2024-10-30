using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class UpdateUsuario : IUpdateUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public UpdateUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void UpdateUser(AltaUsuarioDTO dto)
        {
            if (dto != null)
            {
                RepositorioUsuario.Update(MappersUsuario.FromDTO(dto));
            }
            else
            {
                throw new ExcepcionesUsuario("Usuario no encontrado");
            }
        }
    }
}

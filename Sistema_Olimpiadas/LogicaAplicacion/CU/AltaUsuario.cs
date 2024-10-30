using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class AltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario Repositorio { get; set; }
        public IRepositorioRoles RepositorioRoles { get; set; }

        public AltaUsuario(IRepositorioUsuario repositorio, IRepositorioRoles repositorioRoles)
        {
            Repositorio = repositorio;
            RepositorioRoles = repositorioRoles;
        }

        public void Alta(AltaUsuarioDTO dto)
        {
            Usuario usuario = MappersUsuario.FromDTO(dto);
            Rol rol = RepositorioRoles.FindById(usuario.RolId);
            if (rol == null)
            {
                throw new ExcepcionesUsuario("El rol que usted selecciono no existe");
            }
            usuario.Rol = rol;
            Repositorio.Add(usuario);
        }
    }
}


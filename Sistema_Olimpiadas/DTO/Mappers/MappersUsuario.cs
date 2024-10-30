using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;

namespace DTO.Mappers
{
    public class MappersUsuario
    {
        public static Usuario FromDTO(AltaUsuarioDTO dto)
        {
            if (dto != null)
            {
                EmailUsuario email = new EmailUsuario(dto.EmailUsuario);
                ContraseniaUsuario contrasenia = new ContraseniaUsuario(dto.ContraseniaUsuario);
                Rol rol = new Rol
                {
                    Id = dto.IdRol,
                    Nombre = dto.NombreRol
                };
                Usuario usu = new Usuario(email, contrasenia, null, dto.Date, dto.Hora, dto.EmailAdmin);
                usu.RolId = dto.IdRol;
                usu.Id = dto.IdUser;
                return usu;
            }
            return null;
        }

        public static AltaUsuarioDTO ToDTO(Usuario usuario)
        {
            AltaUsuarioDTO dto = new AltaUsuarioDTO
            {
                EmailUsuario = usuario.Email.Valor,
                ContraseniaUsuario = usuario.Contrasenia.Valor,
                IdRol = usuario.Rol.Id,
                IdUser = usuario.Id,
                NombreRol = usuario.Rol.Nombre,
                Date = usuario.Date,
                Hora = usuario.Hour,
                EmailAdmin = usuario.EmailAdmin
            };
            return dto;
        }

        public static ListadoUsuariosDTO FromUsuario(Usuario usuario)
        {
            ListadoUsuariosDTO dto = new ListadoUsuariosDTO()
            {
                EmailUsuario = usuario.Email.Valor,
                NombreRol = usuario.Rol.Nombre,
                IdUser = usuario.Id,
                Date = usuario.Date,
                Hora = usuario.Hour,
                EmailAdmin = usuario.EmailAdmin
            };
            return dto;
        }

        public static IEnumerable<ListadoUsuariosDTO> FromUsuarios(IEnumerable<Usuario> usuarios)
        {
            List<ListadoUsuariosDTO> dtos = new List<ListadoUsuariosDTO>();

            foreach (Usuario usu in usuarios)
            {
                dtos.Add(FromUsuario(usu));
            }
            return dtos;
        }
    }
}

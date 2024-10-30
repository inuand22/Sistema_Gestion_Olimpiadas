using LogicaNegocio.EntidadesDominio;

namespace DTO.Mappers
{
    public class MappersRol
    {
        public static RolDTO ToDTO(Rol rol)
        {
            RolDTO dto = new RolDTO
            {
                IdRol = rol.Id,
                NombreRol = rol.Nombre
            };
            return dto;
        }

        public static IEnumerable<RolDTO> FromRoles(IEnumerable<Rol> roles)
        {
            List<RolDTO> dtos = new List<RolDTO>();
            foreach (Rol role in roles)
            {
                dtos.Add(ToDTO(role));
            }
            return dtos;
        }
    }
}
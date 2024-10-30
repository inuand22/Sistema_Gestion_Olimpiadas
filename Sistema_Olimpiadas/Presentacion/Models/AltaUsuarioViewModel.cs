using DTO;

namespace Presentacion.Models
{
    public class AltaUsuarioViewModel
    {
        public AltaUsuarioDTO DTOAltaUsuario { get; set; }
        public IEnumerable<RolDTO> RolesDTO { get; set; }
    }
}

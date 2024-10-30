using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class RolDTO
    {
        [Display(Name = "Nombre Rol")]
        public string NombreRol { get; set; }
        [Display(Name = "IdRol")]
        public int IdRol { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class LoginUsuarioDTO
    {
        [Required]
        [Display(Name = "Email")]
        public string EmailUsuario { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string ContraseniaUsuario { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
    }
}

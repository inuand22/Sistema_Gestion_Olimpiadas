using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class AltaUsuarioDTO
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

        public int IdUser { get; set; }
        public string? NombreRol { get; set; }
        public string? Date { get; set; }
        public string? Hora { get; set; }
        public string? EmailAdmin { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ListadoUsuariosDTO
    {
        [Display(Name = "Email")]
        public string EmailUsuario { get; set; }


        [Display(Name = "Rol")]
        public string NombreRol { get; set; }

        [Display(Name = "ID-Usuario")]
        public int IdUser { get; set; }

        [Display(Name = "Fecha")]
        public string Date { get; set; }

        [Display(Name = "Hora")]
        public string Hora { get; set; }

        [Display(Name = "Admin-Email")]
        public string EmailAdmin { get; set; }
    }
}

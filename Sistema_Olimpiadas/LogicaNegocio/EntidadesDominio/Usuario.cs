using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LogicaNegocio.EntidadesDominio
{
    [Table("Usuarios")]
    public class Usuario : IValidable
    {
        public int Id { get; set; }

        [Required]
        public EmailUsuario Email { get; set; } // VO

        [Required]
        [MinLength(6, ErrorMessage = "La Contraseña debe tener al menos 6 caracteres.")]
        [Display(Name = "Contraseña")]
        public ContraseniaUsuario Contrasenia { get; set; } // VO

        [Required] //CAMBIO 27-9-10:37
        public Rol Rol { get; set; } // ED

        public int RolId { get; set; }
        public string? Date { get; set; }
        public string? Hour { get; set; }
        public string? EmailAdmin { get; set; }

        public Usuario(EmailUsuario email, ContraseniaUsuario contrasenia, Rol rol, string? date, string? hour, string? emailAdmin)
        {
            Email = email;
            Contrasenia = contrasenia;
            Rol = rol;
            Date = date;
            Hour = hour;
            EmailAdmin = emailAdmin;
            Validate();
        }

        protected Usuario() { }

        public void Validate()
        {
            if (Email == null) throw new ExcepcionesUsuario("El email es Obligatorio");

            if (Contrasenia == null) throw new ExcepcionesUsuario("La contraseña es obligatoria");
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.EntidadesDominio
{
    [Owned]
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}

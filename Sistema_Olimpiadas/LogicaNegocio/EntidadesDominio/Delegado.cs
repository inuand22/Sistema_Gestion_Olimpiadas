using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.EntidadesDominio
{
    [Owned]
    public class Delegado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
    }
}

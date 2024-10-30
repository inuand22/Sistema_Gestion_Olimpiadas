using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.EntidadesDominio
{
    [Owned]
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadHabitantes { get; set; }
        public Delegado Delegado { get; set; }
    }
}

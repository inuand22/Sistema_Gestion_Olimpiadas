using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreEvento : IEquatable<NombreEvento>
    {
        public string Valor { get; private set; }

        protected NombreEvento() { }

        public NombreEvento(string valor)
        {
            Valor = valor;
            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Valor))
            {
                throw new ExcepcionesEvento("El nombre no puede ser vacío o estar compuesto solo por espacios en blanco");
            }

            if (Valor.Length < 3)
            {
                throw new ExcepcionesEvento("El nombre debe tener al menos 3 caracteres");
            }

            if (Valor.Length > 100)
            {
                throw new ExcepcionesEvento("El nombre no puede exceder los 100 caracteres");
            }
        }

        public bool Equals(NombreEvento? other)
        {
            if (other != null)
            {
                return Valor == other.Valor;
            }
            return false;
        }
    }
}

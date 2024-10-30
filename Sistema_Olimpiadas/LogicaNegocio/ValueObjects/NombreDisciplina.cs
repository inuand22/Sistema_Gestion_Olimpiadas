using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreDisciplina : IEquatable<NombreDisciplina>
    {
        public string Valor { get; private set; }

        protected NombreDisciplina() { }

        public NombreDisciplina(string valor)
        {
            Valor = valor;
            Validate();
        }

        public void Validate()
        {
            if (Valor == "" || Valor == null || string.IsNullOrEmpty(Valor))
            {
                throw new ExcepcionesDisciplina("El nombre no puede ser vacío");
            }
            if (Valor.Length < 10 || Valor.Length > 50)
            {
                throw new ExcepcionesDisciplina("El largo del nombre no puede ser menor a 10 ni mayor a 50");
            }
        }

        public bool Equals(NombreDisciplina? other)
        {
            if (other != null)
            {
                return Valor == other.Valor;
            }
            return false;
        }
    }
}

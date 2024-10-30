using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class AnioDisciplina : IEquatable<AnioDisciplina>
    {
        public int Valor { get; private set; }

        protected AnioDisciplina() { }

        public AnioDisciplina(int valor)
        {
            Valor = valor;
            Validate();
        }

        public void Validate()
        {
            if (Valor == null)
            {
                throw new ExcepcionesDisciplina("El año no puede ser Vacío.");
            }
            if (Valor == 0)
            {
                throw new ExcepcionesDisciplina("El año no puede ser igual a Cero.");
            }
            if (Valor < 0)
            {
                throw new ExcepcionesDisciplina("El año no puede ser menor a Cero.");
            }
            if (Valor < 1896)
            {
                throw new ExcepcionesDisciplina("El año no puede ser menor al de la creación de los juegos olímpicos.");
            }
            if (Valor > DateTime.Now.Year)
            {
                throw new ExcepcionesDisciplina("El año no puede ser mayor al que se está cursando.");
            }
        }

        public bool Equals(AnioDisciplina? other)
        {
            if (other != null)
            {
                return Valor == other.Valor;
            }
            return false;
        }
    }
}


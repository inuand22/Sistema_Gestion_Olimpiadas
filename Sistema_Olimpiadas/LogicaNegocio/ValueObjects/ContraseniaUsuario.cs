using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class ContraseniaUsuario : IEquatable<ContraseniaUsuario>
    {
        public string Valor { get; private set; }

        public ContraseniaUsuario(string contrasenia)
        {
            Valor = contrasenia;
            Validate();
        }

        protected ContraseniaUsuario() { }

        private void Validate()
        {
            Valor = Valor.Trim(); //CAMBIO REALIZADO 27-9-10:30
            if (string.IsNullOrEmpty(Valor) || Valor.Length < 6)
            {
                throw new ExcepcionesUsuario("La contraseña debe tener al menos 6 caracteres.");
            }

            if (!Valor.Contains(".") && !Valor.Contains(";") && !Valor.Contains(",") && !Valor.Contains("!"))
            {
                throw new ExcepcionesUsuario("La contraseña debe tener al menos un caracter especificos");
            }

            if (!ExisteCaracteres())
            {
                throw new ExcepcionesUsuario("La contraseña debe tener al menos una mayúscula,una minúscula y un digito.");
            }
        }

        public bool Equals(ContraseniaUsuario? other)
        {
            if (other != null)
            {
                return Valor.Equals(other.Valor);
            }
            return false;
        }

        public bool ExisteCaracteres()
        {
            bool existeMayus = false;
            bool existeMinus = false;
            bool existeNumero = false;

            foreach (char item in Valor)
            {
                if (char.IsUpper(item))
                {
                    existeMayus = true;
                }
                if (char.IsLower(item))
                {
                    existeMinus = true;
                }
                if (char.IsDigit(item))
                {
                    existeNumero = true;
                }
                if (existeMayus && existeMinus && existeNumero)
                {
                    break;
                }
            }
            return existeMayus && existeMinus && existeNumero;
        }
    }
}

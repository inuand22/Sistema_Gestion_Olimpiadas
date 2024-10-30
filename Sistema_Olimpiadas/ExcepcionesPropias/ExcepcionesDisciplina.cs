namespace ExcepcionesPropias
{
    public class ExcepcionesDisciplina : Exception
    {
        public ExcepcionesDisciplina()
        {
        }

        // Constructor que recibe un mensaje
        public ExcepcionesDisciplina(string mensaje) : base(mensaje)
        {
        }

        // Constructor que recibe un mensaje y una excepción interna
        public ExcepcionesDisciplina(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}

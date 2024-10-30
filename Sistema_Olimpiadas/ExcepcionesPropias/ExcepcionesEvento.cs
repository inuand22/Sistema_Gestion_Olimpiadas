namespace ExcepcionesPropias
{
    public class ExcepcionesEvento : Exception
    {
        public ExcepcionesEvento()
        {
        }

        // Constructor que recibe un mensaje
        public ExcepcionesEvento(string mensaje) : base(mensaje)
        {
        }

        // Constructor que recibe un mensaje y una excepción interna
        public ExcepcionesEvento(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}

namespace ExcepcionesPropias
{
    public class ExcepcionesUsuario : Exception
    {
        public ExcepcionesUsuario() { }

        public ExcepcionesUsuario(string Mensaje) : base(Mensaje) { }

        public ExcepcionesUsuario(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}



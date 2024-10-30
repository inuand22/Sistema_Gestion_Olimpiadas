namespace ExcepcionesPropias
{
    public class ExcepcionesRol : Exception
    {
        public ExcepcionesRol() { }

        public ExcepcionesRol(string Mensaje) : base(Mensaje) { }

        public ExcepcionesRol(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}

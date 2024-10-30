namespace ExcepcionesPropias
{
    public class ExcepcionesPais : Exception
    {
        public ExcepcionesPais() { }

        public ExcepcionesPais(string Mensaje) : base(Mensaje) { }

        public ExcepcionesPais(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}

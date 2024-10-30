namespace ExcepcionesPropias
{
    public class ExcepcionesAtleta : Exception
    {
        public ExcepcionesAtleta() { }

        public ExcepcionesAtleta(string Mensaje) : base(Mensaje) { }

        public ExcepcionesAtleta(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}

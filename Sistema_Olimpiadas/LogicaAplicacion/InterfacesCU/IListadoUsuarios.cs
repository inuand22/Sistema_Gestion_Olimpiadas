using DTO;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoUsuarios
    {
        IEnumerable<ListadoUsuariosDTO> ObtenerListado();
    }
}

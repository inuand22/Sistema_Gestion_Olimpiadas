using DTO;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoRoles
    {
        IEnumerable<RolDTO> ObtenerListado();
    }
}

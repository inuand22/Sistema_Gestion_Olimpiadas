using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoRoles : IListadoRoles
    {
        public IRepositorioRoles Repositorio { get; set; }

        public ListadoRoles(IRepositorioRoles repositorio)
        {
            Repositorio = repositorio;
        }

        public IEnumerable<RolDTO> ObtenerListado()
        {
            return MappersRol.FromRoles(Repositorio.FindAll());
        }
    }
}

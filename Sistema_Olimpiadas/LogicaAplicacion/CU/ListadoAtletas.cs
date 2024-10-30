using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoAtletas : IListadoAtletas
    {
        public IRepositorioAtleta Repositorio { get; set; }

        public ListadoAtletas(IRepositorioAtleta repositorio)
        {
            Repositorio = repositorio;
        }

        public ListadoAtletasDTO GetAtletaPorId(int id)
        {
            if (id != 0 || id > 0)
            {
                return MappersAtleta.FromAtleta(Repositorio.FindById(id));
            }
            throw new ExcepcionesAtleta("Atleta no encontrado");
        }

        public IEnumerable<ListadoAtletasDTO> GetAtletas()
        {
            return MappersAtleta.FromAtletas(Repositorio.FindAll());
        }

        
    }
}

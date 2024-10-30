using DTO;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoAtletas
    {
        ListadoAtletasDTO GetAtletaPorId(int id);
        IEnumerable<ListadoAtletasDTO> GetAtletas();
    
    }
}

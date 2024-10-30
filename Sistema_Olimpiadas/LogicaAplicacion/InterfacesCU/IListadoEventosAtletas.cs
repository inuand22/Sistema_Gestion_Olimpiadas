using DTO.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoEventosAtletas
    {
        IEnumerable<ListadoEventoAtletaDTO> GetAtletasPorEvento(int idEvento);
        IEnumerable<ListadoEventoAtletaDTO> GetEventosPorAtleta(int idAtleta);
    }
}

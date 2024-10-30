using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEventoAtleta:IRepositorio<EventoAtleta>
    {
        IEnumerable<EventoAtleta> ObtenerAtletasPorEvento(int idEvento);
        IEnumerable<EventoAtleta> ObtenerEventosPorAtleta(int idAtleta); 
        int FindIdByAtletaEvento(int idEvento, int idAtleta);
    }
}

using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class AltaDisciplina : IAltaDisciplina
    {
        public IRepositorioDisciplina Repositorio { get; set; }

        public AltaDisciplina(IRepositorioDisciplina repositorio)
        {
            Repositorio = repositorio;
        }

        public void AltaDisci(AltaDisciplinaDTO dto)
        {
            if (dto != null)
            {
                Disciplina disci = MappersDisciplina.FromDTO(dto);
                Repositorio.Add(disci);
            }
            else
            {
                throw new ExcepcionesDisciplina("No existe disciplina");
            }
        }
    }
}

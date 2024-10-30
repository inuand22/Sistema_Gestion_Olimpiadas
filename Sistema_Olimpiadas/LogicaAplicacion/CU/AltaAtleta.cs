using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class AltaAtleta : IAltaAtleta
    {
        public IRepositorioAtleta RepositorioAtleta { get; set; }

        public AltaAtleta(IRepositorioAtleta repositorioAtleta)
        {
            RepositorioAtleta = repositorioAtleta;
        }

        public void UpdateAtleta(ListadoAtletasDTO dto)
        {
            if (dto != null)
            {
                Atleta atleta = MappersAtleta.FromDTO(dto);
                RepositorioAtleta.Update(atleta.Id, dto.IdDisciplina);
            }
            else
            {
                throw new ExcepcionesAtleta("Atleta no puede ser vacío");
            }
        }
    }
}



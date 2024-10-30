using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class AltaEventoPuntaje : IAltaEventoAtletaPuntaje
    {
        public IRepositorioEventoAtleta Repositorio { get; set; }

        public AltaEventoPuntaje(IRepositorioEventoAtleta repositorio)
        {
            Repositorio = repositorio;
        }

        public void AltaPuntaje(AltaEventoAtletaPuntajeDTO dto)
        {
            if (dto != null)
            {
                if (dto.Puntaje < 0)
                {

                    throw new ExcepcionesEvento("Puntaje no puede ser menor a cero");
                }
                if (dto.Puntaje > 100)
                {
                    throw new ExcepcionesEvento("Puntaje no puede ser mayor a cien");
                }

                Repositorio.Update(MappersEventoAtleta.FromDTO(dto));
            }
        }
    }
}

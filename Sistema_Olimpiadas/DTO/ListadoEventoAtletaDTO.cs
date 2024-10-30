using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class ListadoEventoAtletaDTO
    {
        [Display(Name = "Id Evento Atleta")]
        public int Id { get; set; }

        [Display(Name = "Id Atleta")]
        public int IdAtleta { get; set; }

        [Display(Name = "Nombre Atleta")]
        public string NombreAtleta { get; set; }

        [Display(Name = "Id Evento")]
        public int IdEvento { get; set; }

        [Display(Name = "Nombre Evento")]
        public string NombreEvento { get; set; }

        [Display(Name = "Puntaje Atleta")]
        public decimal? PuntajeAtleta { get; set; }

        [Display(Name = "Fecha del Evento")]
        public DateTime FechaEvento { get; set; }
    }
}


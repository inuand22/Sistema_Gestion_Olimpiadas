using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AltaEventoAtletaPuntajeDTO
    {
        public int Id { get; set; }

        [Required]
        public int IdAtleta { get; set; }

        [Required]
        public decimal? Puntaje { get; set; }

        [Required]
        public int IdEvento { get; set; }
    }
}


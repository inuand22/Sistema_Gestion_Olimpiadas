using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class EventoAtleta
    {
        public int Id { get; set; }
        public Atleta Atleta { get; set; }
        public Evento? Evento { get; set; }    
        public decimal? PuntajeAtleta { get; set; }
    }
}

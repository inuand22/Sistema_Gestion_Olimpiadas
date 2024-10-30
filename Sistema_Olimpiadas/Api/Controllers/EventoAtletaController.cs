using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoAtletaController : ControllerBase
    {
        public IListadoEventosAtletas CUListadoEventoAtleta { get; set; }

        public EventoAtletaController(IListadoEventosAtletas cUListadoEventoAtleta)
        {
            CUListadoEventoAtleta = cUListadoEventoAtleta;
        }

        // GET api/<EventoAtletaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id debe ser un número mayor o igual a 1.");
            }

            try
            {
                IEnumerable<ListadoEventoAtletaDTO> eventos = CUListadoEventoAtleta.GetEventosPorAtleta(id);

                if (eventos is not null && eventos.Any())
                {
                    return Ok(eventos);
                }
                else
                {
                    return NotFound("No se encontraron eventos para el atleta especificado.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }


        //// GET: api/<EventoAtletaController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}

        //// POST api/<EventoAtletaController>
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    return Ok();
        //}

        //// PUT api/<EventoAtletaController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //    return Ok();
        //}

        //// DELETE api/<EventoAtletaController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    return Ok();
        //}
    }
}

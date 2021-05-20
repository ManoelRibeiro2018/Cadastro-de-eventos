using Eventos.API.DTO;
using Eventos.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoDTOInterface _eventoDTOInterface;
        public EventosController(IEventoDTOInterface eventoDTOInterface)
        {
            _eventoDTOInterface = eventoDTOInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvento()
        {
            var evento = await _eventoDTOInterface.GetAllEventosAsync();
            return Ok(evento);
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            var evento = await _eventoDTOInterface.GetAllEventosByTemaAsync(tema);
            if (evento == null)
            {
                return NotFound("Não encontrado");
            }
            return Ok(evento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventoById(int id)
        {
            var evento = await _eventoDTOInterface.GetEventoByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EventoDTO model)
        {           

            var evento = await _eventoDTOInterface.AddEvento(model);

            return CreatedAtAction(
                nameof(GetEventoById),
                new { id = evento.Id },
                evento);
        }

        [HttpPut("{id}")]
        public IActionResult PutEvento(int id, [FromBody] EventoDTO model)
        {
            _eventoDTOInterface.UpdateEvento(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            _eventoDTOInterface.DeleteEvento(id);
            return NoContent();
        }



    }
}

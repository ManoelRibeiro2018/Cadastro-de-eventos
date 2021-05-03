using Eventos.API.Domain;
using Eventos.API.Interface;
using Eventos.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoInterface _dbContext;
        public EventosController(IEventoInterface eventoDbContext)
        {
            _dbContext = eventoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvento()
        {
            var evento = await _dbContext.GetAllEventosAsync();
            return Ok(evento);
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            var evento = await _dbContext.GetAllEventosByTemaAsync(tema);
            if(evento == null)
            {
                return NotFound("Não encontrado");
            }
            return Ok(evento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _dbContext.GetEventoByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Evento model)
        {
            var evento = await _dbContext.AddEvento(model);

            return CreatedAtAction(
                nameof(GetById),
                new { id = evento.Id },
                model);
        }


        [HttpPut("{id}")]
        public  IActionResult Put(int id, [FromBody] Evento model)
        {           
            _dbContext.UpdateEvento(id,model);            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _dbContext.GetEventoByIdAsync(id);
            if (evento == null)
            {
                return Ok();
            }
            _dbContext.DeleteEvento(id);
            return NoContent();
        }
    }
}

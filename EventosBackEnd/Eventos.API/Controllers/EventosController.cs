using Eventos.API.Domain;
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
        private readonly EventosDbContext _dbContext;
        public EventosController(EventosDbContext eventoDbContext)
        {
            _dbContext = eventoDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var evento = _dbContext.Eventos.ToList();
            return Ok(evento);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] Evento model)
        {
            _dbContext.Eventos.Add(model);
            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = model.Id },
                model);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Evento model)
        {
            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            evento.Update(model.Local, model.DataEvento, model.Tema, model.QtdPessoas, model.Lote, model.ImageUrl);
            _dbContext.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return Ok();
            }
            _dbContext.Eventos.Remove(evento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}

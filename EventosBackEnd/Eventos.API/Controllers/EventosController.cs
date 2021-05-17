﻿using Eventos.API.Domain;
using Eventos.API.DTO;
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
        private readonly IEventoInterface _dbEventoContext;
        public EventosController(IEventoInterface eventoDbContext)
        {
            _dbEventoContext = eventoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvento()
        {
            var eventos = await _dbEventoContext.GetAllEventosAsync(true);
            if (eventos == null)
            {
                return NotFound("Nenhum evento encontrado");
            }
            var eventoViewModel = new List<EventoDTO>();

            // não deveria está esposto
            foreach (var evento in eventos)
            {
                eventoViewModel.Add(new EventoDTO
                {
                    Id = evento.Id,
                    Local = evento.Local,
                    DataEvento = evento.DataEvento,
                    Tema = evento.Tema,
                    QtdPessoas = evento.QtdPessoas,
                    ImageUrl = evento.ImageUrl,
                    Telefone = evento.Telefone,
                    Email = evento.Email
                });
            }

          
            
            return Ok(eventoViewModel);
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            var evento = await _dbEventoContext.GetAllEventosByTemaAsync(tema);
            if (evento == null)
            {
                return NotFound("Não encontrado");
            }
            return Ok(evento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _dbEventoContext.GetEventoByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Evento model)
        {
            var evento = await _dbEventoContext.AddEvento(model);

            return CreatedAtAction(
                nameof(GetById),
                new { id = evento.Id },
                model);
        }

        [HttpPut("{id}")]
        public IActionResult PutEvento(int id, [FromBody] Evento model)
        {            
            _dbEventoContext.UpdateEvento(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {            
            _dbEventoContext.DeleteEvento(id);
            return NoContent();
        }



    }
}

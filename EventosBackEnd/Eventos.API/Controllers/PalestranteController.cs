using Eventos.API.Domain;
using Eventos.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [Route("api/palestrantes")]
    public class PalestranteController : ControllerBase
    {
        private readonly IPalestranteInterface _dbcontext;
        public PalestranteController(IPalestranteInterface palestranteInterface)
        {
            _dbcontext = palestranteInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var palestrantes = await _dbcontext.GetAllPalestrantes();
            if (palestrantes == null)
            {
                return NotFound();
            }
            return Ok(palestrantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var palestrante = await _dbcontext.GetPalestranteById(id);
            if (palestrante == null)
            {
                return NotFound();
            }
            return Ok(palestrante);
        }
        [HttpGet("{nome}")]
        public async Task<IActionResult> GetAlByName(string name)
        {
            var palestrante = await _dbcontext.GetAllPalestrantesByNome(name);
            if (palestrante == null)
            {
                return NotFound();
            }
            return Ok(palestrante);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Palestrante model)
        {
            var palestrante = await _dbcontext.AddPalestrante(model);
            return CreatedAtAction(
                nameof(GetById),
                new { id = model.Id },
                model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Palestrante model)
        {
            await _dbcontext.UpdatePalestrante(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dbcontext.DeletePalestrante(id);
            return NoContent();
        }
    }
}

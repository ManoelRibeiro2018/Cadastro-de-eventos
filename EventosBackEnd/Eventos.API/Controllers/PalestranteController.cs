using Eventos.API.DTO;
using Eventos.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [Route("api/palestrantes")]
    public class PalestranteController : ControllerBase
    {
        private readonly IPalestranteDTOInterface _dbcontext;
        public PalestranteController(IPalestranteDTOInterface palestranteInterface)
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PalestranteDTO model)
        {
            var palestrante = await _dbcontext.AddPalestrante(model);
            return CreatedAtAction(
                nameof(GetById),
                new { id = palestrante.Id },
                palestrante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PalestranteDTO model)
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

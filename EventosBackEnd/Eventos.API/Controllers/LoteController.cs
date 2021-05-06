using Eventos.API.Domain;
using Eventos.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [Route("lotes")]
    public class LoteController : ControllerBase
    {
        private readonly ILoteInterface _dbLoteContext;
        public LoteController(ILoteInterface dbLoteContext)
        {
            _dbLoteContext = dbLoteContext;
        }
        [HttpPost]
        public IActionResult PostLote([FromBody] Lote model)
        {
            var lote = _dbLoteContext.AddLote(model);
            return Ok(lote);

        }

        [HttpGet("{eventoId}")]
        public IActionResult GetAllLoteByEvento(int eventoId)
        {
            var lotes = _dbLoteContext.GetAllLotesbyEvento(eventoId);
            if (lotes == null)
            {
                return NotFound("Nenhum lote encontrado");
            }
            return Ok(lotes);
        }

        [HttpPut("{idEvento}/lote/{id}")]
        public IActionResult PutLote(int idEvento, int id, [FromBody] Lote model)
        {
            _dbLoteContext.Update(idEvento, id, model);
            return Ok();
        }

        [HttpDelete("{idEvento}/lote/{id}")]
        public IActionResult DeleteLote(int idEvento, int id)
        {
            _dbLoteContext.Delete(idEvento, id);
            return NoContent();
        }
    }
}

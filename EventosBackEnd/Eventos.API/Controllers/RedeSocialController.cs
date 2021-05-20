using Eventos.API.Domain;
using Eventos.API.DTO;
using Eventos.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [Route("api/RedeSociais")]
    public class RedeSocialController : ControllerBase
    {
        private readonly IRedeSocialDTOInterface _dbcontext;
        public RedeSocialController(IRedeSocialDTOInterface redeSocialInterface)
        {
            _dbcontext = redeSocialInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var redeSocial = await _dbcontext.GetAllRedeSocial();
            return Ok(redeSocial);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RedeSocialDTO model)
        {
            var redeSocial = await _dbcontext.AddRedeSocial(model);
            return Ok(redeSocial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RedeSocialDTO model)
        {
           await _dbcontext.UpdateRedeSocial(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dbcontext.DeleteRedeSocial(id);
            return NoContent(); 
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

namespace Sistema_de_Controle_de_Alienígenas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlienController : ControllerBase
    {
        private readonly IAlienService _alienService;

        public AlienController(IAlienService alienService)
        {
            _alienService = alienService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlien(AlienDTO alien)
        {
            await _alienService.CadastraAlienComPlaneta(alien);

            return Ok();
        }

        [HttpPost("{id}/poderes/{poderId}")]
        public async Task<IActionResult> AssociarAlienAoPoder(int id, int poderId)
        {
            var alienPoder = await _alienService.AssociarAlienAoPoder(id, poderId);

            if (alienPoder == null)
            {
                return NotFound();
            }

            return Ok(alienPoder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlienById(int id)
        {
            var alien = await _alienService.DeleteAlienById(id);

            if (alien == null)
            {
                return NotFound();
            }

            return Ok(alien);
        }

    }
}

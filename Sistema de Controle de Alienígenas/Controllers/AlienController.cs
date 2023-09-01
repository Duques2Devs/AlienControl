using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
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
   [HttpGet("{id}")]
   public async Task<ActionResult<AlienModel>> GetAlien(int id)
        {
            await _alienService.CadastraAlienComPlaneta(alien);
      var alien = await _alienService.GetAlienById(id);
      if (alien == null)
         return NotFound($"Alien com ID {id} não encontrado. ");

            return Ok();
      return Ok(alien);
        }

   [HttpGet]
   public async Task<ActionResult<List<AlienModel>>> GetAliens()
   {
      var aliens = await _alienService.GetAllAliens();
      return Ok(aliens);
   }
   
   [HttpGet("/alien/{id}/planeta")]
   public async Task<ActionResult<PlanetaModel>> GetPlanetaByAlienId(int id)
        [HttpPost("{id}/poderes/{poderId}")]
        public async Task<IActionResult> AssociarAlienAoPoder(int id, int poderId)
        {
      var planeta = await _alienService.GetPlanetaByAlienId(id);
            var alienPoder = await _alienService.AssociarAlienAoPoder(id, poderId);

      if (planeta == null)
            if (alienPoder == null)
            {
         return NotFound($"Planeta para o Alien com ID {id} não encontrado.");
                return NotFound();
            }

      return Ok(planeta);
            return Ok(alienPoder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlienById(int id)

   [HttpPut("{id}")]
   public async Task<ActionResult<int>> UpdateAlien(int id, AlienModel alien)
        {
            var alien = await _alienService.DeleteAlienById(id);

            if (alien == null)
      if (id != alien.PlanetaID)
            {
                return NotFound();
         return BadRequest("Id do Alien na URL não corresponde ao ID no corpo da requisição");
            }

            return Ok(alien);
        }
      await _alienService.UpdateAlien(alien);

      return NoContent();
    }
}

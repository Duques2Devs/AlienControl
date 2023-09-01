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

        [HttpGet("{id}")]
        public async Task<ActionResult<AlienModel>> GetAlien(int id)
        {
            var alien = await _alienService.GetAlienById(id);
            if (alien == null)
                return NotFound($"Alien com ID {id} não encontrado. ");

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
        {
            var planeta = await _alienService.GetPlanetaByAlienId(id);

            if (planeta == null)
            {
                return NotFound($"Planeta para o Alien com ID {id} não encontrado.");
            }

            return Ok(planeta);
        }

        [HttpGet("{id}/poderes")]
        public async Task<ActionResult<List<PoderModel>>> GetPoderesByAlienId(int id)
        {
            var poderes = await _alienService.GetPoderesByAlienId(id);

            if (poderes == null)
            {
                return NotFound($"Poderes para o Alien com ID {id} não encontrado.");
            }

            return Ok(poderes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateAlien(int id, AlienModel alien)
        {
            if (id != alien.PlanetaID)
            {
                return BadRequest("Id do Alien na URL não corresponde ao ID no corpo da requisição");
            }

            await _alienService.UpdateAlien(alien);

            return NoContent();
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

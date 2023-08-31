using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

namespace Sistema_de_Controle_de_Alienígenas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoderesController : ControllerBase
    {
        private readonly IPoderService _poderService;
        public PoderesController(IPoderService poderService)
        {
            _poderService = poderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPoderDTO>>> GetAllPoder()
        {
            return await _poderService.GetAllPoder();
        }
        [HttpGet("{id}")]
        public async Task<GetPoderDTO> GetPoderById(int id)
        {
            return await _poderService.GetPoderById(id);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePoder(PoderDTO poder)
        {
            var result =await _poderService.CreatePoder(poder);
            if (result == null) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
       /* [HttpPost("aliens")]
        public async Task<IActionResult> CreatePoderByAlienId(PoderDTO poder, ICollection<int> aliensId)
        {
            var result = await _poderService.CreatePoderByAlienId(poder, aliensId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }*/
        [HttpPut]
        public async Task<IActionResult> UpdateAlienPoder(int id, ICollection<int> aliensId)
        {
            var result = await _poderService.UpdateAlienPoder(id, aliensId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePoder(int id)
        {
            var result = await _poderService.DeletePoder(id);

            if (result == null) return BadRequest(result);

            return Ok(result);
        }


    }
}

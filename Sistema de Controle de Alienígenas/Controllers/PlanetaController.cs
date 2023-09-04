using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;
using System.Numerics;

namespace Sistema_de_Controle_de_Alienígenas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanetaController : ControllerBase
    {
        private readonly IPlanetaService _service;

        public PlanetaController(IPlanetaService service)
        {
            _service = service;
        }
        [HttpGet("/planeta/habitantes/{Id}")]
        public async Task<ActionResult<List<AlienModel>>> GetAliensPlaneta(int Id)
        {
            var habitantes = await _service.GetHabitantesPlanetas(Id);
            if (habitantes == null) return NotFound("Planetas não encontrados!");
            return Ok(habitantes);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetaModel>>> GetPlanetas()
        {
            var planetas = await _service.GetPlanetas();
            if (planetas == null ) return NotFound("Planetas não encontrados!");
            return Ok(planetas);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PlanetaModel>> GetPlanetaById(int Id)
        {
            var planeta = await _service.GetPlanetaById(Id);
            if (planeta == null) return NotFound("Planeta não encontrado!");
            return Ok(planeta);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlaentaSemHabitantes ( DTOPlaneta planeta)
        {
             await _service.CreatePlanetaSemHabitantes(planeta);
             return CreatedAtAction(nameof(GetPlanetaById), new { id = planeta.Id }, planeta);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdatePlaneta(int Id, DTOPlaneta model)
        {
            if (Id != model.Id) return BadRequest();
            await _service.UpdatePlaneta(Id, model);
            return Ok("Planeta atualizado com sucesso");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProduto(int Id)
        {
            await _service.DeletePlaneta(Id);
            return Ok("Planeta excluído com sucesso");
        }

    }
}

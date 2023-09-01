using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

namespace Sistema_de_Controle_de_Alienígenas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroService _registroService;

        public RegistroController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroModel>>> GetAllRegistros()
        {
            var registros = await _registroService.GetAllRegistros();
            return Ok(registros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroModel>> GetRegistroById(int id)
        {
            var registro = await _registroService.GetRegistroById(id);
            if (registro == null) return NotFound();

            return Ok(registro);
        }

        [HttpPost]
        public async Task<ActionResult<RegistroModel>> CreateRegistroInOut(RegistroDTO registro)
        {
            await _registroService.CreateRegistroInOut(registro);

            return Ok(registro);
           // return CreatedAtAction(nameof(GetRegistroById), registro);           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRegistro(int id, UpdateRegistroDTO registro)
        {
            if (id != registro.Id) return BadRequest();

            await _registroService.UpdateRegistro(id, registro);
            return Ok("Registro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegistro(int id)
        {
            await _registroService.DeleteRegistroInOut(id);
            return Ok("Registro excluído com sucesso");
        }
    }
}

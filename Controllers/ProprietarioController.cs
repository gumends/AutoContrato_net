using Microsoft.AspNetCore.Mvc;
using AutoContrato_net.Service;
using AutoContrato_net.DTO;
using Microsoft.AspNetCore.Authorization;

namespace AutoContrato_net.Controllers
{

    [ApiController]
    [Route("Proprietario")]
    [Authorize(Roles = "string")]
    public class ProprietarioController : ControllerBase
    {

        private readonly ProprietarioService _services;

        public ProprietarioController(ProprietarioService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProprietarios(bool status = true, string nome = "", int page = 0, int pageSize = 10){
            var p = await _services.GetAllProprietarios(status, nome, page, pageSize);
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProprietario(ProprietarioDTO proprietario){
            var p = await _services.CriarProprietario(proprietario);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProprietario(ProprietarioDTO proprietario, Guid id){
            var p = await _services.UpdateProprietario(proprietario, id);
            if (p == null) return NotFound(new { message = "Proprietario não encontrado" });
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProprietario(Guid id){
            var p = await _services.DesativarProprietario(id);
            return Ok(p);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id){
            var p = await _services.GetOneProprietario(id);
            if (p == null) return NotFound(new { message = "Proprietario não encontrado" });
            return Ok(p);
        }

        
    }
}
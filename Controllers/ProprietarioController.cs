using Microsoft.AspNetCore.Mvc;
using AutoContrato_net.Service;
using AutoContrato_net.DTO;

namespace AutoContrato_net.Controllers
{

    [ApiController]
    [Route("Proprietario")]
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
    }
}
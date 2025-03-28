using AutoContrato_net.DTO;
using AutoContrato_net.Service;
using Microsoft.AspNetCore.Mvc;

namespace AutoContrato_net.Controllers
{

    [ApiController]
    [Route("Propreidades")]
    public class PropriedadeController : ControllerBase
    {
        private readonly PropriedadeService _service;

        public PropriedadeController(PropriedadeService propriedadeService)
        {
            _service = propriedadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPropriedades(bool status = true, string rua = "", int page = 0, int pageSize = 10)
        {
            var propriedades = await _service.GetAllPropriedades(status, rua, page, pageSize);
            return Ok(propriedades);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePropriedade(PropriedadeDTO propriedade)
        {
            var p = await _service.CreatePropriedade(propriedade);
            return Ok(p);
        }
    }
}
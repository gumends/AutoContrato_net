using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.DTO;
using AutoContrato_net.Service;
using Microsoft.AspNetCore.Mvc;

namespace AutoContrato_net.Controllers
{
    [ApiController, Route("Locatario")]
    public class LocatarioController : ControllerBase
    {

        private readonly LocatarioService _service;

        public LocatarioController(LocatarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocatarios(bool status = true, string nome = "", int page = 0, int pageSize = 10)
        {
            var l = await _service.GetAllLocatarios(status, nome, page, pageSize);
            return Ok(l);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocatario(LocatarioDTO locatario)
        {
            var l = await _service.CreateLocatario(locatario);
            return Ok(l);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var l = await _service.GetOneLocatario(id);
            return Ok(l);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocatario(LocatarioDTO locatario, Guid id)
        {
            var l = await _service.UpdateLocatario(locatario, id);
            if (l == null) return NotFound(new { message = "Locatário não encontrado" });
            return Ok(l);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocatario(Guid id)
        {
            var l = await _service.DesativarLocatario(id);
            return Ok(l);
        }
    }
}
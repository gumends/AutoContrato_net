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
    }
}
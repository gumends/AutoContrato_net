using Microsoft.AspNetCore.Mvc;
using AutoContrato_net.Service;
using AutoContrato_net.DTO;

namespace AutoContrato_net.Controllers
{

    [ApiController]
    [Route("Usuarios")]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuariosServices _services;

        public UsuariosController(UsuariosServices usuariosServices)
        {
            _services = usuariosServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(UsuarioDTO usuario)
        {
            var u = await _services.CadastraUsuario(usuario);
            return Ok(u);
        }

        [HttpGet]
        public async Task<IActionResult> FindAllUsuarios(int page = 0, int pageSize = 10)
        {
            var u = await _services.FindAllUsuarios(page, pageSize);
            return Ok(u);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            var u = _services.FindById(id);
            return Ok(u);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(UsuarioDTO usuario, Guid id)
        {
            var u = await _services.UpdateUsuario(usuario, id);
            if (u == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }
            return Ok(u);
        }

        [HttpGet("Nome/{nome}")]
        public async Task<IActionResult> FindByNome(string nome = "", int page = 0, int pageSize = 10) 
        {
            var u = await _services.FindByNome(nome, page, pageSize);

            return Ok(u);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var u = await _services.ExcluirUsuario(id);
            return Ok(u);
        }
    }
}
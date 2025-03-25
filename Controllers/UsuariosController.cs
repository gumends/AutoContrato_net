using Microsoft.AspNetCore.Mvc;
using AutoContrato_net.Service;
using AutoContrato_net.Model;

namespace AutoContrato_net.Controllers
{

    [ApiController]
    [Route("Usuarios")]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuariosServices _services;

        public UsuariosController(UsuariosServices usuariosServices){
            _services = usuariosServices;
        }
        
        [HttpPost]
        public IActionResult CriarUsuario(Usuario usuario){
            _services.CadastraUsuario(usuario);
            return Ok(usuario);
        }
    }
}
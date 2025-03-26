using Microsoft.AspNetCore.Mvc;
using AutoContrato_net.Service;
using AutoContrato_net.Model;
using AutoContrato_net.DTO;

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
        public IActionResult CriarUsuario(UsuarioDTO usuario){
            var u = _services.CadastraUsuario(usuario);
            return Ok(u);
        }

        [HttpGet]
        public IActionResult FindAllUsuarios(){
            var u = _services.findAllUsuarios();
            return Ok(u);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id){
            var u = _services.FindById(id);
            return Ok(u);
        }
       
        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(UsuarioDTO usuario, Guid id){
            var u =  _services.AlterarUsuario(usuario, id);
            return Ok(u);
        }
        
    }
}
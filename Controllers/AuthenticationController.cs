using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.DTO;
using AutoContrato_net.Service;
using AutoContrato_net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoContrato_net.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {

        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto login)
        {
            var token = await _tokenService.GenerateToken(login);

            if (token == "")
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
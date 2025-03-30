using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoContrato_net.Context;
using AutoContrato_net.DTO;
using AutoContrato_net.Model;
using AutoContrato_net.Service;
using Microsoft.IdentityModel.Tokens;

namespace AutoContrato_net.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UsuariosServices _service;

        public TokenService(IConfiguration configuration, UsuariosServices service)
        {
            _configuration = configuration;
            _service = service;
        }

        public async Task<string> GenerateToken(LoginDto usuario)
        {
            var u = await _service.FindByEmail(usuario.Email);

            if (u == null || !BCrypt.Net.BCrypt.Verify(usuario.Senha, u.Senha))
            {
                return String.Empty;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));

            var issuer = _configuration["Jwt:Issuer"] ?? string.Empty;
            var audience = _configuration["Jwt:Audience"] ?? string.Empty;

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]{
                    new Claim(type: ClaimTypes.Name, u.Nome),
                    new Claim(type: ClaimTypes.Role, u.Role)
                },
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
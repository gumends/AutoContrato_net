using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoContrato_net.DTO;
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
                    new Claim(type: ClaimTypes.Role, u.Role.ToString()),
                    new Claim(type: ClaimTypes.Email, u.Email),
                    new Claim(type: ClaimTypes.Sid, u.Id.ToString())
                },
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
        
        public ClaimsPrincipal? DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token.Replace("Bearer ", ""), validationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Guid> GetUserIdFromToken(string token)
        {
            var principal = DecodeToken(token);
    
            if (principal == null) 
                return Guid.Empty;

            var userIdClaim = principal.FindFirst(ClaimTypes.Sid)?.Value;

            if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out Guid userId))
            {
                return userId;
            }

            return Guid.Empty;
        }

    }
}
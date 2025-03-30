using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.DTO;
using AutoContrato_net.Model;

namespace AutoContrato_net.Services
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(LoginDto usuario);
    }
}
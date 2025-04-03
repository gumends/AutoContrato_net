using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.Enum;

namespace AutoContrato_net.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        
        public string CPF { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public UserRole Role { get; set; }

        public bool Status { get; set; }
    }
}
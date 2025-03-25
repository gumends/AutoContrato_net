using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoContrato_net.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime UltimaAlteracao { get; set; } = DateTime.Now;
    }
}
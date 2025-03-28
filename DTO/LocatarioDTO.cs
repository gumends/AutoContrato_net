using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoContrato_net.DTO
{
    public class LocatarioDTO
    {
        public string Nome { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public DateTime Nascimento { get; set; }

        public Guid? PropriedadeId { get; set; }
    }
}
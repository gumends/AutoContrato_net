using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.Model;

namespace AutoContrato_net.DTO
{
    public class ProprietarioDTO
    {
        public string Nome { get; set; }

        public string Nacionalidade { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public DateTime Nascimento { get; set; }

        public bool status { get; set; }
    }
}
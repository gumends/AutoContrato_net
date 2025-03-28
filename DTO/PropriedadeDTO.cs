using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoContrato_net.DTO
{
    public class PropriedadeDTO
    {
        public string Rua { get; set; }

        public int Numero { get; set; }

        public int NumCasa { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Localizacao { get; set; }

        public decimal? Aluguel { get; set; }

        public DateTime? DataPagamento { get; set; }

        public Guid? ProprietarioId { get; set; } // Chave estrangeira
    }
}
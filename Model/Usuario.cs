using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoContrato_net.Enum;

namespace AutoContrato_net.Model
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        [Required]
        public string Senha { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaAlteracao { get; set; }

        public Usuario()
        {
            DataCadastro = DateTime.UtcNow;
            UltimaAlteracao = DateTime.UtcNow;
        }
    }
}
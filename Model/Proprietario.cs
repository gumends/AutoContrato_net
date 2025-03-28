using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AutoContrato_net.Model
{
public class Proprietario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Nacionalidade { get; set; }

    [Required]
    public string Rg { get; set; }

    [Required]
    public string Cpf { get; set; }

    [Required]
    public DateTime Nascimento { get; set; }

    [Required]
    public bool Status { get; set; } = true;

    // Remova o PropriedadeId daqui
    public List<Propriedade> Propriedades { get; set; } = new List<Propriedade>();

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public Proprietario()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}

}
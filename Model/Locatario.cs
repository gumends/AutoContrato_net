using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AutoContrato_net.Model;
public class Locatario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Rg { get; set; }

    [Required]
    public string Cpf { get; set; }

    [Required]
    public DateTime Nascimento { get; set; }

    [Required]
    public bool Status { get; set; }

    // Correção: Definindo explicitamente que `Locatario` pertence a uma `Propriedade`
    public Guid PropriedadeId { get; set; }
    public Propriedade Propriedade { get; set; }

    [Required]
    public bool Alocado { get; set; } = false;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public Locatario()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarData()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}

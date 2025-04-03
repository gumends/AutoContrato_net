using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutoContrato_net.Model;
public class Propriedade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Rua { get; set; }

    [Required]
    public int Numero { get; set; }

    public int NumCasa { get; set; }

    [Required]
    public string Bairro { get; set; }

    [Required]
    public string Cep { get; set; }

    [Required]
    public string Localizacao { get; set; }

    public decimal? Aluguel { get; set; }

    public DateTime? DataPagamento { get; set; }

    [Required]
    public bool Status { get; set; } = true;

    [Required]
    public bool Alugada { get; set; } = false;
    
    [Required]
    public Guid UsuarioId { get; set; }

    [Required]
    public Guid ProprietarioId { get; set; }

    public Proprietario Proprietario { get; set; }

    public Locatario Locatario { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public Propriedade()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarData()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}


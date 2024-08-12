using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Entidades;

public partial class Endereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }
    public long? IdPessoa { get; set; }

    public long? IdCidade { get; set; }

    public int? Cep { get; set; }

    public string Rua { get; set; } = null!;

    public int Numero { get; set; }

    public string? Complemento { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    [ForeignKey("IdCidade")]
    public virtual Cidade? Cidade { get; set; } = null!;

    [ForeignKey("IdPessoa")]
    public virtual Pessoa? Pessoa { get; set; } = null!;
}

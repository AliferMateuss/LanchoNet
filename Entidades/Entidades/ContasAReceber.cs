using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

public partial class ContasAReceber
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public DateTime DataCompetencia { get; set; }

    public DateTime DataConta { get; set; }

    public DateTime DataVencimento { get; set; }

    public double Valor { get; set; }

    public int? Parcela { get; set; }

    public char Status { get; set; }

    public long IdVenda { get; set; }
    public long IdUsuario { get; set; }
    public long IdPessoa { get; set; }

    [ForeignKey("IdPessoa")]
    public virtual Pessoa? Pessoa { get; set; }

    [ForeignKey("IdUsuario")]
    public virtual Usuario? Usuario { get; set; }

    [ForeignKey("IdVenda")]
    public virtual Venda? Venda { get; set; }
}

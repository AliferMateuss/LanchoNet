using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class ContasAReceber
{
    public long Id { get; set; }

    public DateTime DataCompetencia { get; set; }

    public DateTime DataConta { get; set; }

    public DateTime DataVencimento { get; set; }

    public double Valor { get; set; }

    public int? Parcela { get; set; }

    public char Status { get; set; }

    public long IdVenda { get; set; }

    public long IdPessoa { get; set; }

    public virtual Pessoa? Pessoa { get; set; }

    public virtual Venda? Venda { get; set; }
}

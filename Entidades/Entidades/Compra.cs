using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class Compra
{
    public long Id { get; set; }

    public DateTime DataCompra { get; set; }

    public int? Parcelas { get; set; }

    public double ValorTotal { get; set; }

    public long IdPessoa { get; set; }

    public long IdUsuario { get; set; }

    public long IdTipoPagamento { get; set; }

    public virtual ICollection<ContasAPagar>? ContasAPagar { get; set; }

    public virtual Pessoa? Pessoa { get; set; } = null!;

    public virtual TipoPagamento? TipoPagamento { get; set; } 

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<ItensCompra>? ItensCompra { get; set; }
}

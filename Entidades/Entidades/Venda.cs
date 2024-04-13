using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class Venda
{
    public long Id { get; set; }

    public DateTime? DataVenda { get; set; }

    public int? Parcelas { get; set; }

    public long IdUsuario { get; set; }

    public long IdPessoa { get; set; }

    public double ValorTotal { get; set; }

    public long IdTipoPagamento { get; set; }

    public DateTime? DataPedido { get; set; }

    public char Status { get; set; }

    public bool? EhAreaPublica { get; set; }

    public bool? EhDelivery { get; set; }

    public long IdMesa { get; set; }

    public virtual ICollection<ContasAReceber>? ContasAReceber { get; set; }

    public virtual Mesa? Mesa { get; set; }

    public virtual Pessoa? Pessoa { get; set; }

    public virtual TipoPagamento? TipoPagamento { get; set; }

    public virtual Usuario? Usuario { get; set; } 

    public virtual ICollection<ItensVenda>? ItensVenda { get; set; }
}

using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class VendaDto
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

    public virtual ICollection<ContasAReceberDto>? ContasAReceber { get; set; }

    public virtual MesaDto? Mesa { get; set; }

    public virtual PessoaDto? Pessoa { get; set; }

    public virtual TipoPagamentoDto? TipoPagamento { get; set; }

    public virtual UsuarioDto? Usuario { get; set; } 

    public virtual ICollection<ItensVendaDto>? ItensVenda { get; set; }
}

using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class CompraDto
{
    public long Id { get; set; }

    public DateTime DataCompra { get; set; }

    public int? Parcelas { get; set; }

    public double ValorTotal { get; set; }

    public long IdPessoa { get; set; }

    public long IdUsuario { get; set; }

    public long IdTipoPagamento { get; set; }

    public virtual ICollection<ContasAPagarDto>? ContasAPagar { get; set; }

    public virtual PessoaDto? Pessoa { get; set; } = null!;

    public virtual TipoPagamentoDto? TipoPagamento { get; set; } 

    public virtual UsuarioDto? Usuario { get; set; }

    public virtual ICollection<ItensCompraDto>? ItensCompra { get; set; }
}

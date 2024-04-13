using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class TipoPagamentoDto
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? Juros { get; set; }

    public virtual ICollection<CompraDto>? Compras { get; set; }

    public virtual ICollection<VendaDto>? Venda { get; set; }
}

using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class TipoPagamento
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? Juros { get; set; }

    public virtual ICollection<Compra>? Compras { get; set; }

    public virtual ICollection<Venda>? Venda { get; set; }
}

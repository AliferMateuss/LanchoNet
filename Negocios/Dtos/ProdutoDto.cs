using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class ProdutoDto
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    public virtual ICollection<ItensCompraDto>? ItensCompras { get; set; }

    public virtual ICollection<ItensVendaDto>? ItensVenda { get; set; }
}

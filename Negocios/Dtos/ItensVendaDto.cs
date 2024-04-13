using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class ItensVendaDto
{
    public long Id { get; set; }

    public long IdVenda { get; set; }

    public long IdProduto { get; set; }

    public double PrecoUnitario { get; set; }

    public int Quantidade { get; set; }

    public double SubTotal { get; set; }

    public char? Status { get; set; }

    public virtual ProdutoDto? Produto { get; set; }

    public virtual VendaDto? Venda { get; set; }
}

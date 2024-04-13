using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class ItensCompra
{
    public long Id { get; set; }

    public long IdCompra { get; set; }

    public long IdProduto { get; set; }

    public double PrecoUnitario { get; set; }

    public int Quantidade { get; set; }

    public double SubTotal { get; set; }

    public virtual Compra? Compra { get; set; }

    public virtual Produto? Produto { get; set; }
}

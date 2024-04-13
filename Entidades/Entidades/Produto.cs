﻿using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class Produto
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    public virtual ICollection<ItensCompra>? ItensCompras { get; set; }

    public virtual ICollection<ItensVenda>? ItensVenda { get; set; }
}
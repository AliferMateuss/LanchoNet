using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class ContasAPagar
{
    public long Id { get; set; }

    public DateTime DataCompetencia { get; set; }

    public DateTime DataConta { get; set; }

    public DateTime DataVencimento { get; set; }

    public long IdFornecedor { get; set; }

    public long IdCompra { get; set; }

    public virtual Compra? Compra { get; set; }
}

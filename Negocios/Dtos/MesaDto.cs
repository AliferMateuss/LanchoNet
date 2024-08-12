using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class MesaDto
{
    public long? Id { get; set; }

    public int Numero { get; set; }

    public char? Status { get; set; }

    public int Capacidade { get; set; }

    public int? TotalPessoas { get; set; }

    public virtual ICollection<VendaDto>? Venda { get; set; }
}

using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

/// <summary>
/// Unidades Federativas
/// </summary>
public partial class EstadoDto
{
    public long Id { get; set; }

    public string? Nome { get; set; }

    public string? Uf { get; set; }

    public int? Ibge { get; set; }

    public virtual ICollection<CidadeDto>? Cidades { get; set; }
}

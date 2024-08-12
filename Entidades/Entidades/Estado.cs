using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

/// <summary>
/// Unidades Federativas
/// </summary>
public partial class Estado
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Nome { get; set; }

    public string? Uf { get; set; }

    public int? Ibge { get; set; }

    public virtual ICollection<Cidade>? Cidades { get; set; }
}

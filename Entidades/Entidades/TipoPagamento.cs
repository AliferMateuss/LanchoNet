using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

public partial class TipoPagamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? Juros { get; set; }

    public virtual ICollection<Compra>? Compras { get; set; }

    public virtual ICollection<Venda>? Venda { get; set; }
}

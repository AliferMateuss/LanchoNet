﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

public partial class Compra
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public DateTime DataCompra { get; set; }

    public int? Parcelas { get; set; }

    public double ValorTotal { get; set; }
    public long IdUsuario { get; set; }
    public long IdPessoa { get; set; }
    public long IdTipoPagamento { get; set; }

    public virtual ICollection<ContasAPagar>? ContasAPagar { get; set; }

    [ForeignKey("IdPessoa")]
    public virtual Pessoa? Pessoa { get; set; } = null!;
    [ForeignKey("IdTipoPagamento")]
    public virtual TipoPagamento? TipoPagamento { get; set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<ItensCompra>? ItensCompra { get; set; }
}

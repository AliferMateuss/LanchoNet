using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

public partial class ItensCompra
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }


    public long IdCompra { get; set; }


    public long IdProduto { get; set; }

    public double PrecoUnitario { get; set; }

    public int Quantidade { get; set; }

    public double SubTotal { get; set; }

    [ForeignKey("IdCompra")]
    public virtual Compra? Compra { get; set; }

    [ForeignKey("IdProduto")]
    public virtual Produto? Produto { get; set; }
}

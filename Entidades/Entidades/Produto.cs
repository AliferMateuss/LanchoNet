using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Entidades;

public partial class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Quantidade { get; set; }

    public double Preco { get; set; }
    public double PrecoCompra { get; set; }
    public byte[]? Imagem { get; set; }

    public virtual ICollection<ItensCompra>? ItensCompras { get; set; }

    public virtual ICollection<ItensVenda>? ItensVenda { get; set; }
}

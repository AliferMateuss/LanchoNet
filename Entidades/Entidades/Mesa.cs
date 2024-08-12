using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

public partial class Mesa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public int Numero { get; set; }

    public char Status { get; set; }

    public int Capacidade { get; set; }

    public int TotalPessoas { get; set; }

    public virtual ICollection<Venda>? Venda { get; set; }
}

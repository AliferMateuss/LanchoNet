using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Entidades;

public partial class GrupoUsuario
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Usuario>? Usuarios { get; set; }
}

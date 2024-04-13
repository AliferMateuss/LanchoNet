using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class GrupoUsuario
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Usuario>? Usuarios { get; set; }
}

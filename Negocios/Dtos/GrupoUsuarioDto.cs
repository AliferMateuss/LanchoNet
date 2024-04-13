using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class GrupoUsuarioDto
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<UsuarioDto>? Usuarios { get; set; }
}

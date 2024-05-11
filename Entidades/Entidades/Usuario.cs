using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class Usuario
{
    public long Id { get; set; }

    public string UsuarioNome { get; set; }

    public string Senha { get; set; }

    public long IdPessoa { get; set; }

    public long IdGrupoUsuario { get; set; }

    public DateTime DataSenha { get; set; }

    public virtual ICollection<Compra>? Compras { get; set; }

    public virtual GrupoUsuario? GrupoUsuario { get; set; }

    public virtual Pessoa? Pessoa { get; set; }

    public virtual ICollection<Venda>? Venda { get; set; }
}

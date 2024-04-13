using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class UsuarioDto
{
    public long Id { get; set; }

    public string Usuario { get; set; }

    public string Senha { get; set; }

    public long IdPessoa { get; set; }

    public long IdGrupoUsuario { get; set; }

    public DateTime DataSenha { get; set; }

    public virtual ICollection<CompraDto>? Compras { get; set; }

    public virtual GrupoUsuarioDto? GrupoUsuario { get; set; }

    public virtual PessoaDto? Pessoa { get; set; }

    public virtual ICollection<VendaDto>? Venda { get; set; }
}

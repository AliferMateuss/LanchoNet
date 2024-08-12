using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades;

public partial class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string UsuarioNome { get; set; }

    public string Senha { get; set; }
    public long IdPessoa { get; set; }
    public long IdGrupoUsuario { get; set; } 

    public DateTime DataSenha { get; set; }

    public virtual ICollection<Compra>? Compras { get; set; }

    [ForeignKey("IdGrupoUsuario")]
    public virtual GrupoUsuario? GrupoUsuario { get; set; }
    [ForeignKey("IdPessoa")]
    public virtual Pessoa? Pessoa { get; set; }

    public virtual ICollection<Venda>? Venda { get; set; }
}

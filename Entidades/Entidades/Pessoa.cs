using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class Pessoa
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string? Telefone1 { get; set; }

    public string? Telefone2 { get; set; }

    public char TipoPessoa { get; set; }

    public string Email { get; set; } = null!;

    public string? Cpf { get; set; }

    public string? Cnpj { get; set; }

    public string? Ie { get; set; }

    public string? Rg { get; set; }

    public string? RazaoSocial { get; set; }

    public bool Ativo { get; set; }

    public double? Salario { get; set; }

    public string? Cargo { get; set; }

    public string? Pis { get; set; }

    public virtual ICollection<Compra>? Compras { get; set; }

    public virtual ICollection<ContasAReceber>? ContasAReceber { get; set; }

    public virtual ICollection<Endereco>? Enderecos { get; set; }

    public virtual ICollection<Usuario>? Usuarios { get; set; }

    public virtual ICollection<Venda>? Venda { get; set; }
}

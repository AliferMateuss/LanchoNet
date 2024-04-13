using System;
using System.Collections.Generic;

namespace Entidades.Entidades;

public partial class Endereco
{
    public long Id { get; set; }

    public long IdPessoa { get; set; }

    public long IdCidade { get; set; }

    public int? Cep { get; set; }

    public string Rua { get; set; } = null!;

    public int Numero { get; set; }

    public string Complemento { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public virtual Cidade? Cidade { get; set; } = null!;

    public virtual Pessoa? Pessoa { get; set; } = null!;
}

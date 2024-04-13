using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Entidades.Entidades;

public partial class Cidade
{
    public long Id { get; set; }

    public string? Nome { get; set; }

    public int? Ibge { get; set; }

    public NpgsqlPoint? LatLon { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
    public short? CodTom { get; set; }

    public long? Idestado { get; set; }

    public virtual ICollection<Endereco>? Enderecos { get; set; } = new List<Endereco>();

    public virtual Estado? IdestadoNavigation { get; set; }
}

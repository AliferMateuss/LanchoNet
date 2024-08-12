using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;

namespace Entidades.Entidades;

[Table("Cidade")]
public partial class Cidade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Nome { get; set; }

    public int? Ibge { get; set; }

    public NpgsqlPoint? LatLon { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
    public short? CodTom { get; set; }
    public long? EstadoId { get; set; }

    public virtual ICollection<Endereco>? Enderecos { get; set; } = new List<Endereco>();

    [ForeignKey("EstadoId")]
    public virtual Estado? Estado { get; set; }
}

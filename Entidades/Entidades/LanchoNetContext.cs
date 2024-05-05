using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entidades.Entidades;

public partial class LanchoNetContext : DbContext
{
    public LanchoNetContext()
    {
    }

    public LanchoNetContext(DbContextOptions<LanchoNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cidade> Cidades { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<ContasAPagar> ContasAPagar { get; set; }

    public virtual DbSet<ContasAReceber> ContasAReceber { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<GrupoUsuario> GrupoUsuarios { get; set; }

    public virtual DbSet<ItensCompra> ItensCompras { get; set; }

    public virtual DbSet<ItensVenda> ItensVenda { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=LanchoNet;Username=postgres;Password=sup01");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
        foreach (var property in keysProperties)
        {
            property.ValueGenerated = ValueGenerated.OnAdd;
        }

        modelBuilder.Entity<Cidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cidade_pkey");

            entity.ToTable("Cidade");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            entity.Property(e => e.CodTom)
                .HasDefaultValueSql("0")
                .HasComment("Código TOM (SEFAZ)")
                .HasColumnName("CodTom");
            entity.Property(e => e.Ibge).HasColumnName("Ibge");
            entity.Property(e => e.EstadoId).HasColumnName("IdEstado");
            entity.Property(e => e.LatLon).HasColumnName("LatLon");
            entity.Property(e => e.Latitude).HasColumnName("Latitude");
            entity.Property(e => e.Longitude).HasColumnName("Longitude");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .HasColumnName("Nome");

            entity.HasOne(d => d.Estado).WithMany(p => p.Cidades)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("fk_cidade_estado");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Compra_pkey");

            entity.ToTable("Compra");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Compra_IdPessoa_fkey");

            entity.HasOne(d => d.TipoPagamento).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdTipoPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Compra_IdTipoPagamento_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Compra_IdUsuario_fkey");
        });

        modelBuilder.Entity<ContasAPagar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ContasAPagar_pkey");

            entity.ToTable("ContasAPagar");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Compra).WithMany(p => p.ContasAPagar)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ContasAPagar_IdCompra_fkey");
        });

        modelBuilder.Entity<ContasAReceber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ContasAReceber_pkey");

            entity.ToTable("ContasAReceber");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).HasColumnType("char");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.ContasAReceber)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ContasAReceber_IdPessoa_fkey");

            entity.HasOne(d => d.Venda).WithMany(p => p.ContasAReceber)
                .HasForeignKey(d => d.IdVenda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ContasAReceber_IdVenda_fkey");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("endereco_pkey");

            entity.ToTable("Endereco");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Bairro).HasMaxLength(50);
            entity.Property(e => e.Cep).HasColumnName("CEP");
            entity.Property(e => e.Complemento).HasMaxLength(100);
            entity.Property(e => e.Rua).HasMaxLength(100);

            entity.HasOne(d => d.Cidade).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.IdCidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdCidade");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdPessoa");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estado_pkey");

            entity.ToTable("Estado", tb => tb.HasComment("Unidades Federativas"));

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            entity.Property(e => e.Ibge).HasColumnName("Ibge");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .HasColumnName("Nome");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("Uf");
        });

        modelBuilder.Entity<GrupoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("GrupoUsuario_pkey");

            entity.ToTable("GrupoUsuario");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<ItensCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ItensCompra_pkey");

            entity.ToTable("ItensCompra");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Compra).WithMany(p => p.ItensCompra)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ItensCompra_IdCompra_fkey");

            entity.HasOne(d => d.Produto).WithMany(p => p.ItensCompras)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ItensCompra_IdProduto_fkey");
        });

        modelBuilder.Entity<ItensVenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ItensVenda_pkey");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).HasColumnType("char");

            entity.HasOne(d => d.Produto).WithMany(p => p.ItensVenda)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ItensVenda_IdProduto_fkey");

            entity.HasOne(d => d.Venda).WithMany(p => p.ItensVenda)
                .HasForeignKey(d => d.IdVenda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ItensVenda_IdVenda_fkey");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Mesa_pkey");

            entity.ToTable("Mesa");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).HasColumnType("char");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Cargo).HasColumnType("character varying");
            entity.Property(e => e.Cnpj)
                .HasColumnType("character varying")
                .HasColumnName("CNPJ");
            entity.Property(e => e.Cpf)
                .HasColumnType("character varying")
                .HasColumnName("CPF");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Ie)
                .HasColumnType("character varying")
                .HasColumnName("IE");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Pis)
                .HasColumnType("character varying")
                .HasColumnName("PIS");
            entity.Property(e => e.RazaoSocial).HasColumnType("character varying");
            entity.Property(e => e.Rg)
                .HasColumnType("character varying")
                .HasColumnName("RG");
            entity.Property(e => e.Telefone1).HasMaxLength(15);
            entity.Property(e => e.Telefone2).HasMaxLength(15);
            entity.Property(e => e.Cliente);
            entity.Property(e => e.Fornecedor);
            entity.Property(e => e.Funcionario);
            entity.HasMany(p => p.Enderecos)
        .WithOne(e => e.Pessoa)
        .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Produto_pkey");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TipoPagamento_pkey");

            entity.ToTable("TipoPagamento");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usuario_pkey");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Senha).HasMaxLength(100);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.GrupoUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdGrupoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuario_IdGrupoUsuario_fkey");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdPessoa");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Venda_pkey");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IdMesa).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).HasColumnType("char");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Venda)
                .HasForeignKey(d => d.IdMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Venda_IdMesa_fkey");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Venda)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Venda_IdPessoa_fkey");

            entity.HasOne(d => d.TipoPagamento).WithMany(p => p.Venda)
                .HasForeignKey(d => d.IdTipoPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Venda_IdTipoPagamento_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venda)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Venda_IdUsuario_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

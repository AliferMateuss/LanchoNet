﻿// <auto-generated />
using System;
using Entidades.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace Entidades.Migrations
{
    [DbContext(typeof(PostgresContexto))]
    partial class PostgresContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entidades.Entidades.Cidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<short?>("CodTom")
                        .HasColumnType("smallint");

                    b.Property<long?>("EstadoId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Ibge")
                        .HasColumnType("integer");

                    b.Property<NpgsqlPoint?>("LatLon")
                        .HasColumnType("point");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Entidades.Entidades.Compra", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTipoPagamento")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<int?>("Parcelas")
                        .HasColumnType("integer");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdTipoPagamento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Entidades.Entidades.ContasAPagar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCompetencia")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataConta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("IdCompra")
                        .HasColumnType("bigint");

                    b.Property<long>("IdFornecedor")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<int?>("Parcela")
                        .HasColumnType("integer");

                    b.Property<char>("Status")
                        .HasColumnType("character(1)");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdFornecedor");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ContaAPagar");
                });

            modelBuilder.Entity("Entidades.Entidades.ContasAReceber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCompetencia")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataConta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<long>("IdVenda")
                        .HasColumnType("bigint");

                    b.Property<int?>("Parcela")
                        .HasColumnType("integer");

                    b.Property<char>("Status")
                        .HasColumnType("character(1)");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdVenda");

                    b.ToTable("ContaAReceber");
                });

            modelBuilder.Entity("Entidades.Entidades.Endereco", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Cep")
                        .HasColumnType("integer");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<long?>("IdCidade")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Entidades.Entidades.Estado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("Ibge")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Uf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Entidades.Entidades.GrupoUsuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GrupoUsuario");
                });

            modelBuilder.Entity("Entidades.Entidades.ItensCompra", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCompra")
                        .HasColumnType("bigint");

                    b.Property<long>("IdProduto")
                        .HasColumnType("bigint");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<double>("SubTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItensCompra");
                });

            modelBuilder.Entity("Entidades.Entidades.ItensVenda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdProduto")
                        .HasColumnType("bigint");

                    b.Property<long>("IdVenda")
                        .HasColumnType("bigint");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<char?>("Status")
                        .HasColumnType("character(1)");

                    b.Property<double>("SubTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdVenda");

                    b.ToTable("ItensVendas");
                });

            modelBuilder.Entity("Entidades.Entidades.Mesa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<char>("Status")
                        .HasColumnType("character(1)");

                    b.Property<int>("TotalPessoas")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Mesa");
                });

            modelBuilder.Entity("Entidades.Entidades.Pessoa", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Cargo")
                        .HasColumnType("text");

                    b.Property<bool>("Cliente")
                        .HasColumnType("boolean");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Fornecedor")
                        .HasColumnType("boolean");

                    b.Property<bool>("Funcionario")
                        .HasColumnType("boolean");

                    b.Property<string>("Ie")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Pis")
                        .HasColumnType("text");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text");

                    b.Property<string>("Rg")
                        .HasColumnType("text");

                    b.Property<double?>("Salario")
                        .HasColumnType("double precision");

                    b.Property<string>("Telefone1")
                        .HasColumnType("text");

                    b.Property<string>("Telefone2")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Entidades.Entidades.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("bytea");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.Property<double>("PrecoCompra")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Entidades.Entidades.TipoPagamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("Juros")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoPagamento");
                });

            modelBuilder.Entity("Entidades.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataSenha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("IdGrupoUsuario")
                        .HasColumnType("bigint");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdGrupoUsuario");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entidades.Entidades.Venda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataPedido")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataVenda")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("EhAreaPublica")
                        .HasColumnType("boolean");

                    b.Property<bool?>("EhDelivery")
                        .HasColumnType("boolean");

                    b.Property<long>("IdMesa")
                        .HasColumnType("bigint");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTipoPagamento")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<int?>("Parcelas")
                        .HasColumnType("integer");

                    b.Property<char>("Status")
                        .HasColumnType("character(1)");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdMesa");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdTipoPagamento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Entidades.Entidades.Cidade", b =>
                {
                    b.HasOne("Entidades.Entidades.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Entidades.Entidades.Compra", b =>
                {
                    b.HasOne("Entidades.Entidades.Pessoa", "Pessoa")
                        .WithMany("Compras")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.TipoPagamento", "TipoPagamento")
                        .WithMany("Compras")
                        .HasForeignKey("IdTipoPagamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Usuario", "Usuario")
                        .WithMany("Compras")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("TipoPagamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entidades.Entidades.ContasAPagar", b =>
                {
                    b.HasOne("Entidades.Entidades.Compra", "Compra")
                        .WithMany("ContasAPagar")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Pessoa", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("IdPessoa");

                    b.HasOne("Entidades.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Fornecedor");

                    b.Navigation("Pessoa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entidades.Entidades.ContasAReceber", b =>
                {
                    b.HasOne("Entidades.Entidades.Pessoa", "Pessoa")
                        .WithMany("ContasAReceber")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Venda", "Venda")
                        .WithMany("ContasAReceber")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Usuario");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Entidades.Entidades.Endereco", b =>
                {
                    b.HasOne("Entidades.Entidades.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdCidade");

                    b.HasOne("Entidades.Entidades.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cidade");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Entidades.Entidades.ItensCompra", b =>
                {
                    b.HasOne("Entidades.Entidades.Compra", "Compra")
                        .WithMany("ItensCompra")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Produto", "Produto")
                        .WithMany("ItensCompras")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Entidades.Entidades.ItensVenda", b =>
                {
                    b.HasOne("Entidades.Entidades.Produto", "Produto")
                        .WithMany("ItensVenda")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Venda", "Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Entidades.Entidades.Usuario", b =>
                {
                    b.HasOne("Entidades.Entidades.GrupoUsuario", "GrupoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdGrupoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Pessoa", "Pessoa")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoUsuario");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Entidades.Entidades.Venda", b =>
                {
                    b.HasOne("Entidades.Entidades.Mesa", "Mesa")
                        .WithMany("Venda")
                        .HasForeignKey("IdMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Pessoa", "Pessoa")
                        .WithMany("Venda")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.TipoPagamento", "TipoPagamento")
                        .WithMany("Venda")
                        .HasForeignKey("IdTipoPagamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Entidades.Usuario", "Usuario")
                        .WithMany("Venda")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");

                    b.Navigation("Pessoa");

                    b.Navigation("TipoPagamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entidades.Entidades.Cidade", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("Entidades.Entidades.Compra", b =>
                {
                    b.Navigation("ContasAPagar");

                    b.Navigation("ItensCompra");
                });

            modelBuilder.Entity("Entidades.Entidades.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("Entidades.Entidades.GrupoUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entidades.Entidades.Mesa", b =>
                {
                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Entidades.Entidades.Pessoa", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("ContasAReceber");

                    b.Navigation("Enderecos");

                    b.Navigation("Usuarios");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Entidades.Entidades.Produto", b =>
                {
                    b.Navigation("ItensCompras");

                    b.Navigation("ItensVenda");
                });

            modelBuilder.Entity("Entidades.Entidades.TipoPagamento", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Entidades.Entidades.Usuario", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Entidades.Entidades.Venda", b =>
                {
                    b.Navigation("ContasAReceber");

                    b.Navigation("ItensVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
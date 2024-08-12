using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace Entidades.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: true),
                    Ibge = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<char>(type: "character(1)", nullable: false),
                    Capacidade = table.Column<int>(type: "integer", nullable: false),
                    TotalPessoas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Telefone1 = table.Column<string>(type: "text", nullable: true),
                    Telefone2 = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    Ie = table.Column<string>(type: "text", nullable: true),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Cliente = table.Column<bool>(type: "boolean", nullable: false),
                    Fornecedor = table.Column<bool>(type: "boolean", nullable: false),
                    Funcionario = table.Column<bool>(type: "boolean", nullable: false),
                    Salario = table.Column<double>(type: "double precision", nullable: true),
                    Cargo = table.Column<string>(type: "text", nullable: true),
                    Pis = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    PrecoCompra = table.Column<double>(type: "double precision", nullable: false),
                    Imagem = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Juros = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Ibge = table.Column<int>(type: "integer", nullable: true),
                    LatLon = table.Column<NpgsqlPoint>(type: "point", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    CodTom = table.Column<short>(type: "smallint", nullable: true),
                    EstadoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioNome = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    IdGrupoUsuario = table.Column<long>(type: "bigint", nullable: false),
                    DataSenha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_GrupoUsuario_IdGrupoUsuario",
                        column: x => x.IdGrupoUsuario,
                        principalTable: "GrupoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: true),
                    IdCidade = table.Column<long>(type: "bigint", nullable: true),
                    Cep = table.Column<int>(type: "integer", nullable: true),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Parcelas = table.Column<int>(type: "integer", nullable: true),
                    ValorTotal = table.Column<double>(type: "double precision", nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoPagamento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_TipoPagamento_IdTipoPagamento",
                        column: x => x.IdTipoPagamento,
                        principalTable: "TipoPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Parcelas = table.Column<int>(type: "integer", nullable: true),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    ValorTotal = table.Column<double>(type: "double precision", nullable: false),
                    IdTipoPagamento = table.Column<long>(type: "bigint", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<char>(type: "character(1)", nullable: false),
                    EhAreaPublica = table.Column<bool>(type: "boolean", nullable: true),
                    EhDelivery = table.Column<bool>(type: "boolean", nullable: true),
                    IdMesa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Mesa_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "Mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_TipoPagamento_IdTipoPagamento",
                        column: x => x.IdTipoPagamento,
                        principalTable: "TipoPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaAPagar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCompetencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataConta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Parcela = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<char>(type: "character(1)", nullable: false),
                    IdFornecedor = table.Column<long>(type: "bigint", nullable: false),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: true),
                    IdCompra = table.Column<long>(type: "bigint", nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaAPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaAPagar_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaAPagar_Pessoas_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaAPagar_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContaAPagar_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensCompra",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCompra = table.Column<long>(type: "bigint", nullable: false),
                    IdProduto = table.Column<long>(type: "bigint", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "double precision", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCompra_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCompra_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaAReceber",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCompetencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataConta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Parcela = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<char>(type: "character(1)", nullable: false),
                    IdVenda = table.Column<long>(type: "bigint", nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaAReceber_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaAReceber_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaAReceber_Vendas_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensVendas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVenda = table.Column<long>(type: "bigint", nullable: false),
                    IdProduto = table.Column<long>(type: "bigint", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "double precision", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<char>(type: "character(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVendas_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensVendas_Vendas_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdPessoa",
                table: "Compras",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdTipoPagamento",
                table: "Compras",
                column: "IdTipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdUsuario",
                table: "Compras",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAPagar_IdCompra",
                table: "ContaAPagar",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAPagar_IdFornecedor",
                table: "ContaAPagar",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAPagar_IdPessoa",
                table: "ContaAPagar",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAPagar_IdUsuario",
                table: "ContaAPagar",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAReceber_IdPessoa",
                table: "ContaAReceber",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAReceber_IdUsuario",
                table: "ContaAReceber",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ContaAReceber_IdVenda",
                table: "ContaAReceber",
                column: "IdVenda");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCidade",
                table: "Enderecos",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdPessoa",
                table: "Enderecos",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_IdCompra",
                table: "ItensCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_IdProduto",
                table: "ItensCompra",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_IdProduto",
                table: "ItensVendas",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_IdVenda",
                table: "ItensVendas",
                column: "IdVenda");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdGrupoUsuario",
                table: "Usuarios",
                column: "IdGrupoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPessoa",
                table: "Usuarios",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdMesa",
                table: "Vendas",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdPessoa",
                table: "Vendas",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdTipoPagamento",
                table: "Vendas",
                column: "IdTipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdUsuario",
                table: "Vendas",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaAPagar");

            migrationBuilder.DropTable(
                name: "ContaAReceber");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "ItensCompra");

            migrationBuilder.DropTable(
                name: "ItensVendas");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "TipoPagamento");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "GrupoUsuario");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}

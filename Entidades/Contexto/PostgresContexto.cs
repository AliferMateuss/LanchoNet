using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Contexto
{
    public class PostgresContexto : DbContext
    {
        private static string _server = "localhost";
        private static string _database = "LanchoNet";
        private static string _username = "postgres";
        private static string _password = "sup01";

        private static string connectionString = $@"Host={_server};Database={_database};Username={_username};Password={_password}";

        public PostgresContexto() : base()
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<TipoPagamento> TipoPagamento { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItensVenda> ItensVendas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItensCompra> ItensCompra { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<ContasAPagar> ContaAPagar { get; set; }
        public DbSet<ContasAReceber> ContaAReceber { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasMany(c => c.Venda)
                .WithOne(v => v.Pessoa)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
              .HasMany(c => c.ItensVenda)
              .WithOne(v => v.Venda)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
                .HasMany(c => c.ContasAReceber)
                .WithOne(v => v.Venda)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

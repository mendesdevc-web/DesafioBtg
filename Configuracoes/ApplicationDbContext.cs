using DesafioBTG.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DesafioBTG.Configuracoes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Fundo> Fundos { get; set; }
        public DbSet<Aplicacao> Aplicacoes { get; set; }
        public DbSet<Resgate> Resgates { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chaves primárias
            modelBuilder.Entity<Fundo>()
                .HasKey(f => f.IdFundo);

            // Relacionamento Fundo - Aplicacao
            modelBuilder.Entity<Aplicacao>()
                .HasOne(a => a.Fundo)
                .WithMany(f => f.Aplicacoes)
                .HasForeignKey(a => a.FundoId);

            // Relacionamento Cliente - Aplicacao
            modelBuilder.Entity<Aplicacao>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Aplicacoes)
                .HasForeignKey(a => a.ClienteId);

            // Relacionamento Fundo - Resgate
            modelBuilder.Entity<Resgate>()
                .HasOne(r => r.Fundo)
                .WithMany(f => f.Resgates)
                .HasForeignKey(r => r.FundoId);

            // Relacionamento Cliente - Resgate
            modelBuilder.Entity<Resgate>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Resgates)
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<Aplicacao>()
                .Property(a => a.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Resgate>()
                .Property(r => r.ImpostoDeRenda)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Resgate>()
                .Property(r => r.ValorResgate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Resgate>()
                .Property(r => r.ValorLiquido)
                .HasColumnType("decimal(18,2)");



            modelBuilder.Entity<Fundo>().HasData(
                new Fundo("Fundo de investimento A") { IdFundo = 1 },
                new Fundo("Fundo de investimento A") { IdFundo = 2 },
                new Fundo("Fundo de investimento A") { IdFundo = 3 });

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente(id:1, nome:"Mendes"),
                new Cliente(id: 2, nome: "Matheus"),
                new Cliente(id: 3, nome: "Marlyson"));

        }
    }
}

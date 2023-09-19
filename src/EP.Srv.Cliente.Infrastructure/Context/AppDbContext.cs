using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace EP.Srv.Cliente.Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Domain.Entities.Cliente> Clientes { get; set; } = null!;
        public DbSet<Domain.Entities.Empresa> Empresa { get; set; } = null!;
        public DbSet<Domain.Entities.Banco> Bancos { get; set; } = null!;
        public DbSet<Domain.Entities.FormaPagamento> FormaPagamentos { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public async Task SaveAsync()
        {
            await this.SaveChangesAsync();
        }

        public void DetectChanges()
        {
            this.ChangeTracker.DetectChanges();
        }

        public void EntryChanges<TEntity>([NotNull] TEntity entity, object currentValues)
        {
            this.Entry(entity!).CurrentValues.SetValues(currentValues);
        }

        public EntityEntry EntryChanges<TEntity>([NotNull] TEntity entity) => Entry(entity: entity);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().ToTable("Empresas");
            modelBuilder.Entity<Empresa>().HasKey(l => l.Id);
            modelBuilder.Entity<Empresa>().Property(l => l.Id).UseMySqlIdentityColumn();

            modelBuilder.Entity<Domain.Entities.Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Domain.Entities.Cliente>().HasKey(l => l.Id);
            modelBuilder.Entity<Domain.Entities.Cliente>().Property(l => l.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<Domain.Entities.Cliente>().HasOne(l => l.Empresa).WithMany(a => a.Clientes);

            modelBuilder.Entity<Domain.Entities.Banco>().ToTable("Bancos");
            modelBuilder.Entity<Domain.Entities.Banco>().HasKey(l => l.Id);
            modelBuilder.Entity<Domain.Entities.Banco>().Property(l => l.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<Domain.Entities.Banco>().HasOne(l => l.Empresa).WithMany(a => a.Bancos);

            modelBuilder.Entity<Domain.Entities.FormaPagamento>().ToTable("FormasPagamentos");
            modelBuilder.Entity<Domain.Entities.FormaPagamento>().HasKey(l => l.Id);
            modelBuilder.Entity<Domain.Entities.FormaPagamento>().Property(l => l.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<Domain.Entities.FormaPagamento>().HasOne(l => l.Empresa).WithMany(a => a.FormaPagamentos);
        }
    }
}

using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace EP.Srv.Cliente.Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        //public DbSet<ImpConsorcioHistorico> ConsorcioHistorico { get; set; } = null!;
        

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

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

        public EntityEntry EntryChanges<TEntity>([NotNull] TEntity entity) => Entry(entity: entity!);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<LayoutArquivo>().ToTable("LayoutArquivo");
            //modelBuilder.Entity<LayoutArquivo>().HasKey(l => l.Id);
            //modelBuilder.Entity<LayoutArquivo>().Property(l => l.Id).UseMySqlIdentityColumn();
        }
    }
}

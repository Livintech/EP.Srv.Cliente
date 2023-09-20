using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Domain.Entities.Cliente> Clientes { get; set; }
        DbSet<Domain.Entities.Empresa> Empresa { get; set; }
        DbSet<Domain.Entities.Banco> Bancos { get; set; }
        DbSet<Domain.Entities.FormaPagamento> FormaPagamentos { get; set; }
        DbSet<Domain.Entities.CentroCustos> CentroCustos { get; set; }
        DbSet<Domain.Entities.ProdutosServicos> ProdutosServicos { get; set; }

        Task SaveAsync();
        void DetectChanges();
        void EntryChanges<TEntity>([NotNull] TEntity entity, object currentValues);
        EntityEntry EntryChanges<TEntity>([NotNull] TEntity entity);
        DatabaseFacade Database { get; }
    }
}

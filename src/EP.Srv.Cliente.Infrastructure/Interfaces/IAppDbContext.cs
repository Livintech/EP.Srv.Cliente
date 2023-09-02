using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IAppDbContext
    {
        Task SaveAsync();
        void DetectChanges();
        void EntryChanges<TEntity>([NotNull] TEntity entity, object currentValues);
        EntityEntry EntryChanges<TEntity>([NotNull] TEntity entity);
        DatabaseFacade Database { get; }
    }
}

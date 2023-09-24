using EP.Srv.Cliente.Domain.Entities;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IPlanoDeContasRepository
    {
        Task<IEnumerable<PlanoContas>> ListarPlanoDeContasAsync();
        Task<PlanoContas> GravarPlanoDeContasAsync(PlanoContas planoContas);
        Task<PlanoContas> AtualizarPlanoDeContasAsync(PlanoContas planoContas);
    }
}

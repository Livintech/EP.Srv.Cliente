using EP.Srv.Cliente.Domain.Entities;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IContasPagarRepository
    {
        Task<ContasPagar> CadastrarLancamentoAsync(ContasPagar contasPagar);
        Task<ContasPagar> AtualizarLancamentoAsync(ContasPagar contasPagar);
        Task<IEnumerable<ContasPagar>> ListarLancamentosAsync();
    }
}

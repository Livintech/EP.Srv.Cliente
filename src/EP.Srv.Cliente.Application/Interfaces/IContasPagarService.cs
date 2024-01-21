using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IContasPagarService
    {
        Task<BaseResponse> CadastrarLancamentoAsync(ContasPagar contasPagar);
        Task<BaseResponse> AtualizarLancamentoAsync(ContasPagar contasPagar);
        Task<BaseResponse> ListarLancamentosAsync();
    }
}

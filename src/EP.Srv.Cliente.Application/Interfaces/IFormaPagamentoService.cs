using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IFormaPagamentoService
    {
        Task<BaseResponse> CadastrarAsync(FormaPagamento formaPagamento);
        Task<BaseResponse> ListarFormasPagamentosAsync(string empresaId);
        Task<BaseResponse> AtualizaPagamentoAsync(FormaPagamento formaPagamento);
    }
}

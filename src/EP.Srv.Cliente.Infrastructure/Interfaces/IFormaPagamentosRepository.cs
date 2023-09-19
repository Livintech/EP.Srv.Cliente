using EP.Srv.Cliente.Domain.Entities;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IFormaPagamentosRepository
    {
        Task<FormaPagamento> CadastrarAsync(FormaPagamento formaPagamento);
        Task<IEnumerable<FormaPagamento>> ListarFormasPagamentosAsync();
        Task<FormaPagamento> AtualizaPagamentoAsync(FormaPagamento formaPagamento);
    }
}

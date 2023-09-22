using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IProdutosServicosService
    {
        Task<BaseResponse> AtualizarProdutosServicosAsync(ProdutosServicos produtosServicos);
        Task<BaseResponse> GravarPRodutosServicosAsync(ProdutosServicos produtosServicos);
        Task<BaseResponse> ListarProdutosServicosAsync(string empresaId);
    }
}

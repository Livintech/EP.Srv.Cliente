using EP.Srv.Cliente.Domain.Entities;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IProdutosServicosRepository
    {
        Task<ProdutosServicos> AtualizarProdutosServicosAsync(ProdutosServicos produtosServicos);
        Task<ProdutosServicos> GravarPRodutosServicosAsync(ProdutosServicos produtosServicos);
        Task<IEnumerable<ProdutosServicos>> ListarProdutosServicosAsync();
    }
}

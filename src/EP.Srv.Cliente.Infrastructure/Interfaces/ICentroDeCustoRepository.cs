using EP.Srv.Cliente.Domain.Entities;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface ICentroDeCustoRepository
    {
        Task<IEnumerable<CentroCustos>> ListarCentroCustoAsync();
        Task<CentroCustos> GravarCentroCustoAsync(CentroCustos centroCustos);
        Task<CentroCustos> AtualizaCentroCustoAsync(CentroCustos centroCustos);
    }
}

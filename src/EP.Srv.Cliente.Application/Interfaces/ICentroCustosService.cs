using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface ICentroCustosService
    {
        Task<BaseResponse> ListarCentroCustoAsync();
        Task<BaseResponse> GravarCentroCustoAsync(CentroCustos centroCustos);
        Task<BaseResponse> AtualizarCentroCustoAsync(CentroCustos centroCustos);
    }
}

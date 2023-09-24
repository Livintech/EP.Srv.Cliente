using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IPlanoDeContasService
    {
        Task<BaseResponse> ListarPlanoDeContasAsync(string codigoEmpresa);
        Task<BaseResponse> GravarPlanoDeContasAsync(PlanoContas planoContas);
        Task<BaseResponse> AtualizarPlanoDeContasAsync(PlanoContas planoContas);
    }
}

using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IBancoService
    {
        Task<BaseResponse> CadastrarBancoAsync(Banco banco);
        Task<BaseResponse> ObterBancoByIdAsunc(int id);
        Task<BaseResponse> ListarBancosAsync(string empresaId);
        Task<BaseResponse> AtualizarBancoAsync(Banco banco);
    }
}

using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResponse> AtualizarClienteAsync(Domain.Entities.Cliente cliente);
        Task<BaseResponse> CadastrarAsync(Domain.Entities.Cliente cliente);
        Task<BaseResponse> LiatarClientesAsync(string codigoEmpresa);
        Task<BaseResponse> LiatarEmpresasAsync();
    }
}

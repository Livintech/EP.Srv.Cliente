using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<BaseResponse> CadastrarEmpresaAsync(Empresa empresa);
        Task<BaseResponse> AtualizarEmpresaAsync(Empresa empresa);
        Task<BaseResponse> ListarEmpresasAsync(string codigoEmpresa);
    }
}

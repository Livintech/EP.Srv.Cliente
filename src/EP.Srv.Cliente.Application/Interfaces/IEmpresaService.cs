using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<BaseResponse> CadastrarAsync(Empresa empresa);
        Task<BaseResponse> ListarTodosAsync();
    }
}

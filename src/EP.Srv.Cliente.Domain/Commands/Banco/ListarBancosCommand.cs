using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Banco
{
    public class ListarBancosCommand : IRequest<BaseResponse>
    {
        public string EmpresaId { get; set; } = string.Empty;
    }
}

using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.CentroCusto
{
    public class ListarCentroCustoCommand : IRequest<BaseResponse>
    {
        public string EmpresaId { get; set; }
    }
}

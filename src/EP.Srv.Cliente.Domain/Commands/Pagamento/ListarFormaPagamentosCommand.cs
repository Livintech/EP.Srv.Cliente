using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Pagamento
{
    public class ListarFormaPagamentosCommand : IRequest<BaseResponse>
    {
        public string EmpresaId { get; set; }
    }
}

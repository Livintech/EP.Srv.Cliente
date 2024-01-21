using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.ContasPagar
{
    public class ListarLancamentoCommand : IRequest<BaseResponse>
    {
        public string CodigoEmpresa { get; set; } = string.Empty;
    }
}

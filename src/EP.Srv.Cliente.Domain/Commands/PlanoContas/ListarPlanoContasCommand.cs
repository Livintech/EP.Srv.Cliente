using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.PlanoContas
{
    public class ListarPlanoContasCommand : IRequest<BaseResponse>
    {
        public string CodigoEmpresa { get; set; } = string.Empty;
    }
}

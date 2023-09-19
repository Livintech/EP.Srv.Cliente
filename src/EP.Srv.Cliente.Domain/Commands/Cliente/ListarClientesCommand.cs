using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Cliente
{
    public class ListarClientesCommand : IRequest<BaseResponse>
    {
        public string CodigoEmpresa { get; set; } = string.Empty;
    }
}

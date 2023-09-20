using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.ProdutosServicos
{
    public class ListarProdutosServicosCommand : IRequest<BaseResponse>
    {
        public string EmpresaId { get; set; } = string.Empty;
    }
}

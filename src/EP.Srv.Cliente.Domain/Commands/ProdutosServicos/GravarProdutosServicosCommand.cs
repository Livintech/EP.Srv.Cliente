using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.ProdutosServicos
{
    public class GravarProdutosServicosCommand : IRequest<BaseResponse>
    {
        public string Descricao { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
    }
}

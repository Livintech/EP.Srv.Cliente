using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Pagamento
{
    public class CadastrarFormaPagamentosCommand : IRequest<BaseResponse>
    {
        public string Descricao { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
    }
}

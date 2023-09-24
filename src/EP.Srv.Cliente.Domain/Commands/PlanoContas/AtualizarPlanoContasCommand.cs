using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.PlanoContas
{
    public class AtualizarPlanoContasCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Natureza { get; set; } = string.Empty;
        public string TipoNatureza { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
    }
}

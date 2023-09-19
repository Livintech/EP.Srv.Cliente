using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Banco
{
    public class CadastroBancoCommand : IRequest<BaseResponse>
    {
        public int Codigo { get; set; }
        public string Instituicao { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public string Conta { get; set; } = string.Empty;
        public string SaldoInicial { get; set; } = string.Empty;
        public string DataSaldoInicial { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
    }
}

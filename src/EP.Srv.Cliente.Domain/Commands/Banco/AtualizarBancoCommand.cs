using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Banco
{
    public class AtualizarBancoCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Instituicao { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public int Conta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public DateTime DataSaldoInicio { get; set; }
        public bool Ativo { get; set; }
    }
}

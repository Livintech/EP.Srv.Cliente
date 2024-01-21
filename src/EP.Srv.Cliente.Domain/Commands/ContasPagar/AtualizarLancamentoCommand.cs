using EP.Srv.Cliente.Domain.Commands.Empresa;
using EP.Srv.Cliente.Domain.Responses;
using FluentValidation;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.ContasPagar
{
    public class AtualizarLancamentoCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string NumeroTitulo { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Vencimento { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime DtEmissao { get; set; }
        public DateTime DtLancamento { get; set; }

        public class AtualizarLancamentoValidator : AbstractValidator<AtualizarLancamentoCommand>
        {
            public AtualizarLancamentoValidator()
            {
                RuleFor(u => u.Id).NotEmpty()
                    .WithMessage("Id do lançamento é obrigatório.");
            }
        }
    }
}

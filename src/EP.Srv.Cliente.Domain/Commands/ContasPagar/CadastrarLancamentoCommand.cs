using EP.Srv.Cliente.Domain.Responses;
using FluentValidation;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.ContasPagar
{
    public class CadastrarLancamentoCommand : IRequest<BaseResponse>
    {
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string NumeroTitulo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Vencimento { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime DtEmissao { get; set; }
        public DateTime DtLancamento { get; set; }

        public class CadastrarLancamentoValidator : AbstractValidator<CadastrarLancamentoCommand>
        {
            public CadastrarLancamentoValidator()
            {
                RuleFor(u => u.CodigoEmpresa).NotEmpty()
                    .WithMessage("É necessário preencher o código da empresa.");
                RuleFor(u => u.NumeroTitulo).NotEmpty()
                    .WithMessage("É necessário preencher o número do título.");
                RuleFor(u => u.Nome).NotEmpty()
                    .WithMessage("É necessário preencher o nome do lançamento.");
                RuleFor(u => u.Valor).NotEmpty()
                    .WithMessage("É necessário preencher o valor do lançamento.");
                RuleFor(u => u.Vencimento).NotEmpty()
                    .WithMessage("É necessário preencher um vencimento válido.");
                RuleFor(u => u.Vencimento).NotEmpty()
                    .WithMessage("É necessário preencher uma data de emissão válido.");
                RuleFor(u => u.Vencimento).NotEmpty()
                    .WithMessage("É necessário preencher uma data de lançamento válido.");
            }
        }
    }
}

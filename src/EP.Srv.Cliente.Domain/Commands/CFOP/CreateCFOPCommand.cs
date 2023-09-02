using FluentValidation;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.CFOP
{
    public class CreateCFOPCommand : IRequest<BaseResponse>
    {
        public int Numeracao { get; set; }
        public string? Descricao { get; set; }
        public string EntradaSaida { get; set; }
        public string Credito { get; set; }

        public class CreateCFOPValidator : AbstractValidator<CreateCFOPCommand>
        {
            public CreateCFOPValidator()
            {
                RuleFor(u => u.Numeracao).NotEmpty()
                    .WithMessage("A numeração do CFOP é obrigatório");
                RuleFor(u => u.Descricao).NotEmpty()
                    .WithMessage("A descrição do CFOP é obrigatório");
                RuleFor(u => u.EntradaSaida).NotEmpty()
                    .WithMessage("O tipo de entrada é obrigatório");
                RuleFor(u => u.Credito).NotEmpty()
                    .WithMessage("O tipo de crédito é obrigatório");

            }
        }
    }
}

using EP.Srv.Cliente.Domain.Responses;
using FluentValidation;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Empresa
{
    public class CadastrarEmpresaCommand : IRequest<BaseResponse>
    {
        public string cpf { get; set; } = string.Empty;
        public string cnpj { get; set; } = string.Empty;
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty;
        public string cep { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string cidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public string complemento { get; set; } = string.Empty;
        public string numero { get; set; } = string.Empty;
        public string dataSituacao { get; set; } = string.Empty;
        public string tipo { get; set; } = string.Empty;
        public string nomeRazao { get; set; } = string.Empty;

        public class CadastrarEmpresaValidator : AbstractValidator<CadastrarEmpresaCommand>
        {
            //public CreateCFOPValidator()
            //{
            //    RuleFor(u => u.Numeracao).NotEmpty()
            //        .WithMessage("A numeração do CFOP é obrigatório");
            //    RuleFor(u => u.Descricao).NotEmpty()
            //        .WithMessage("A descrição do CFOP é obrigatório");
            //    RuleFor(u => u.EntradaSaida).NotEmpty()
            //        .WithMessage("O tipo de entrada é obrigatório");
            //    RuleFor(u => u.Credito).NotEmpty()
            //        .WithMessage("O tipo de crédito é obrigatório");

            //}
        }
    }
}

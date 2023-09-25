using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Empresa
{
    public class AtualizarEmpresaCommand : IRequest<BaseResponse>
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
        public string dataSituacao { get; set; } = string.Empty;
        public string tipo { get; set; } = string.Empty;
        public string nomeRazao { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public int? Numero { get; set; }
        public int Id { get; set; }
    }
}

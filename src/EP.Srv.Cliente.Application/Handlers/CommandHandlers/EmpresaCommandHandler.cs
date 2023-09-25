using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.Empresa;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class EmpresaCommandHandler : 
        IRequestHandler<CadastrarEmpresaCommand, BaseResponse>,
        IRequestHandler<ListarEmpresasCommand, BaseResponse>,
        IRequestHandler<AtualizarEmpresaCommand, BaseResponse>
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaCommandHandler(IEmpresaService empresaService)
            => _empresaService = empresaService;

        public async Task<BaseResponse> Handle(CadastrarEmpresaCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _empresaService.CadastrarEmpresaAsync(
                new Empresa
                {
                    NomeRazao = request.nomeRazao,
                    Cpf = request.cpf,
                    Cnpj = request.cnpj,
                    Telefone = request.telefone,
                    Email = request.email,
                    Endereco = request.endereco,
                    Cep = request.cep,
                    Uf = request.uf,
                    Cidade = request.cidade,
                    Bairro = request.bairro,
                    Complemento = request.complemento,
                    Tipo = request.tipo,
                    DataSituacao = request.dataSituacao,
                    Numero = request.numero
                });
        }

        public async Task<BaseResponse> Handle(ListarEmpresasCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _empresaService.ListarEmpresasAsync(request.CodigoEmpresa);
        }

        public async Task<BaseResponse> Handle(AtualizarEmpresaCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _empresaService.AtualizarEmpresaAsync(
                new Empresa
                {
                    NomeRazao = request.nomeRazao,
                    Cpf = request.cpf,
                    Cnpj = request.cnpj,
                    Telefone = request.telefone,
                    Email = request.email,
                    Endereco = request.endereco,
                    Cep = request.cep,
                    Uf = request.uf,
                    Cidade = request.cidade,
                    Bairro = request.bairro,
                    Complemento = request.complemento,
                    Tipo = request.tipo,
                    DataSituacao = request.dataSituacao,
                    Numero = request.Numero?.ToString()!,
                    Ativo = request.Ativo,
                    Id = request.Id
                });
        }
    }
}

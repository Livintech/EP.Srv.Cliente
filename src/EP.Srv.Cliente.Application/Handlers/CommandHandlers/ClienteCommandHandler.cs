using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.Cliente;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandoHandlers
{
    public class ClienteCommandHandler : IRequestHandler<CadastroClienteCommand, BaseResponse>
    {
        private readonly IClienteService _clienteService;
        private readonly IEmpresaService _empresaService;

        public ClienteCommandHandler(IClienteService clienteService, IEmpresaService empresaService)
        {
            _clienteService = clienteService;
            _empresaService = empresaService;
        }

        public async Task<BaseResponse> Handle(CadastroClienteCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            if (request.tipo == "EMP")
            {
                var empresa = new Domain.Entities.Empresa
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
                    DataSituacao = request.dataSituacao
                };

                return await _empresaService.CadastrarAsync(empresa: empresa);
            }
            else
            {
                var cliente = new Domain.Entities.Cliente
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
                    CodigoEmpresa = request.codigoEmpresa
                };

                return await _clienteService.CadastrarAsync(cliente: cliente);
            }
        }
    }
}

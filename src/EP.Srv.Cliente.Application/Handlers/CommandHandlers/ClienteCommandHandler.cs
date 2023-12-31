﻿using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.Cliente;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandoHandlers
{
    public class ClienteCommandHandler :
        IRequestHandler<CadastroClienteCommand, BaseResponse>,
        IRequestHandler<AtualizarClienteCommand, BaseResponse>
    {
        private readonly IClienteService _clienteService;

        public ClienteCommandHandler(IClienteService clienteService)
            => _clienteService = clienteService;

        public async Task<BaseResponse> Handle(CadastroClienteCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

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

        public async Task<BaseResponse> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _clienteService.AtualizarClienteAsync(
                new Domain.Entities.Cliente
                {
                    Id = request.Id,
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
                    CodigoEmpresa = request.codigoEmpresa,
                    Numero = request.Numero.ToString()!,
                    Ativo = request.Ativo
                });
        }
    }
}

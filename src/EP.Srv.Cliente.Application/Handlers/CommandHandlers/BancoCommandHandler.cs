using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.Banco;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class BancoCommandHandler :
        IRequestHandler<CadastroBancoCommand, BaseResponse>,
        IRequestHandler<ListarBancosCommand, BaseResponse>,
        IRequestHandler<ObterBancoByIdCommand, BaseResponse>,
        IRequestHandler<AtualizarBancoCommand, BaseResponse>
    {
        private readonly IBancoService _bancoService;

        public BancoCommandHandler(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        public async Task<BaseResponse> Handle(CadastroBancoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var response = await _bancoService.CadastrarBancoAsync(new Banco 
            { 
                Codigo = request.Codigo,
                Conta = int.Parse(request.Conta.Replace("-", "")),
                Agencia = request.Agencia,
                Instituicao = request.Instituicao,
                SaldoInicial = decimal.Parse(request.SaldoInicial),
                DataSaldoInicio = DateTime.Parse(request.DataSaldoInicial),
                EmpresaId = int.Parse(request.EmpresaId)
            });

            return response;
        }

        public async Task<BaseResponse> Handle(ListarBancosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var response = await _bancoService.ListarBancosAsync(request.EmpresaId);
            return response;
        }

        public async Task<BaseResponse> Handle(ObterBancoByIdCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var response = await _bancoService.ObterBancoByIdAsunc(request.BancoId);
            return response;
        }

        public async Task<BaseResponse> Handle(AtualizarBancoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _bancoService.AtualizarBancoAsync(
                new Banco
                {
                    Id = request.Id,
                    Codigo = request.Codigo,
                    Conta = request.Conta,
                    Agencia = request.Agencia,
                    SaldoInicial = request.SaldoInicial,
                    Instituicao = request.Instituicao,
                    Ativo = request.Ativo
                });
        }
    }
}

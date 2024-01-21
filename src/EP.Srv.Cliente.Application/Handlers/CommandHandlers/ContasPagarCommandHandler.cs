using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.ContasPagar;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class ContasPagarCommandHandler : 
        IRequestHandler<CadastrarLancamentoCommand, BaseResponse>,
        IRequestHandler<ListarLancamentoCommand, BaseResponse>,
        IRequestHandler<AtualizarLancamentoCommand, BaseResponse>
    {
        private readonly IContasPagarService _contasPagarService;

        public ContasPagarCommandHandler(IContasPagarService contasPagarService)
        {
            _contasPagarService = contasPagarService;
        }

        public async Task<BaseResponse> Handle(CadastrarLancamentoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var lancamento = new ContasPagar
            {
                Ativo = true,
                Categoria = request.Categoria,
                CodigoEmpresa = request.CodigoEmpresa,
                DtEmissao = request.DtEmissao,
                Nome = request.Nome,
                NumeroTitulo = request.NumeroTitulo,
                Observacao = request.Observacao,
                Valor = decimal.Parse(request.Valor),
                Vencimento = DateTime.Parse(request.Vencimento),
                DtLancamento = request.DtLancamento
            };

            return await _contasPagarService.CadastrarLancamentoAsync(lancamento);
        }

        public Task<BaseResponse> Handle(ListarLancamentoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return _contasPagarService.ListarLancamentosAsync();
        }

        public async Task<BaseResponse> Handle(AtualizarLancamentoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var lancamento = new ContasPagar
            {
                Ativo = true,
                Categoria = request.Categoria,
                CodigoEmpresa = request.CodigoEmpresa,
                DtEmissao = request.DtEmissao,
                Nome = request.Nome,
                NumeroTitulo = request.NumeroTitulo,
                Observacao = request.Observacao,
                Valor = decimal.Parse(request.Valor),
                Vencimento = DateTime.Parse(request.Vencimento),
                DtLancamento = request.DtLancamento
            };

            return await _contasPagarService.AtualizarLancamentoAsync(lancamento);
        }
    }
}

using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.Pagamento;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class FormaPagamentosCommandHandler : 
        IRequestHandler<CadastrarFormaPagamentosCommand, BaseResponse>,
        IRequestHandler<ListarFormaPagamentosCommand, BaseResponse>,
        IRequestHandler<AtualizaFormaPagamentosCommand, BaseResponse>
    {
        private readonly IFormaPagamentoService _formaPagamentoService;

        public FormaPagamentosCommandHandler(IFormaPagamentoService formaPagamentoService)
        {
            _formaPagamentoService = formaPagamentoService;
        }

        public async Task<BaseResponse> Handle(CadastrarFormaPagamentosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _formaPagamentoService.CadastrarAsync(
                new FormaPagamento
                {
                    Descricao = request.Descricao,
                    CodigoEmpresa = request.CodigoEmpresa,
                    EmpresaId = int.Parse(request.EmpresaId)
                });
        }

        public async Task<BaseResponse> Handle(ListarFormaPagamentosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _formaPagamentoService.ListarFormasPagamentosAsync(request.EmpresaId);
        }

        public async Task<BaseResponse> Handle(AtualizaFormaPagamentosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _formaPagamentoService.AtualizaPagamentoAsync(
                new FormaPagamento
                {
                    Id = request.Id,
                    CodigoEmpresa = request.CodigoEmpresa,
                    EmpresaId = int.Parse(request.EmpresaId),
                    Descricao = request.Descricao,
                    Ativo = request.Ativo
                });
        }
    }
}

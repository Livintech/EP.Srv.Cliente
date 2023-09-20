using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Application.Services;
using EP.Srv.Cliente.Domain.Commands.ProdutosServicos;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class ProdutosServicosCommandHandler :
        IRequestHandler<GravarProdutosServicosCommand, BaseResponse>,
        IRequestHandler<ListarProdutosServicosCommand, BaseResponse>,
        IRequestHandler<AtualizarProdutosServicosCommand, BaseResponse>
    {

        private readonly IProdutosServicosService _produtosServicosService;

        public ProdutosServicosCommandHandler(IProdutosServicosService produtosServicosService)
            => _produtosServicosService = produtosServicosService;

        public async Task<BaseResponse> Handle(GravarProdutosServicosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _produtosServicosService.GravarPRodutosServicosAsync(
                new ProdutosServicos
                {
                    Descricao = request.Descricao,
                    EmpresaId = int.Parse(request.EmpresaId),
                    CodigoEmpresa = request.CodigoEmpresa
                });
        }

        public async Task<BaseResponse> Handle(ListarProdutosServicosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _produtosServicosService.ListarProdutosServicosAsync();
        }

        public async Task<BaseResponse> Handle(AtualizarProdutosServicosCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _produtosServicosService.AtualizarProdutosServicosAsync(
               new ProdutosServicos
               {
                   Id = request.Id,
                   Descricao = request.Descricao,
                   EmpresaId = int.Parse(request.EmpresaId),
                   CodigoEmpresa = request.CodigoEmpresa,
                   Ativo = request.Ativo
               });
        }
    }
}

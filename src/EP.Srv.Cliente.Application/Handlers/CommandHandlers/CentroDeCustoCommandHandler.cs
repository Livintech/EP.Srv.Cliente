using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.CentroCusto;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class CentroDeCustoCommandHandler :
        IRequestHandler<GravarCentroCustoCommand, BaseResponse>,
        IRequestHandler<AtualizarCentroCustoCommand, BaseResponse>,
        IRequestHandler<ListarCentroCustoCommand, BaseResponse>
    {
        private readonly ICentroCustosService _centroCustosService;

        public CentroDeCustoCommandHandler(ICentroCustosService centroCustosService)
             => _centroCustosService = centroCustosService;

        public async Task<BaseResponse> Handle(GravarCentroCustoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _centroCustosService.GravarCentroCustoAsync(
                new CentroCustos
                {
                    Descricao = request.Descricao,
                    EmpresaId = int.Parse(request.EmpresaId),
                    CodigoEmpresa = request.CodigoEmpresa,
                });
        }

        public async Task<BaseResponse> Handle(AtualizarCentroCustoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _centroCustosService.AtualizarCentroCustoAsync(
                new CentroCustos
                {
                    Id = request.Id,
                    Descricao = request.Descricao,
                    EmpresaId = int.Parse(request.EmpresaId),
                    CodigoEmpresa = request.CodigoEmpresa,
                    Ativo = request.Ativo
                });
        }

        public async Task<BaseResponse> Handle(ListarCentroCustoCommand request, CancellationToken cancellationToken)
            => await _centroCustosService.ListarCentroCustoAsync();
    }
}

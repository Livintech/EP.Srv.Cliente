using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.PlanoContas;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.CommandHandlers
{
    public class PlanoContasCommandHandler :
        IRequestHandler<CadastrarPlanoContasCommand, BaseResponse>,
        IRequestHandler<AtualizarPlanoContasCommand, BaseResponse>,
        IRequestHandler<ListarPlanoContasCommand, BaseResponse>
    {
        private readonly IPlanoDeContasService _planoDeContasService;

        public PlanoContasCommandHandler(IPlanoDeContasService planoDeContasService)
            => _planoDeContasService = planoDeContasService;

        public async Task<BaseResponse> Handle(CadastrarPlanoContasCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _planoDeContasService.GravarPlanoDeContasAsync(
                new PlanoContas
                {
                    Codigo = request.Codigo,
                    Natureza = request.Natureza,
                    TipoNatureza = request.TipoNatureza,
                    CodigoEmpresa = request.CodigoEmpresa
                });
        }

        public async Task<BaseResponse> Handle(AtualizarPlanoContasCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _planoDeContasService.AtualizarPlanoDeContasAsync(
                new PlanoContas
                {
                    Id = request.Id,
                    Ativo = request.Ativo,
                    Codigo = request.Codigo,
                    Natureza = request.Natureza,
                    TipoNatureza = request.TipoNatureza,
                    CodigoEmpresa = request.CodigoEmpresa
                });
        }

        public async Task<BaseResponse> Handle(ListarPlanoContasCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            return await _planoDeContasService.ListarPlanoDeContasAsync(request.CodigoEmpresa);
        }
    }
}

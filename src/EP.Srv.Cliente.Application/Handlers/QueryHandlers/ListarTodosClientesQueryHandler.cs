using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Commands.Cliente;
using EP.Srv.Cliente.Domain.Commands.Empresa;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.QueryHandlers
{
    public class ListarTodosClientesQueryHandler : 
        IRequestHandler<ListarClientesCommand, BaseResponse>,
        IRequestHandler<ListarEmpresasCommand, BaseResponse>
    {
        private readonly IClienteService _clienteService;

        public ListarTodosClientesQueryHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<BaseResponse> Handle(ListarClientesCommand request, CancellationToken cancellationToken)
        {
            return await _clienteService.LiatarClientesAsync(request.CodigoEmpresa);
        }

        public async Task<BaseResponse> Handle(ListarEmpresasCommand request, CancellationToken cancellationToken)
        {
            var empresas =  await _clienteService.LiatarEmpresasAsync();

            return empresas;
        }
    }
}

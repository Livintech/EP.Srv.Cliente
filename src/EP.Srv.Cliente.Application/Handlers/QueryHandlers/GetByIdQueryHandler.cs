using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Application.Handlers.QueryHandlers
{
    //public class GetByIdQueryHandler : 
    //    IRequestHandler<GetJvByIdCommand, BaseResponse>,
    //    IRequestHandler<GetCFOPCommand, BaseResponse>,
    //    IRequestHandler<GetNCMCommand, BaseResponse>,
    //    IRequestHandler<GetMetaObjetoCommand, BaseResponse>,
    //    IRequestHandler<GetTextoCommand, BaseResponse>
    //{
    //    private readonly IConsortiumService _consortiumService;
    //    private readonly IConsortiumJVService _consortiumJvService;
    //    private readonly ICFOPService _cfopService;
    //    private readonly INCMService _ncmService;
    //    private readonly IMetaObjetoService _metaObjetoService;
    //    private readonly ITextoService _textoService;

    //    public GetByIdQueryHandler(IConsortiumService consortiumService, IConsortiumJVService consortiumJvService, ICFOPService cfopService, INCMService ncmService, IMetaObjetoService metaObjetoService, ITextoService textoService)
    //    {
    //        _consortiumService = consortiumService;
    //        _consortiumJvService = consortiumJvService;
    //        _cfopService = cfopService;
    //        _ncmService = ncmService;
    //        _metaObjetoService = metaObjetoService;
    //        _textoService = textoService;
    //    }


    //    public Task<BaseResponse> Handle(GetJvByIdCommand request, CancellationToken cancellationToken)
    //    {
    //        ArgumentNullException.ThrowIfNull(nameof(request));

    //        return _consortiumJvService.GetByIdAsync(request);
    //    }

    //    public Task<BaseResponse> Handle(GetCFOPCommand request, CancellationToken cancellationToken)
    //    {
    //        ArgumentNullException.ThrowIfNull(nameof(request));

    //        return _cfopService.GetByIdAsync(request);
    //    }

    //    public Task<BaseResponse> Handle(GetNCMCommand request, CancellationToken cancellationToken)
    //    {
    //        ArgumentNullException.ThrowIfNull(nameof(request));

    //        return _ncmService.GetByIdAsync(request);
    //    }

    //    public Task<BaseResponse> Handle(GetMetaObjetoCommand request, CancellationToken cancellationToken)
    //    {
    //        ArgumentNullException.ThrowIfNull(nameof(request));

    //        return _metaObjetoService.GetByIdAsync(request);
    //    }
    //    public Task<BaseResponse> Handle(GetTextoCommand request, CancellationToken cancellationToken)
    //    {
    //        ArgumentNullException.ThrowIfNull(nameof(request));

    //        return _textoService.GetByIdAsync(request);
    //    }
    //}
}

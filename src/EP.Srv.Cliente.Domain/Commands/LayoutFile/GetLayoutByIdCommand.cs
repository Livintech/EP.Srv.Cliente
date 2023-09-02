using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.LayoutFile
{
    public class GetLayoutByIdCommand //: IRequest<LayoutResponse>
    {
        public int Id { get; set; }
    }
}

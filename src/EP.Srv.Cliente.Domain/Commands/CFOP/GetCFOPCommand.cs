using FluentValidation;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.CFOP
{
    public class GetCFOPCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}

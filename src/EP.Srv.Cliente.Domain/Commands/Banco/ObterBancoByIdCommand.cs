using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Banco
{
    public class ObterBancoByIdCommand : IRequest<BaseResponse>
    {
        public int BancoId{ get; set; }
    }
}

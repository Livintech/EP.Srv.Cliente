using FluentValidation;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.CFOP
{
    public class GetListCFOPCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string EntradaSaida { get; set; }
        public string Credito { get; set; }
    }
}

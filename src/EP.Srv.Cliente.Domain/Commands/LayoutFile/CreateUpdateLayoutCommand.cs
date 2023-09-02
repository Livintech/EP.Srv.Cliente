using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.LayoutFile
{
    public class CreateUpdateLayoutCommand //: IRequest<LayoutResponse>
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Arquivo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}

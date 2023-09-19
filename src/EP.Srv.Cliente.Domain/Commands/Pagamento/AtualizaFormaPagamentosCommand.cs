﻿using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Pagamento
{
    public class AtualizaFormaPagamentosCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
        public bool Ativo {  get; set; }
    }
}

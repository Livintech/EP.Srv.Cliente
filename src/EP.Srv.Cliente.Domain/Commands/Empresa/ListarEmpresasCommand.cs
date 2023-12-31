﻿using EP.Srv.Cliente.Domain.Responses;
using MediatR;

namespace EP.Srv.Cliente.Domain.Commands.Empresa
{
    public class ListarEmpresasCommand : IRequest<BaseResponse>
    {
        public string CodigoEmpresa { get; set; } = string.Empty;
    }
}

﻿using EP.Srv.Cliente.Domain.Commands.PlanoContas;
using EP.Srv.Cliente.Domain.Commands.ProdutosServicos;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EP.Srv.Cliente.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class PlanoDeContasController : Controller
    {
        private readonly IMediator _mediator;

        public PlanoDeContasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cadastrar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Master")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public async Task<IActionResult> CadastrarAsync([FromBody] CadastrarPlanoContasCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Listar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Master,Operador")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Listar([FromBody] ListarPlanoContasCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Atualizar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Master,Operador")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarPlanoContasCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

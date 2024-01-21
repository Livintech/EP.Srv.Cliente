using EP.Srv.Cliente.Domain.Commands.ContasPagar;
using EP.Srv.Cliente.Domain.Commands.Empresa;
using EP.Srv.Cliente.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EP.Srv.Cliente.Domain.Commands.ContasPagar.AtualizarLancamentoCommand;

namespace EP.Srv.Cliente.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ContasPagarController : Controller
    {
        private readonly IMediator _mediator;

        public ContasPagarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CadastrarLancamento")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Master")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public async Task<IActionResult> CadastrarAsync([FromBody] CadastrarLancamentoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("ListarLancamentos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Master,Operador")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ListarEmpresas([FromBody] ListarLancamentoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPost("AtualizarLancamento")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Master")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarLancamentoCommand command)
        {
            var validator = new AtualizarLancamentoValidator().Validate(command);

            if (validator.IsValid)
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            else
            {
                return BadRequest(validator.Errors);
            }
        }
    }
}

using EP.Srv.Cliente.Api.Attributes;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Extensions.Pagination;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Threading;
using Ubiety.Dns.Core;

namespace EP.Srv.Cliente.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ArquivoConsolidadoController : Controller
    {
        //private readonly IFileService _fileService;
        //private readonly string _contentType = "application/octeto-streaml";
        //private readonly string _nameFileConsolidated = "Consolidação Relatórios de Gastos.xlsx";

        //public ArquivoConsolidadoController(IFileService fileService)
        //{
        //    _fileService = fileService;
        //}

        //[HttpGet("Download")]
        //[AllowAnonymous]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        //public async Task<FileStreamResult> Download([FromQuery] string dateProccess, bool flagReprocessa)
        //{
        //    try
        //    {
        //        CancellationToken cancellationToken = HttpContext.RequestAborted;
        //        Serilog.Log.Information($"Requisição abortada: {cancellationToken.IsCancellationRequested}");

        //        var dataStream = await _fileService.GenereteConsolidatedReport(dateProccess, flagReprocessa);

        //        Serilog.Log.Information($"Requisição abortada: {cancellationToken.IsCancellationRequested}");

        //        var stream = new FileStreamResult(dataStream, new MediaTypeHeaderValue(_contentType))
        //        {
        //            FileDownloadName = _nameFileConsolidated,
        //            EnableRangeProcessing = true
        //        };

        //        Serilog.Log.Information($"Criou arquivo stream.. {DateTime.Now.ToShortTimeString()}");

        //        return stream;
        //    }
        //    catch (Exception ex)
        //    {
        //        Serilog.Log.Information($"Erro exception: {ex.Message}", ex);
        //        return null;
        //    }
        //}

    }
}

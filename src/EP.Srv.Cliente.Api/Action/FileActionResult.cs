﻿using System.Net;
using System.Web.Http;

namespace EP.Srv.Cliente.Api.Action
{
    public class FileActionResult : IHttpActionResult
    {
        MemoryStream arquivoStuff;
        string nomeDoArquivo;
        HttpRequestMessage httpRequestMessage;
        HttpResponseMessage httpResponseMessage;

        public FileActionResult(MemoryStream data, HttpRequestMessage request, string filename)
        {
            arquivoStuff = data;
            httpRequestMessage = request;
            nomeDoArquivo = filename;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(arquivoStuff);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = nomeDoArquivo;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return Task.FromResult(httpResponseMessage);
        }
    }
}

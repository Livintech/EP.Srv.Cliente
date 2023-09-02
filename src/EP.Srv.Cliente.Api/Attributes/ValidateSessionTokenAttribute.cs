using EP.Srv.Cliente.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

namespace EP.Srv.Cliente.Api.Attributes
{
    public class ValidateSessionTokenAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Microsoft.Extensions.Primitives.StringValues headerValuesToken;
            Microsoft.Extensions.Primitives.StringValues headerValuesRefreshToken;
            var refreshToken = context.HttpContext.Request.Headers.TryGetValue("RefreshToken", out headerValuesRefreshToken);

            if (!refreshToken)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Não Autorizado"
                };
                return;
            }
            else
            {
                try
                {
                    var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                    var _loginServiceBaseUrl = _configuration.GetSection("Http").GetChildren().SingleOrDefault(c => c.Key == "SrvAuth")?.Value;

                    var json = new StringContent(
                       System.Text.Json.JsonSerializer.Serialize(new RefreshTokenModel
                       {
                           RefreshToken = headerValuesRefreshToken.First()!
                       }),
                       Encoding.UTF8,
                       System.Net.Mime.MediaTypeNames.Application.Json);


                    using (var client = new HttpClient())
                    {
                        var validate = await client.PostAsync($"{_loginServiceBaseUrl}/api/v1/Auth/ValidateSession", json);
                        var readString = await validate.Content.ReadAsStringAsync();
                        var session = JsonConvert.DeserializeObject<ValidateSessionModel>(JsonConvert.DeserializeObject(readString)!.ToString()!);

                        if (validate.IsSuccessStatusCode && !string.IsNullOrEmpty(session.RefreshToken) && session.Success)
                            context.HttpContext.Response.Headers.Add("RefreshToken", session.RefreshToken);
                        else
                        {
                            context.Result = new ContentResult()
                            {
                                StatusCode = 401,
                                Content = "Não Autorizado"
                            };
                            return;
                        }
                    }


                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            await next();
        }
    }
}

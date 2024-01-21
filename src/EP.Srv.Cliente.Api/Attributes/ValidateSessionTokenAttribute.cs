using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using EP.Srv.Cliente.CrossCutting.Options;
using Microsoft.Extensions.Options;

namespace EP.Srv.Cliente.Api.Attributes
{
    public class ValidateSessionTokenAttribute : Attribute, IAsyncActionFilter
    {
        private static JwtOptions jwtOpt = new();

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            SecurityToken validationToken;
            Microsoft.Extensions.Primitives.StringValues autorizationValueToken;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out autorizationValueToken);

            IServiceProvider services = context.HttpContext.RequestServices;

            jwtOpt = services.GetService<JwtOptions>()!;

            var parameters = GetValidationParameters();
            var tokenHandler = new JwtSecurityTokenHandler();
            IPrincipal principal = tokenHandler.ValidateToken(autorizationValueToken.First().Replace("Bearer ", string.Empty), parameters, out validationToken);

            if (principal.Identity == null || !principal.Identity!.IsAuthenticated)
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
                //var claims = ((System.Security.Claims.ClaimsIdentity)principal.Identity).Claims;
                //var dateExp = DateTime.Now;

                //foreach (var claim in claims)
                //{
                //    if(claim.Type == "exp")
                //    {
                //        dateExp = DateTime.Parse(claim.Value);
                //    }
                //}
            }

            /*
            if (!refreshToken)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Não Autorizado - Token inválido"
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
            */

            await next();
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidIssuer = jwtOpt.Issuer,
                ValidAudience = jwtOpt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpt.Key))
            };
        }
    }
}

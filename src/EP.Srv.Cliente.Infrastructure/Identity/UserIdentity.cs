using EP.Srv.Cliente.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EP.Srv.Cliente.Infrastructure.Identity
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _accessor;

        public UserIdentity(IHttpContextAccessor accessor) => _accessor = accessor;

        public bool IsAuthenticated() => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity() => _accessor.HttpContext.User.Claims!;

        public string CpfCnpj => GetClaimsIdentity().First().Value;

        public string Perfil => GetClaimsIdentity().Where(c => c.Type == ClaimTypes.Role).First().Value;

        public string Email => GetClaimsIdentity().Where(c => c.Type == ClaimTypes.Email).First().Value;

        public string CodigoEmpresa => GetClaimsIdentity().Where(c => c.Type == "CodigoEmpresa").First().Value;
    }
}

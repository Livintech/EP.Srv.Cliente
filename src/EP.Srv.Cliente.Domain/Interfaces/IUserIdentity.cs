using System.Security.Claims;

namespace EP.Srv.Cliente.Domain.Interfaces
{
    public interface IUserIdentity
    {
        string CpfCnpj { get; }
        string Perfil {  get; }
        string Email { get; }
        string CodigoEmpresa { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}

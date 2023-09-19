using EP.Srv.Cliente.Domain.Entities;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<Empresa> CadastrarAsync(Empresa empresa);
        Task<IEnumerable<Empresa>> ListarTodosAsync();
    }
}

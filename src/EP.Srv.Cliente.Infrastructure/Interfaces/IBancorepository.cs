using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;

namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IBancorepository
    {
        Task<Banco> CadastrarBancoAsync(Banco banco);
        Task<IEnumerable<Banco>> ListarBancosAsync();
        Task<Banco> ObterBancoByIdAsunc(int id);
        Task<Banco> AtualizarBancoAsync(Banco banco);
    }
}

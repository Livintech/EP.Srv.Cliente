namespace EP.Srv.Cliente.Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        Task<Domain.Entities.Cliente> CadastrarAsync(Domain.Entities.Cliente cliente);
        Task<IEnumerable<Domain.Entities.Cliente>> ListarTodosAsync();
    }
}

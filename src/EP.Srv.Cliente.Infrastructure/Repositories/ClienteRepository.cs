using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IAppDbContext _context;

        public ClienteRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Cliente> CadastrarAsync(Domain.Entities.Cliente cliente)
        {
            cliente.Ativo = true;
            cliente.Empresa = await _context.Empresa.Where(e => e.Id == int.Parse(cliente.CodigoEmpresa)).FirstOrDefaultAsync();

            if (cliente.Empresa != null)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveAsync();
            }
            else
            {
                throw new Exception($"Empresa associada não econtrada. Código: {cliente.CodigoEmpresa}");
            }
            return cliente;
        }

        public async Task<IEnumerable<Domain.Entities.Cliente>> ListarTodosAsync()
            => await _context.Clientes.ToListAsync();
    }
}

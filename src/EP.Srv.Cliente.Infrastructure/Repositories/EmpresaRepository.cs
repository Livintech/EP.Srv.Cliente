using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IAppDbContext _context;

        public EmpresaRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> CadastrarAsync(Empresa empresa)
        {
            empresa.Ativo = true;
            _context.Empresa.Add(empresa);
            await _context.SaveAsync();

            return empresa;
        }

        public async Task<IEnumerable<Empresa>> ListarTodosAsync()
            => await _context.Empresa.ToListAsync();
    }
}

using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class CentroDeCustoRepository : ICentroDeCustoRepository
    {
        private readonly IAppDbContext _appDbContext;

        public CentroDeCustoRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CentroCustos> GravarCentroCustoAsync(CentroCustos centroCustos)
        {
            var existe = await _appDbContext.CentroCustos.Where(c => c.Descricao == centroCustos.Descricao && c.EmpresaId == centroCustos.EmpresaId).FirstOrDefaultAsync();
            var empresa = await _appDbContext.Empresa.Where(e => e.Id == centroCustos.EmpresaId).FirstOrDefaultAsync();
            var entity = new CentroCustos
            {
                Empresa = empresa!,
                CodigoEmpresa = centroCustos.CodigoEmpresa,
                Descricao = centroCustos.Descricao,
                EmpresaId = centroCustos.EmpresaId,
                Ativo = true
            };

            _appDbContext.CentroCustos.Add(entity);
            await _appDbContext.SaveAsync();

            return entity;
        }

        public async Task<CentroCustos> AtualizaCentroCustoAsync(CentroCustos centroCustos)
        {
            var entity = await _appDbContext.CentroCustos.Where(a => a.Id == centroCustos.Id).FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.Descricao = centroCustos.Descricao;
                entity.Ativo = centroCustos.Ativo;
                entity.AtualizadoEm = DateTime.Now;

                _appDbContext.EntryChanges(entity);
                await _appDbContext.SaveAsync();
            }

            return entity ?? centroCustos;
        }

        public async Task<IEnumerable<CentroCustos>> ListarCentroCustoAsync()
            => await _appDbContext.CentroCustos.ToListAsync();
    }
}

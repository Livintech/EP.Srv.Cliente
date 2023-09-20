using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class ProdutosServicosRepository : IProdutosServicosRepository
    {
        private readonly IAppDbContext _appDbContext;

        public ProdutosServicosRepository(IAppDbContext appDbContext)
         => _appDbContext = appDbContext;

        public async Task<ProdutosServicos> GravarPRodutosServicosAsync(ProdutosServicos produtosServicos)
        {
            var existe = await _appDbContext.ProdutosServicos.Where(c => c.Descricao == produtosServicos.Descricao && c.EmpresaId == produtosServicos.EmpresaId).FirstOrDefaultAsync();
            var empresa = await _appDbContext.Empresa.Where(e => e.Id == produtosServicos.EmpresaId).FirstOrDefaultAsync();
            var entity = new ProdutosServicos
            {
                Empresa = empresa!,
                CodigoEmpresa = produtosServicos.CodigoEmpresa,
                Descricao = produtosServicos.Descricao,
                EmpresaId = produtosServicos.EmpresaId,
                Ativo = true
            };

            _appDbContext.ProdutosServicos.Add(entity);
            await _appDbContext.SaveAsync();

            return entity;
        }

        public async Task<ProdutosServicos> AtualizarProdutosServicosAsync(ProdutosServicos produtosServicos)
        {
            var entity = await _appDbContext.ProdutosServicos.Where(a => a.Id == produtosServicos.Id).FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.Descricao = produtosServicos.Descricao;
                entity.Ativo = produtosServicos.Ativo;
                entity.AtualizadoEm = DateTime.Now;

                _appDbContext.EntryChanges(entity);
                await _appDbContext.SaveAsync();
            }

            return entity ?? produtosServicos;
        }

        public async Task<IEnumerable<ProdutosServicos>> ListarProdutosServicosAsync()
            => await _appDbContext.ProdutosServicos.ToListAsync();
    }
}

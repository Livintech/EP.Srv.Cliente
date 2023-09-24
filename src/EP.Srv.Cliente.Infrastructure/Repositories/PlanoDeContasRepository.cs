using DocumentFormat.OpenXml.Vml.Spreadsheet;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using EP.Srv.Cliente.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class PlanoDeContasRepository : IPlanoDeContasRepository
    {
        private readonly IAppDbContext _appDbContext;

        public PlanoDeContasRepository(IAppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<IEnumerable<PlanoContas>> ListarPlanoDeContasAsync()
            => await _appDbContext.PlanoContas.ToListAsync();

        public async Task<PlanoContas> AtualizarPlanoDeContasAsync(PlanoContas planoContas)
        {
            var entity = await _appDbContext.PlanoContas.Where(p => p.Id == planoContas.Id).FirstOrDefaultAsync();

            if (entity == null)
                throw new Exception("Plano de contas não encontrado.");
            else
            {
                entity.Codigo = planoContas.Codigo;
                entity.TipoNatureza = planoContas.TipoNatureza;
                entity.Natureza = planoContas.Natureza;
                entity.Ativo = planoContas.Ativo;
                entity.AtualizadoEm = DateTime.Now;
            }

            _appDbContext.EntryChanges(entity);
            await _appDbContext.SaveAsync();

            return entity;
        }
    
        public async Task<PlanoContas> GravarPlanoDeContasAsync(PlanoContas planoContas)
        {
            var entity = new PlanoContas
            {
                Ativo = true,
                Codigo = planoContas.Codigo,
                Natureza = planoContas.Natureza,
                TipoNatureza = planoContas.TipoNatureza,
                CodigoEmpresa = planoContas.CodigoEmpresa
            };

            _appDbContext.PlanoContas.Add(entity);
            await _appDbContext.SaveAsync();

            return entity;
        }
    }
}

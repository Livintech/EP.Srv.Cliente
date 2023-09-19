using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class FormaPagamentosRepository : IFormaPagamentosRepository
    {
        private readonly IAppDbContext _appDbContext;

        public FormaPagamentosRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<FormaPagamento> AtualizaPagamentoAsync(FormaPagamento formaPagamento)
        {
            var entity = await _appDbContext.FormaPagamentos.Where(a => a.Id == formaPagamento.Id).FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.Descricao = formaPagamento.Descricao;
                entity.Ativo = formaPagamento.Ativo;
                entity.AtualizadoEm = DateTime.Now;

                _appDbContext.EntryChanges(entity);
                await _appDbContext.SaveAsync();
            }

            return entity;
        }

        public async Task<FormaPagamento> CadastrarAsync(FormaPagamento formaPagamento)
        {
            var existe = await _appDbContext.FormaPagamentos.Where(f => f.Descricao == formaPagamento.Descricao && f.CodigoEmpresa == formaPagamento.CodigoEmpresa).FirstOrDefaultAsync();
            var empresa = await _appDbContext.Empresa.Where(e => e.Id == formaPagamento.EmpresaId).FirstOrDefaultAsync();
            if (existe != null)
            {
                throw new Exception("Já existe uma forma de pagamento cadastrada para este código.");
            }
            else
            {
                var entity = new FormaPagamento
                {
                    Ativo = true,
                    Descricao = formaPagamento.Descricao,
                    CodigoEmpresa = formaPagamento.EmpresaId.ToString("D5"),
                    Empresa = empresa,
                    EmpresaId = formaPagamento.EmpresaId
                };

                _appDbContext.FormaPagamentos.Add(entity);
                await _appDbContext.SaveAsync();

                return entity;
            }
        }

        public async Task<IEnumerable<FormaPagamento>> ListarFormasPagamentosAsync()
            => await _appDbContext.FormaPagamentos.ToListAsync();
    }
}

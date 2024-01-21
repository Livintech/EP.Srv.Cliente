using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Context;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class ContasPagarRepository : IContasPagarRepository
    {
        private readonly AppDbContext _context;

        public ContasPagarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContasPagar> AtualizarLancamentoAsync(ContasPagar contasPagar)
        {
            var entity = _context.ContasPagar.Where(x => x.Id == contasPagar.Id).FirstOrDefault();

            if (entity != null)
            {
                entity.Ativo = contasPagar.Ativo;
                entity.NumeroTitulo = contasPagar.NumeroTitulo;
                entity.Observacao = contasPagar.Observacao;
                entity.DtLancamento = contasPagar.DtLancamento;
                entity.DtEmissao = contasPagar.DtEmissao;
                entity.AtualizadoEm = DateTime.Now;
                entity.Categoria = contasPagar.Categoria;
                entity.Valor = contasPagar.Valor;
                entity.Nome = contasPagar.Nome;
                entity.Vencimento = contasPagar.Vencimento;

                _context.EntryChanges(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                entity = new();
            }

            return entity;
        }

        public async Task<ContasPagar> CadastrarLancamentoAsync(ContasPagar contasPagar)
        {
            _context.ContasPagar.Add(contasPagar);
            await _context.SaveChangesAsync();

            return contasPagar;
        }

        public async Task<IEnumerable<ContasPagar>> ListarLancamentosAsync()
            => await _context.ContasPagar.ToListAsync();
    }
}

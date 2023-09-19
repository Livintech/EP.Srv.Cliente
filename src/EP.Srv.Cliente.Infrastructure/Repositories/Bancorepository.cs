using DocumentFormat.OpenXml.Drawing.Charts;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class Bancorepository : IBancorepository
    {
        private readonly IAppDbContext _appDbContext;

        public Bancorepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Banco> CadastrarBancoAsync(Banco banco)
        {
            var empresa = await _appDbContext.Empresa.Where(c => c.Id == banco.EmpresaId).FirstOrDefaultAsync();
            var entity = new Banco
            {
                Codigo = banco.Codigo,
                Conta = banco.Conta,
                Agencia = banco.Agencia,
                Instituicao = banco.Instituicao,
                SaldoInicial = banco.SaldoInicial,
                DataSaldoInicio = banco.DataSaldoInicio,
                Empresa = empresa,
                Ativo = true
            };

            _appDbContext.Bancos.Add(entity);
            await _appDbContext.SaveAsync();

            return entity;
        }

        public async Task<IEnumerable<Banco>> ListarBancosAsync()
            => await _appDbContext.Bancos.ToListAsync();

        public async Task<Banco> ObterBancoByIdAsunc(int id)
        {
            var banco = await _appDbContext.Bancos.Where(b => b.Id == id).FirstOrDefaultAsync();

            return banco == null ? new() : banco;
        }

        public async Task<Banco> AtualizarBanco(Banco banco)
        {
            var entity = _appDbContext.Bancos.Where(b => b.Id == banco.Id).FirstOrDefault();

            if (entity != null)
            {
                entity.Codigo = banco.Codigo;
                entity.Conta = banco.Conta;
                entity.Agencia = banco.Agencia;
                entity.Instituicao = banco.Instituicao;
                entity.SaldoInicial = banco.SaldoInicial;
                entity.DataSaldoInicio = banco.DataSaldoInicio;
                entity.AtualizadoEm = DateTime.Now;
                entity.Ativo = true;

                _appDbContext.EntryChanges(entity);
            }

            await _appDbContext.SaveAsync();

            return banco;
        }

        public async Task<Banco> AtualizarBancoAsync(Banco banco)
        {
            var entity = await _appDbContext.Bancos.Where(b => b.Id == banco.Id).FirstOrDefaultAsync();
            
            if(entity != null)
            {
                entity.Codigo = banco.Codigo;
                entity.Conta = banco.Conta;
                entity.Agencia = banco.Agencia;
                entity.SaldoInicial= banco.SaldoInicial;
                entity.Instituicao= banco.Instituicao;
                entity.Ativo = banco.Ativo;

                _appDbContext.EntryChanges(entity);
                await _appDbContext.SaveAsync();
            }
            else
            {
                throw new Exception("Não há banco a ser atualizado para este Id");
            }

            return entity!;
        }
    }
}

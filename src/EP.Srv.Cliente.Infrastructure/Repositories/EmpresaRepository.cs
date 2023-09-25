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

        public async Task<Empresa> AtualizarEmpresaAsync(Empresa empresa)
        {
            var entity = await _context.Empresa.Where(e => e.Id == empresa.Id).FirstOrDefaultAsync();

            if (entity == null)
                throw new Exception("Empresa não encontrada.");
            else
            {
                entity.NomeRazao = empresa.NomeRazao;
                entity.Cpf = empresa.Cpf;
                entity.Cep = empresa.Cep;
                entity.Telefone = empresa.Telefone;
                entity.Email = empresa.Email;
                entity.Endereco = empresa.Endereco;
                entity.Cep = empresa.Cep;
                entity.Uf = empresa.Uf;
                entity.Cidade = empresa.Cidade;
                entity.Bairro = empresa.Bairro;
                entity.Complemento = empresa.Complemento;
                entity.Tipo = empresa.Tipo;
                entity.DataSituacao = empresa.DataSituacao;
                entity.Numero = empresa.Numero;
                entity.Ativo = empresa.Ativo;
                entity.AtualizadoEm = DateTime.Now;

                _context.EntryChanges(entity);
                await _context.SaveAsync();
            }

            return entity;
        }
    }
}

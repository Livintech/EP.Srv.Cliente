using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace EP.Srv.Cliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IAppDbContext _context;

        public ClienteRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Cliente> AtualizaClienteAsync(Domain.Entities.Cliente cliente)
        {
            var entity = await _context.Clientes.Where(c => c.Id == cliente.Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.NomeRazao = cliente.NomeRazao;
                entity.Cpf = cliente.Cpf;
                entity.Cep = cliente.Cep;
                entity.Telefone = cliente.Telefone;
                entity.Email = cliente.Email;
                entity.Endereco = cliente.Endereco;
                entity.Cep = cliente.Cep;
                entity.Uf = cliente.Uf;
                entity.Cidade = cliente.Cidade;
                entity.Bairro = cliente.Bairro;
                entity.Complemento = cliente.Complemento;
                entity.Tipo = cliente.Tipo;
                entity.DataSituacao = cliente.DataSituacao;
                entity.CodigoEmpresa = cliente.CodigoEmpresa;
                entity.Numero = cliente.Numero;
                entity.Ativo = cliente.Ativo;
                entity.AtualizadoEm = DateTime.Now;

                _context.EntryChanges(entity);
                await _context.SaveAsync();
            }
            else
            {
                throw new Exception("Cliente não encontrado.");
            }

            return entity;
        }

        public async Task<Domain.Entities.Cliente> CadastrarAsync(Domain.Entities.Cliente cliente)
        {
            cliente.Ativo = true;
            var empresa = await _context.Empresa.Where(e => e.Id == int.Parse(cliente.CodigoEmpresa)).FirstOrDefaultAsync();

            if (cliente.Empresa != null)
            {
                cliente.Empresa = empresa!;
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

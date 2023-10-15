using Microsoft.EntityFrameworkCore;
using PHDevIO.Domain.Entities;
using PHDevIO.Domain.Interfaces;
using PHDevIO.Infra.Data.Context;

namespace PHDevIO.Infra.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fornecedor>> ObterTodosAsync()
        {
            return await _context.Fornecedores.AsNoTracking().ToListAsync();
        }

        public async Task<Fornecedor> ObterPorIdAsync(Guid id)
        {
            return await _context.Fornecedores
                .Include(x => x.Endereco)
                .Include(x => x.Produtos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fornecedor> AdicionarAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> AtualizarAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            var entityToExclude = await ObterPorIdAsync(id);
            _context.Remove(entityToExclude);
            return await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PHDevIO.Domain.Entities;
using PHDevIO.Domain.Interfaces;
using PHDevIO.Infra.Data.Context;

namespace PHDevIO.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            return await _context.Produtos
                .Include(x => x.Fornecedor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Produto> AdicionarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            var entityToExclude = await ObterPorIdAsync(id);
            _context.Remove(entityToExclude);
            return await _context.SaveChangesAsync();
        }

        
    }
}

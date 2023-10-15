using Microsoft.EntityFrameworkCore;
using PHDevIO.Domain.Entities;
using PHDevIO.Domain.Interfaces;
using PHDevIO.Infra.Data.Context;

namespace PHDevIO.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> ObterTodosAsync()
        {
            return await _context.Enderecos.AsNoTracking().ToListAsync();
        }

        public async Task<Endereco> ObterPorIdAsync(Guid id)
        {
            return await _context.Enderecos
                .Include(x => x.Fornecedor)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Endereco> AdicionarAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> AtualizarAsync(Endereco endereco)
        {
            _context.Update(endereco);
            await _context.SaveChangesAsync();
            return endereco;

        }

        public async Task<int> RemoverAsync(Guid id)
        {
            var entityToExclude = await ObterPorIdAsync(id);
            _context.Enderecos.Remove(entityToExclude);
            return await _context.SaveChangesAsync();
        }
    }
}

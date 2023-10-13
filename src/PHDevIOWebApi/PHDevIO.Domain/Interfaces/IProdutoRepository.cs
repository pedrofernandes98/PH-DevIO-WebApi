using PHDevIO.Domain.Entities;

namespace PHDevIO.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ObterTodosAsync();
        Task<Produto> ObterPorIdAsync(Guid id);

        Task<Produto> AdicionarAsync(Produto produto);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<int> ExcluirAsync(Guid id);
    }
}

using PHDevIO.Domain.Entities;

namespace PHDevIO.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> ObterTodosAsync();
        Task<Fornecedor> ObterPorIdAsync(Guid id);

        Task<Fornecedor> AdicionarAsync(Fornecedor fornecedor);
        Task<Fornecedor> AtualizarAsync(Fornecedor fornecedor);
        Task<int> ExcluirAsync(Guid id);

        
    }
}

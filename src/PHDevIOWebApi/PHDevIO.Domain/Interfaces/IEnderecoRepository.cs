using PHDevIO.Domain.Entities;

namespace PHDevIO.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<List<Endereco>> ObterTodosAsync();
        Task<Endereco> ObterPorIdAsync(Guid id);

        Task<Endereco> AdicionarAsync(Endereco endereco);
        Task<Endereco> AtualizarAsync(Endereco endereco);
        Task<int> RemoverAsync(Guid id);
    }
}

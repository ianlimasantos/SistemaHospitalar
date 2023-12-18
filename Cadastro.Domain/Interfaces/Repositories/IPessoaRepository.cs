using Cadastro.Domain.Models;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task CadastrarPessoa(Pessoa pessoa);
        Task AtualizarPessoa(Pessoa pessoa);
        Task<IEnumerable<Pessoa>> ListarUsuarios();
        Task DeletarPessoa(Pessoa pessoa);

    }
}

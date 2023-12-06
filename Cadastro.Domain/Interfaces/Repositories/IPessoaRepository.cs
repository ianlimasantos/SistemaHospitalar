using Cadastro.Domain.Models;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> ListarUsuarios();

    }
}

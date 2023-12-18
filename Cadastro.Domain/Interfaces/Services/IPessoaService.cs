using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<Pessoa> CadastrarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoa(AtualizarPessoaCommand command);
        Task<IEnumerable<Pessoa>> ListarPessoas();
        Task<Pessoa> ListarUmaPessoa(long id);
        Task<bool> DeletarPessoa(long id);
    }
}

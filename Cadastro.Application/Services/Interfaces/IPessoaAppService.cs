using Cadastro.Domain.Models.Commands;
using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro.Application.ViewModels;

namespace Cadastro.Application.Services.Interfaces
{
    public interface IPessoaAppService
    {
        Task<PessoaViewModel> CadastrarPessoa(NovaPessoaViewModel pessoa);
        Task<PessoaViewModel> AtualizarPessoa(AtualizarPessoaViewModel command);
        Task<IEnumerable<PessoaViewModel>> ListarPessoas();
        Task<bool> DeletarPessoa(long id);
        Task<PessoaViewModel> ListarUmaPessoa(long id);
    }
}

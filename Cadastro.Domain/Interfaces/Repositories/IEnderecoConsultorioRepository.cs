using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IEnderecoConsultorioRepository : IBaseRepository<EnderecoConsultorio>
    {
        Task<EnderecoConsultorio> CadastrarEnderecoConsultorio(EnderecoConsultorio enderecoConsultorio);
        Task<IEnumerable<EnderecoConsultorio>> ListarEnderecos();
        Task AtualizarEnderecoConsultorio(EnderecoConsultorio enderecoConsultorio);
        Task DeletarEndereco(EnderecoConsultorio enderecoConsultorio);
    }
}

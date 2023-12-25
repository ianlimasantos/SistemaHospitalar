using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface IEnderecoConsultorioService
    {
        Task<EnderecoConsultorio> CadastrarEnderecoConsultorio(EnderecoConsultorio enderecoConsultorio);
        Task<IEnumerable<EnderecoConsultorio>> ListarEnderecos();
        Task<EnderecoConsultorio> AtualizarEnderecoConsultorio(AtualizarEnderecoConsultorioCommand command);
        Task<bool> DeletarEndereco(EnderecoConsultorio enderecoConsultorio);
    }
}

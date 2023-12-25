using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;

namespace Cadastro.Domain.Services
{
    public class EnderecoConsultorioService : IEnderecoConsultorioService
    {
        private readonly IEnderecoConsultorioRepository _repositoryEnderecoConsultorio;
        public EnderecoConsultorioService(IEnderecoConsultorioRepository repository)
        {
            _repositoryEnderecoConsultorio = repository;
        }

        public async Task<EnderecoConsultorio> CadastrarEnderecoConsultorio(EnderecoConsultorio enderecoConsultorio)
        {
            await _repositoryEnderecoConsultorio.CadastrarEnderecoConsultorio(enderecoConsultorio);
            await _repositoryEnderecoConsultorio.UnitOfWork.SaveChangesAsync();
            return enderecoConsultorio;
        }

        public async Task<EnderecoConsultorio> AtualizarEnderecoConsultorio(AtualizarEnderecoConsultorioCommand command)
        {
            var enderecoConsultorio = await _repositoryEnderecoConsultorio.GetByIdAsync(command.Id);
            if (enderecoConsultorio == null) return null;

            enderecoConsultorio.Atualizar(command.Logradouro,
                command.Numero,
                command.Complemento,
                command.Bairro,
                command.Cidade,
                command.UF,
                command.CEP);

            await _repositoryEnderecoConsultorio.AtualizarEnderecoConsultorio(enderecoConsultorio);
            await _repositoryEnderecoConsultorio.UnitOfWork.SaveChangesAsync();
            return enderecoConsultorio;

        }

        public Task<bool> DeletarEndereco(EnderecoConsultorio enderecoConsultorio)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoConsultorio>> ListarEnderecos()
        {
            throw new NotImplementedException();
        }
    }
}

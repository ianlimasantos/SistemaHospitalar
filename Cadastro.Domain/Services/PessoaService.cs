using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) 
        { 
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> CadastrarPessoa(Pessoa pessoa)
        {
            await _pessoaRepository.CadastrarPessoa(pessoa);
            try
            {
                await _pessoaRepository.UnitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var erro = ex;
            }
         
            return pessoa;
        }
        public async Task<Pessoa> AtualizarPessoa(AtualizarPessoaCommand command)
        {
            var pessoa = await _pessoaRepository.GetByIdAsync(command.Id);
            if (pessoa == null) return null;

            pessoa.Atualizar(command.Nome,
                             command.DataNascimento);
            await _pessoaRepository.AtualizarPessoa(pessoa);
            try
            {
                await _pessoaRepository.UnitOfWork.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                var erro = ex;
            }
            
            return pessoa;
        }

        public async Task<bool> DeletarPessoa(long id)
        {
            var pessoa = await _pessoaRepository.GetByIdAsync(id);
            if (pessoa == null) return false;

            await _pessoaRepository.DeletarPessoa(pessoa);
            await _pessoaRepository.UnitOfWork.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Pessoa>> ListarPessoas()
        {
            var lista = await _pessoaRepository.ListarUsuarios();
            return lista;
        }

        public async Task<Pessoa> ListarUmaPessoa(long id)
        {
            var usuario = await _pessoaRepository.GetByIdAsync(id);
            return usuario;
        }
    }
}

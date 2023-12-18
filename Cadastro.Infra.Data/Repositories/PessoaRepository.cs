
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF;
using Cadastro.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infra.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly CadastroContext _context;
        public PessoaRepository(CadastroContext context) : base(context)
        {
            _context = context;
        }

        public async Task AtualizarPessoa(Pessoa pessoa)
        {
            await Task.FromResult(_context.Update(pessoa));
        }

        public async Task CadastrarPessoa(Pessoa pessoa)
        {
            await _context.AddAsync(pessoa);
        }

        public async Task DeletarPessoa(Pessoa pessoa)
        {
            await Task.FromResult(_context.Remove(pessoa));
        }

        public async Task<IEnumerable<Pessoa>> ListarUsuarios()
        {
            return await _context.Pessoas.ToListAsync();
        }
    }
}

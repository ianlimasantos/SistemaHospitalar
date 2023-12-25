using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF;
using Cadastro.Infra.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Data.Repositories
{
    public class EnderecoConsultorioRepository : BaseRepository<EnderecoConsultorio>, IEnderecoConsultorioRepository
    {
        private readonly CadastroContext _context;
        public EnderecoConsultorioRepository(CadastroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EnderecoConsultorio> CadastrarEnderecoConsultorio(EnderecoConsultorio enderecoConsultorio)
        {
            await _context.EnderecoConsultorios.AddAsync(enderecoConsultorio);
            return enderecoConsultorio;
        }

        public async Task AtualizarEnderecoConsultorio(EnderecoConsultorio enderecoConsultorio)
        {
            await Task.FromResult(_context.EnderecoConsultorios.Update(enderecoConsultorio));
        }

        public Task DeletarEndereco(EnderecoConsultorio enderecoConsultorio)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoConsultorio>> ListarEnderecos()
        {
            throw new NotImplementedException();
        }


    }
}

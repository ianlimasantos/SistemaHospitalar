using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF;
using Cadastro.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infra.Data.Repositories
{
    public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
    {
        private readonly CadastroContext _context;

        public ConsultaRepository(CadastroContext context) : base(context) 
        {
            _context = context;
        }
        public async Task CadastrarConsulta(Consulta consulta)
        {
            await _context.Consultas.AddAsync(consulta);
        }

        public async Task AtualizarConsulta(Consulta consulta)
        {
            await Task.FromResult(_context.Consultas.Update(consulta));
        }

        public async Task DeletarConsulta(Consulta consulta)
        {
            await Task.FromResult(_context.Consultas.Remove(consulta));
        }

        public async Task<IEnumerable<Consulta>> ListarConsultas()
        {
            return await _context.Consultas.ToListAsync();
        }
    }
}

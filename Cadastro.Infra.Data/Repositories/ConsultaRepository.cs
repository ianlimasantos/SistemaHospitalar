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

        /*
        public async Task<bool> ValidaMedicoPacientePessoasDiferentes(Consulta consulta)
        {

            var pessoaIdPaciente = consulta.Paciente.PessoaId;
            var pessoaIdMedico = consulta.Medico.PessoaId;

            if (pessoaIdPaciente == pessoaIdMedico) return false;
            return true;
            
            var pessoaIdMedico = _context.Consultas
                .Where(c => c.Id == consulta.Id)
                .Include(c => c.Medico.Pessoa)
                .Select(c => c.Medico.PessoaId);

            var teste = pessoaIdMedico;

            var pessoaIdPaciente = _context.Consultas
                .Where(c => c.Id == consulta.Id)
                .Include(c => c.Paciente.Pessoa)
                .Select(c => c.Paciente.PessoaId);
            

            if (pessoaIdMedico == pessoaIdPaciente) return false;
            return true;

            
        }*/
    }
}

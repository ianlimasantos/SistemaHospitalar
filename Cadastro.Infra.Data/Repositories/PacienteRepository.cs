using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF;
using Cadastro.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Data.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        private readonly CadastroContext _context;

        public PacienteRepository(CadastroContext context) : base(context)
        {
            _context = context;
        }

        public async Task CadastrarPaciente(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
        }

        public async Task AtualizarPaciente(Paciente paciente)
        {
            await Task.FromResult(_context.Pacientes.Update(paciente));
        }

        public async Task DeletarPaciente(Paciente paciente)
        {
            await Task.FromResult(_context.Pacientes.Remove(paciente));
        }

        public async Task<IEnumerable<Paciente>> ListarPacientes()
        {
           return await _context.Pacientes.ToListAsync();
        }
    }
}

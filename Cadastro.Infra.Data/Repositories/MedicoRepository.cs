using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF;
using Cadastro.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Data.Repositories
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        private readonly CadastroContext _context;
        public MedicoRepository(CadastroContext context) : base(context)
        {
            _context = context;
        }

        public async Task AtualizarMedico(Medico medico)
        {
            await Task.FromResult(_context.Medicos.Update(medico));
        }

        public async Task CadastrarMedico(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
        }

        public async Task DeletarMedico(Medico medico)
        {
            await Task.FromResult(_context.Medicos.Remove(medico));
        }

        public async Task<IEnumerable<Medico>> ListarMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }
    }
}

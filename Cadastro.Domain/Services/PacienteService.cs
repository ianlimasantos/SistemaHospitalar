/*using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Task AtualizarPaciente(AtualizarPacienteCommand paciente)
        {
            throw new NotImplementedException();
        }

        public async Task CadastrarPaciente(Paciente paciente)
        {
         //   await _pacienteRepository.CadastrarPaciente(paciente);
           // return 
        }

        public Task DeletarPaciente(long id)
        {
            throw new NotImplementedException();
        }

        public Task InativarPaciente(long id)
        {
            throw new NotImplementedException();
        }

        public Task ListarPacientePorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Paciente>> ListarPacientes()
        {
            throw new NotImplementedException();
        }
    }
}
*/
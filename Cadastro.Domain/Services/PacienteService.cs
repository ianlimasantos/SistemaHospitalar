using Cadastro.Domain.Interfaces.Repositories;
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

        public async Task<Paciente> CadastrarPaciente(Paciente paciente)
        {
            await _pacienteRepository.CadastrarPaciente(paciente);
            await _pacienteRepository.UnitOfWork.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> AtualizarPaciente(AtualizarPacienteCommand command)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(command.Id);
            if (paciente == null) return null;

            paciente.Atualizar(command.Telefone, command.Validade_Cartao, command.Ativo);
            await _pacienteRepository.UnitOfWork.SaveChangesAsync();
            return paciente;
        }



        public Task<bool> DeletarPaciente(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> InativarPaciente(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> ListarPacientePorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Paciente>> ListarPacientes()
        {
            throw new NotImplementedException();
        }
    }
}

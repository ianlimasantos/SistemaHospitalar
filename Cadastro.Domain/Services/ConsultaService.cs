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
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public ConsultaService(IConsultaRepository consultaRepository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            _consultaRepository = consultaRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository; 
        }
        public async Task<Consulta> CadastrarConsulta(Consulta consulta)
        {
            var consultaValida = await ValidaCadastroConsulta(consulta);
            if (!consultaValida) return null;

            await _consultaRepository.CadastrarConsulta(consulta);
            await _consultaRepository.UnitOfWork.SaveChangesAsync();
            return consulta;
        }

        public async Task<bool> ValidaCadastroConsulta(Consulta consulta)
        {
            //garante que o médico e o paciente não sejam a mesma pessoa
            var medico = await _medicoRepository.GetByIdAsync(consulta.MedicoId);
            var paciente = await _pacienteRepository.GetByIdAsync(consulta.PacienteId);
            if (medico.PessoaId == paciente.PessoaId) return false;

            // garante que não sejam marcadas consultas com pacientes/medicos inativos no sistema
            if(!medico.Ativo || !paciente.Ativo) return false;

            // garante que só marque consulta de segunda à sábado, das 07:00h às 19:00h
            var dia = consulta.DataCadastro.DayOfWeek;
            var hora = consulta.DataCadastro.Hour;
            //if (dia.ToString() == "Sunday" || hora < 7 || hora> 19) return false;

            //antecedencia mínima de 30 minutos
            var limiteAntecedencia = consulta.DataInicio.AddMinutes(-30);
            if (consulta.DataCadastro>limiteAntecedencia) return false;


            // não permite que o paciente tenha duas consultas no mesmo dia
            var consultaMarcadaNoDia = await _consultaRepository.ConsultaPacienteNaData(consulta);
            if (consultaMarcadaNoDia.Count > 0) return false;

            // não permite o agendamento de consultas com um médico que possui outra consulta agendada na mesma data/hora
            var medicoEmConsulta = await _consultaRepository.MedicoEmConsulta(consulta);
            if(medicoEmConsulta.Count > 0) return false;

            return true;
        }

        public async Task<Consulta> AtualizarConsulta(AtualizarConsultaCommand command)
        {
            var consulta = await _consultaRepository.GetByIdAsync(command.Id);
            if (consulta == null) return null;

            consulta.Atualizar(command.MedicoId, command.PacienteId, command.DataInicio);
            await _consultaRepository.AtualizarConsulta(consulta);
            await _consultaRepository.UnitOfWork.SaveChangesAsync();

            return consulta;

        }

        public async Task<bool> DeletarConsulta(long id)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);
            if (consulta == null) return false;

            await _consultaRepository.DeletarConsulta(consulta);
            await _consultaRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Consulta> ListarConsultaPeloId(long id)
        {
            return await _consultaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Consulta>> ListarConsultas()
        {
            var consultas = await _consultaRepository.ListarConsultas();
            if (consultas == null) return null;
            return consultas;
        }
    }
}

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

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }
        public async Task<Consulta> CadastrarConsulta(Consulta consulta)
        {
            await _consultaRepository.CadastrarConsulta(consulta);
            var pessoasDiferentes = await _consultaRepository.ValidaMedicoPacientePessoasDiferentes(consulta);
            if (!pessoasDiferentes) return null;
            
            await _consultaRepository.UnitOfWork.SaveChangesAsync();
            
            return consulta;
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

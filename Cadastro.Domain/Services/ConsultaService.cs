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
            try
            {
                await _consultaRepository.UnitOfWork.SaveChangesAsync();
            } catch(Exception ex)
            {
                var erro = ex;
            }
            
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

        public Task<bool> DeletarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Task<Consulta> ListarConsultaPeloId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Consulta>> ListarConsultas()
        {
            throw new NotImplementedException();
        }
    }
}

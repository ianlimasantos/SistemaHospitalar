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
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Medico> CadastrarMedico(Medico medico)
        {
            await _medicoRepository.CadastrarMedico(medico);
            await _medicoRepository.UnitOfWork.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> AtualizarMedico(AtualizarMedicoCommand command)
        {
            var medico = await _medicoRepository.GetByIdAsync(command.Id);
            if (medico == null) return null;

            medico.Atualizar(command.Email,
                command.Telefone,
                command.Ativo);

            await _medicoRepository.AtualizarMedico(medico);
            await _medicoRepository.UnitOfWork.SaveChangesAsync();
            return medico;
        }

        public Task<bool> DeletarMedico(Medico medico)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> ListarMedicoPorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Medico>> ListarMedicos()
        {
            throw new NotImplementedException();
        }
    }
}

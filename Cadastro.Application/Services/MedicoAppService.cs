using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;

namespace Cadastro.Application.Services
{
    public class MedicoAppService : IMedicoAppService
    {
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;
        public MedicoAppService(IMedicoService medicoService, IMapper mapper) 
        {
            _medicoService = medicoService;
            _mapper = mapper;
        }
        public async Task<MedicoViewModel> CadastrarMedico(NovoMedicoViewModel novoMedicoViewModel)
        {
            var novoMedico = new Medico(novoMedicoViewModel.PessoaId,
                novoMedicoViewModel.CRM,
                novoMedicoViewModel.Especialidade,
                novoMedicoViewModel.Email,
                novoMedicoViewModel.Telefone,
                novoMedicoViewModel.Ativo);
            await _medicoService.CadastrarMedico(novoMedico);
            return _mapper.Map<MedicoViewModel>(novoMedico);
        }
        public async Task<MedicoViewModel> AtualizarMedico(AtualizarMedicoViewModel atualizarMedicoViewModel)
        {
            var command = new AtualizarMedicoCommand
            {
                Id = atualizarMedicoViewModel.Id,
                Email = atualizarMedicoViewModel.Email,
                Telefone = atualizarMedicoViewModel.Telefone,
                Ativo = atualizarMedicoViewModel.Ativo,
                DataUpdate = atualizarMedicoViewModel.DataUpdate
            };

            var medicoAtualizado = await _medicoService.AtualizarMedico(command);
            return _mapper.Map<MedicoViewModel>(medicoAtualizado);
        }

        public async Task<bool> DeletarMedico(long id)
        {
            return await _medicoService.DeletarMedico(id);
        }
        public async Task<MedicoViewModel> ListarMedicoPorId(long id)
        {
            var medico = await _medicoService.ListarMedicoPorId(id);
            return _mapper.Map<MedicoViewModel>(medico);

        }
        public async Task<IEnumerable<MedicoViewModel>> ListarMedicos()
        {
            var medicos = await _medicoService.ListarMedicos();
            return _mapper.Map<IEnumerable<MedicoViewModel>>(medicos);
        }


    }
}

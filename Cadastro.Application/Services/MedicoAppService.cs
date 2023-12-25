using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using Cadastro.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<bool> DeletarUsuario(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicoViewModel>> ListarMedicos()
        {
            throw new NotImplementedException();
        }
    }
}

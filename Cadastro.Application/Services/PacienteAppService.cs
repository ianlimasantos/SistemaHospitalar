using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;

namespace Cadastro.Application.Services
{
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteAppService(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }
        public async Task<PacienteViewModel> CadastrarPaciente(NovoPacienteViewModel paciente)
        {
            var novoPaciente = new Paciente(paciente.PessoaId,
                                            paciente.CartaoSUS,
                                            paciente.Telefone,
                                            paciente.Validade_Cartao,
                                            paciente.Ativo);
            await _pacienteService.CadastrarPaciente(novoPaciente);
            return _mapper.Map<PacienteViewModel>(novoPaciente);
        }
        public async Task<PacienteViewModel> AtualizarPaciente(AtualizarPacienteViewModel atualizarPacienteViewModel)
        {
            var command = new AtualizarPacienteCommand
            {
                Id = atualizarPacienteViewModel.Id,
                Telefone = atualizarPacienteViewModel.Telefone,
                Validade_Cartao = atualizarPacienteViewModel.Validade_Cartao,
                DataUpdate = DateTime.Now,
                Ativo = atualizarPacienteViewModel.Ativo
            };

            var paciente = await _pacienteService.AtualizarPaciente(command);
            return _mapper.Map<PacienteViewModel>(paciente);

        }

        public async Task<bool> DeletarPaciente(long id)
        {
            return await _pacienteService.DeletarPaciente(id);
        }

        public async Task<PacienteViewModel> InativarPaciente(long id)
        {
            var paciente = await _pacienteService.InativarPaciente(id);
            return _mapper.Map<PacienteViewModel>(paciente);
        }

        public async Task<PacienteViewModel> ListarPacientePorId(long id)
        {
            var paciente = await _pacienteService.ListarPacientePorId(id);
            return _mapper.Map<PacienteViewModel>(paciente);
        }

        public async Task<IEnumerable<PacienteViewModel>> ListarPacientes()
        {
            var pacientes = await _pacienteService.ListarPacientes();
            return _mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);
        }
    }
}

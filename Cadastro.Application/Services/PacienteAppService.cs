using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;

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
            return _mapper.Map<PacienteViewModel>(paciente);
        }
        public Task<PacienteViewModel> AtualizarPaciente(AtualizarPacienteViewModel paciente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarPaciente(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PacienteViewModel> InativarPaciente(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PacienteViewModel> ListarPacientePorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PacienteViewModel>> ListarPacientes()
        {
            throw new NotImplementedException();
        }
    }
}

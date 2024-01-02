using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;

namespace Cadastro.Application.Services
{
    public class ConsultaAppService : IConsultaAppService
    {
        private readonly IConsultaService _consultaService;
        private readonly IMapper _mapper;
        public ConsultaAppService(IConsultaService consultaService, IMapper mapper) 
        {
            _consultaService = consultaService;
            _mapper = mapper;
        }
        public async Task<ConsultaViewModel> CadastrarConsulta(NovaConsultaViewModel novaConsultaViewModel)
        {
            var consulta = new Consulta(novaConsultaViewModel.MedicoId, 
                                        novaConsultaViewModel.PacienteId, 
                                        novaConsultaViewModel.DataInicio);
            await _consultaService.CadastrarConsulta(consulta);
            return _mapper.Map<ConsultaViewModel>(consulta);
        }

        public Task<ConsultaViewModel> AtualizarConsulta(AtualizarConsultaViewModel consultaViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarConsulta(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ConsultaViewModel> ListarConsultaPeloId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConsultaViewModel>> ListarConsultas()
        {
            throw new NotImplementedException();
        }
    }
}

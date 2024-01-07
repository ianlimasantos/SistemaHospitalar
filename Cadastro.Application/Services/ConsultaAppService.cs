using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;

namespace Cadastro.Application.Services
{
    public class ConsultaAppService : IConsultaAppService
    {
        private readonly IConsultaService _consultaService;
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;
        public ConsultaAppService(IConsultaService consultaService, IMapper mapper, IMedicoService medicoService) 
        {
            _consultaService = consultaService;
            _mapper = mapper;
            _medicoService = medicoService;
        }
        public async Task<ConsultaViewModel> CadastrarConsulta(NovaConsultaViewModel novaConsultaViewModel)
        {
            /*
            if (novaConsultaViewModel.MedicoId == null)
            {
                Random random = new Random();
                var lista = await _medicoService.ListarMedicos();
                List<long> listaIdMedicos = new List<long>();
                foreach (Medico medico in lista)
                {
                    listaIdMedicos.Add(medico.Id);
                }
                long idMedicoAleatorio = lista[random.N]
                    
                
            }
            */
            var consulta = new Consulta(novaConsultaViewModel.MedicoId, 
                                        novaConsultaViewModel.PacienteId, 
                                        novaConsultaViewModel.DataInicio);
            var resultado = await _consultaService.CadastrarConsulta(consulta);
            if (resultado == null) return null;
            return _mapper.Map<ConsultaViewModel>(consulta);
        }

        public async Task<ConsultaViewModel> AtualizarConsulta(AtualizarConsultaViewModel atualizarConsultaViewModel)
        {
            var command = new AtualizarConsultaCommand
            {
                Id = atualizarConsultaViewModel.Id,
                MedicoId = atualizarConsultaViewModel.MedicoId,
                PacienteId = atualizarConsultaViewModel.PacienteId,
                DataInicio = atualizarConsultaViewModel.DataInicio,
                DataUpdate = DateTime.Now
            };

            var consulta = await _consultaService.AtualizarConsulta(command);
            return _mapper.Map<ConsultaViewModel>(consulta);

        }

        public async Task<bool> DeletarConsulta(long id)
        {
            return await _consultaService.DeletarConsulta(id); 
        }

        public async Task<ConsultaViewModel> ListarConsultaPeloId(long id)
        {
            var consulta = await _consultaService.ListarConsultaPeloId(id);
            return _mapper.Map<ConsultaViewModel>(consulta);
        }

        public async Task<IEnumerable<ConsultaViewModel>> ListarConsultas()
        {
            var consulta = await _consultaService.ListarConsultas();
            return _mapper.Map<IEnumerable<ConsultaViewModel>>(consulta);
        }
    }
}

using Cadastro.Domain.Models.Commands;
using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro.Application.ViewModels;

namespace Cadastro.Application.Services.Interfaces
{
    public interface IConsultaAppService
    {
        Task<ConsultaViewModel> CadastrarConsulta(NovaConsultaViewModel novaConsultaViewModel);
        Task<ConsultaViewModel> ListarConsultaPeloId(long id);
        Task<IEnumerable<ConsultaViewModel>> ListarConsultas();
        Task<ConsultaViewModel> AtualizarConsulta(AtualizarConsultaViewModel consultaViewModel);
        Task<bool> DeletarConsulta(long Id);
    }
}

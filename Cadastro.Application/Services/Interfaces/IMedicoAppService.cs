using Cadastro.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Services.Interfaces
{
    public interface IMedicoAppService
    {
        Task<MedicoViewModel> CadastrarMedico(NovoMedicoViewModel novoMedicoViewModel);
        Task<MedicoViewModel> AtualizarMedico(AtualizarMedicoViewModel atualizarMedicoViewModel);
        Task<IEnumerable<MedicoViewModel>> ListarMedicos();
        Task<bool> DeletarUsuario(long id);

    }
}

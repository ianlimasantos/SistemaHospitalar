using Cadastro.Application.ViewModels;

namespace Cadastro.Application.Services.Interfaces
{
    public interface IMedicoAppService
    {
        Task<MedicoViewModel> CadastrarMedico(NovoMedicoViewModel novoMedicoViewModel);
        Task<MedicoViewModel> AtualizarMedico(AtualizarMedicoViewModel atualizarMedicoViewModel);
        Task<MedicoViewModel> ListarMedicoPorId(long id);
        Task<IEnumerable<MedicoViewModel>> ListarMedicos();
        Task<bool> DeletarMedico(long id);
    }
}

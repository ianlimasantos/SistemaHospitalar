using Cadastro.Application.ViewModels;

namespace Cadastro.Application.Services.Interfaces
{
    public interface IPacienteAppService
    {
        Task<PacienteViewModel> CadastrarPaciente(NovoPacienteViewModel paciente);
        Task<PacienteViewModel> AtualizarPaciente(AtualizarPacienteViewModel paciente);
        Task<PacienteViewModel> ListarPacientePorId(long id);
        Task<IEnumerable<PacienteViewModel>> ListarPacientes();
        Task<PacienteViewModel> InativarPaciente(long id);
        Task<bool> DeletarPaciente(long id);
    }
}

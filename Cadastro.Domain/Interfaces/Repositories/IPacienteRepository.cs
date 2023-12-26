using Cadastro.Domain.Models;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Task CadastrarPaciente(Paciente paciente);
        Task AtualizarPaciente(Paciente paciente);
        Task <IEnumerable<Paciente>> ListarPacientes();
        Task DeletarPaciente(Paciente paciente);
    }
}

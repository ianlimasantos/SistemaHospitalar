using Cadastro.Domain.Models;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task CadastrarPaciente(Paciente paciente);
        Task AtualizarPaciente(Paciente paciente);
        Task ListarPacientePorId(long id);
        Task <IEnumerable<Paciente>> ListarPacientes();
        Task InativarPaciente(Paciente paciente);
        Task DeletarPaciente(Paciente paciente);
    }
}

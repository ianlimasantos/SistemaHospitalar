using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Task <Paciente> CadastrarPaciente(Paciente paciente);
        Task <Paciente> AtualizarPaciente(AtualizarPacienteCommand paciente);
        Task <Paciente> ListarPacientePorId(long id);
        Task<IEnumerable<Paciente>> ListarPacientes();
        Task<Paciente> InativarPaciente(long id);
        Task<bool> DeletarPaciente(long id);
    }
}

using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface IMedicoService
    {
        Task<Medico> CadastrarMedico(Medico medico);
        Task<Medico> AtualizarMedico(AtualizarMedicoCommand command);
        Task<Medico> ListarMedicoPorId(long id);
        Task<IEnumerable<Medico>> ListarMedicos();
        Task<bool> DeletarMedico(long id);
    }
}

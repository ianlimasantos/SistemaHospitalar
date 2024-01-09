using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IConsultaRepository : IBaseRepository<Consulta>
    {
        Task CadastrarConsulta(Consulta consulta);
        Task<IEnumerable<Consulta>> ListarConsultas(); 
        Task AtualizarConsulta(Consulta consulta);
        Task DeletarConsulta(Consulta consulta);
        Task<ICollection<Consulta>> ConsultaPacienteNaData(Consulta consulta);
        Task<ICollection<Consulta>> MedicoEmConsulta(Consulta consulta);
    }
}

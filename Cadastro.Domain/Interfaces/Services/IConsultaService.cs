using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces.Services
{
    public interface IConsultaService
    {
        Task<Consulta> CadastrarConsulta(Consulta consulta);
        Task<Consulta> ListarConsultaPeloId(long id);
        Task<IEnumerable<Consulta>> ListarConsultas();
        Task<Consulta> AtualizarConsulta(AtualizarConsultaCommand command);
        Task <bool> DeletarConsulta(Consulta consulta);
    }
}

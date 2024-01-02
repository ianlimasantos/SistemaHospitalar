using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Models.Commands
{
    public class AtualizarConsultaCommand
    {
        public long Id { get; set; }
        public long MedicoId { get; set; }
        public long PacienteId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}

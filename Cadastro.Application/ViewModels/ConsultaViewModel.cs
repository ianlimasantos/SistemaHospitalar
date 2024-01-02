using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.ViewModels
{
    public class ConsultaViewModel
    {
        public long MedicoId { get; set; }
        public long PacienteId { get; set; }
        public DateTime DataInicio { get; set; }
    }
}

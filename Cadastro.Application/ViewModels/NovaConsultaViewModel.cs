using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.ViewModels
{
    public class NovaConsultaViewModel
    {
        public long? MedicoId { get; set; }
        public long PacienteId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUpdate { get; set; }
        public bool Ativo { get; set; }
    }
}

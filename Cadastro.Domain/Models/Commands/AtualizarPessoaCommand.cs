using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Models.Commands
{
    public class AtualizarPessoaCommand
    {
        public long Id { get;  set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}

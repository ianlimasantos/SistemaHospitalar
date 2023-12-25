using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.ViewModels
{
    public class AtualizarMedicoViewModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}

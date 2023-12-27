using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.ViewModels
{
    public class AtualizarPacienteViewModel
    {
        public long Id { get; set; }
        public string Telefone { get; set; }
        public DateTime Validade_Cartao { get; set; }
        public DateTime DataUpdate { get; set; }
        public bool Ativo { get; set; }
    }
}

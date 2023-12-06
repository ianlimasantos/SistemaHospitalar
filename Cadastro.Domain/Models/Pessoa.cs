using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Models
{
    public class Pessoa
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUpdate { get; private set; }
        public Paciente Paciente { get; private set; }  
        public Endereco Endereco { get; private set; }

        public Pessoa(string nome, string cPF, string email, bool ativo, DateTime dataNascimento)
        {
            Nome = nome;
            CPF = cPF;
            Email = email;
            Ativo = ativo;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            DataUpdate = DateTime.Now;
        }

        public void Atualizar(string nome, DateTime dataNascimento,
               bool ativo)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            DataUpdate = DateTime.Now;
            Ativo = ativo;
        }
    }
}

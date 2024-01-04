using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Models
{
    public class Paciente
    {
        public long Id { get; private set; }
        public long PessoaId { get; private set; }
        public string CartaoSUS { get; private set; }
        public string Telefone { get; private set; }
        public DateTime Validade_Cartao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUpdate { get; private set; }
        public bool Ativo { get; private set; }
        public virtual ICollection<Consulta> Consultas { get; private set; }
        public virtual Pessoa Pessoa { get; private set; }

        public Paciente(long pessoaId, string cartaoSUS, string telefone, DateTime validade_Cartao, bool ativo)
        {
            PessoaId = pessoaId;
            CartaoSUS = cartaoSUS;
            Telefone = telefone;
            Validade_Cartao = validade_Cartao;
            DataCadastro = DateTime.Now;
            DataUpdate = DateTime.Now;
            Ativo = ativo;
        }

        public void Atualizar(string telefone, DateTime validade_Cartao, bool ativo)
        {
            Telefone = telefone;
            Validade_Cartao = validade_Cartao;
            DataUpdate = DateTime.Now;
            Ativo = ativo;
        }

        public void Inativar()
        {
            Ativo = false;
            DataUpdate = DateTime.Now;
        }
    }
}

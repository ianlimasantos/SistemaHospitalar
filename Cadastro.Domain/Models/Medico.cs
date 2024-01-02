namespace Cadastro.Domain.Models
{
    public class Medico
    {
        public long Id { get; private set; }
        public long PessoaId { get; private set; }
        public string CRM { get; private set; }
        public Especialidade Especialidade { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUpdate { get; private set; }
        public ICollection<Consulta> Consultas { get; private set; }
        public ICollection<EnderecoConsultorio> EnderecoConsultorios { get; private set; }
        public virtual Pessoa Pessoa { get; private set; }
        public virtual Consulta Consulta { get; private set; }

        public Medico(long pessoaId, string cRM, Especialidade especialidade, string email,
              string telefone, bool ativo)
        {
            PessoaId = pessoaId;
            CRM = cRM;
            Especialidade = especialidade;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
            DataCadastro = DateTime.Now;
            DataUpdate = DateTime.Now;  
        }

        public void Atualizar(string email, string telefone, bool ativo)
        {
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
            DataUpdate = DateTime.Now;
        }
    }

}

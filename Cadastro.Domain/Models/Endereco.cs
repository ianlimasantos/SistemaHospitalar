namespace Cadastro.Domain.Models
{
    public class Endereco
    {
        public long Id { get; private set; }
        public long PessoaId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero {get; private set;}
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }

        public Endereco(string logradouro, string numero, string complemento, string bairro,
                        string cidade, string uF, string cEP)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            CEP = cEP;
        }

        public void Atualizar(string logradouro, string numero, string complemento, string bairro,
                        string cidade, string uF, string cEP)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            CEP = cEP;
        }
    }
}

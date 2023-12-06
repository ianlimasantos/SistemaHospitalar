using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Domain.Models
{
    public class EnderecoConsultorio
    {
        public long Id { get; private set; }
        public long MedicoId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public Medico Medico { get; private set; }

        public EnderecoConsultorio(string logradouro, string numero, string complemento, string bairro,
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

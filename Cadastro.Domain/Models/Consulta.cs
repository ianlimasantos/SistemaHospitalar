namespace Cadastro.Domain.Models
{
    public class Consulta
    {
        public long Id { get; private set; }
        public long MedicoId { get; private set; }
        public long PacienteId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataUpdate { get; private set; }

        public Consulta(long medicoId, long pacienteId, DateTime dataInicio, DateTime dataFim)
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataCadastro = DateTime.Now;
            DataUpdate = DateTime.Now;
        }   

        public void Atualizar(long medicoId, DateTime dataInicio, DateTime dataFim) 
        {
            MedicoId = medicoId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataUpdate = DateTime.Now;
        }
    }
}
